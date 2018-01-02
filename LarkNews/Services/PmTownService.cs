using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
using LarkNews.Commons;
using LarkNews.Dao;
using LarkNews.Entity;

namespace LarkNews.Services
{
    public class PmTownService:IPMTownService
    {
        private readonly IRepository<NewsList> _repository;

        public PmTownService(IRepository<NewsList> repository)
        {
            _repository = repository;
        }

        public NewsList GetFirstPaper()
        {
            return _repository.GetQueryable(p => p.NewsFrom.Equals("泡面小镇")).LastOrDefault();
        }

        public NewsList GetMorningPaper(int id)
        {
            return _repository.Get(p => p.Id == id);
        }

        public int UpDateMorningPaper()
        {
            var url = "http://www.pmtown.com/archives/category/%E6%97%A9%E6%8A%A5";

            var dom = new HtmlParser().Parse(GetHTMLByURL(url));
            var newsTime = dom.QuerySelector("time").TextContent;

            var info = dom.QuerySelectorAll("#list > article");
            if (info != null)
            {
                var title= info.First().QuerySelectorAll("a").First().TextContent;
                var detailUrl = info.First().QuerySelectorAll("a").First().GetAttribute("href");

                var dom2=new HtmlParser().Parse(GetHTMLByURL(detailUrl)).QuerySelectorAll("#article");

                if (dom2 != null)
                {
                    //var time = String2DateTime(publishTime.TextContent);
                    //if (time == null) return -2;

                    dom2.First().RemoveChild(dom2.First().QuerySelector("h1"));
                    dom2.First().RemoveChild(dom2.First().QuerySelector("ul"));

                    string context = dom2.First().TextContent.Replace("\t", "");
                    context = context.Substring(context.IndexOf("【"));
                    context = context.Replace(context.Substring(context.IndexOf("更早获取早报内容")+8),"");

                    var model = new NewsList
                    {
                        NewsFrom = "泡面小镇",
                        NewsFromUrl = detailUrl,
                        NewsTitle = title,
                        NewsPublishTime = TimeHelper.ConvertToTimeStamp(Convert.ToDateTime(newsTime)),
                        NewsContent = context,
                        NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
                    };

                    var first = GetFirstPaper();
                    if (first == null)
                    {
                        _repository.Save(model);
                        return 0;
                    }
                    if (model.NewsPublishTime != first.NewsPublishTime)
                    {
                        _repository.Save(model);

                        return 0;
                    }
                    else
                    {
                        return -3;
                    }
                }
            }
            else
            {
                return -1;
            }

            return -2;
        }

        public void SaveError()
        {
            var model = new NewsList
            {
                NewsFrom = "Error",
                NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
            };

            _repository.Save(model);
        }

        public DateTime? String2DateTime(string str)
        {
            var index = str.IndexOf("小时",StringComparison.Ordinal);

            if (index <= -1) return null;
            var hours= str.Substring(0, index);

            return DateTime.Now.AddHours(-Int32.Parse(hours));
        }

        public string GetHTMLByURL(string url)
        {
            try
            {
                WebRequest wRequest = WebRequest.Create(url);
                wRequest.ContentType = "text/html; charset=utf8";
                wRequest.Method = "get";
                wRequest.UseDefaultCredentials = true;
                // Get the response instance.
                var task = wRequest.GetResponseAsync();
                System.Net.WebResponse wResp = task.Result;
                System.IO.Stream respStream = wResp.GetResponseStream();
                //dy2018这个网站编码方式是GB2312,
                using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return e.ToString();
            }
        }
    }
}

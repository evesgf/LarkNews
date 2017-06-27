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
            return _repository.GetFirstPaper();
        }

        public NewsList GetMorningPaper(int id)
        {
            return _repository.Get(p => p.Id == id);
        }

        public int UpDateMorningPaper()
        {
            var url = "http://www.pmtown.com/archives/category/paomianzaobanche";

            var dom = new HtmlParser().Parse(GetHTMLByURL(url));

            var publishTime = dom.QuerySelector("span.item-meta-li");

            var info = dom.QuerySelectorAll("h2.item-title");
            if (info != null)
            {
                var title= info.First().QuerySelectorAll("a").First().GetAttribute("title");
                var detailUrl = info.First().QuerySelectorAll("a").First().GetAttribute("href");

                var dom2=new HtmlParser().Parse(GetHTMLByURL(detailUrl)).QuerySelectorAll("div.entry-content");

                if (dom2 != null)
                {
                    var time = String2DateTime(publishTime.TextContent);
                    //if (time == null) return -2;

                    var model = new NewsList
                    {
                        NewsFrom = "泡面小镇",
                        NewsFromUrl = detailUrl,
                        NewsTitle = title,
                        NewsPublishTime = TimeHelper.ConvertToTimeStamp((DateTime)time),
                        NewsContent = dom2.First().InnerHtml,
                        NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
                    };

                    _repository.Save(model);
                    return 0;
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

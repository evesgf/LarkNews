using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;
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

        public NewsList GetMorningPaper(int id)
        {
            return _repository.Get(p => p.Id == id);
        }

        public NewsList GetFirstPaper()
        {
            return null;
        }

        public int UpDateMorningPaper()
        {
            var url = "http://www.pmtown.com/archives/category/paomianzaobanche";

            var info = new HtmlParser().Parse(GetHTMLByURL(url)).QuerySelectorAll("h2.item-title");
            if (info != null)
            {
                var detailUrl = info.First().QuerySelectorAll("a").First().GetAttribute("href");

                var dom=new HtmlParser().Parse(GetHTMLByURL(detailUrl)).QuerySelectorAll("div.entry-content");

                if (dom != null)
                {
                    var model = new NewsList
                    {
                        From = detailUrl,
                        Content = dom.First().InnerHtml,
                        CreateTime = DateTime.Now
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

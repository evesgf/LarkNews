using AngleSharp.Parser.Html;
using LarkNews.Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Services.Home
{
    public class HomeService : IHomeService
    {
        public async Task<string> GetChinaTime()
        {
            var reTime = string.Empty;

            var crawler = new LittleCrawler();

            var re=await crawler.Start(new Uri("https://www.hao123.com/"), null);
            var dom = new HtmlParser().Parse(re);
            var y = dom.QuerySelector("#calendar> span").TextContent;

            reTime = string.Format(y);

            return reTime;
        }
    }
}

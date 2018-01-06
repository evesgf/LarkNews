using AngleSharp.Parser.Html;
using LarkNews.Crawler;
using LarkNews.Dao;
using LarkNews.Entity;
using Pomelo.AspNetCore.TimedJob.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Services.Home
{
    public class HomeService : IHomeService
    {

        private readonly IRepository<NewsList> _repository;
        private readonly IRepository<TimedJob> _repository2;

        public HomeService(IRepository<NewsList> repository,
            IRepository<TimedJob> repository2)
        {
            _repository = repository;
            _repository2 = repository2;
        }


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

        public NewsList GetFirstPaper()
        {
            return _repository.GetQueryable(p => p.NewsFrom.Equals("泡面小镇")).LastOrDefault();
        }

        public void AddTestTimeJobs()
        {
            var model = new TimedJob
            {
                Id = "LarkNews.TimedJobs.PrintJob.Print", // 按照完整类名+方法形式填写
                Begin = DateTime.Now,
                Interval = 3000,
                IsEnabled = true
            };
            _repository2.Save(model);
        }
    }
}

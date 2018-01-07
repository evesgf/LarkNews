using AngleSharp.Parser.Html;
using LarkNews.Commons;
using LarkNews.Crawler;
using LarkNews.Dao;
using LarkNews.Entity;
using LarkNews.TimedJobs;
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
        private readonly ITimeJobsService _ITimeJobsService;

        public HomeService(IRepository<NewsList> repository,
            ITimeJobsService iTimeJobsService)
        {
            _repository = repository;
            _ITimeJobsService = iTimeJobsService;
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

        public int UpDateMorningPaper()
        {
            var model = new NewsList
            {
                NewsFrom = "泡面小镇",
                NewsFromUrl = "泡面小镇",
                NewsTitle = "泡面小镇",
                NewsPublishTime = TimeHelper.ConvertToTimeStamp(DateTime.Now),
                NewsContent = "泡面小镇",
                NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
            };

            _repository.Insert(model);
            return 0;
        }

        public NewsList GetFirstPaper()
        {
            return _repository.Get(p => p.NewsFrom.Equals("泡面小镇"));
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
            _ITimeJobsService.AddTimeJob(model);
        }
    }
}

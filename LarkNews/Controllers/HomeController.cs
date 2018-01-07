using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LarkNews.Services.Home;
using LarkNews.TimedJobs;

namespace LarkNews.Controllers
{
    //启用跨域
    [EnableCors("AllowSameDomain")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IHomeService _IHomeService;
        //private readonly IPMTownService _IPMTownService;

        public HomeController(IHomeService iHomeService)
        {
            _IHomeService = iHomeService;
            //_IPMTownService = iPMTownService;
        }

        /// <summary>
        /// Home
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Index()
        {
            //_IHomeService.AddTestTimeJobs();
            return new string[] { "Hello World! This is LarkNews!"};
        }

        ///// <summary>
        ///// Home
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public string TestAddTimeJob()
        //{
        //    _ITimeJobsService.TestAdd();
        //    return "AddOK";
        //}

        // GET api/values
        [HttpGet]
        public IEnumerable<string> UpDateMorningPaper()
        {
            var re = _IHomeService.GetFirstPaper();
            return new string[] { "value1", re.ToString() };
        }

        //[HttpGet]
        //public string FristPaper()
        //{
        //    string week = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
        //    if (week == "星期六" || week == "星期日")
        //    {
        //        return "欧尼酱~周末人家不上工哟,试下‘历史早报’吧";
        //    }
        //    else
        //    {
        //        var re = _IPMTownService.GetFirstPaper();
        //        return re.NewsContent;
        //    }
        //}

        //[HttpGet]
        //public string LastPaper()
        //{
        //    var re = _IPMTownService.GetFirstPaper();
        //    return re.NewsContent;
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return _IPMTownService.GetMorningPaper(id).NewsContent;
        //}
    }
}
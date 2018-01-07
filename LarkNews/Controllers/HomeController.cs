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
    //���ÿ���
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
        //    if (week == "������" || week == "������")
        //    {
        //        return "ŷ�ὴ~��ĩ�˼Ҳ��Ϲ�Ӵ,���¡���ʷ�籨����";
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
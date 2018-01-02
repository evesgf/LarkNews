using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LarkNews.Controllers
{
    //���ÿ���
    [EnableCors("AllowSameDomain")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IPMTownService _pmTownService;

        public HomeController(IPMTownService pmTownService)
        {
            _pmTownService = pmTownService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> UpDateMorningPaper()
        {
            var re = _pmTownService.UpDateMorningPaper();
            return new string[] { "value1", re.ToString() };
        }

        [HttpGet]
        public string FristPaper()
        {
            string week = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            if (week == "������" || week == "������")
            {
                return "ŷ�ὴ~��ĩ�˼Ҳ��Ϲ�Ӵ,���¡���ʷ�籨����";
            }
            else
            {
                var re = _pmTownService.GetFirstPaper();
                return re.NewsContent;
            }
        }

        [HttpGet]
        public string LastPaper()
        {
            var re = _pmTownService.GetFirstPaper();
            return re.NewsContent;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _pmTownService.GetMorningPaper(id).NewsContent;
        }
    }
}
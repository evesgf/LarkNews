using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LarkNews.Controllers
{
    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {
        private readonly IPMTownService _pmTownService;

        public HomeController(IPMTownService pmTownService)
        {
            _pmTownService = pmTownService;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var re = _pmTownService.UpDateMorningPaper();
            return new string[] { "value1","value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _pmTownService.GetMorningPaper(id).Content;
        }
    }
}
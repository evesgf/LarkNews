using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using LarkNews.Services;
using LarkNews.Entity;

namespace LarkNews.Controllers
{
    //启用跨域
    [EnableCors("AllowSameDomain")]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BitNewsController : Controller
    {
        private readonly IBitNewsService _bitNewsService;

        public BitNewsController(IBitNewsService bitNewsService)
        {
            _bitNewsService = bitNewsService;
        }

        [HttpGet]
        public string GetNewestPaper()
        {
            return "【金色财经】"+_bitNewsService.GetJinseNewestPaper().NewsContent+"\n【币世界】"+_bitNewsService.GetBishijieNewestPaper().NewsContent+"\n【BitCoin】"+_bitNewsService.GetBitcoinNewstPaper().NewsContent;
        }
        [HttpGet]
        public IEnumerable<string> UpDateAllPaper()
        {
            var re1 = _bitNewsService.UpDateJinsePaper();
            var re2 = _bitNewsService.UpDateBishijiePaper();
            var re3 = _bitNewsService.UpdateBitcoinNewstPaper();
            return new string[] { "value1", re1.ToString(),re2.ToString() };
        }


        [HttpGet]
        public string GetJinseNewestPaper()
        {
            return _bitNewsService.GetJinseNewestPaper().NewsContent;
        }
        [HttpGet]
        public IEnumerable<string> UpDateJinsePaper()
        {
            var re = _bitNewsService.UpDateJinsePaper();
            return new string[] { "value1", re.ToString() };
        }


        [HttpGet]
        public string GetBishijieNewestPaper()
        {
            return _bitNewsService.GetBishijieNewestPaper().NewsContent;
        }
        [HttpGet]
        public IEnumerable<string> UpDateBishijiePaper()
        {
            var re = _bitNewsService.UpDateBishijiePaper();
            return new string[] { "value1", re.ToString() };
        }

        [HttpGet]
        public string GetOffSitePrice()
        {
            return _bitNewsService.OffSitePrice();
        }

        //[HttpGet]
        //public string GetHashpiNewestPaper()
        //{
        //    return _bitNewsService.GetHashpiNewestPaper().NewsContent;
        //}
        //[HttpGet]
        //public IEnumerable<string> UpDateHashpiPaper()
        //{
        //    var re = _bitNewsService.UpDateHashpiPaper();
        //    return new string[] { "value1", re.ToString() };
        //}

        [HttpGet]
        public string UpdateBitcoinNewstPaper()
        {
            return _bitNewsService.UpdateBitcoinNewstPaper().ToString();
        }
    }
}

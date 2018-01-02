using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Entity;
using LarkNews.Dao;
using AngleSharp.Parser.Html;
using LarkNews.Commons;
using System.Net;

namespace LarkNews.Services
{
    public class BitNewsService : IBitNewsService
    {
        private readonly IRepository<NewsList> _repository;

        public BitNewsService(IRepository<NewsList> repository)
        {
            _repository = repository;
        }

        #region 金色财经
        public NewsList GetJinseNewestPaper()
        {
            return _repository.GetQueryable(p => p.NewsFrom.Equals("金色财经")).LastOrDefault();
        }

        public int UpDateJinsePaper()
        {
            var url = "http://www.jinse.com/lives";

            var dom = new HtmlParser().Parse(GetHTMLByURL(url));
            //var newsTime = dom.QuerySelector("time").TextContent;

            var info = dom.QuerySelectorAll("li.clearfix").FirstOrDefault();
            if (info != null)
            {
                //去除制表符
                var context = info.TextContent.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                var newsTime = context.Substring(0, 5);

                var model = new NewsList
                {
                    NewsFrom = "金色财经",
                    NewsFromUrl = url,
                    NewsTitle = "金色财经",
                    NewsPublishTime = TimeHelper.ConvertToTimeStamp(Convert.ToDateTime(newsTime)),
                    NewsContent = context,
                    NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
                };
                var first = GetJinseNewestPaper();
                if (first == null)
                {
                    _repository.Save(model);

                    return 0;
                }
                else if (model.NewsPublishTime != first.NewsPublishTime)
                {
                    _repository.Save(model);

                    return 0;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region 币世界
        public NewsList GetBishijieNewestPaper()
        {
            return _repository.GetQueryable(p => p.NewsFrom.Equals("币世界")).LastOrDefault();
        }

        public int UpDateBishijiePaper()
        {
            var url = "http://www.bishijie.com/kuaixun/?from=mp_bsjkx";

            var dom = new HtmlParser().Parse(GetHTMLByURL(url));
            //var newsTime = dom.QuerySelector("time").TextContent;

            var info = dom.QuerySelectorAll("article").FirstOrDefault();
            if (info != null)
            {
                //去除制表符
                var context = info.TextContent.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                var newsTime = context.Substring(0, 5);

                var model = new NewsList
                {
                    NewsFrom = "币世界",
                    NewsFromUrl = url,
                    NewsTitle = "币世界",
                    NewsPublishTime = TimeHelper.ConvertToTimeStamp(Convert.ToDateTime(newsTime)),
                    NewsContent = context,
                    NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
                };
                var first = GetBishijieNewestPaper();
                if (first == null)
                {
                    _repository.Save(model);

                    return 0;
                }
                else if (model.NewsPublishTime != first.NewsPublishTime)
                {
                    _repository.Save(model);

                    return 0;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion

        #region 哈希派
        public NewsList GetHashpiNewestPaper()
        {
            return _repository.GetQueryable(p => p.NewsFrom.Equals("哈希派")).LastOrDefault();
        }

        public int UpDateHashpiPaper()
        {
            var url = "https://weibo.com/u/6340417459?is_hot=1";

            var dom = new HtmlParser().Parse(GetHTMLByURL(url));
            //var newsTime = dom.QuerySelector("time").TextContent;

            var info = dom.QuerySelectorAll("WB_text W_f14").FirstOrDefault();
            if (info != null)
            {
                //去除制表符
                var context = info.TextContent.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");
                var newsTime = context.Substring(0, 5);

                var model = new NewsList
                {
                    NewsFrom = "币世界",
                    NewsFromUrl = url,
                    NewsTitle = "币世界",
                    NewsPublishTime = TimeHelper.ConvertToTimeStamp(Convert.ToDateTime(newsTime)),
                    NewsContent = context,
                    NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
                };
                var first = GetHashpiNewestPaper();
                if (model.NewsPublishTime != first.NewsPublishTime)
                {
                    _repository.Save(model);

                    return 0;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 场外币价
        /// </summary>
        /// <returns></returns>
        public string OffSitePrice()
        {
            string re= "马基雅巴库内！";

            //BTC/CNY
            string url = "https://localbitcoins.com/instant-bitcoins/?action=buy&country_code=CN&amount=&currency=CNY&place_country=CN&online_provider=ALL_ONLINE&find-offers=%E6%90%9C%E7%B4%A2";

            var dom = new HtmlParser().Parse(GetHTMLByURL(url));
            var buy = dom.QuerySelectorAll("body > div.container > table > tbody > tr:nth-child(2) > td.column-price").FirstOrDefault().TextContent;

            re = "btc localbitcoins卖一:" + buy.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "");

            string url2 = "https://otc.huobipro.com/#/trade/list?coin=1&type=1";

            var dom2 = new HtmlParser().Parse(GetHTMLByURL(url2));
            var buy2 = dom2.QuerySelectorAll(".tables-item").FirstOrDefault();

            return re;
        }
        #endregion

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

        #region bitcoin
        public NewsList GetBitcoinNewstPaper()
        {
            return _repository.GetQueryable(p => p.NewsFrom.Equals("bitcoin")).LastOrDefault();
        }

        public int UpdateBitcoinNewstPaper()
        {
            var url = "https://news.bitcoin.com/press-releases/";

            var dom = new HtmlParser().Parse(GetHTMLByURL(url));
            //var newsTime = dom.QuerySelector("time").TextContent;

            var info = dom.QuerySelectorAll(".latest-container").FirstOrDefault();
            if (info != null)
            {
                var time = info.QuerySelector(".latest-left").TextContent.Replace("\t", "").Replace("\r", "").Replace("  ", "").Replace("\n","");
                var title = info.QuerySelector(".entry-title").TextContent.Replace("\t", "").Replace("\r", "").Replace("  ", "").Replace("\n", "");
                var context = info.QuerySelector(".td-bonus-excerpt").TextContent.Replace("\t", "").Replace("\r", "").Replace("  ", "").Replace("\n", "");

                var model = new NewsList
                {
                    NewsFrom = "bitcoin",
                    NewsFromUrl = url,
                    NewsTitle = title,
                    NewsPublishTime = TimeHelper.ConvertToTimeStamp(DateTime.Now),
                    NewsContent = time+","+context,
                    NewsCreateTime = TimeHelper.ConvertToTimeStamp(DateTime.Now)
                };
                var first = GetBishijieNewestPaper();
                if (first == null)
                {
                    _repository.Save(model);

                    return 0;
                }
                else if (model.NewsTitle != first.NewsTitle)
                {
                    _repository.Save(model);

                    return 0;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
}

using LarkNews.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Services
{
    public interface IBitNewsService: IDependencyRegister
    {
        #region 金色财经 http://www.jinse.com/lives

        #endregion

        #region 币世界 http://www.bishijie.com/kuaixun/?from=mp_bsjkx

        #endregion

        #region 哈希派 https://weibo.com/u/6340417459?is_hot=1

        #endregion

        /// <summary>
        /// 获取金色财经最新的第一条资讯
        /// </summary>
        /// <returns></returns>
        NewsList GetJinseNewestPaper();
        /// <summary>
        /// 更新金色财经的第一条资讯
        /// </summary>
        /// <returns></returns>
        int UpDateJinsePaper();

        /// <summary>
        /// 获取币世界最新的第一条资讯
        /// </summary>
        /// <returns></returns>
        NewsList GetBishijieNewestPaper();
        /// <summary>
        /// 更新币世界的第一条资讯
        /// </summary>
        /// <returns></returns>
        int UpDateBishijiePaper();

        /// <summary>
        /// 获取哈希派最新的第一条资讯
        /// </summary>
        /// <returns></returns>
        NewsList GetHashpiNewestPaper();
        /// <summary>
        /// 更新哈希派的第一条资讯
        /// </summary>
        /// <returns></returns>
        int UpDateHashpiPaper();

        /// <summary>
        /// 获取场外币价
        /// </summary>
        /// <returns></returns>
        string OffSitePrice();

        #region bitcoin https://news.bitcoin.com/
        /// <summary>
        /// 获取bitcoin最新的第一条资讯
        /// </summary>
        /// <returns></returns>
        NewsList GetBitcoinNewstPaper();
        /// <summary>
        /// 获取bitcoin最新的第一条资讯
        /// </summary>
        /// <returns></returns>
        int UpdateBitcoinNewstPaper();
        #endregion
    }
}

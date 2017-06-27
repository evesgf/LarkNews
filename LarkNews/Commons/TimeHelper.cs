using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Commons
{
    public static class TimeHelper
    {
        /// <summary>
        /// 时间戳转换为日期（时间戳单位秒）
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns>C#格式时间</returns>
        public static DateTime GetTime(long timeStamp)
        {
            var start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return start.AddMilliseconds(timeStamp).AddHours(8);
        }

        /// <summary>
        /// /// 日期转换为时间戳（时间戳单位秒）
        /// /// </summary>
        /// /// <param name="TimeStamp"></param>
        /// <param name="time"></param>
        /// /// <returns></returns>
        public static long ConvertToTimeStamp(DateTime time)
        {
            DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long) (time.AddHours(-8) - Jan1st1970).TotalMilliseconds;
        }
    }
}

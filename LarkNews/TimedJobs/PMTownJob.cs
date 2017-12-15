using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using LarkNews.Services;
using Pomelo.AspNetCore.TimedJob;

namespace LarkNews.TimedJobs
{
    public class PMTownJob:Job
    {
        private readonly IPMTownService _pmTownService;

        public PMTownJob(IPMTownService pmTownService)
        {
            _pmTownService = pmTownService;
        }

        //TimedJob使用：http://www.1234.sh/post/pomelo-extensions-timed-jobs
        //Begin 起始时间；Interval执行时间间隔，单位是毫秒，建议使用以下格式，此处为3小时；SkipWhileExecuting是否等待上一个执行完成，true为等待；
        [Invoke(Begin = "2017-12-15 00:00", Interval = 1000*60*5, SkipWhileExecuting = true)]
        public void Run()
        {
            //Job要执行的逻辑代码
            if (_pmTownService.UpDateMorningPaper() != 0)
            {

            }
        }
    }
}

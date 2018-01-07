using LarkNews.Services;
using Pomelo.AspNetCore.TimedJob;
using System;

namespace LarkNews.TimedJobs
{
    public class PrintJob : Job
    {
        //public readonly IPMTownService _IPMTownService;

        //public PrintJob(IPMTownService iPMTownService)
        //{
        //    _IPMTownService = iPMTownService;
        //}

        public void Print()
        {
            Console.WriteLine("Test dynamic invoke...");
            //_IPMTownService.GetFirstPaper();
        }
    }
}

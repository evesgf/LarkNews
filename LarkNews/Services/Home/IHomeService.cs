using LarkNews.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Services.Home
{
    public interface IHomeService: IDependencyRegister
    {
        Task<string> GetChinaTime();

        int UpDateMorningPaper();

        NewsList GetFirstPaper();

        void AddTestTimeJobs();
    }
}

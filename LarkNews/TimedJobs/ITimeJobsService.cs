using LarkNews.Services;
using Pomelo.AspNetCore.TimedJob.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.TimedJobs
{
    public interface ITimeJobsService: IDependencyRegister
    {
        bool AddTimeJob(TimedJob entity, bool isCommit = true);
    }
}

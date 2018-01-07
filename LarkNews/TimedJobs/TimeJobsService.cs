using LarkNews.Dao;
using Pomelo.AspNetCore.TimedJob.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.TimedJobs
{
    public class TimeJobsService: ITimeJobsService
    {
        private MySqlDBContext _context;
        private UnitOfWork _unitOfWork;

        public TimeJobsService(MySqlDBContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        public bool AddTimeJob(TimedJob entity, bool isCommit = true)
        {
            _context.Add(entity);

            return isCommit && _unitOfWork.Commit();
        }
    }
}

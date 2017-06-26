using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Dao
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}

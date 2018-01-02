using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LarkNews.Dao
{
    public interface IRepository<T> where T : class
    {
        bool Save(T entity, bool isCommit = true);
        bool Update(T entity, bool isCommit = true);
        T Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetQueryable(Expression<Func<T, bool>> express);
        bool Delete(T entity, bool isCommit = true);
        T GetFirstPaper();
    }
}

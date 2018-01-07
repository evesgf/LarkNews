using LarkNews.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LarkNews.Dao
{
    public interface IRepository<T> where T:class, IDependencyRegister
    {
        T GetById(object id);
        T Get(Expression<Func<T, bool>> expression);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
    }
}

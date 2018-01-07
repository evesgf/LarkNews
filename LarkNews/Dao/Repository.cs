using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LarkNews.Entity;
using Microsoft.EntityFrameworkCore;
using LarkNews.Services;

namespace LarkNews.Dao
{
    public abstract class Repository<T> : IRepository<T> where T : class, IDependencyRegister
    {
        private readonly MySqlDBContext _MySqlDBContext;

        public Repository(MySqlDBContext mySqlDBContext)
        {
            _MySqlDBContext = mySqlDBContext;
        }

        public virtual T GetById(object id)
        {
            return _MySqlDBContext.Set<T>().Find(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _MySqlDBContext.Set<T>().AsNoTracking().SingleOrDefault(expression);
        }

        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _MySqlDBContext.Set<T>().Add(entity);

                _MySqlDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _MySqlDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _MySqlDBContext.Set<T>().Remove(entity);

                _MySqlDBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return _MySqlDBContext.Set<T>();
            }
        }
        IQueryable<T> IRepository<T>.Table
        {
            get { return Table; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LarkNews.Entity;
using Microsoft.EntityFrameworkCore;

namespace LarkNews.Dao
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private MyDbContext _context;
        private UnitOfWork _unitOfWork;

        public Repository(MyDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        public bool Save(T entity, bool isCommit = true)
        {
            _context.Add(entity);

            return isCommit && _unitOfWork.Commit();
        }

        public bool Update(T entity, bool isCommit = true)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return isCommit && _unitOfWork.Commit();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>> express)
        {
            Func<T, bool> lamada = express.Compile();
            return _context.Set<T>().Where(lamada).AsQueryable();
        }

        public bool Delete(T entity, bool isCommit = true)
        {
            if (entity == null) return false;

            _context.Remove(entity);

            return isCommit && _unitOfWork.Commit();
        }

        public T GetFirstPaper()
        {
            return _context.Set<T>().LastOrDefault();
        }
    }
}

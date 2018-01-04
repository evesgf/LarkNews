using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Dao
{
    public class UnitOfWork : IUnitOfWork
    {
        private MySqlDBContext _context;

        public UnitOfWork(MySqlDBContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}

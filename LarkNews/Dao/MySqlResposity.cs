using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Entity;

namespace LarkNews.Dao
{
    public class MySqlResposity:Repository<NewsList>
    {
        public MySqlResposity(MySqlDBContext context) : base(context)
        {
        }
    }
}

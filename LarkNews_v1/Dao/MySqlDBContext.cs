using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews_v1.Dao
{
    /// <summary>
    /// 生成数据库架构：Add-Migration MyFirstMigration
    /// 开启自动迁移：Enable-Migrations -EnableAutomaticMigrations
    /// 更新数据库：Update-Database
    /// </summary>
    public class MySqlDBContext: DbContext
    {
        public MySqlDBContext()
        {
        }

        public MySqlDBContext(DbContextOptions<MySqlDBContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

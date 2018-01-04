using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Entity;
using Microsoft.EntityFrameworkCore;
using LarkNews.Entitys;
using LarkNews.Mappings;

namespace LarkNews.Dao
{
    /// <summary>
    /// 生成数据库架构：Add-Migration MyFirstMigration
    /// 开启自动迁移:Enable-Migrations -EnableAutomaticMigrations
    /// 更新数据库：Update-Database
    /// </summary>
    public class MySqlDBContext: DbContext
    {
        public MySqlDBContext(DbContextOptions<MySqlDBContext> options) : base(options){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //关联Mapping
            new UserMapping(modelBuilder.Entity<NewsList>());
            new UserMapping(modelBuilder.Entity<Sys_User>());
        }
    }
}

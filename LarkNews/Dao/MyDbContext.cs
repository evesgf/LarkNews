using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Entity;
using Microsoft.EntityFrameworkCore;

namespace LarkNews.Dao
{
    /// <summary>
    /// 生成数据库架构：Add-Migration MyFirstMigration
    /// 开启自动迁移:Enable-Migrations -EnableAutomaticMigrations
    /// 更新数据库：Update-Database
    /// </summary>
    public class MyDbContext: DbContext
    {
        //public MyDbContext()
        //{

        //}

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options){ }

        //public DbSet<Sys_User> Sys_User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //关联Mapping
            new NewsListMapping(modelBuilder.Entity<NewsList>());
        }
    }
}

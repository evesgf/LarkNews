using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Configs;
using LarkNews.Dao;
using LarkNews.Entity;
using LarkNews.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MySQL.Data.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using LarkNews.Commons;
using System.Reflection;

namespace LarkNews
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加数据库链接配置
            //var dblink = "Data Source=localhost;port=3306;Initial Catalog=NewsDB;uid=root;password=;Character Set=utf8;";
            services.AddDbContext<MySqlDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));

            //依赖注入
            //services.AddTransient<ISiteService, SiteService>();
            //services.AddTransient<IPMTownService, PmTownService>();
            //services.AddTransient<IBitNewsService, BitNewsService>();
            //services.AddTransient<IRepository<NewsList>, MySqlResposity>();

            //循环依赖注入
            services.AddCommandHandlers(Assembly.GetEntryAssembly());

            // Add framework services.
            services.AddMvc();

            //添加TimeJob
            services.AddTimedJob();

            #region 跨域
            //var urls = Configuration["AppConfig:Cores"].Split(',');
            var urls = "http://newsserver.evesgf.com";
            services.AddCors(options =>
                options.AddPolicy("AllowSameDomain",
                    builder => builder.WithOrigins(urls).AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin().AllowCredentials())
            );
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //检查数据库
            using (var ser = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ser.ServiceProvider.GetService<MySqlDBContext>().Database.Migrate();
                //ser.ServiceProvider.GetService<TestAllDbContext>().Database.EnsureSeedData();
            }

            //使用TimeJob
            app.UseTimedJob();
        }
    }
}

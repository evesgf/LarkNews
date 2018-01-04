using LarkNews_v1.Common;
using LarkNews_v1.Dao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LarkNews_v1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加数据库链接配置
            //var dblink = "Data Source=localhost;port=3306;Initial Catalog=NewsDB;uid=root;password=;Character Set=utf8;";
            services.AddDbContext<MySqlDBContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConnection")));

            //循环依赖注入
            services.AddCommandHandlers(Assembly.GetEntryAssembly());

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //检查数据库
            using (var ser = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                ser.ServiceProvider.GetService<MySqlDBContext>().Database.Migrate();
            }
        }
    }
}

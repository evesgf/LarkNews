using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LarkNews.Configs
{
    public class SiteService:ISiteService
    {
        public T GetSiteService<T>(string key) where T : class, new()
        {
            var config=new ConfigurationBuilder().Add(new JsonConfigurationSource{Path = " Configs/SiteConfig.json" }).Build();

            return new ServiceCollection().AddOptions().Configure<T>(config.GetSection(key)).BuildServiceProvider().GetService<IOptions<T>>().Value;
        }
    }
}

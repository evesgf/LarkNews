using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews.Configs
{
    public interface ISiteService
    {
        T GetSiteService<T>(string key) where T : class, new();
    }
}

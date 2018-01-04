using LarkNews_v1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews_v1.Config
{
    public interface ISiteConfigService : IDependencyRegister
    {
        T GetSiteConfigs<T>(string key) where T : class, new();
    }
}

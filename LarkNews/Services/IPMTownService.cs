using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Entity;

namespace LarkNews.Services
{
    public interface IPMTownService: IDependencyRegister
    {
        NewsList GetFirstPaper();
        NewsList GetMorningPaper(int id);
        int UpDateMorningPaper();
        void SaveError();
    }
}

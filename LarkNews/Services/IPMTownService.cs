using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Entity;

namespace LarkNews.Services
{
    public interface IPMTownService
    {
        NewsList GetMorningPaper(int id);

        NewsList GetFirstPaper();

        int UpDateMorningPaper();
    }
}

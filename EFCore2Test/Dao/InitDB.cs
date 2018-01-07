using EFCore2Test.Entity;
using System.Linq;

namespace EFCore2Test.Dao
{
    public static class InitDB
    {
        public static void Initialize(MySqlDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.SysUsers.Any()) return;     //有数据则不插入

            var mode = new SysUser { Name = "Test",Password="123456",NickName="evesgf" };
            context.SysUsers.Add(mode);
            context.SaveChangesAsync();
        }
    }
}

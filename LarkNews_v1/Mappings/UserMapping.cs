using LarkNews_v1.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LarkNews_v1.Mappings
{
    public class UserMapping
    {
        public UserMapping(EntityTypeBuilder<Sys_User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.PassWord).IsRequired().HasMaxLength(50);
        }
    }
}

using LarkNews.Entitys;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LarkNews.Entity;

namespace LarkNews.Mappings
{
    public class UserMapping
    {
        private EntityTypeBuilder<NewsList> entityTypeBuilder;

        public UserMapping(EntityTypeBuilder<Sys_User> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.UserName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.PassWord).IsRequired().HasMaxLength(50);
        }

        public UserMapping(EntityTypeBuilder<NewsList> entityTypeBuilder)
        {
            this.entityTypeBuilder = entityTypeBuilder;
        }
    }
}

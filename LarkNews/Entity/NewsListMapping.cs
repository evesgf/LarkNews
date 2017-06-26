using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LarkNews.Entity
{
    public class NewsListMapping
    {
        public NewsListMapping(EntityTypeBuilder<NewsList> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.From).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Content).IsRequired().HasColumnType("text");
        }
    }
}

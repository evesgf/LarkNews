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
            entityBuilder.ToTable("newslist");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.NewsFrom).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.NewsFromUrl).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.NewsPublishTime).IsRequired().HasColumnType("long");
            entityBuilder.Property(x => x.NewsTitle).IsRequired().HasMaxLength(255);
            entityBuilder.Property(x => x.NewsContent).IsRequired().HasColumnType("text");
            entityBuilder.Property(x => x.NewsCreateTime).IsRequired().HasColumnType("long");
        }
    }
}

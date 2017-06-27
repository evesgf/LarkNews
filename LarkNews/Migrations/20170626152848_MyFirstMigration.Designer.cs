using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LarkNews.Dao;

namespace LarkNews.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170626152848_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("LarkNews.Entity.NewsList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NewsContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("NewsCreateTime")
                        .HasColumnType("long");

                    b.Property<string>("NewsFrom")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NewsFromUrl")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<long>("NewsPublishTime")
                        .HasColumnType("long");

                    b.Property<string>("NewsTitle")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("newslist");
                });
        }
    }
}

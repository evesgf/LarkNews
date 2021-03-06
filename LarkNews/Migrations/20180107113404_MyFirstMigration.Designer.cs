﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LarkNews.Dao;

namespace LarkNews.Migrations
{
    [DbContext(typeof(MySqlDBContext))]
    [Migration("20180107113404_MyFirstMigration")]
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
                        .HasMaxLength(50);

                    b.Property<long>("NewsCreateTime")
                        .HasMaxLength(50);

                    b.Property<string>("NewsFrom")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NewsFromUrl")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("NewsPublishTime")
                        .HasMaxLength(50);

                    b.Property<string>("NewsTitle")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("NewsList");
                });

            modelBuilder.Entity("LarkNews.Entitys.Sys_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Sys_User");
                });

            //modelBuilder.Entity("Pomelo.AspNetCore.TimedJob.EntityFramework.TimedJob", b =>
            //    {
            //        b.Property<string>("Id")
            //            .ValueGeneratedOnAdd()
            //            .HasMaxLength(512);

            //        b.Property<DateTime>("Begin");

            //        b.Property<int>("Interval");

            //        b.Property<bool>("IsEnabled");

            //        b.HasKey("Id");

            //        b.ToTable("AspNetTimedJobs");
            //    });
        }
    }
}

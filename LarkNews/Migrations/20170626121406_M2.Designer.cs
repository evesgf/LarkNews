﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LarkNews.Dao;

namespace LarkNews.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170626121406_M2")]
    partial class M2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("LarkNews.Entity.NewsList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("From")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("NewsList");
                });
        }
    }
}

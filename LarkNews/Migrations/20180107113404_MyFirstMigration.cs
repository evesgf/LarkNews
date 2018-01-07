using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LarkNews.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NewsContent = table.Column<string>(maxLength: 50, nullable: false),
                    NewsCreateTime = table.Column<long>(maxLength: 50, nullable: false),
                    NewsFrom = table.Column<string>(maxLength: 50, nullable: false),
                    NewsFromUrl = table.Column<string>(maxLength: 50, nullable: false),
                    NewsPublishTime = table.Column<long>(maxLength: 50, nullable: false),
                    NewsTitle = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sys_User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PassWord = table.Column<string>(maxLength: 50, nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys_User", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "AspNetTimedJobs",
            //    columns: table => new
            //    {
            //        Id = table.Column<string>(maxLength: 512, nullable: false),
            //        Begin = table.Column<DateTime>(nullable: false),
            //        Interval = table.Column<int>(nullable: false),
            //        IsEnabled = table.Column<bool>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_AspNetTimedJobs", x => x.Id);
            //    });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsList");

            migrationBuilder.DropTable(
                name: "Sys_User");

            //migrationBuilder.DropTable(
            //    name: "AspNetTimedJobs");
        }
    }
}

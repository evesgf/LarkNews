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
                name: "newslist",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    NewsContent = table.Column<string>(type: "text", nullable: false),
                    NewsCreateTime = table.Column<long>(type: "long", nullable: false),
                    NewsFrom = table.Column<string>(maxLength: 50, nullable: false),
                    NewsFromUrl = table.Column<string>(maxLength: 255, nullable: false),
                    NewsPublishTime = table.Column<long>(type: "long", nullable: false),
                    NewsTitle = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_newslist", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "newslist");
        }
    }
}

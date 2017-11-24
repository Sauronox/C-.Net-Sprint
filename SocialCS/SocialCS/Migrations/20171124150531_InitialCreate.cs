using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SocialCS.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MvcUser",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvcUser", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "MvcArticles",
                columns: table => new
                {
                    ArticlesID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvcArticles", x => x.ArticlesID);
                    table.ForeignKey(
                        name: "FK_MvcArticles_MvcUser_UserID",
                        column: x => x.UserID,
                        principalTable: "MvcUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MvcComments",
                columns: table => new
                {
                    CommentsID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArtilcesID = table.Column<int>(type: "INTEGER", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    MvcArticlesArticlesID = table.Column<int>(type: "INTEGER", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MvcComments", x => x.CommentsID);
                    table.ForeignKey(
                        name: "FK_MvcComments_MvcArticles_MvcArticlesArticlesID",
                        column: x => x.MvcArticlesArticlesID,
                        principalTable: "MvcArticles",
                        principalColumn: "ArticlesID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MvcComments_MvcUser_UserID",
                        column: x => x.UserID,
                        principalTable: "MvcUser",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MvcArticles_UserID",
                table: "MvcArticles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_MvcComments_MvcArticlesArticlesID",
                table: "MvcComments",
                column: "MvcArticlesArticlesID");

            migrationBuilder.CreateIndex(
                name: "IX_MvcComments_UserID",
                table: "MvcComments",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MvcComments");

            migrationBuilder.DropTable(
                name: "MvcArticles");

            migrationBuilder.DropTable(
                name: "MvcUser");
        }
    }
}

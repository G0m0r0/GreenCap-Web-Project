using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenCap.Data.Migrations
{
    public partial class MergedTableNews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SummaryNews_SummaryNewsId",
                table: "News");

            migrationBuilder.DropTable(
                name: "SummaryNews");

            migrationBuilder.DropIndex(
                name: "IX_News_SummaryNewsId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "SummaryNewsId",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageSmallUrl",
                table: "News",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalUrl",
                table: "News",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostedOn",
                table: "News",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "News",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_CategoryNews_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "CategoryNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_CategoryNews_CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ImageSmallUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "OriginalUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PostedOn",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "News");

            migrationBuilder.AddColumn<int>(
                name: "SummaryNewsId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SummaryNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ImageSmallUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewsId = table.Column<int>(type: "int", nullable: false),
                    OriginalUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PostedOn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryNews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryNews_CategoryNews_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SummaryNews_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_SummaryNewsId",
                table: "News",
                column: "SummaryNewsId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryNews_CategoryId",
                table: "SummaryNews",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryNews_IsDeleted",
                table: "SummaryNews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryNews_NewsId",
                table: "SummaryNews",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_SummaryNews_SummaryNewsId",
                table: "News",
                column: "SummaryNewsId",
                principalTable: "SummaryNews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

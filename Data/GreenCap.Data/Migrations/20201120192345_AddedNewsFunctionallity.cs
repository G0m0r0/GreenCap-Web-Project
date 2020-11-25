namespace GreenCap.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedNewsFunctionallity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Proposals",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Proposals",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Proposals",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemTitle",
                table: "Posts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                maxLength: 20000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                maxLength: 15000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateTable(
                name: "CategoryNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummaryNews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    PostedOn = table.Column<string>(maxLength: 30, nullable: false),
                    Summary = table.Column<string>(maxLength: 1000, nullable: false),
                    OriginalUrl = table.Column<string>(maxLength: 1000, nullable: false),
                    ImageSmallUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    NewsId = table.Column<int>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(maxLength: 1000, nullable: true),
                    Credit = table.Column<string>(maxLength: 1000, nullable: true),
                    Description = table.Column<string>(maxLength: 50000, nullable: false),
                    SummaryNewsId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_SummaryNews_SummaryNewsId",
                        column: x => x.SummaryNewsId,
                        principalTable: "SummaryNews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryNews_IsDeleted",
                table: "CategoryNews",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_News_IsDeleted",
                table: "News",
                column: "IsDeleted");

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
                name: "FK_SummaryNews_News_NewsId",
                table: "SummaryNews",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_SummaryNews_SummaryNewsId",
                table: "News");

            migrationBuilder.DropTable(
                name: "SummaryNews");

            migrationBuilder.DropTable(
                name: "CategoryNews");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Proposals",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Proposals",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Proposals",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10000);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemTitle",
                table: "Posts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Posts",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20000);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Events",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Events",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15000);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 500);
        }
    }
}

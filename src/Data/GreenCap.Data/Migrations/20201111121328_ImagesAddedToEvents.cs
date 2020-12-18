namespace GreenCap.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ImagesAddedToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserLikes_IsDeleted",
                table: "UserLikes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserLikes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserLikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserLikes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserLikes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_IsDeleted",
                table: "UserLikes",
                column: "IsDeleted");
        }
    }
}

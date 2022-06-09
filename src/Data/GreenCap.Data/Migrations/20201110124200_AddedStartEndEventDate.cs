namespace GreenCap.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;
    using System;

    public partial class AddedStartEndEventDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Ideas");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Ideas",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Events",
                maxLength: 1000,
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Ideas",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: " ");
        }
    }
}

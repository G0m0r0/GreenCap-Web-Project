namespace GreenCap.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class MinorChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TotalNeededPeople",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Events",
                maxLength: 30,
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<int>(
                name: "TotalPeople",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TotalPeople",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Events",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<int>(
                name: "TotalNeededPeople",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

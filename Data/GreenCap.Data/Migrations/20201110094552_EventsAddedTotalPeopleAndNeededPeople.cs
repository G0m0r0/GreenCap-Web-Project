using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenCap.Data.Migrations
{
    public partial class EventsAddedTotalPeopleAndNeededPeople : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalNeededPeople",
                table: "Events",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalNeededPeople",
                table: "Events");
        }
    }
}

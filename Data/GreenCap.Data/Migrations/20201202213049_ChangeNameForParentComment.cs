using Microsoft.EntityFrameworkCore.Migrations;

namespace GreenCap.Data.Migrations
{
    public partial class ChangeNameForParentComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                type: "int",
                nullable: true);
        }
    }
}

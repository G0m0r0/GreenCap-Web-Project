namespace GreenCap.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class CreatorsListForEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_AspNetUsers_HostId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_HostId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "HostId",
                table: "Events");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(max)",
                maxLength: 50000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Events_EventId",
                table: "AspNetUsers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Events_EventId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EventId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "HostId",
                table: "Events",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Comments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 50000);

            migrationBuilder.CreateIndex(
                name: "IX_Events_HostId",
                table: "Events",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_AspNetUsers_HostId",
                table: "Events",
                column: "HostId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

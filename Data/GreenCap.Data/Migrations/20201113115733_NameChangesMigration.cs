namespace GreenCap.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class NameChangesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ideas_AspNetUsers_UserId",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_UserEvents_IsDeleted",
                table: "UserEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ideas",
                table: "Ideas");

            migrationBuilder.DropIndex(
                name: "IX_Ideas_UserId",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserEvents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserEvents");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Ideas");

            migrationBuilder.RenameTable(
                name: "Ideas",
                newName: "Proposals");

            migrationBuilder.RenameIndex(
                name: "IX_Ideas_IsDeleted",
                table: "Proposals",
                newName: "IX_Proposals_IsDeleted");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Proposals",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proposals",
                table: "Proposals",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    AddedById = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    ProposalId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_AspNetUsers_AddedById",
                        column: x => x.AddedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Images_Proposals_ProposalId",
                        column: x => x.ProposalId,
                        principalTable: "Proposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_CreatedById",
                table: "Proposals",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AddedById",
                table: "Images",
                column: "AddedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_IsDeleted",
                table: "Images",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProposalId",
                table: "Images",
                column: "ProposalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposals_AspNetUsers_CreatedById",
                table: "Proposals",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Proposals_AspNetUsers_CreatedById",
                table: "Proposals");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proposals",
                table: "Proposals");

            migrationBuilder.DropIndex(
                name: "IX_Proposals_CreatedById",
                table: "Proposals");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Proposals");

            migrationBuilder.RenameTable(
                name: "Proposals",
                newName: "Ideas");

            migrationBuilder.RenameIndex(
                name: "IX_Proposals_IsDeleted",
                table: "Ideas",
                newName: "IX_Ideas_IsDeleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserEvents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Ideas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: " ");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Ideas",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ideas",
                table: "Ideas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserEvents_IsDeleted",
                table: "UserEvents",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_UserId",
                table: "Ideas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ideas_AspNetUsers_UserId",
                table: "Ideas",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

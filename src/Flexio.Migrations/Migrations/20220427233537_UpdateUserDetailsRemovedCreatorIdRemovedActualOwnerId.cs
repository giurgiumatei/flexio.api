using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flexio.Migrations.Migrations
{
    public partial class UpdateUserDetailsRemovedCreatorIdRemovedActualOwnerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_ActualOwnerId",
                table: "UserDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_Users_CreatorId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_ActualOwnerId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_CreatorId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "ActualOwnerId",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "UserDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActualOwnerId",
                table: "UserDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "UserDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_ActualOwnerId",
                table: "UserDetails",
                column: "ActualOwnerId",
                unique: true,
                filter: "[ActualOwnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_CreatorId",
                table: "UserDetails",
                column: "CreatorId",
                unique: true,
                filter: "[CreatorId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_ActualOwnerId",
                table: "UserDetails",
                column: "ActualOwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_Users_CreatorId",
                table: "UserDetails",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

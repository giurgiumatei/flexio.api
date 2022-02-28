using Microsoft.EntityFrameworkCore.Migrations;

namespace Flexio.Migrations.Migrations
{
    public partial class UpdateUserDetailMadeCreatorAndActualOwnerOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_ActualOwnerId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_CreatorId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "UserDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ActualOwnerId",
                table: "UserDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_ActualOwnerId",
                table: "UserDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserDetails_CreatorId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<int>(
                name: "CreatorId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ActualOwnerId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_ActualOwnerId",
                table: "UserDetails",
                column: "ActualOwnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_CreatorId",
                table: "UserDetails",
                column: "CreatorId",
                unique: true);
        }
    }
}

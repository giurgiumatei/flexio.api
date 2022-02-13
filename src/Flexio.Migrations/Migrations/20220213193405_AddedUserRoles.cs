using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flexio.Migrations.Migrations
{
    public partial class AddedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "UserDetails",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoleLookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLookup", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RoleLookup",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "FlexioAdmin" });

            migrationBuilder.InsertData(
                table: "RoleLookup",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Client" });

            migrationBuilder.InsertData(
                table: "RoleLookup",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "IdentityChecker" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleLookup");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserDetails");

            migrationBuilder.AlterColumn<string>(
                name: "DateOfBirth",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}

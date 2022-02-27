using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flexio.Migrations.Migrations
{
    public partial class UpdatedUserAndUserDetailsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkSetDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "UserDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "UserDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "LinkSetDate",
                table: "Users",
                type: "datetime2",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "UserDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

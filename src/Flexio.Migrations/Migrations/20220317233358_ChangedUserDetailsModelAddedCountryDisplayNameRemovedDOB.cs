using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flexio.Migrations.Migrations
{
    public partial class ChangedUserDetailsModelAddedCountryDisplayNameRemovedDOB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "UserDetails");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "UserDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "UserDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "UserDetails");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "UserDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "UserDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flexio.Migrations.Migrations
{
    public partial class AddedGenders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GenderLookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenderLookup", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GenderLookup",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Male" });

            migrationBuilder.InsertData(
                table: "GenderLookup",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Female" });

            migrationBuilder.InsertData(
                table: "GenderLookup",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Other" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenderLookup");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "UserDetails");
        }
    }
}

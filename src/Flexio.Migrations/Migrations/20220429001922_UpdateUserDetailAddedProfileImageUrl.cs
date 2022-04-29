using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flexio.Migrations.Migrations
{
    public partial class UpdateUserDetailAddedProfileImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageUrl",
                table: "UserDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageUrl",
                table: "UserDetails");
        }
    }
}

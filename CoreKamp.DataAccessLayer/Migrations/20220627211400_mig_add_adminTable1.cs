using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreKamp.DataAccessLayer.Migrations
{
    public partial class mig_add_adminTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Admins");
        }
    }
}

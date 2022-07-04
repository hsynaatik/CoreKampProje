using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreKamp.DataAccessLayer.Migrations
{
    public partial class mig_add_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Message2s",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "IsDelete",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "AspNetRoles");
        }
    }
}

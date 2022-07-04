using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreKamp.DataAccessLayer.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactMeassage",
                table: "Contacts",
                newName: "ContactMessage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactMessage",
                table: "Contacts",
                newName: "ContactMeassage");
        }
    }
}

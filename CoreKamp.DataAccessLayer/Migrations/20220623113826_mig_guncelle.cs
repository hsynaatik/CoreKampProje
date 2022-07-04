using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreKamp.DataAccessLayer.Migrations
{
    public partial class mig_guncelle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_ReceiverID",
                table: "Message2");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2_Writers_SenderID",
                table: "Message2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message2",
                table: "Message2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.RenameTable(
                name: "Message2",
                newName: "Message2s");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_SenderID",
                table: "Message2s",
                newName: "IX_Message2s_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Message2_ReceiverID",
                table: "Message2s",
                newName: "IX_Message2s_ReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message2s",
                table: "Message2s",
                column: "MessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_ReceiverID",
                table: "Message2s",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_SenderID",
                table: "Message2s",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_ReceiverID",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_SenderID",
                table: "Message2s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message2s",
                table: "Message2s");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Message2s",
                newName: "Message2");

            migrationBuilder.RenameIndex(
                name: "IX_Message2s_SenderID",
                table: "Message2",
                newName: "IX_Message2_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_Message2s_ReceiverID",
                table: "Message2",
                newName: "IX_Message2_ReceiverID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "MessageID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message2",
                table: "Message2",
                column: "MessageID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_ReceiverID",
                table: "Message2",
                column: "ReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2_Writers_SenderID",
                table: "Message2",
                column: "SenderID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

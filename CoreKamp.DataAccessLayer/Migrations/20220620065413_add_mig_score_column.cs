﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreKamp.DataAccessLayer.Migrations
{
    public partial class add_mig_score_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogScore",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogScore",
                table: "Comments");
        }
    }
}

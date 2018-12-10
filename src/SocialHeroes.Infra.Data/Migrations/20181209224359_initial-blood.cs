using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialHeroes.Infra.Data.Migrations
{
    public partial class initialblood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BloodId",
                table: "DonatorUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(type: "Varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUsers_BloodId",
                table: "DonatorUsers",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloods_Type",
                table: "Bloods",
                column: "Type",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DonatorUsers_Bloods_BloodId",
                table: "DonatorUsers",
                column: "BloodId",
                principalTable: "Bloods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DonatorUsers_Bloods_BloodId",
                table: "DonatorUsers");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropIndex(
                name: "IX_DonatorUsers_BloodId",
                table: "DonatorUsers");

            migrationBuilder.DropColumn(
                name: "BloodId",
                table: "DonatorUsers");
        }
    }
}

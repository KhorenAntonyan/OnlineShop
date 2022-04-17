using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DAL.Migrations
{
    public partial class UpdatePhotoEntitiy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bytes",
                table: "Photo");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Photo");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "Photo",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "Photo");

            migrationBuilder.AddColumn<byte[]>(
                name: "Bytes",
                table: "Photo",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<decimal>(
                name: "Size",
                table: "Photo",
                type: "decimal(38,18)",
                precision: 38,
                scale: 18,
                nullable: false,
                defaultValue: 0m);
        }
    }
}

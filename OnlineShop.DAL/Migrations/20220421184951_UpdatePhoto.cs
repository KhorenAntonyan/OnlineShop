using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.DAL.Migrations
{
    public partial class UpdatePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Photo",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Photo");
        }
    }
}

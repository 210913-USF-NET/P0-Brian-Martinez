using Microsoft.EntityFrameworkCore.Migrations;

namespace DL.Migrations
{
    public partial class ninth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

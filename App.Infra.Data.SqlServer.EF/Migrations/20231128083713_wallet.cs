using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Data.SqlServer.EF.Migrations
{
    public partial class wallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Wallet",
                table: "Sellers",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Wallet",
                table: "Admins",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Sellers");

            migrationBuilder.DropColumn(
                name: "Wallet",
                table: "Admins");
        }
    }
}

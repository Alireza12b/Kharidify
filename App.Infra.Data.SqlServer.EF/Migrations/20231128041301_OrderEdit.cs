using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Data.SqlServer.EF.Migrations
{
    public partial class OrderEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Cities",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AddressDetail",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Carts");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderLines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Cities_CityId",
                table: "Carts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Cities_CityId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderLines");

            migrationBuilder.AddColumn<string>(
                name: "AddressDetail",
                table: "Carts",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Carts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Carts",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Carts",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Cities",
                table: "Carts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}

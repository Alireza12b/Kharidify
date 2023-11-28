using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Infra.Data.SqlServer.EF.Migrations
{
    public partial class editcart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "isPaid",
                table: "Carts");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "OrderLines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "OrderLines",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "PayDate",
                table: "OrderLines");

            migrationBuilder.AddColumn<DateTime>(
                name: "PayDate",
                table: "Carts",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isPaid",
                table: "Carts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

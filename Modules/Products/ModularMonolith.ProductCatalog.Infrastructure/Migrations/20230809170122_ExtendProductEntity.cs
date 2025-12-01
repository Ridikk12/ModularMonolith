using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModularMonolith.Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExtendProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "out");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "pr",
                table: "Products",
                newName: "ModifiedDate");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "pr",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "pr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                schema: "pr",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                schema: "pr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price_CurrencySymbol",
                schema: "pr",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price_Price",
                schema: "pr",
                table: "Products",
                type: "decimal(4,2)",
                precision: 4,
                nullable: true);
            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                schema: "pr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                schema: "pr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                schema: "pr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_CurrencySymbol",
                schema: "pr",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price_Price",
                schema: "pr",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                schema: "pr",
                table: "Products",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "pr",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Data.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsQATests_ProductQATestsId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductQATestsId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsQATests_ProductQATestsId",
                table: "Products",
                column: "ProductQATestsId",
                principalTable: "ProductsQATests",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductsQATests_ProductQATestsId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductQATestsId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductsQATests_ProductQATestsId",
                table: "Products",
                column: "ProductQATestsId",
                principalTable: "ProductsQATests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

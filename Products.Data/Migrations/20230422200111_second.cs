using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReferenceId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reference",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    MaterialType = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reference_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReferenceId",
                table: "Products",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reference_ProductId",
                table: "Reference",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Reference_ReferenceId",
                table: "Products",
                column: "ReferenceId",
                principalTable: "Reference",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Reference_ReferenceId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Reference");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReferenceId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReferenceId",
                table: "Products");
        }
    }
}

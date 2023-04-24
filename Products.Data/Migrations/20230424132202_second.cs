using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "MaximumSizeAllowed",
                table: "References",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MaximumWeightAllowed",
                table: "References",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinimumSizeAllowed",
                table: "References",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "MinimumWeightAllowed",
                table: "References",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximumSizeAllowed",
                table: "References");

            migrationBuilder.DropColumn(
                name: "MaximumWeightAllowed",
                table: "References");

            migrationBuilder.DropColumn(
                name: "MinimumSizeAllowed",
                table: "References");

            migrationBuilder.DropColumn(
                name: "MinimumWeightAllowed",
                table: "References");
        }
    }
}

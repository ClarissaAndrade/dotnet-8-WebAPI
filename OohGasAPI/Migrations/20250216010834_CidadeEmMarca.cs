using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OohGasAPI.Migrations
{
    /// <inheritdoc />
    public partial class CidadeEmMarca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Brands",
                type: "varchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Brands");
        }
    }
}

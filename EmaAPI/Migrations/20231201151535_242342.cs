using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmaAPI.Migrations
{
    /// <inheritdoc />
    public partial class _242342 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vat",
                table: "Items",
                newName: "DiscountRate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountRate",
                table: "Items",
                newName: "Vat");
        }
    }
}

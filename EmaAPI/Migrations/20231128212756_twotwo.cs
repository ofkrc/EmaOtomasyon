using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmaAPI.Migrations
{
    /// <inheritdoc />
    public partial class twotwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "Varchar(15)", maxLength: 15, nullable: true),
                    Website = table.Column<string>(type: "Varchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    TaxOffice = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    TaxNo = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UserRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Companies_Users_UserRecordId",
                        column: x => x.UserRecordId,
                        principalTable: "Users",
                        principalColumn: "RecordId");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "Varchar(15)", maxLength: 15, nullable: true),
                    CompanyRecordId = table.Column<int>(type: "int", nullable: true),
                    UserRecordId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyRecordId",
                        column: x => x.CompanyRecordId,
                        principalTable: "Companies",
                        principalColumn: "RecordId");
                    table.ForeignKey(
                        name: "FK_Customers_Users_UserRecordId",
                        column: x => x.UserRecordId,
                        principalTable: "Users",
                        principalColumn: "RecordId");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrderNumber = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Vat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    CompanyRecordId = table.Column<int>(type: "int", nullable: true),
                    CustomerRecordId = table.Column<int>(type: "int", nullable: true),
                    UserRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Invoices_Companies_CompanyRecordId",
                        column: x => x.CompanyRecordId,
                        principalTable: "Companies",
                        principalColumn: "RecordId");
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerRecordId",
                        column: x => x.CustomerRecordId,
                        principalTable: "Customers",
                        principalColumn: "RecordId");
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserRecordId",
                        column: x => x.UserRecordId,
                        principalTable: "Users",
                        principalColumn: "RecordId");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CreatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDatetime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceRecordId = table.Column<int>(type: "int", nullable: false),
                    UserRecordId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Items_Invoices_InvoiceRecordId",
                        column: x => x.InvoiceRecordId,
                        principalTable: "Invoices",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Users_UserRecordId",
                        column: x => x.UserRecordId,
                        principalTable: "Users",
                        principalColumn: "RecordId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_UserRecordId",
                table: "Companies",
                column: "UserRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyRecordId",
                table: "Customers",
                column: "CompanyRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserRecordId",
                table: "Customers",
                column: "UserRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyRecordId",
                table: "Invoices",
                column: "CompanyRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerRecordId",
                table: "Invoices",
                column: "CustomerRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserRecordId",
                table: "Invoices",
                column: "UserRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_InvoiceRecordId",
                table: "Items",
                column: "InvoiceRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UserRecordId",
                table: "Items",
                column: "UserRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

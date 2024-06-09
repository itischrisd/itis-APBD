using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KolokwiumCF.Migrations
{
    /// <inheritdoc />
    public partial class InitialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_PK", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RenewalPeriod = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Subscription_PK", x => x.IdSubscription);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    IdDiscount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Discount_PK", x => x.IdDiscount);
                    table.ForeignKey(
                        name: "Client_Discount_FK",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Payment_PK", x => x.IdPayment);
                    table.ForeignKey(
                        name: "Payment_Client_FK",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Subscription_Payment_FK",
                        column: x => x.IdSubscription,
                        principalTable: "Subscriptions",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdSale_PK", x => x.IdSale);
                    table.ForeignKey(
                        name: "Client_Sale_FK",
                        column: x => x.IdClient,
                        principalTable: "Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Subscription_Sale_FK",
                        column: x => x.IdSubscription,
                        principalTable: "Subscriptions",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "IdClient", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "test@mail.com", "Sample", "Client", "123456789" },
                    { 2, "test@mail.com", "Jakub", "Biologist", "123456789" },
                    { 3, "test@mail.com", "Michal", "Pediatrician", "123456789" },
                    { 4, "test@mail.com", "Sergio", "Psychiatrist", "123456789" },
                    { 5, "test@mail.com", "Pablo", "Dentist", "123456789" },
                    { 6, "test@mail.com", "Azucar", "Cardiologist", "123456789" }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "IdSubscription", "EndTime", "Name", "Price", "RenewalPeriod" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 14, 0, 0, 0, 0, DateTimeKind.Local), "Sample", 100.0, 5 },
                    { 2, new DateTime(2024, 6, 19, 0, 0, 0, 0, DateTimeKind.Local), "Jakub", 200.0, 10 },
                    { 3, new DateTime(2024, 6, 24, 0, 0, 0, 0, DateTimeKind.Local), "Michal", 300.0, 15 }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "IdDiscount", "DateFrom", "DateTo", "IdClient", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9067), new DateTime(2024, 7, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9114), 1, 10 },
                    { 2, new DateTime(2024, 6, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9119), new DateTime(2024, 7, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9120), 2, 20 },
                    { 3, new DateTime(2024, 6, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9122), new DateTime(2024, 7, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9124), 3, 30 }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "IdPayment", "Date", "IdClient", "IdSubscription" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(2972), 1, 1 },
                    { 2, new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(2995), 2, 2 },
                    { 3, new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(2998), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "IdSale", "CreatedAt", "IdClient", "IdSubscription" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(7037), 1, 1 },
                    { 2, new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(7054), 2, 2 },
                    { 3, new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(7056), 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_IdClient",
                table: "Discounts",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdClient",
                table: "Payments",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_IdSubscription",
                table: "Payments",
                column: "IdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdClient",
                table: "Sales",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_IdSubscription",
                table: "Sales",
                column: "IdSubscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}

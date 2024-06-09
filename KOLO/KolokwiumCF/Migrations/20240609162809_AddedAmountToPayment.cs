using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KolokwiumCF.Migrations
{
    /// <inheritdoc />
    public partial class AddedAmountToPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "IdDiscount",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(4715), new DateTime(2024, 7, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(4763) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "IdDiscount",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(4768), new DateTime(2024, 7, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(4769) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "IdDiscount",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(4771), new DateTime(2024, 7, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(4772) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "IdPayment",
                keyValue: 1,
                columns: new[] { "Amount", "Date" },
                values: new object[] { 100, new DateTime(2024, 6, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(8830) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "IdPayment",
                keyValue: 2,
                columns: new[] { "Amount", "Date" },
                values: new object[] { 200, new DateTime(2024, 6, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(8849) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "IdPayment",
                keyValue: 3,
                columns: new[] { "Amount", "Date" },
                values: new object[] { 300, new DateTime(2024, 6, 9, 18, 28, 9, 617, DateTimeKind.Local).AddTicks(8851) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 9, 18, 28, 9, 618, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 9, 18, 28, 9, 618, DateTimeKind.Local).AddTicks(5117));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 9, 18, 28, 9, 618, DateTimeKind.Local).AddTicks(5119));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "IdDiscount",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9067), new DateTime(2024, 7, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9114) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "IdDiscount",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9119), new DateTime(2024, 7, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9120) });

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "IdDiscount",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 6, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9122), new DateTime(2024, 7, 9, 18, 17, 18, 331, DateTimeKind.Local).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "IdPayment",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "IdPayment",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "Payments",
                keyColumn: "IdPayment",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(7037));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(7054));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "IdSale",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 6, 9, 18, 17, 18, 332, DateTimeKind.Local).AddTicks(7056));
        }
    }
}

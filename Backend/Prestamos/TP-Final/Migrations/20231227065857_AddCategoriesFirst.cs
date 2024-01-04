using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP_Final.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoriesFirst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5152));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5179), "Indumentaria" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5182), "Herramientas" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreationDate", "Description" },
                values: new object[,]
                {
                    { 4, new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5184), "Electronica" },
                    { 5, new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5186), "Objetos Varios" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 2, 24, 2, 820, DateTimeKind.Local).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2023, 12, 27, 2, 24, 2, 820, DateTimeKind.Local).AddTicks(8258), "Objetos" });

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description" },
                values: new object[] { new DateTime(2023, 12, 27, 2, 24, 2, 820, DateTimeKind.Local).AddTicks(8261), "Objetos" });
        }
    }
}

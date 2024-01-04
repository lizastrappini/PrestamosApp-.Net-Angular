using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_Final.Migrations
{
    /// <inheritdoc />
    public partial class addCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 15, 5, 299, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 15, 5, 299, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 15, 5, 299, DateTimeKind.Local).AddTicks(1985));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 15, 5, 299, DateTimeKind.Local).AddTicks(1987));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 15, 5, 299, DateTimeKind.Local).AddTicks(1989));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5182));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 3, 58, 56, 800, DateTimeKind.Local).AddTicks(5186));
        }
    }
}

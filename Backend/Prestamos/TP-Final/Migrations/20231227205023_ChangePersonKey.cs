using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_Final.Migrations
{
    /// <inheritdoc />
    public partial class ChangePersonKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 50, 22, 849, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 50, 22, 849, DateTimeKind.Local).AddTicks(6922));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 50, 22, 849, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 50, 22, 849, DateTimeKind.Local).AddTicks(6927));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 50, 22, 849, DateTimeKind.Local).AddTicks(6929));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 46, 51, 916, DateTimeKind.Local).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 46, 51, 916, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 46, 51, 916, DateTimeKind.Local).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 46, 51, 916, DateTimeKind.Local).AddTicks(1458));

            migrationBuilder.UpdateData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2023, 12, 27, 17, 46, 51, 916, DateTimeKind.Local).AddTicks(1460));
        }
    }
}

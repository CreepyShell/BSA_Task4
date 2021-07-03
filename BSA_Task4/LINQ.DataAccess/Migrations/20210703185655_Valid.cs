using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LINQ.DataAccess.Migrations
{
    public partial class Valid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(3829));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(6429));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(7065));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 23, DateTimeKind.Local).AddTicks(2723));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 32, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 32, DateTimeKind.Local).AddTicks(9181));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(1947));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(1974));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(1981));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 21, 56, 54, 33, DateTimeKind.Local).AddTicks(2012));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(8109));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(9721));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(9732));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 242, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(6644));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(7060));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(7064));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(7068));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 24, 10, 248, DateTimeKind.Local).AddTicks(7076));
        }
    }
}

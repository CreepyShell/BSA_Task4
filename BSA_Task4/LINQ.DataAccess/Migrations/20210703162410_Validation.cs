using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LINQ.DataAccess.Migrations
{
    public partial class Validation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(5439));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(5779));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(5791));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(7074));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(7086));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 781, DateTimeKind.Local).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(2751));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(3986));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(4368));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(4381));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(4385));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(4388));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 3, 19, 18, 4, 787, DateTimeKind.Local).AddTicks(4396));
        }
    }
}

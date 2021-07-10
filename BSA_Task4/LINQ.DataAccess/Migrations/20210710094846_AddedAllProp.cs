using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LINQ.DataAccess.Migrations
{
    public partial class AddedAllProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FinishedAt",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Projects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(3047));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(3387));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(4287));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(4617));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(4621));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 428, DateTimeKind.Local).AddTicks(5723));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(546));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(597));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(2036));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(2040));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 48, 45, 433, DateTimeKind.Local).AddTicks(2054));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "FinishedAt",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Projects");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(3571));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(3897));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(3908));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(5510));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(5947));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 450, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(972));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(2534));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(2547));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "RegisteredAt",
                value: new DateTime(2021, 7, 10, 12, 44, 39, 455, DateTimeKind.Local).AddTicks(2568));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class FixTableExaminationColumnWeigthToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Weight",
                table: "Examinations",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Weight" },
                values: new object[] { new DateTime(2024, 2, 27, 9, 37, 27, 347, DateTimeKind.Utc).AddTicks(4656), 12.0 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StatusId", "Weight" },
                values: new object[] { new DateTime(2024, 2, 27, 9, 37, 27, 347, DateTimeKind.Utc).AddTicks(4691), 2, 10.0 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StatusId", "Weight" },
                values: new object[] { new DateTime(2024, 2, 27, 9, 37, 27, 347, DateTimeKind.Utc).AddTicks(4695), 3, 30.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Examinations",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Weight" },
                values: new object[] { new DateTime(2024, 2, 24, 10, 34, 55, 808, DateTimeKind.Utc).AddTicks(6736), 12 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StatusId", "Weight" },
                values: new object[] { new DateTime(2024, 2, 24, 10, 34, 55, 808, DateTimeKind.Utc).AddTicks(6779), 1, 10 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "StatusId", "Weight" },
                values: new object[] { new DateTime(2024, 2, 24, 10, 34, 55, 808, DateTimeKind.Utc).AddTicks(6783), 1, 30 });
        }
    }
}

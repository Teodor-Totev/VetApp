using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class AddMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41e4c6d6-64fc-449d-8350-4555ad09a429", "AQAAAAEAACcQAAAAEJ2uBGuwZS1WcDRLpUZxkjFxvtMGmZ/iVPi9tvLQKZEQUgJfPNuM0llKOWvBeyCrlg==", "2B615401-BDF5-46E6-9193-ACE284D611A2" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 11, 20, 42, 27, 896, DateTimeKind.Utc).AddTicks(263));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StatusId" },
                values: new object[] { new DateTime(2024, 3, 11, 20, 42, 27, 896, DateTimeKind.Utc).AddTicks(280), 3 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 11, 20, 42, 27, 896, DateTimeKind.Utc).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 11, 20, 42, 27, 896, DateTimeKind.Utc).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Frank");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Jerry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73aacf6f-7295-4039-b22a-f773905d4c6e", "AQAAAAEAACcQAAAAEFVdqAg5prZnvvbqgC+sLv11/QWEyVluJaLs6B5xlCus1fM3pZiLiXeVl6kWX7rgaQ==", "47C839AC-A6B1-4F57-84A1-437EE042D5E7" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 18, 17, 31, 979, DateTimeKind.Utc).AddTicks(543));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "StatusId" },
                values: new object[] { new DateTime(2024, 3, 7, 18, 17, 31, 979, DateTimeKind.Utc).AddTicks(552), 2 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 18, 17, 31, 979, DateTimeKind.Utc).AddTicks(555));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2024, 3, 7, 18, 17, 31, 979, DateTimeKind.Utc).AddTicks(557));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Lasi");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Djeri");
        }
    }
}

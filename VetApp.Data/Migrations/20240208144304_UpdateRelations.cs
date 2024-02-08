using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class UpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PatientId" },
                values: new object[] { new DateTime(2024, 1, 19, 16, 43, 4, 143, DateTimeKind.Local).AddTicks(4784), 1 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PatientId" },
                values: new object[] { new DateTime(2023, 8, 8, 16, 43, 4, 143, DateTimeKind.Local).AddTicks(4855), 2 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "PatientId" },
                values: new object[] { new DateTime(2023, 2, 8, 16, 43, 4, 143, DateTimeKind.Local).AddTicks(4861), 3 });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
                column: "PatientId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("6625a7bb-93ea-4bad-b228-a408be9725e9"),
                column: "PatientId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
                column: "PatientId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "PatientId" },
                values: new object[] { new DateTime(2024, 1, 19, 16, 35, 26, 612, DateTimeKind.Local).AddTicks(3277), null });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "PatientId" },
                values: new object[] { new DateTime(2023, 8, 8, 16, 35, 26, 612, DateTimeKind.Local).AddTicks(3330), null });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "PatientId" },
                values: new object[] { new DateTime(2023, 2, 8, 16, 35, 26, 612, DateTimeKind.Local).AddTicks(3337), null });

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("10d3246c-45e8-4492-9f3e-a1f1d3c4e033"),
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("6625a7bb-93ea-4bad-b228-a408be9725e9"),
                column: "PatientId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Owners",
                keyColumn: "Id",
                keyValue: new Guid("e90872c9-5b9b-412c-a5a5-ee871bbe9299"),
                column: "PatientId",
                value: null);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class FixStatusTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Status_StatusId",
                table: "Examinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Status",
                table: "Status");

            migrationBuilder.RenameTable(
                name: "Status",
                newName: "Statuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "CreatedOn", "CurrentCondition", "Diagnosis", "DoctorId", "Exit", "MedicalHistory", "NextExamination", "PatientId", "Reason", "Research", "SpecificCondition", "StatusId", "Surgery", "Therapy", "Weight" },
                values: new object[] { 1, new DateTime(2024, 2, 24, 10, 34, 55, 808, DateTimeKind.Utc).AddTicks(6736), null, null, new Guid("67d4e605-d264-48d5-44c9-08dc28f5b9f5"), null, null, null, 1, "Primary", null, null, 1, null, null, 12 });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "CreatedOn", "CurrentCondition", "Diagnosis", "DoctorId", "Exit", "MedicalHistory", "NextExamination", "PatientId", "Reason", "Research", "SpecificCondition", "StatusId", "Surgery", "Therapy", "Weight" },
                values: new object[] { 2, new DateTime(2024, 2, 24, 10, 34, 55, 808, DateTimeKind.Utc).AddTicks(6779), null, null, new Guid("67d4e605-d264-48d5-44c9-08dc28f5b9f5"), null, null, null, 2, "Secondary", null, null, 1, null, null, 10 });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "CreatedOn", "CurrentCondition", "Diagnosis", "DoctorId", "Exit", "MedicalHistory", "NextExamination", "PatientId", "Reason", "Research", "SpecificCondition", "StatusId", "Surgery", "Therapy", "Weight" },
                values: new object[] { 3, new DateTime(2024, 2, 24, 10, 34, 55, 808, DateTimeKind.Utc).AddTicks(6783), null, null, new Guid("67d4e605-d264-48d5-44c9-08dc28f5b9f5"), null, null, null, 3, "Primary", null, null, 1, null, null, 30 });

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Statuses_StatusId",
                table: "Examinations",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Statuses_StatusId",
                table: "Examinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Status",
                table: "Status",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Status_StatusId",
                table: "Examinations",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

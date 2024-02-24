using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class AddEntityStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Examinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "In Progress" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Done" });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Hospital" });

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_StatusId",
                table: "Examinations",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Status_StatusId",
                table: "Examinations",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Status_StatusId",
                table: "Examinations");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_StatusId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Examinations");

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "CreatedOn", "CurrentCondition", "Diagnosis", "DoctorId", "Exit", "MedicalHistory", "NextExamination", "PatientId", "Reason", "Research", "SpecificCondition", "Surgery", "Therapy", "Weight" },
                values: new object[] { 1, new DateTime(2024, 2, 23, 15, 48, 53, 402, DateTimeKind.Utc).AddTicks(3620), null, null, new Guid("67d4e605-d264-48d5-44c9-08dc28f5b9f5"), null, null, null, 1, "Primary", null, null, null, null, 12 });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "CreatedOn", "CurrentCondition", "Diagnosis", "DoctorId", "Exit", "MedicalHistory", "NextExamination", "PatientId", "Reason", "Research", "SpecificCondition", "Surgery", "Therapy", "Weight" },
                values: new object[] { 2, new DateTime(2024, 2, 23, 15, 48, 53, 402, DateTimeKind.Utc).AddTicks(3652), null, null, new Guid("67d4e605-d264-48d5-44c9-08dc28f5b9f5"), null, null, null, 2, "Secondary", null, null, null, null, 10 });

            migrationBuilder.InsertData(
                table: "Examinations",
                columns: new[] { "Id", "CreatedOn", "CurrentCondition", "Diagnosis", "DoctorId", "Exit", "MedicalHistory", "NextExamination", "PatientId", "Reason", "Research", "SpecificCondition", "Surgery", "Therapy", "Weight" },
                values: new object[] { 3, new DateTime(2024, 2, 23, 15, 48, 53, 402, DateTimeKind.Utc).AddTicks(3657), null, null, new Guid("67d4e605-d264-48d5-44c9-08dc28f5b9f5"), null, null, null, 3, "Primary", null, null, null, null, 30 });
        }
    }
}

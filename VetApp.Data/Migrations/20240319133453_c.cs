using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserPatient");

            migrationBuilder.DropTable(
                name: "PatientsUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a20e56ee-26d2-4767-8b91-de3b834c6b1f", "AQAAAAEAACcQAAAAELQctnSDAw9OkyJXVT4zeyRznylvqVe3MraeP6nuIaSqYiG2gSKZQHc4HvwNKgAV6Q==", "682AF017-E31E-487C-8C5F-49501A65E44B" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 13, 34, 52, 810, DateTimeKind.Utc).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 13, 34, 52, 810, DateTimeKind.Utc).AddTicks(4348));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 13, 34, 52, 810, DateTimeKind.Utc).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("c84db966-6f32-44af-8026-d142b1ea15b9"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 13, 34, 52, 810, DateTimeKind.Utc).AddTicks(4363));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserPatient",
                columns: table => new
                {
                    DoctorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserPatient", x => new { x.DoctorsId, x.PatientsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserPatient_AspNetUsers_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserPatient_Patients_PatientsId",
                        column: x => x.PatientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientsUsers",
                columns: table => new
                {
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsUsers", x => new { x.DoctorId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_PatientsUsers_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientsUsers_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "User Patints");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63398074-518b-447e-8f4f-d37f3167af04", "AQAAAAEAACcQAAAAEMFcOBN1zXPhFq+bEuNZh4NK9qYDoYiux5T1g5J6JVEdaLalij0kdVvxpHlflxIzgA==", "F125B44E-D966-4E9B-8F2F-14D1B12411FA" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 12, 51, 38, 590, DateTimeKind.Utc).AddTicks(1400));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 12, 51, 38, 590, DateTimeKind.Utc).AddTicks(1368));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 12, 51, 38, 590, DateTimeKind.Utc).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("c84db966-6f32-44af-8026-d142b1ea15b9"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 19, 12, 51, 38, 590, DateTimeKind.Utc).AddTicks(1407));

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserPatient_PatientsId",
                table: "ApplicationUserPatient",
                column: "PatientsId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientsUsers_PatientId",
                table: "PatientsUsers",
                column: "PatientId");
        }
    }
}

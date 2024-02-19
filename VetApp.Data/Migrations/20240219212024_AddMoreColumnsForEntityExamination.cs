using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class AddMoreColumnsForEntityExamination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Patients_PatientId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Examinations");

            migrationBuilder.RenameColumn(
                name: "MicroChip",
                table: "Patients",
                newName: "Microchip");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Examinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentCondition",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diagnosis",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exit",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalHistory",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextExamination",
                table: "Examinations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Research",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecificCondition",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surgery",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Therapy",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Examinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Examinations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "User" },
                values: new object[] { new DateTime(2024, 2, 19, 23, 20, 24, 234, DateTimeKind.Local).AddTicks(3733), "D-r Pesho Petrov" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "User" },
                values: new object[] { new DateTime(2024, 2, 19, 23, 20, 24, 234, DateTimeKind.Local).AddTicks(3791), "D-r Gosho Georgiev" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "User" },
                values: new object[] { new DateTime(2024, 2, 19, 23, 20, 24, 234, DateTimeKind.Local).AddTicks(3796), "D-r Dimitrichko Dimitrov" });

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Patients_PatientId",
                table: "Examinations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Patients_PatientId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "CurrentCondition",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Diagnosis",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Exit",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "MedicalHistory",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "NextExamination",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Research",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "SpecificCondition",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Surgery",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Therapy",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Examinations");

            migrationBuilder.RenameColumn(
                name: "Microchip",
                table: "Patients",
                newName: "MicroChip");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Examinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Examinations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Examinations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Description", "State" },
                values: new object[] { new DateTime(2024, 1, 19, 23, 41, 48, 487, DateTimeKind.Local).AddTicks(4552), "Пълна кръвна картина", "Primary" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Description", "State" },
                values: new object[] { new DateTime(2023, 8, 8, 23, 41, 48, 487, DateTimeKind.Local).AddTicks(4606), "Изследване за паразити", "Secondary" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Description", "State" },
                values: new object[] { new DateTime(2023, 2, 8, 23, 41, 48, 487, DateTimeKind.Local).AddTicks(4611), "Преглед за кожно заболяване", "Primary" });

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Patients_PatientId",
                table: "Examinations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}

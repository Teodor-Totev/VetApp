using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class AddDoctorIdColumnExamination : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientsUsers_AspNetUsers_UserId",
                table: "PatientsUsers");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Examinations");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "PatientsUsers",
                newName: "DoctorId");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Examinations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DoctorId",
                table: "Examinations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "DoctorId", "Reason", "Weight" },
                values: new object[] { new DateTime(2024, 2, 23, 15, 48, 53, 402, DateTimeKind.Utc).AddTicks(3620), new Guid("67D4E605-D264-48D5-44C9-08DC28F5B9F5"), "Primary", 12 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "DoctorId", "Reason", "Weight" },
                values: new object[] { new DateTime(2024, 2, 23, 15, 48, 53, 402, DateTimeKind.Utc).AddTicks(3652), new Guid("67D4E605-D264-48D5-44C9-08DC28F5B9F5"), "Secondary", 10 });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "DoctorId", "Reason", "Weight" },
                values: new object[] { new DateTime(2024, 2, 23, 15, 48, 53, 402, DateTimeKind.Utc).AddTicks(3657), new Guid("67D4E605-D264-48D5-44C9-08DC28F5B9F5"), "Primary", 30 });

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_AspNetUsers_DoctorId",
                table: "Examinations",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsUsers_AspNetUsers_DoctorId",
                table: "PatientsUsers",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_AspNetUsers_DoctorId",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientsUsers_AspNetUsers_DoctorId",
                table: "PatientsUsers");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_DoctorId",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Examinations");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "PatientsUsers",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "Weight",
                table: "Examinations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Reason",
                table: "Examinations",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Examinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "Reason", "User", "Weight" },
                values: new object[] { new DateTime(2024, 2, 19, 23, 20, 24, 234, DateTimeKind.Local).AddTicks(3733), null, "D-r Pesho Petrov", null });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "Reason", "User", "Weight" },
                values: new object[] { new DateTime(2024, 2, 19, 23, 20, 24, 234, DateTimeKind.Local).AddTicks(3791), null, "D-r Gosho Georgiev", null });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "Reason", "User", "Weight" },
                values: new object[] { new DateTime(2024, 2, 19, 23, 20, 24, 234, DateTimeKind.Local).AddTicks(3796), null, "D-r Dimitrichko Dimitrov", null });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientsUsers_AspNetUsers_UserId",
                table: "PatientsUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

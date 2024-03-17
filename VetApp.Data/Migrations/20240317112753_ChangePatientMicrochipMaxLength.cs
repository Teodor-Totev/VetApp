using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class ChangePatientMicrochipMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Microchip",
                table: "Patients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15d11bd2-72a7-47b4-ac38-16bf8de37246", "AQAAAAEAACcQAAAAEBAp1rc37M0Pdpw6Mim9j47dZuy+2sWak/CvXviltg82H1iRRQm3Sc3NwbA+RHLiSg==", "A38945F5-0E87-4231-9C47-5B66C91525C0" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("c84db966-6f32-44af-8026-d142b1ea15b9"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 17, 11, 27, 52, 879, DateTimeKind.Utc).AddTicks(9526));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Microchip",
                table: "Patients",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ec21a55-ef2d-46da-bf20-7534c0b8cd76", "AQAAAAEAACcQAAAAEBU2f47AGEGQeDzxOQpVkIzgFj5mojq2Ipds1m4Ae+I/zZstYbcmm2znm/Q6pA9Kiw==", "8C475C31-F768-4E3D-B9A4-E3EACF1F82B3" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 13, 11, 59, 33, 307, DateTimeKind.Utc).AddTicks(9930));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 13, 11, 59, 33, 307, DateTimeKind.Utc).AddTicks(9907));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 13, 11, 59, 33, 307, DateTimeKind.Utc).AddTicks(9945));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("c84db966-6f32-44af-8026-d142b1ea15b9"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 13, 11, 59, 33, 307, DateTimeKind.Utc).AddTicks(9938));
        }
    }
}

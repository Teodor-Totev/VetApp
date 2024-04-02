using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VetApp.Data.Migrations
{
    public partial class seedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d788818-9f8c-4332-b982-920b9a93e040", "AQAAAAEAACcQAAAAEOSPRLpn//5pZRGguvob3lVeEYzqOHoJlVf4g66dQ2natO4XYJ7Gk8UdDVmqYl7Gpg==", "B36D757A-3D14-4120-90A2-E096337C790B" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8df82639-d79b-405e-af30-b245f2224fab"), 0, "123 Main St Plovdiv", "a3009bfe-b941-4f70-8f18-7802278ce36a", "admin@gmail.com", false, "Great", "Admin", true, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAECx2KiNnUdCiS9I3nsGy5mX2p6SUehRLcfUvnw8z1zGddZq5lhUBHeaxz+8aNBzY3w==", null, false, "A21B8BE6-B522-4383-9A56-9D5386DEED94", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 13, 34, 20, 317, DateTimeKind.Utc).AddTicks(6804));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 13, 34, 20, 317, DateTimeKind.Utc).AddTicks(6793));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 13, 34, 20, 317, DateTimeKind.Utc).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("c84db966-6f32-44af-8026-d142b1ea15b9"),
                column: "CreatedOn",
                value: new DateTime(2024, 4, 2, 13, 34, 20, 317, DateTimeKind.Utc).AddTicks(6808));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8df82639-d79b-405e-af30-b245f2224fab"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("051ff0f3-4490-4676-ae7c-09cdea604ac1"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42550025-9b09-4936-be1f-9e80e2d021c8", "AQAAAAEAACcQAAAAEBWFHy8J2Z9gArbMy6JsfRjK9YEwJVCRasdH/SfFk7k4JP0FnFqPSQkI4kt0qALLzg==", "A9AB5816-CD1B-42E6-926F-EA9E4B92ADBA" });

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("917f60f0-485a-4cbc-a3d5-83bfc30015ed"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 22, 15, 46, 28, 236, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("a6be4500-3245-4ecc-a9f5-5b2af8baff97"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 22, 15, 46, 28, 236, DateTimeKind.Utc).AddTicks(9162));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("b05fb0d0-9e05-4c00-a9e7-d3f0600e566b"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 22, 15, 46, 28, 236, DateTimeKind.Utc).AddTicks(9219));

            migrationBuilder.UpdateData(
                table: "Examinations",
                keyColumn: "Id",
                keyValue: new Guid("c84db966-6f32-44af-8026-d142b1ea15b9"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 22, 15, 46, 28, 236, DateTimeKind.Utc).AddTicks(9213));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.Data.EFContext.Migrations
{
    public partial class UpdatingEditingSeedOfBlogPostEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "003a7539-d7ab-4924-bd5c-437ef27b419d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "c95985d2-0c9c-4b43-a59f-2decaa4a2e87");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33e30ac8-a39b-4979-90a9-9d999e514bd0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3f3e219c-ba76-4c3d-934e-ae904dd84d84", "AQAAAAEAACcQAAAAEBguXuNql6S2pUXokAtwltOcuuhMRQ8v7q1PpO59mE3CIqS31vmNIyXf9AGGDK/Cww==", "c5f59bd1-5fdc-440e-ac38-156e2d1bd0e0" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 55, 53, 12, DateTimeKind.Local).AddTicks(715));

            migrationBuilder.UpdateData(
                table: "BlogPostEditors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditorName" },
                values: new object[] { new DateTime(2019, 5, 20, 21, 55, 53, 96, DateTimeKind.Local).AddTicks(3841), "Admin1" });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 55, 53, 85, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 55, 53, 98, DateTimeKind.Local).AddTicks(8790));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 55, 53, 99, DateTimeKind.Local).AddTicks(1171));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f0a1f8e7-387c-4864-953d-54c5ac57d052");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "84514daf-91d6-4ee6-8acc-deceb26fc6f4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33e30ac8-a39b-4979-90a9-9d999e514bd0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "256ff7fa-fed1-4584-8597-739342eda6f3", "AQAAAAEAACcQAAAAEHCMtgtQV++srFlxg18qgmHOT0HOaef++n0X1OQUS+72oT6lD//p/k4P8IPVzIt9Yw==", "0bdb386c-9698-4c6e-9510-c5baca433bd3" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 45, 32, 973, DateTimeKind.Local).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "BlogPostEditors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "EditorName" },
                values: new object[] { new DateTime(2019, 5, 20, 21, 45, 32, 998, DateTimeKind.Local).AddTicks(795), null });

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 45, 32, 991, DateTimeKind.Local).AddTicks(3720));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 45, 33, 2, DateTimeKind.Local).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 21, 45, 33, 2, DateTimeKind.Local).AddTicks(8329));
        }
    }
}

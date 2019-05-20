using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.Data.EFContext.Migrations
{
    public partial class SeedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "68b4d47d-f571-49d0-8e0a-1975ed307560");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4e11f7a5-a0fc-4e5c-8f88-e8ec28e3fc48");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33e30ac8-a39b-4979-90a9-9d999e514bd0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45bd6513-d020-4aac-9465-127f8a9aaf18", "AQAAAAEAACcQAAAAEDd7yDevgK2VjCB3wnAeqlAa0wjbXudPIZrNl1a8ZpqNVJ3ffjlGzgrF+DEDQwPH7A==", "c06fe3d6-1c0b-4126-836f-a3b768869b7c" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 8, 54, 59, 981, DateTimeKind.Local).AddTicks(2474));

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedBy", "CreatedOn", "DeletedOn", "IsDeleted", "LastEditedBy", "ModifiedOn", "Title" },
                values: new object[] { 1, 1, "This is a simple post content.", "Admin 1", new DateTime(2019, 5, 20, 8, 54, 59, 989, DateTimeKind.Local).AddTicks(6567), null, false, "Admin 1", null, "Demo Post" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 5, 20, 8, 54, 59, 991, DateTimeKind.Local).AddTicks(3367), null, false, null, "First Tag" },
                    { 2, new DateTime(2019, 5, 20, 8, 54, 59, 992, DateTimeKind.Local).AddTicks(8644), null, false, null, "Second Tag" }
                });

            migrationBuilder.InsertData(
                table: "BlogPostTags",
                columns: new[] { "BlogPostId", "TagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "BlogPostTags",
                columns: new[] { "BlogPostId", "TagId" },
                values: new object[] { 1, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BlogPostTags",
                keyColumns: new[] { "BlogPostId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "BlogPostTags",
                keyColumns: new[] { "BlogPostId", "TagId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f6c67902-eaf5-4e44-8aa3-d9b3f8a6f32d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "4622e86d-8359-4987-8b5f-bf3be0dea10b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33e30ac8-a39b-4979-90a9-9d999e514bd0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1aab1bac-7921-4e97-a001-b1ca4e798476", "AQAAAAEAACcQAAAAELc6RPvdOT04nH9gQKZnXnpypKVpcq+WUYSoJNcEn+3YhdHO0HIM1S/QLTkjzGCGIQ==", "7d534a67-b0bb-473a-840b-53ea9145cd0e" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 8, 41, 40, 213, DateTimeKind.Local).AddTicks(6865));
        }
    }
}

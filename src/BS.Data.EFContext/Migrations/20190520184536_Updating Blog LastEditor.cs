using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BS.Data.EFContext.Migrations
{
    public partial class UpdatingBlogLastEditor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastEditedBy",
                table: "BlogPosts");

            migrationBuilder.CreateTable(
                name: "BlogPostEditors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EditorName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    BlogPostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostEditors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostEditors_BlogPosts_BlogPostId",
                        column: x => x.BlogPostId,
                        principalTable: "BlogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "BlogPostEditors",
                columns: new[] { "Id", "BlogPostId", "CreatedOn", "DeletedOn", "EditorName", "IsDeleted", "ModifiedOn" },
                values: new object[] { 1, 1, new DateTime(2019, 5, 20, 21, 45, 32, 998, DateTimeKind.Local).AddTicks(795), null, null, false, null });

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

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostEditors_BlogPostId",
                table: "BlogPostEditors",
                column: "BlogPostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostEditors");

            migrationBuilder.AddColumn<string>(
                name: "LastEditedBy",
                table: "BlogPosts",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "LastEditedBy" },
                values: new object[] { new DateTime(2019, 5, 20, 8, 54, 59, 989, DateTimeKind.Local).AddTicks(6567), "Admin 1" });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 8, 54, 59, 991, DateTimeKind.Local).AddTicks(3367));

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2019, 5, 20, 8, 54, 59, 992, DateTimeKind.Local).AddTicks(8644));
        }
    }
}

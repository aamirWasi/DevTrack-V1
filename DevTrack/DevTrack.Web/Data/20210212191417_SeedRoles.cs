using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.Web.Data
{
    public partial class SeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("647bd95b-115c-4b29-8078-e97919a5d530"), "b6150c18-0979-4ba1-92f7-f984db661661", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("93f86480-abc4-486d-9a4a-16c68e15d8dd"), "110df3f9-203f-4dd6-bbc7-e1a639978646", "Trainer", "TRAINER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e5ee7021-4a67-405f-8bfb-bf6bc996cf5b"), "8f089daf-1e3a-4e95-b507-97dd38390f36", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("647bd95b-115c-4b29-8078-e97919a5d530"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("93f86480-abc4-486d-9a4a-16c68e15d8dd"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e5ee7021-4a67-405f-8bfb-bf6bc996cf5b"));
        }
    }
}

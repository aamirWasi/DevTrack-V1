using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.Web.Data
{
    public partial class UserRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("36c7d5a3-04e8-4c2f-9eb4-254f27a71b0c"), "a3e0ade2-3d2a-4068-b589-6477062ed604", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0c8dd35c-c1b8-46e1-9ac7-1a5639d99ba0"), "f084d5a9-e09f-41bb-8308-ec5d63881392", "Trainer", "TRAINER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a66e7ff3-9ddf-4fe7-b360-e763a3bb7a16"), "c7696fc8-b8fc-47c0-ad3d-3e083694fc63", "Student", "STUDENT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0c8dd35c-c1b8-46e1-9ac7-1a5639d99ba0"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("36c7d5a3-04e8-4c2f-9eb4-254f27a71b0c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a66e7ff3-9ddf-4fe7-b360-e763a3bb7a16"));
        }
    }
}

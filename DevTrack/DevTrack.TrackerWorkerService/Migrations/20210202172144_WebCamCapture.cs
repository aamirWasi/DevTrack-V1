using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.TrackerWorkerService.Migrations
{
    public partial class WebCamCapture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebCamCapture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WebCamImagePath = table.Column<string>(nullable: true),
                    WebCamImageDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebCamCapture", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebCamCapture");
        }
    }
}

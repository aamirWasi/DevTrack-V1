using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.TrackerWorkerService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivePrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramName = table.Column<string>(nullable: true),
                    ProgramTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivePrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunningPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RunningApplications = table.Column<string>(nullable: true),
                    RunningApplicationsDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunningPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SnapshotImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilePath = table.Column<string>(nullable: true),
                    CaptureTime = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SnapshotImages", x => x.Id);
                });

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
                name: "ActivePrograms");

            migrationBuilder.DropTable(
                name: "RunningPrograms");

            migrationBuilder.DropTable(
                name: "SnapshotImages");

            migrationBuilder.DropTable(
                name: "WebCamCapture");
        }
    }
}

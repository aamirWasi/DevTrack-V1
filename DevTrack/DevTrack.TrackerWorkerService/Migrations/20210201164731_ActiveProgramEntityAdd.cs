using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.TrackerWorkerService.Migrations
{
    public partial class ActiveProgramEntityAdd : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivePrograms");
        }
    }
}

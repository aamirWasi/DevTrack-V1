using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.TrackerWorkerService.Migrations
{
    public partial class MouseTablenitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalClicks = table.Column<int>(nullable: false),
                    LeftButtonClick = table.Column<int>(nullable: false),
                    LeftButtonDoubleClick = table.Column<int>(nullable: false),
                    MiddleButtonClick = table.Column<int>(nullable: false),
                    MiddleButtonDoubleClick = table.Column<int>(nullable: false),
                    MouseWheel = table.Column<int>(nullable: false),
                    RightButtonClick = table.Column<int>(nullable: false),
                    RightButtonDoubleClick = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mouses");
        }
    }
}

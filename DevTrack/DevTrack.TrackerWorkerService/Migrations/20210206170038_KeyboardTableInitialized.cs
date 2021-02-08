using Microsoft.EntityFrameworkCore.Migrations;

namespace DevTrack.TrackerWorkerService.Migrations
{
    public partial class KeyboardTableInitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalKeyHits = table.Column<int>(nullable: false),
                    Escape = table.Column<int>(nullable: false),
                    F1 = table.Column<int>(nullable: false),
                    F2 = table.Column<int>(nullable: false),
                    F3 = table.Column<int>(nullable: false),
                    F4 = table.Column<int>(nullable: false),
                    F5 = table.Column<int>(nullable: false),
                    F6 = table.Column<int>(nullable: false),
                    F7 = table.Column<int>(nullable: false),
                    F8 = table.Column<int>(nullable: false),
                    F9 = table.Column<int>(nullable: false),
                    F10 = table.Column<int>(nullable: false),
                    F11 = table.Column<int>(nullable: false),
                    F12 = table.Column<int>(nullable: false),
                    NumPad0 = table.Column<int>(nullable: false),
                    NumPad1 = table.Column<int>(nullable: false),
                    NumPad2 = table.Column<int>(nullable: false),
                    NumPad3 = table.Column<int>(nullable: false),
                    NumPad4 = table.Column<int>(nullable: false),
                    NumPad5 = table.Column<int>(nullable: false),
                    NumPad6 = table.Column<int>(nullable: false),
                    NumPad7 = table.Column<int>(nullable: false),
                    NumPad8 = table.Column<int>(nullable: false),
                    NumPad9 = table.Column<int>(nullable: false),
                    Decimal = table.Column<int>(nullable: false),
                    Add = table.Column<int>(nullable: false),
                    Subtract = table.Column<int>(nullable: false),
                    Multiply = table.Column<int>(nullable: false),
                    Divide = table.Column<int>(nullable: false),
                    NumLock = table.Column<int>(nullable: false),
                    Oemtilde = table.Column<int>(nullable: false),
                    D1 = table.Column<int>(nullable: false),
                    D2 = table.Column<int>(nullable: false),
                    D3 = table.Column<int>(nullable: false),
                    D4 = table.Column<int>(nullable: false),
                    D5 = table.Column<int>(nullable: false),
                    D6 = table.Column<int>(nullable: false),
                    D7 = table.Column<int>(nullable: false),
                    D8 = table.Column<int>(nullable: false),
                    D9 = table.Column<int>(nullable: false),
                    D0 = table.Column<int>(nullable: false),
                    OemMinus = table.Column<int>(nullable: false),
                    Oemplus = table.Column<int>(nullable: false),
                    Oem5 = table.Column<int>(nullable: false),
                    Back = table.Column<int>(nullable: false),
                    Tab = table.Column<int>(nullable: false),
                    OemOpenBrackets = table.Column<int>(nullable: false),
                    Oem6 = table.Column<int>(nullable: false),
                    Capital = table.Column<int>(nullable: false),
                    Oem1 = table.Column<int>(nullable: false),
                    Oem7 = table.Column<int>(nullable: false),
                    Enter = table.Column<int>(nullable: false),
                    LShiftKey = table.Column<int>(nullable: false),
                    Oemcomma = table.Column<int>(nullable: false),
                    OemPeriod = table.Column<int>(nullable: false),
                    OemQuestion = table.Column<int>(nullable: false),
                    RShiftKey = table.Column<int>(nullable: false),
                    LControlKey = table.Column<int>(nullable: false),
                    LWin = table.Column<int>(nullable: false),
                    Space = table.Column<int>(nullable: false),
                    RWin = table.Column<int>(nullable: false),
                    Apps = table.Column<int>(nullable: false),
                    RControlKey = table.Column<int>(nullable: false),
                    PrintScreen = table.Column<int>(nullable: false),
                    Scroll = table.Column<int>(nullable: false),
                    Pause = table.Column<int>(nullable: false),
                    Insert = table.Column<int>(nullable: false),
                    Home = table.Column<int>(nullable: false),
                    PageUp = table.Column<int>(nullable: false),
                    Delete = table.Column<int>(nullable: false),
                    End = table.Column<int>(nullable: false),
                    Next = table.Column<int>(nullable: false),
                    Left = table.Column<int>(nullable: false),
                    Up = table.Column<int>(nullable: false),
                    Right = table.Column<int>(nullable: false),
                    Down = table.Column<int>(nullable: false),
                    A = table.Column<int>(nullable: false),
                    B = table.Column<int>(nullable: false),
                    C = table.Column<int>(nullable: false),
                    D = table.Column<int>(nullable: false),
                    E = table.Column<int>(nullable: false),
                    F = table.Column<int>(nullable: false),
                    G = table.Column<int>(nullable: false),
                    H = table.Column<int>(nullable: false),
                    I = table.Column<int>(nullable: false),
                    J = table.Column<int>(nullable: false),
                    K = table.Column<int>(nullable: false),
                    L = table.Column<int>(nullable: false),
                    M = table.Column<int>(nullable: false),
                    N = table.Column<int>(nullable: false),
                    O = table.Column<int>(nullable: false),
                    P = table.Column<int>(nullable: false),
                    Q = table.Column<int>(nullable: false),
                    R = table.Column<int>(nullable: false),
                    S = table.Column<int>(nullable: false),
                    T = table.Column<int>(nullable: false),
                    U = table.Column<int>(nullable: false),
                    V = table.Column<int>(nullable: false),
                    W = table.Column<int>(nullable: false),
                    X = table.Column<int>(nullable: false),
                    Y = table.Column<int>(nullable: false),
                    Z = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Keyboards");
        }
    }
}

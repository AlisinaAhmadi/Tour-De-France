using Microsoft.EntityFrameworkCore.Migrations;

namespace Tour_De_France.Migrations
{
    public partial class Tour_De_France : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deltagere",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Mobil = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    VIP = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deltagere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Time = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    People = table.Column<int>(nullable: false),
                    Mobil = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Eid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "Musiktelte",
                columns: table => new
                {
                    Sid = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Band = table.Column<string>(nullable: false),
                    Drinks = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musiktelte", x => x.Sid);
                });

            migrationBuilder.CreateTable(
                name: "ParkingPlads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Free = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingPlads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spisetelte",
                columns: table => new
                {
                    Time = table.Column<int>(nullable: false),
                    Food = table.Column<string>(nullable: false),
                    Drinks = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spisetelte", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "Togafgange",
                columns: table => new
                {
                    Tid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArrivalK = table.Column<string>(nullable: true),
                    DepartureK = table.Column<string>(nullable: true),
                    ArrivalN = table.Column<string>(nullable: true),
                    DepartureN = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Togafgange", x => x.Tid);
                });

            migrationBuilder.CreateTable(
                name: "Tribuner",
                columns: table => new
                {
                    Tid = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribuner", x => x.Tid);
                });

            migrationBuilder.CreateTable(
                name: "VIPs",
                columns: table => new
                {
                    Titel = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPs", x => x.Titel);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deltagere");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Musiktelte");

            migrationBuilder.DropTable(
                name: "ParkingPlads");

            migrationBuilder.DropTable(
                name: "Spisetelte");

            migrationBuilder.DropTable(
                name: "Togafgange");

            migrationBuilder.DropTable(
                name: "Tribuner");

            migrationBuilder.DropTable(
                name: "VIPs");
        }
    }
}

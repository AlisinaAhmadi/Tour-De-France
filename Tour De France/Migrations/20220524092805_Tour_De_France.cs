using System;
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
                    DeltagerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Mobil = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    VIP = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deltagere", x => x.DeltagerId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    Titel = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Musiktelte",
                columns: table => new
                {
                    Mid = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Band = table.Column<string>(nullable: false),
                    Drinks = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musiktelte", x => x.Mid);
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
                    Sid = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    Food = table.Column<string>(nullable: false),
                    Drinks = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spisetelte", x => x.Sid);
                });

            migrationBuilder.CreateTable(
                name: "Togafgange",
                columns: table => new
                {
                    TogafgangId = table.Column<int>(nullable: false),
                    Arrival = table.Column<DateTime>(nullable: false),
                    Departure = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Togafgange", x => x.TogafgangId);
                });

            migrationBuilder.CreateTable(
                name: "Tribuner",
                columns: table => new
                {
                    TribuneId = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tribuner", x => x.TribuneId);
                });

            migrationBuilder.CreateTable(
                name: "VIPs",
                columns: table => new
                {
                    VIPId = table.Column<int>(nullable: false),
                    Titel = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Champagne = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VIPs", x => x.VIPId);
                });

            migrationBuilder.CreateTable(
                name: "EventOrders",
                columns: table => new
                {
                    EventOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    DeltagerId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventOrders", x => x.EventOrderId);
                    table.ForeignKey(
                        name: "FK_EventOrders_Deltagere_DeltagerId",
                        column: x => x.DeltagerId,
                        principalTable: "Deltagere",
                        principalColumn: "DeltagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventOrders_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(nullable: false),
                    DeltagerId = table.Column<int>(nullable: false),
                    VIPId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Deltagere_DeltagerId",
                        column: x => x.DeltagerId,
                        principalTable: "Deltagere",
                        principalColumn: "DeltagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_VIPs_VIPId",
                        column: x => x.VIPId,
                        principalTable: "VIPs",
                        principalColumn: "VIPId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventOrders_DeltagerId",
                table: "EventOrders",
                column: "DeltagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EventOrders_EventId",
                table: "EventOrders",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeltagerId",
                table: "Orders",
                column: "DeltagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VIPId",
                table: "Orders",
                column: "VIPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventOrders");

            migrationBuilder.DropTable(
                name: "Musiktelte");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ParkingPlads");

            migrationBuilder.DropTable(
                name: "Spisetelte");

            migrationBuilder.DropTable(
                name: "Togafgange");

            migrationBuilder.DropTable(
                name: "Tribuner");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Deltagere");

            migrationBuilder.DropTable(
                name: "VIPs");
        }
    }
}

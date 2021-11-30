using Microsoft.EntityFrameworkCore.Migrations;

namespace AirLineModelClassLibrary.Migrations
{
    public partial class intialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airplanes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassengerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EconomySeatsOccupied = table.Column<int>(type: "int", nullable: false),
                    BusinessSeatsOccupied = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CabinMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CabinMembers_AirLines_WerkId",
                        column: x => x.WerkId,
                        principalTable: "AirLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pilots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WerkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pilots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pilots_AirLines_WerkId",
                        column: x => x.WerkId,
                        principalTable: "AirLines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Arrival = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Departure = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PilotId = table.Column<int>(type: "int", nullable: false),
                    CopilotId = table.Column<int>(type: "int", nullable: true),
                    AirplaneId = table.Column<int>(type: "int", nullable: false),
                    PassengerInfoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightNumber);
                    table.ForeignKey(
                        name: "FK_Flights_Airplanes_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplanes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_PassengerInfos_PassengerInfoId",
                        column: x => x.PassengerInfoId,
                        principalTable: "PassengerInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_CopilotId",
                        column: x => x.CopilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Pilots_PilotId",
                        column: x => x.PilotId,
                        principalTable: "Pilots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CabinMemberFlight",
                columns: table => new
                {
                    CabinMembersId = table.Column<int>(type: "int", nullable: false),
                    VluchtenFlightNumber = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinMemberFlight", x => new { x.CabinMembersId, x.VluchtenFlightNumber });
                    table.ForeignKey(
                        name: "FK_CabinMemberFlight_CabinMembers_CabinMembersId",
                        column: x => x.CabinMembersId,
                        principalTable: "CabinMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CabinMemberFlight_Flights_VluchtenFlightNumber",
                        column: x => x.VluchtenFlightNumber,
                        principalTable: "Flights",
                        principalColumn: "FlightNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CabinMemberFlight_VluchtenFlightNumber",
                table: "CabinMemberFlight",
                column: "VluchtenFlightNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CabinMembers_WerkId",
                table: "CabinMembers",
                column: "WerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirplaneId",
                table: "Flights",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CopilotId",
                table: "Flights",
                column: "CopilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PassengerInfoId",
                table: "Flights",
                column: "PassengerInfoId",
                unique: true,
                filter: "[PassengerInfoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PilotId",
                table: "Flights",
                column: "PilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Pilots_WerkId",
                table: "Pilots",
                column: "WerkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinMemberFlight");

            migrationBuilder.DropTable(
                name: "CabinMembers");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airplanes");

            migrationBuilder.DropTable(
                name: "PassengerInfos");

            migrationBuilder.DropTable(
                name: "Pilots");

            migrationBuilder.DropTable(
                name: "AirLines");
        }
    }
}

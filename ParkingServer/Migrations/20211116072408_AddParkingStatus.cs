using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingServer.Migrations
{
    public partial class AddParkingStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlte = table.Column<string>(maxLength: 10, nullable: false),
                    TimeOfArrival = table.Column<DateTime>(nullable: false),
                    TimeOfLeave = table.Column<DateTime>(nullable: true),
                    RegisteredVehicleId = table.Column<int>(nullable: true),
                    PriceRangeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingStatus_PriceRange_PriceRangeId",
                        column: x => x.PriceRangeId,
                        principalTable: "PriceRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingStatus_RegisteredVehicles_RegisteredVehicleId",
                        column: x => x.RegisteredVehicleId,
                        principalTable: "RegisteredVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingStatus_PriceRangeId",
                table: "ParkingStatus",
                column: "PriceRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingStatus_RegisteredVehicleId",
                table: "ParkingStatus",
                column: "RegisteredVehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingStatus");
        }
    }
}

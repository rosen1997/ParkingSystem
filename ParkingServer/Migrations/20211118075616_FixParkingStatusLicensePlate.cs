using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingServer.Migrations
{
    public partial class FixParkingStatusLicensePlate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlte",
                table: "ParkingStatus");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlate",
                table: "ParkingStatus",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LicensePlate",
                table: "ParkingStatus");

            migrationBuilder.AddColumn<string>(
                name: "LicensePlte",
                table: "ParkingStatus",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }
    }
}

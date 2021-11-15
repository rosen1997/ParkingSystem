using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingServer.Migrations
{
    public partial class CreateParkingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    AllSpaces = table.Column<int>(nullable: false),
                    FreeSpacesLeft = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingData", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ParkingData",
                columns: new[] { "Id", "AllSpaces", "Description", "FreeSpacesLeft", "Name" },
                values: new object[] { 1, 100, "My super duper cool parking.", 100, "Rosen's Parking" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingData");
        }
    }
}

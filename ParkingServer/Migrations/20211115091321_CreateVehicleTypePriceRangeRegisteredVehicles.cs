using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingServer.Migrations
{
    public partial class CreateVehicleTypePriceRangeRegisteredVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceRange",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisteredVehicles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(maxLength: 10, nullable: false),
                    PriceRangeId = table.Column<int>(nullable: false),
                    VehicleTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegisteredVehicles_PriceRange_PriceRangeId",
                        column: x => x.PriceRangeId,
                        principalTable: "PriceRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisteredVehicles_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PriceRange",
                columns: new[] { "Id", "Price" },
                values: new object[,]
                {
                    { 1, 0.0 },
                    { 2, 0.5 },
                    { 3, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "VehicleTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Ambulance" },
                    { 2, "Police Car" },
                    { 3, "Fire Truck" },
                    { 4, "Ambulance" },
                    { 5, "Company Car" },
                    { 6, "Paid Subscription" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredVehicles_LicensePlate",
                table: "RegisteredVehicles",
                column: "LicensePlate",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredVehicles_PriceRangeId",
                table: "RegisteredVehicles",
                column: "PriceRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredVehicles_VehicleTypeId",
                table: "RegisteredVehicles",
                column: "VehicleTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisteredVehicles");

            migrationBuilder.DropTable(
                name: "PriceRange");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}

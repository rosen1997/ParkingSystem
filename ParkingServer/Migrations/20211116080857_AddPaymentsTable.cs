using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkingServer.Migrations
{
    public partial class AddPaymentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(nullable: false),
                    PaymentAmount = table.Column<double>(nullable: false),
                    ParkingStatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_ParkingStatus_ParkingStatusId",
                        column: x => x.ParkingStatusId,
                        principalTable: "ParkingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ParkingStatusId",
                table: "Payments",
                column: "ParkingStatusId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}

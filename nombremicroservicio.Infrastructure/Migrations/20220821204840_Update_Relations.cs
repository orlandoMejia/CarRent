using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nombremicroservicio.Infrastructure.Migrations
{
    public partial class Update_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assigment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DriveWayId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assigment_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assigment_DriveWay_DriveWayId",
                        column: x => x.DriveWayId,
                        principalTable: "DriveWay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assigment_ClientId",
                table: "Assigment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Assigment_DriveWayId",
                table: "Assigment",
                column: "DriveWayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assigment");
        }
    }
}

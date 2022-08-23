using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nombremicroservicio.Infrastructure.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "text", nullable: true),
                    Names = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastNames = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    MaterialStatus = table.Column<string>(type: "text", nullable: true),
                    SpoceIdentification = table.Column<string>(type: "text", nullable: true),
                    SpoceName = table.Column<string>(type: "text", nullable: true),
                    CreditSubject = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriveWay",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveWay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Executive",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "text", nullable: false),
                    Names = table.Column<string>(type: "text", nullable: true),
                    LastNames = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Celphone = table.Column<string>(type: "text", nullable: true),
                    WorkPlace = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Place = table.Column<string>(type: "text", nullable: false),
                    Vehicle = table.Column<string>(type: "text", nullable: false),
                    Months = table.Column<string>(type: "text", nullable: false),
                    Quota = table.Column<string>(type: "text", nullable: false),
                    Entry = table.Column<string>(type: "text", nullable: false),
                    RequestType = table.Column<int>(type: "integer", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    SalesExecutiveId = table.Column<Guid>(type: "uuid", nullable: false),
                    Observation = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditRequest_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditRequest_Executive_SalesExecutiveId",
                        column: x => x.SalesExecutiveId,
                        principalTable: "Executive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_ClientId",
                table: "CreditRequest",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_SalesExecutiveId",
                table: "CreditRequest",
                column: "SalesExecutiveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "CreditRequest");

            migrationBuilder.DropTable(
                name: "DriveWay");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Executive");
        }
    }
}

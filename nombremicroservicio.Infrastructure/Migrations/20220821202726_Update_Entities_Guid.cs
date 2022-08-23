using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nombremicroservicio.Infrastructure.Migrations
{
    public partial class Update_Entities_Guid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_Brand_BrandId",
                table: "CreditRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_Client_ClientId",
                table: "CreditRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_DriveWay_DriveWayId",
                table: "CreditRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_Executive_ExecutiveId",
                table: "CreditRequest");

            migrationBuilder.DropIndex(
                name: "IX_CreditRequest_BrandId",
                table: "CreditRequest");

            migrationBuilder.DropIndex(
                name: "IX_CreditRequest_ClientId",
                table: "CreditRequest");

            migrationBuilder.DropIndex(
                name: "IX_CreditRequest_DriveWayId",
                table: "CreditRequest");

            migrationBuilder.DropIndex(
                name: "IX_CreditRequest_ExecutiveId",
                table: "CreditRequest");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "CreditRequest");

            migrationBuilder.RenameColumn(
                name: "ExecutiveId",
                table: "CreditRequest",
                newName: "IdExecutive");

            migrationBuilder.RenameColumn(
                name: "DriveWayId",
                table: "CreditRequest",
                newName: "IdDriveWay");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "CreditRequest",
                newName: "IdBrand");

            migrationBuilder.AddColumn<Guid>(
                name: "IdClient",
                table: "CreditRequest",
                type: "uuid",
                maxLength: 255,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdClient",
                table: "CreditRequest");

            migrationBuilder.RenameColumn(
                name: "IdExecutive",
                table: "CreditRequest",
                newName: "ExecutiveId");

            migrationBuilder.RenameColumn(
                name: "IdDriveWay",
                table: "CreditRequest",
                newName: "DriveWayId");

            migrationBuilder.RenameColumn(
                name: "IdBrand",
                table: "CreditRequest",
                newName: "ClientId");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "CreditRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_BrandId",
                table: "CreditRequest",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_ClientId",
                table: "CreditRequest",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_DriveWayId",
                table: "CreditRequest",
                column: "DriveWayId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_ExecutiveId",
                table: "CreditRequest",
                column: "ExecutiveId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditRequest_Brand_BrandId",
                table: "CreditRequest",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditRequest_Client_ClientId",
                table: "CreditRequest",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditRequest_DriveWay_DriveWayId",
                table: "CreditRequest",
                column: "DriveWayId",
                principalTable: "DriveWay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditRequest_Executive_ExecutiveId",
                table: "CreditRequest",
                column: "ExecutiveId",
                principalTable: "Executive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

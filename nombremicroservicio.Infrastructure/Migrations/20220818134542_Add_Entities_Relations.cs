using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nombremicroservicio.Infrastructure.Migrations
{
    public partial class Add_Entities_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_Executive_SalesExecutiveId",
                table: "CreditRequest");

            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "Executive");

            migrationBuilder.RenameColumn(
                name: "SalesExecutiveId",
                table: "CreditRequest",
                newName: "ExecutiveId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditRequest_SalesExecutiveId",
                table: "CreditRequest",
                newName: "IX_CreditRequest_ExecutiveId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Executive",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "Executive",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastNames",
                table: "Executive",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                table: "Executive",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Celphone",
                table: "Executive",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Executive",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Executive",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DriveWayId",
                table: "Executive",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DriveWay",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Vehicle",
                table: "CreditRequest",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Quota",
                table: "CreditRequest",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "CreditRequest",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "CreditRequest",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Months",
                table: "CreditRequest",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Entry",
                table: "CreditRequest",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "BrandId",
                table: "CreditRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DriveWayId",
                table: "CreditRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "SpoceName",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpoceIdentification",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialStatus",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastNames",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreditSubject",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Client",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Executive_DriveWayId",
                table: "Executive",
                column: "DriveWayId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_BrandId",
                table: "CreditRequest",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequest_DriveWayId",
                table: "CreditRequest",
                column: "DriveWayId");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditRequest_Brand_BrandId",
                table: "CreditRequest",
                column: "BrandId",
                principalTable: "Brand",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Executive_DriveWay_DriveWayId",
                table: "Executive",
                column: "DriveWayId",
                principalTable: "DriveWay",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_Brand_BrandId",
                table: "CreditRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_DriveWay_DriveWayId",
                table: "CreditRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditRequest_Executive_ExecutiveId",
                table: "CreditRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_Executive_DriveWay_DriveWayId",
                table: "Executive");

            migrationBuilder.DropIndex(
                name: "IX_Executive_DriveWayId",
                table: "Executive");

            migrationBuilder.DropIndex(
                name: "IX_CreditRequest_BrandId",
                table: "CreditRequest");

            migrationBuilder.DropIndex(
                name: "IX_CreditRequest_DriveWayId",
                table: "CreditRequest");

            migrationBuilder.DropColumn(
                name: "DriveWayId",
                table: "Executive");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "CreditRequest");

            migrationBuilder.DropColumn(
                name: "DriveWayId",
                table: "CreditRequest");

            migrationBuilder.RenameColumn(
                name: "ExecutiveId",
                table: "CreditRequest",
                newName: "SalesExecutiveId");

            migrationBuilder.RenameIndex(
                name: "IX_CreditRequest_ExecutiveId",
                table: "CreditRequest",
                newName: "IX_CreditRequest_SalesExecutiveId");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Executive",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "Executive",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "LastNames",
                table: "Executive",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                table: "Executive",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Celphone",
                table: "Executive",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Executive",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Executive",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "Executive",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "DriveWay",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Vehicle",
                table: "CreditRequest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Quota",
                table: "CreditRequest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "CreditRequest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Observation",
                table: "CreditRequest",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Months",
                table: "CreditRequest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Entry",
                table: "CreditRequest",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "SpoceName",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "SpoceIdentification",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Names",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialStatus",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "LastNames",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "IdentificationNumber",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "CreditSubject",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Client",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brand",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditRequest_Executive_SalesExecutiveId",
                table: "CreditRequest",
                column: "SalesExecutiveId",
                principalTable: "Executive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nombremicroservicio.Infrastructure.Migrations
{
    public partial class Update_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "DriveWay",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "DriveWay",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "DriveWay",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "DriveWay");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "DriveWay");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "DriveWay");
        }
    }
}

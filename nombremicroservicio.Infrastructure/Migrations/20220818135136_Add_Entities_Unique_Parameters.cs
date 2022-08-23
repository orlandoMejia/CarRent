using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nombremicroservicio.Infrastructure.Migrations
{
    public partial class Add_Entities_Unique_Parameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Executive_IdentificationNumber",
                table: "Executive",
                column: "IdentificationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DriveWay_Name",
                table: "DriveWay",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdentificationNumber",
                table: "Client",
                column: "IdentificationNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brand_Name",
                table: "Brand",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Executive_IdentificationNumber",
                table: "Executive");

            migrationBuilder.DropIndex(
                name: "IX_DriveWay_Name",
                table: "DriveWay");

            migrationBuilder.DropIndex(
                name: "IX_Client_IdentificationNumber",
                table: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Brand_Name",
                table: "Brand");
        }
    }
}

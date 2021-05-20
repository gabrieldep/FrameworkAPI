using Microsoft.EntityFrameworkCore.Migrations;

namespace FrameworkAPI.Migrations
{
    public partial class WithOneRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "UserAddressFKConstraint",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "AddressGeoFKConstraint",
                table: "Geos");

            migrationBuilder.DropIndex(
                name: "IX_Geos_IdAddress",
                table: "Geos");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_IdUser",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "IdAddress",
                table: "Geos");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Addresses");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdAddress",
                table: "Users",
                column: "IdAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IdGeo",
                table: "Addresses",
                column: "IdGeo");

            migrationBuilder.AddForeignKey(
                name: "AddressGeoFKConstraint",
                table: "Addresses",
                column: "IdGeo",
                principalTable: "Geos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "UserAddressFKConstraint",
                table: "Users",
                column: "IdAddress",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "AddressGeoFKConstraint",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "UserAddressFKConstraint",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_IdAddress",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_IdGeo",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "IdAddress",
                table: "Geos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUser",
                table: "Addresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Geos_IdAddress",
                table: "Geos",
                column: "IdAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_IdUser",
                table: "Addresses",
                column: "IdUser",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "UserAddressFKConstraint",
                table: "Addresses",
                column: "IdUser",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "AddressGeoFKConstraint",
                table: "Geos",
                column: "IdAddress",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

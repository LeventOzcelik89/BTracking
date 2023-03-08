using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTracking.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "AppCity",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity",
                column: "CountryId",
                principalTable: "AppCountry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "AppCity",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_AppCity_AppCountry_CountryId",
                table: "AppCity",
                column: "CountryId",
                principalTable: "AppCountry",
                principalColumn: "Id");
        }
    }
}

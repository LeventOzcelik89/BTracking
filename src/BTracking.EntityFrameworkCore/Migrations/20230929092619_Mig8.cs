using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTracking.EntityFrameworkCore
{
    /// <inheritdoc />
    public partial class Mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FinanceDailyDatas",
                newName: "cap");

            migrationBuilder.AddColumn<double>(
                name: "high",
                table: "FinanceDailyDatas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "low",
                table: "FinanceDailyDatas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "now",
                table: "FinanceDailyDatas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "open",
                table: "FinanceDailyDatas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "high",
                table: "FinanceDailyDatas");

            migrationBuilder.DropColumn(
                name: "low",
                table: "FinanceDailyDatas");

            migrationBuilder.DropColumn(
                name: "now",
                table: "FinanceDailyDatas");

            migrationBuilder.DropColumn(
                name: "open",
                table: "FinanceDailyDatas");

            migrationBuilder.RenameColumn(
                name: "cap",
                table: "FinanceDailyDatas",
                newName: "Name");
        }
    }
}

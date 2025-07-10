using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class ForecastDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyParkSales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GeneralAdmission = table.Column<int>(type: "int", nullable: false),
                    ExtendedHour = table.Column<int>(type: "int", nullable: false),
                    PWDGeneralAdmission = table.Column<int>(type: "int", nullable: false),
                    EarlyJump = table.Column<int>(type: "int", nullable: false),
                    OverallPaxQty = table.Column<int>(type: "int", nullable: false),
                    OverallPaxAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyParkSales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForecastedData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PredictedVisitors = table.Column<int>(type: "int", nullable: false),
                    PredictedSales = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForecastedData", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyParkSales");

            migrationBuilder.DropTable(
                name: "ForecastedData");
        }
    }
}

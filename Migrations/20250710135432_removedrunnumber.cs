using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class removedrunnumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RunNumber",
                table: "DailyParkSales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RunNumber",
                table: "DailyParkSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 1,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 2,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 3,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 4,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 5,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 6,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 7,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 8,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 9,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 10,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 11,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 12,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 13,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 14,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 15,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 16,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 17,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 18,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 19,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 20,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 21,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 22,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 23,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 24,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 25,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 26,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 27,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 28,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 29,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 30,
                column: "RunNumber",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 31,
                column: "RunNumber",
                value: 0);
        }
    }
}

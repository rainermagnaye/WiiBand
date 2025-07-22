using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class addedtenhourandtwentyhourmultipassmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TenHourMultipass",
                table: "DailyParkSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TwentyHourMultipass",
                table: "DailyParkSales",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });

            migrationBuilder.UpdateData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "TenHourMultipass", "TwentyHourMultipass" },
                values: new object[] { 0, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenHourMultipass",
                table: "DailyParkSales");

            migrationBuilder.DropColumn(
                name: "TwentyHourMultipass",
                table: "DailyParkSales");
        }
    }
}

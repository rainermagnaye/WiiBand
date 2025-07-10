using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class seedDailyParkSales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DailyParkSales",
                columns: new[] { "Id", "Date", "DayOfWeek", "EarlyJump", "ExtendedHour", "GeneralAdmission", "OverallPaxAmount", "OverallPaxQty", "PWDGeneralAdmission" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday", 8, 25, 120, 15900m, 159, 6 },
                    { 2, new DateTime(2022, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saturday", 10, 30, 160, 20700m, 207, 7 },
                    { 3, new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunday", 9, 28, 150, 19300m, 193, 6 },
                    { 4, new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monday", 6, 20, 110, 14100m, 141, 5 },
                    { 5, new DateTime(2022, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", 5, 18, 105, 13300m, 133, 5 },
                    { 6, new DateTime(2022, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wednesday", 6, 19, 108, 13700m, 137, 4 },
                    { 7, new DateTime(2022, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thursday", 6, 20, 112, 14300m, 143, 5 },
                    { 8, new DateTime(2022, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday", 8, 23, 125, 16200m, 162, 6 },
                    { 9, new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saturday", 10, 31, 165, 21300m, 213, 7 },
                    { 10, new DateTime(2022, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunday", 9, 29, 155, 19900m, 199, 6 },
                    { 11, new DateTime(2022, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monday", 7, 21, 115, 14800m, 148, 5 },
                    { 12, new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", 6, 19, 110, 14000m, 140, 5 },
                    { 13, new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wednesday", 6, 20, 113, 14400m, 144, 5 },
                    { 14, new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thursday", 6, 21, 116, 14800m, 148, 5 },
                    { 15, new DateTime(2022, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday", 8, 24, 128, 16600m, 166, 6 },
                    { 16, new DateTime(2022, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saturday", 10, 32, 170, 21900m, 219, 7 },
                    { 17, new DateTime(2022, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunday", 9, 30, 158, 20300m, 203, 6 },
                    { 18, new DateTime(2022, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monday", 7, 21, 117, 15000m, 150, 5 },
                    { 19, new DateTime(2022, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", 6, 19, 112, 14200m, 142, 5 },
                    { 20, new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wednesday", 6, 20, 115, 14600m, 146, 5 },
                    { 21, new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thursday", 6, 21, 118, 15000m, 150, 5 },
                    { 22, new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday", 8, 25, 130, 16900m, 169, 6 },
                    { 23, new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saturday", 10, 33, 172, 22200m, 222, 7 },
                    { 24, new DateTime(2022, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunday", 9, 31, 160, 20600m, 206, 6 },
                    { 25, new DateTime(2022, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Monday", 7, 22, 120, 15400m, 154, 5 },
                    { 26, new DateTime(2022, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuesday", 6, 20, 114, 14500m, 145, 5 },
                    { 27, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wednesday", 6, 21, 117, 14900m, 149, 5 },
                    { 28, new DateTime(2022, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thursday", 6, 22, 120, 15300m, 153, 5 },
                    { 29, new DateTime(2022, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Friday", 8, 26, 132, 17200m, 172, 6 },
                    { 30, new DateTime(2022, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saturday", 10, 34, 175, 22600m, 226, 7 },
                    { 31, new DateTime(2022, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sunday", 9, 32, 162, 20900m, 209, 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DailyParkSales",
                keyColumn: "Id",
                keyValue: 31);
        }
    }
}

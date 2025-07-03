using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class wiibandmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RfidBands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScannerLoc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfidBands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RfidMonitorSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WiiBandTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WiiBandIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfidMonitorSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RfidMonitorSessions_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RfidScanLogs",
                columns: table => new
                {
                    TagId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RfidScanLogs", x => x.TagId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RfidMonitorSessions_TransactionId",
                table: "RfidMonitorSessions",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RfidBands");

            migrationBuilder.DropTable(
                name: "RfidMonitorSessions");

            migrationBuilder.DropTable(
                name: "RfidScanLogs");
        }
    }
}

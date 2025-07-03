using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class editedwiibanddbname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RfidMonitorSessions_Transactions_TransactionId",
                table: "RfidMonitorSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidScanLogs",
                table: "RfidScanLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidMonitorSessions",
                table: "RfidMonitorSessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RfidBands",
                table: "RfidBands");

            migrationBuilder.RenameTable(
                name: "RfidScanLogs",
                newName: "WiiBandMaster");

            migrationBuilder.RenameTable(
                name: "RfidMonitorSessions",
                newName: "WiiBandMonitor");

            migrationBuilder.RenameTable(
                name: "RfidBands",
                newName: "WiiBandTag");

            migrationBuilder.RenameIndex(
                name: "IX_RfidMonitorSessions_TransactionId",
                table: "WiiBandMonitor",
                newName: "IX_WiiBandMonitor_TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WiiBandMaster",
                table: "WiiBandMaster",
                column: "TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WiiBandMonitor",
                table: "WiiBandMonitor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WiiBandTag",
                table: "WiiBandTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WiiBandMonitor_Transactions_TransactionId",
                table: "WiiBandMonitor",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WiiBandMonitor_Transactions_TransactionId",
                table: "WiiBandMonitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WiiBandTag",
                table: "WiiBandTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WiiBandMonitor",
                table: "WiiBandMonitor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WiiBandMaster",
                table: "WiiBandMaster");

            migrationBuilder.RenameTable(
                name: "WiiBandTag",
                newName: "RfidBands");

            migrationBuilder.RenameTable(
                name: "WiiBandMonitor",
                newName: "RfidMonitorSessions");

            migrationBuilder.RenameTable(
                name: "WiiBandMaster",
                newName: "RfidScanLogs");

            migrationBuilder.RenameIndex(
                name: "IX_WiiBandMonitor_TransactionId",
                table: "RfidMonitorSessions",
                newName: "IX_RfidMonitorSessions_TransactionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidBands",
                table: "RfidBands",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidMonitorSessions",
                table: "RfidMonitorSessions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RfidScanLogs",
                table: "RfidScanLogs",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_RfidMonitorSessions_Transactions_TransactionId",
                table: "RfidMonitorSessions",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }
    }
}

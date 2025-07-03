using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchtoTransactionandSummaryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "Summaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Branch",
                table: "Summaries");
        }
    }
}

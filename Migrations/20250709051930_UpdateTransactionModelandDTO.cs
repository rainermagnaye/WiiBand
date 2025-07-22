using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTransactionModelandDTO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscounted",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "Discounted",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discounted",
                table: "Transactions");

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscounted",
                table: "Transactions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

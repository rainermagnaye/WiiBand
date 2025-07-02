using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace app_example.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EInvitation",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ElecFoodCart",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "FoodCart",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "GameCoach",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MelonaIC",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PartyArea",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PartyDecorations",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PartyDecorationsEnabled",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PartyEquipCD",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartyEquipUtils",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PartyEquipment",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PartyGuest",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PartyHours",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Socks",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrampolineGames",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "WaterBottle",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EInvitation",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ElecFoodCart",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FoodCart",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "GameCoach",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "MelonaIC",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyArea",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyDecorations",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyDecorationsEnabled",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyEquipCD",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyEquipUtils",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyEquipment",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyGuest",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PartyHours",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Socks",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TrampolineGames",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "WaterBottle",
                table: "Events");
        }
    }
}

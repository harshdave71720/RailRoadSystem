using Microsoft.EntityFrameworkCore.Migrations;

namespace RailRoad.DataPersistenct.EFCore.Migrations
{
    public partial class AddedNewFieldsToTripRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "DISTANCE",
                table: "TRIPSRECORD",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "EXCAVATION_DONE",
                table: "TRIPSRECORD",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LNT_DONE",
                table: "TRIPSRECORD",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DISTANCE",
                table: "TRIPSRECORD");

            migrationBuilder.DropColumn(
                name: "EXCAVATION_DONE",
                table: "TRIPSRECORD");

            migrationBuilder.DropColumn(
                name: "LNT_DONE",
                table: "TRIPSRECORD");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace RailRoad.DataPersistenct.EFCore.Migrations
{
    public partial class AddedChainageToTripsRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CHAINAGE",
                table: "TRIPSRECORD",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CHAINAGE",
                table: "TRIPSRECORD");
        }
    }
}

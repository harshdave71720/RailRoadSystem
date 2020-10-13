using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace RailRoad.DataPersistenct.EFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TRIPCHARGES",
                columns: table => new
                {
                    TRIPCHARGES_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EXCAVATION_CHARGE = table.Column<double>(nullable: false),
                    LNT_BASIC_CHARGE = table.Column<double>(nullable: false),
                    LNT_LEADING_CHARGE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRIPCHARGES", x => x.TRIPCHARGES_ID);
                });

            migrationBuilder.CreateTable(
                name: "SITE",
                columns: table => new
                {
                    SITE_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DEF_TRUCK_CAPACITY = table.Column<double>(nullable: false),
                    DISTANCE = table.Column<int>(nullable: false),
                    TRIPCHARGES_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SITE", x => x.SITE_ID);
                    table.ForeignKey(
                        name: "FK_SITE_TRIPCHARGES_TRIPCHARGES_ID",
                        column: x => x.TRIPCHARGES_ID,
                        principalTable: "TRIPCHARGES",
                        principalColumn: "TRIPCHARGES_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TRIPSRECORD",
                columns: table => new
                {
                    TRIPSRECORD_ID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TRIPS_DATE = table.Column<DateTime>(nullable: false),
                    TRIPS_COUNT = table.Column<int>(nullable: false),
                    TRUCK_CAPACITY = table.Column<double>(nullable: false),
                    DIESEL_QUANTITY = table.Column<double>(nullable: false),
                    DIESEL_PRICE = table.Column<double>(nullable: false),
                    SITE_ID = table.Column<int>(nullable: false),
                    TRIPCHARGES = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRIPSRECORD", x => x.TRIPSRECORD_ID);
                    table.ForeignKey(
                        name: "FK_TRIPSRECORD_SITE_SITE_ID",
                        column: x => x.SITE_ID,
                        principalTable: "SITE",
                        principalColumn: "SITE_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TRIPSRECORD_TRIPCHARGES_TRIPCHARGES",
                        column: x => x.TRIPCHARGES,
                        principalTable: "TRIPCHARGES",
                        principalColumn: "TRIPCHARGES_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SITE_TRIPCHARGES_ID",
                table: "SITE",
                column: "TRIPCHARGES_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRIPSRECORD_SITE_ID",
                table: "TRIPSRECORD",
                column: "SITE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRIPSRECORD_TRIPCHARGES",
                table: "TRIPSRECORD",
                column: "TRIPCHARGES");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TRIPSRECORD");

            migrationBuilder.DropTable(
                name: "SITE");

            migrationBuilder.DropTable(
                name: "TRIPCHARGES");
        }
    }
}

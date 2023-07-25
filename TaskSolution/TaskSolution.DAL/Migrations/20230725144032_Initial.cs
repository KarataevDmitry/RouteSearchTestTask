using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskSolution.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TravelRouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StartDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalDateTimeUTC = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeToLive = table.Column<long>(type: "bigint", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelRoutes_TravelPoints_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "TravelPoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TravelRoutes_TravelPoints_StartPointId",
                        column: x => x.StartPointId,
                        principalTable: "TravelPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelRoutes_EndPointId",
                table: "TravelRoutes",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelRoutes_StartPointId",
                table: "TravelRoutes",
                column: "StartPointId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelRoutes");

            migrationBuilder.DropTable(
                name: "TravelPoints");
        }
    }
}

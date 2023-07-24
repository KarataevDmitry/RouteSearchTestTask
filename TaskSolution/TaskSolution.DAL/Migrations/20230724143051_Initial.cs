using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.InsertData(
                table: "TravelPoints",
                columns: new[] { "Id", "Name", "TravelRouteId" },
                values: new object[,]
                {
                    { new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"), "San-Francisco", new Guid("b6fda7de-e180-47d0-a49b-6a5013150280") },
                    { new Guid("72bc2a1d-d029-492d-a008-0c0e2540b7c4"), "Washington", new Guid("674968a2-8684-48ac-a8da-23a230dc9d87") },
                    { new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"), "Alabama", new Guid("b6fda7de-e180-47d0-a49b-6a5013150280") },
                    { new Guid("d7a64d76-2ba3-42a1-b412-96fc89bec6a4"), "Ohaio", new Guid("b6fda7de-e180-47d0-a49b-6a5013150280") }
                });

            migrationBuilder.InsertData(
                table: "TravelRoutes",
                columns: new[] { "Id", "ArrivalDateTimeUTC", "Cost", "EndPointId", "StartDateTimeUTC", "StartPointId", "TimeToLive" },
                values: new object[,]
                {
                    { new Guid("571de9b2-a818-403a-a2bb-cea966971456"), new DateTime(2023, 2, 15, 2, 0, 0, 0, DateTimeKind.Utc), 25, new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"), new DateTime(2023, 2, 15, 4, 0, 0, 0, DateTimeKind.Utc), new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"), 108000000000L },
                    { new Guid("7f85b28d-9f8b-4a0a-9b15-0c046995d3fa"), new DateTime(2023, 2, 15, 2, 0, 0, 0, DateTimeKind.Utc), 70, new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"), new DateTime(2023, 2, 15, 4, 0, 0, 0, DateTimeKind.Utc), new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"), 18000000000L },
                    { new Guid("a70eeb33-1be3-48b2-960f-11f57b1e3084"), new DateTime(2023, 2, 15, 2, 0, 0, 0, DateTimeKind.Utc), 29, new Guid("674968a2-8684-48ac-a8da-23a230dc9d87"), new DateTime(2023, 2, 15, 4, 0, 0, 0, DateTimeKind.Utc), new Guid("b6fda7de-e180-47d0-a49b-6a5013150280"), 72000000000L }
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

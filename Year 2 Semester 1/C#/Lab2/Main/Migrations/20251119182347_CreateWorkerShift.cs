using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class CreateWorkerShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_Ticket_Id",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_EventBlocks_Team_Id",
                table: "EventBlocks");

            migrationBuilder.CreateTable(
                name: "WorkerShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starts_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ends_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Worker_Id = table.Column<int>(type: "int", nullable: false),
                    Zone_Activation_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkerShifts_Workers_Worker_Id",
                        column: x => x.Worker_Id,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkerShifts_ZoneActivations_Zone_Activation_Id",
                        column: x => x.Zone_Activation_Id,
                        principalTable: "ZoneActivations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_Ticket_Id",
                table: "TeamMembers",
                column: "Ticket_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventBlocks_Team_Id",
                table: "EventBlocks",
                column: "Team_Id",
                unique: true,
                filter: "[Team_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerShifts_Worker_Id",
                table: "WorkerShifts",
                column: "Worker_Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkerShifts_Zone_Activation_Id",
                table: "WorkerShifts",
                column: "Zone_Activation_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkerShifts");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_Ticket_Id",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_EventBlocks_Team_Id",
                table: "EventBlocks");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_Ticket_Id",
                table: "TeamMembers",
                column: "Ticket_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EventBlocks_Team_Id",
                table: "EventBlocks",
                column: "Team_Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class CreateVolunteerShifts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VolunteersShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starts_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ends_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Volunteer_Id = table.Column<int>(type: "int", nullable: false),
                    Zone_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VolunteersShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VolunteersShifts_Volunteers_Volunteer_Id",
                        column: x => x.Volunteer_Id,
                        principalTable: "Volunteers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VolunteersShifts_Zones_Zone_Id",
                        column: x => x.Zone_Id,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersShifts_Volunteer_Id",
                table: "VolunteersShifts",
                column: "Volunteer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_VolunteersShifts_Zone_Id",
                table: "VolunteersShifts",
                column: "Zone_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VolunteersShifts");
        }
    }
}

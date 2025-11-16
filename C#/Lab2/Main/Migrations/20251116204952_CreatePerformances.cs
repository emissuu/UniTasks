using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class CreatePerformances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starts_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ends_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Participant_Id = table.Column<int>(type: "int", nullable: false),
                    Stage_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performances_Participants_Participant_Id",
                        column: x => x.Participant_Id,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performances_Stages_Stage_Id",
                        column: x => x.Stage_Id,
                        principalTable: "Stages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Performances_Participant_Id",
                table: "Performances",
                column: "Participant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_Stage_Id",
                table: "Performances",
                column: "Stage_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performances");
        }
    }
}

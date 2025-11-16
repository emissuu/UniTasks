using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class FixParticipant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Participants_ParticipantId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ParticipantId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Participants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ParticipantId",
                table: "Participants",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Participants_ParticipantId",
                table: "Participants",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id");
        }
    }
}

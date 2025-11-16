using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class CreateTeamMembers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Participants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Contact_Number = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ParticipantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ParticipantId",
                table: "Participants",
                column: "ParticipantId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_ParticipantId",
                table: "TeamMembers",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Participants_ParticipantId",
                table: "Participants",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Participants_ParticipantId",
                table: "Participants");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ParticipantId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Participants");
        }
    }
}

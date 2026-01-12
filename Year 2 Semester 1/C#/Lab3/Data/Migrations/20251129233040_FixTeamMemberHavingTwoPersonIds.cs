using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTeamMemberHavingTwoPersonIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Persons_PersonId1",
                table: "TeamMembers");

            migrationBuilder.DropIndex(
                name: "IX_TeamMembers_PersonId1",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "PersonId1",
                table: "TeamMembers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId1",
                table: "TeamMembers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_PersonId1",
                table: "TeamMembers",
                column: "PersonId1",
                unique: true,
                filter: "[PersonId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Persons_PersonId1",
                table: "TeamMembers",
                column: "PersonId1",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}

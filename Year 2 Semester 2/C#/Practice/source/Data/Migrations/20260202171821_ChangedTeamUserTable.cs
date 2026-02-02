using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTeamUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Teams_TeamId1",
                table: "TeamUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamUsers_Users_UserId1",
                table: "TeamUsers");

            migrationBuilder.DropIndex(
                name: "IX_TeamUsers_TeamId1",
                table: "TeamUsers");

            migrationBuilder.DropIndex(
                name: "IX_TeamUsers_UserId1",
                table: "TeamUsers");

            migrationBuilder.DropColumn(
                name: "TeamId1",
                table: "TeamUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TeamUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId1",
                table: "TeamUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "TeamUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamUsers_TeamId1",
                table: "TeamUsers",
                column: "TeamId1");

            migrationBuilder.CreateIndex(
                name: "IX_TeamUsers_UserId1",
                table: "TeamUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Teams_TeamId1",
                table: "TeamUsers",
                column: "TeamId1",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamUsers_Users_UserId1",
                table: "TeamUsers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}

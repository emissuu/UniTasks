using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixEventBlockZoneActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_EventBlocks_EventBlockId",
                table: "ZoneActivations");

            migrationBuilder.DropIndex(
                name: "IX_ZoneActivations_EventBlockId",
                table: "ZoneActivations");

            migrationBuilder.DropColumn(
                name: "EventBlockId",
                table: "ZoneActivations");

            migrationBuilder.AddColumn<int>(
                name: "ZoneActivationId",
                table: "EventBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventBlocks_ZoneActivationId",
                table: "EventBlocks",
                column: "ZoneActivationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlocks_ZoneActivations_ZoneActivationId",
                table: "EventBlocks",
                column: "ZoneActivationId",
                principalTable: "ZoneActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBlocks_ZoneActivations_ZoneActivationId",
                table: "EventBlocks");

            migrationBuilder.DropIndex(
                name: "IX_EventBlocks_ZoneActivationId",
                table: "EventBlocks");

            migrationBuilder.DropColumn(
                name: "ZoneActivationId",
                table: "EventBlocks");

            migrationBuilder.AddColumn<int>(
                name: "EventBlockId",
                table: "ZoneActivations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ZoneActivations_EventBlockId",
                table: "ZoneActivations",
                column: "EventBlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_EventBlocks_EventBlockId",
                table: "ZoneActivations",
                column: "EventBlockId",
                principalTable: "EventBlocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

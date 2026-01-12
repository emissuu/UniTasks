using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FixZoneActivation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBlocks_Events_EventId",
                table: "EventBlocks");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "ZoneActivations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBlocks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ZoneActivations_EventId",
                table: "ZoneActivations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlocks_Events_EventId",
                table: "EventBlocks",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_Events_EventId",
                table: "ZoneActivations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBlocks_Events_EventId",
                table: "EventBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_Events_EventId",
                table: "ZoneActivations");

            migrationBuilder.DropIndex(
                name: "IX_ZoneActivations_EventId",
                table: "ZoneActivations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "ZoneActivations");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "EventBlocks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlocks_Events_EventId",
                table: "EventBlocks",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

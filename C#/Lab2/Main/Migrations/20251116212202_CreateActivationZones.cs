using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class CreateActivationZones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivationZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Required_Power = table.Column<int>(type: "int", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partner_Id = table.Column<int>(type: "int", nullable: false),
                    Zone_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivationZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivationZones_Partners_Partner_Id",
                        column: x => x.Partner_Id,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivationZones_Zones_Zone_Id",
                        column: x => x.Zone_Id,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivationZones_Partner_Id",
                table: "ActivationZones",
                column: "Partner_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ActivationZones_Zone_Id",
                table: "ActivationZones",
                column: "Zone_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivationZones");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class CreateIncident : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBlocks_Teams_Team_Id",
                table: "EventBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_EventBlocks_ZoneActivations_Zone_Activation_Id",
                table: "EventBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Administrators_Administrator_Id",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_Team_Id",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Tickets_Ticket_Id",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_Event_Id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerShifts_Workers_Worker_Id",
                table: "WorkerShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerShifts_ZoneActivations_Zone_Activation_Id",
                table: "WorkerShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_Events_Event_Id",
                table: "ZoneActivations");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_Partners_Partner_Id",
                table: "ZoneActivations");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_Zones_Zone_Id",
                table: "ZoneActivations");

            migrationBuilder.DropIndex(
                name: "IX_EventBlocks_Team_Id",
                table: "EventBlocks");

            migrationBuilder.RenameColumn(
                name: "Zone_Id",
                table: "ZoneActivations",
                newName: "ZoneId");

            migrationBuilder.RenameColumn(
                name: "Partner_Id",
                table: "ZoneActivations",
                newName: "PartnerId");

            migrationBuilder.RenameColumn(
                name: "Event_Id",
                table: "ZoneActivations",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneActivations_Zone_Id",
                table: "ZoneActivations",
                newName: "IX_ZoneActivations_ZoneId");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneActivations_Partner_Id",
                table: "ZoneActivations",
                newName: "IX_ZoneActivations_PartnerId");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneActivations_Event_Id",
                table: "ZoneActivations",
                newName: "IX_ZoneActivations_EventId");

            migrationBuilder.RenameColumn(
                name: "Zone_Activation_Id",
                table: "WorkerShifts",
                newName: "ZoneActivationId");

            migrationBuilder.RenameColumn(
                name: "Worker_Id",
                table: "WorkerShifts",
                newName: "WorkerId");

            migrationBuilder.RenameColumn(
                name: "Starts_At",
                table: "WorkerShifts",
                newName: "StartsAt");

            migrationBuilder.RenameColumn(
                name: "Ends_At",
                table: "WorkerShifts",
                newName: "EndsAt");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerShifts_Zone_Activation_Id",
                table: "WorkerShifts",
                newName: "IX_WorkerShifts_ZoneActivationId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerShifts_Worker_Id",
                table: "WorkerShifts",
                newName: "IX_WorkerShifts_WorkerId");

            migrationBuilder.RenameColumn(
                name: "Contact_Number",
                table: "Workers",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "Qr_Code",
                table: "Tickets",
                newName: "QrCode");

            migrationBuilder.RenameColumn(
                name: "Event_Id",
                table: "Tickets",
                newName: "EventId");

            migrationBuilder.RenameColumn(
                name: "Buyer_Name",
                table: "Tickets",
                newName: "BuyerName");

            migrationBuilder.RenameColumn(
                name: "Buyer_Contact_Number",
                table: "Tickets",
                newName: "BuyerContactNumber");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_Event_Id",
                table: "Tickets",
                newName: "IX_Tickets_EventId");

            migrationBuilder.RenameColumn(
                name: "Hand_Color",
                table: "Teams",
                newName: "HandColor");

            migrationBuilder.RenameColumn(
                name: "Contact_Number",
                table: "Teams",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "Arrives_At",
                table: "Teams",
                newName: "ArrivesAt");

            migrationBuilder.RenameColumn(
                name: "Ticket_Id",
                table: "TeamMembers",
                newName: "TicketId");

            migrationBuilder.RenameColumn(
                name: "Team_Id",
                table: "TeamMembers",
                newName: "TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_Ticket_Id",
                table: "TeamMembers",
                newName: "IX_TeamMembers_TicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_Team_Id",
                table: "TeamMembers",
                newName: "IX_TeamMembers_TeamId");

            migrationBuilder.RenameColumn(
                name: "Contact_Number",
                table: "Partners",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "Administrator_Id",
                table: "Events",
                newName: "AdministratorId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_Administrator_Id",
                table: "Events",
                newName: "IX_Events_AdministratorId");

            migrationBuilder.RenameColumn(
                name: "Zone_Activation_Id",
                table: "EventBlocks",
                newName: "ZoneActivationId");

            migrationBuilder.RenameColumn(
                name: "Team_Id",
                table: "EventBlocks",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "Starts_At",
                table: "EventBlocks",
                newName: "StartsAt");

            migrationBuilder.RenameColumn(
                name: "Ends_At",
                table: "EventBlocks",
                newName: "EndsAt");

            migrationBuilder.RenameIndex(
                name: "IX_EventBlocks_Zone_Activation_Id",
                table: "EventBlocks",
                newName: "IX_EventBlocks_ZoneActivationId");

            migrationBuilder.RenameColumn(
                name: "Contact_Number",
                table: "Administrators",
                newName: "ContactNumber");

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HappenedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidents_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventBlocks_TeamId",
                table: "EventBlocks",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TicketId",
                table: "Incidents",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlocks_Teams_TeamId",
                table: "EventBlocks",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlocks_ZoneActivations_ZoneActivationId",
                table: "EventBlocks",
                column: "ZoneActivationId",
                principalTable: "ZoneActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Administrators_AdministratorId",
                table: "Events",
                column: "AdministratorId",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Tickets_TicketId",
                table: "TeamMembers",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerShifts_Workers_WorkerId",
                table: "WorkerShifts",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerShifts_ZoneActivations_ZoneActivationId",
                table: "WorkerShifts",
                column: "ZoneActivationId",
                principalTable: "ZoneActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_Events_EventId",
                table: "ZoneActivations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_Partners_PartnerId",
                table: "ZoneActivations",
                column: "PartnerId",
                principalTable: "Partners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_Zones_ZoneId",
                table: "ZoneActivations",
                column: "ZoneId",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventBlocks_Teams_TeamId",
                table: "EventBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_EventBlocks_ZoneActivations_ZoneActivationId",
                table: "EventBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Administrators_AdministratorId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Teams_TeamId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_Tickets_TicketId",
                table: "TeamMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Events_EventId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerShifts_Workers_WorkerId",
                table: "WorkerShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkerShifts_ZoneActivations_ZoneActivationId",
                table: "WorkerShifts");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_Events_EventId",
                table: "ZoneActivations");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_Partners_PartnerId",
                table: "ZoneActivations");

            migrationBuilder.DropForeignKey(
                name: "FK_ZoneActivations_Zones_ZoneId",
                table: "ZoneActivations");

            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_EventBlocks_TeamId",
                table: "EventBlocks");

            migrationBuilder.RenameColumn(
                name: "ZoneId",
                table: "ZoneActivations",
                newName: "Zone_Id");

            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "ZoneActivations",
                newName: "Partner_Id");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "ZoneActivations",
                newName: "Event_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneActivations_ZoneId",
                table: "ZoneActivations",
                newName: "IX_ZoneActivations_Zone_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneActivations_PartnerId",
                table: "ZoneActivations",
                newName: "IX_ZoneActivations_Partner_Id");

            migrationBuilder.RenameIndex(
                name: "IX_ZoneActivations_EventId",
                table: "ZoneActivations",
                newName: "IX_ZoneActivations_Event_Id");

            migrationBuilder.RenameColumn(
                name: "ZoneActivationId",
                table: "WorkerShifts",
                newName: "Zone_Activation_Id");

            migrationBuilder.RenameColumn(
                name: "WorkerId",
                table: "WorkerShifts",
                newName: "Worker_Id");

            migrationBuilder.RenameColumn(
                name: "StartsAt",
                table: "WorkerShifts",
                newName: "Starts_At");

            migrationBuilder.RenameColumn(
                name: "EndsAt",
                table: "WorkerShifts",
                newName: "Ends_At");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerShifts_ZoneActivationId",
                table: "WorkerShifts",
                newName: "IX_WorkerShifts_Zone_Activation_Id");

            migrationBuilder.RenameIndex(
                name: "IX_WorkerShifts_WorkerId",
                table: "WorkerShifts",
                newName: "IX_WorkerShifts_Worker_Id");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Workers",
                newName: "Contact_Number");

            migrationBuilder.RenameColumn(
                name: "QrCode",
                table: "Tickets",
                newName: "Qr_Code");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Tickets",
                newName: "Event_Id");

            migrationBuilder.RenameColumn(
                name: "BuyerName",
                table: "Tickets",
                newName: "Buyer_Name");

            migrationBuilder.RenameColumn(
                name: "BuyerContactNumber",
                table: "Tickets",
                newName: "Buyer_Contact_Number");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_EventId",
                table: "Tickets",
                newName: "IX_Tickets_Event_Id");

            migrationBuilder.RenameColumn(
                name: "HandColor",
                table: "Teams",
                newName: "Hand_Color");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Teams",
                newName: "Contact_Number");

            migrationBuilder.RenameColumn(
                name: "ArrivesAt",
                table: "Teams",
                newName: "Arrives_At");

            migrationBuilder.RenameColumn(
                name: "TicketId",
                table: "TeamMembers",
                newName: "Ticket_Id");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "TeamMembers",
                newName: "Team_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_TicketId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_Ticket_Id");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_TeamId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_Team_Id");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Partners",
                newName: "Contact_Number");

            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "Events",
                newName: "Administrator_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Events_AdministratorId",
                table: "Events",
                newName: "IX_Events_Administrator_Id");

            migrationBuilder.RenameColumn(
                name: "ZoneActivationId",
                table: "EventBlocks",
                newName: "Zone_Activation_Id");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "EventBlocks",
                newName: "Team_Id");

            migrationBuilder.RenameColumn(
                name: "StartsAt",
                table: "EventBlocks",
                newName: "Starts_At");

            migrationBuilder.RenameColumn(
                name: "EndsAt",
                table: "EventBlocks",
                newName: "Ends_At");

            migrationBuilder.RenameIndex(
                name: "IX_EventBlocks_ZoneActivationId",
                table: "EventBlocks",
                newName: "IX_EventBlocks_Zone_Activation_Id");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Administrators",
                newName: "Contact_Number");

            migrationBuilder.CreateIndex(
                name: "IX_EventBlocks_Team_Id",
                table: "EventBlocks",
                column: "Team_Id",
                unique: true,
                filter: "[Team_Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlocks_Teams_Team_Id",
                table: "EventBlocks",
                column: "Team_Id",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventBlocks_ZoneActivations_Zone_Activation_Id",
                table: "EventBlocks",
                column: "Zone_Activation_Id",
                principalTable: "ZoneActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Administrators_Administrator_Id",
                table: "Events",
                column: "Administrator_Id",
                principalTable: "Administrators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Teams_Team_Id",
                table: "TeamMembers",
                column: "Team_Id",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_Tickets_Ticket_Id",
                table: "TeamMembers",
                column: "Ticket_Id",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Events_Event_Id",
                table: "Tickets",
                column: "Event_Id",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerShifts_Workers_Worker_Id",
                table: "WorkerShifts",
                column: "Worker_Id",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkerShifts_ZoneActivations_Zone_Activation_Id",
                table: "WorkerShifts",
                column: "Zone_Activation_Id",
                principalTable: "ZoneActivations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_Events_Event_Id",
                table: "ZoneActivations",
                column: "Event_Id",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_Partners_Partner_Id",
                table: "ZoneActivations",
                column: "Partner_Id",
                principalTable: "Partners",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZoneActivations_Zones_Zone_Id",
                table: "ZoneActivations",
                column: "Zone_Id",
                principalTable: "Zones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

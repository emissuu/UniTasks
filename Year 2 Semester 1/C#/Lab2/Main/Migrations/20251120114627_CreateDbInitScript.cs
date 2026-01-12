using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class CreateDbInitScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventBlocks_TeamId",
                table: "EventBlocks");

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "ContactNumber", "Name" },
                values: new object[] { 1, "054-5417", "Bohdan" });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "ContactNumber", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "054-7001", "Leading provider of sound equipment for events.", "SoundWave Co." },
                    { 2, "054-7002", "Specialists in event security and crowd management.", "EventSecure Ltd." },
                    { 3, "054-7003", "Catering services for large-scale events.", "Foodies Inc." }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ArrivesAt", "ContactNumber", "HandColor", "Name", "Notes", "Transport" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 14, 10, 0, 0, 0, DateTimeKind.Unspecified), "054-5441", "Red", "The Rockers", "Requires backstage access.", "Bus" },
                    { 2, new DateTime(2024, 12, 4, 15, 0, 0, 0, DateTimeKind.Unspecified), "054-5499", "Blue", "Jazz Masters", "Needs special sound equipment.", "Van" },
                    { 3, new DateTime(2024, 12, 4, 12, 0, 0, 0, DateTimeKind.Unspecified), "054-5490", "Green", "Fire Jazz", "Bringing their own instruments.", "Car" }
                });

            migrationBuilder.InsertData(
                table: "Workers",
                columns: new[] { "Id", "ContactNumber", "Name", "Role", "Salary" },
                values: new object[,]
                {
                    { 1, "054-8001", "John Doe", "Sound Technician", 12000 },
                    { 2, "054-8002", "Jane Smith", "Security Staff", 10000 },
                    { 3, "054-8003", "Mike Johnson", "Catering Staff", 9000 }
                });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "Id", "Location", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Central Area", "Main Stage", "Performance" },
                    { 2, "North Wing", "VIP Lounge", "Exclusive" },
                    { 3, "East Side", "Food Court", "Catering" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AdministratorId", "Date", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "An electrifying rock music festival featuring top bands from around the world.", "Summer Rock Festival" },
                    { 2, 1, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "A cozy jazz event to warm up your winter nights with smooth tunes.", "Winter Jazz Nights" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "BuyerContactNumber", "BuyerName", "EventId", "QrCode" },
                values: new object[,]
                {
                    { 1, "054-5001", "Alice Johnson", 1, "QR123456" },
                    { 2, "054-5002", "Bob Smith", 1, "QR123457" },
                    { 3, "054-6001", "Charlie Brown", 2, "QR223456" },
                    { 4, "054-6002", "Diana Prince", 2, "QR223457" },
                    { 5, "054-6003", "Ethan Hunt", 2, "QR223458" },
                    { 6, "054-5003", "Fiona Glenanne", 1, "QR123458" },
                    { 7, "054-5004", "George Clooney", 1, "QR123459" }
                });

            migrationBuilder.InsertData(
                table: "ZoneActivations",
                columns: new[] { "Id", "EventId", "Notes", "PartnerId", "ZoneId" },
                values: new object[,]
                {
                    { 1, 1, "Setup sound systems and lighting.", 1, 1 },
                    { 2, 1, "Manage VIP access and security.", 2, 2 },
                    { 3, 1, "Arrange food stalls and seating.", 3, 3 },
                    { 4, 2, "Setup sound systems and lighting.", 1, 1 },
                    { 5, 2, "Manage VIP access and security.", 2, 2 },
                    { 6, 2, "Arrange food stalls and seating.", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "EventBlocks",
                columns: new[] { "Id", "EndsAt", "Name", "StartsAt", "TeamId", "Type", "ZoneActivationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), "Rock Band Performance", new DateTime(2024, 8, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), 1, "Performance", 1 },
                    { 2, new DateTime(2024, 8, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), "Intermission", new DateTime(2024, 8, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), null, "Break", 1 },
                    { 3, new DateTime(2024, 8, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), "Closing Act", new DateTime(2024, 8, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), 1, "Performance", 1 },
                    { 4, new DateTime(2024, 12, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), "Jazz Evening", new DateTime(2024, 12, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), 2, "Performance", 4 },
                    { 5, new DateTime(2024, 12, 5, 21, 30, 0, 0, DateTimeKind.Unspecified), "Intermission", new DateTime(2024, 12, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), null, "Break", 4 },
                    { 6, new DateTime(2024, 12, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), "Late Night Jazz", new DateTime(2024, 12, 5, 21, 30, 0, 0, DateTimeKind.Unspecified), 3, "Performance", 4 }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "Description", "HappenedAt", "IsResolved", "TicketId", "Type" },
                values: new object[,]
                {
                    { 1, "Lost sunglasses during the event.", new DateTime(2024, 8, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), true, 1, "Lost Item" },
                    { 2, "Attendee fainted and required medical attention.", new DateTime(2024, 12, 5, 20, 15, 0, 0, DateTimeKind.Unspecified), true, 4, "Medical Emergency" },
                    { 3, "QR code not scanning at entry.", new DateTime(2024, 8, 15, 17, 45, 0, 0, DateTimeKind.Unspecified), false, 6, "Ticket Issue" }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Role", "TeamId", "TicketId" },
                values: new object[,]
                {
                    { 1, "Guitarist", 1, 1 },
                    { 2, "Drummer", 1, 2 },
                    { 3, "Saxophonist", 2, 3 },
                    { 4, "Vocalist", 2, 4 },
                    { 5, "Vocalist", 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "WorkerShifts",
                columns: new[] { "Id", "EndsAt", "StartsAt", "WorkerId", "ZoneActivationId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 8, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, new DateTime(2024, 8, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 8, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 4, new DateTime(2024, 12, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 5, new DateTime(2024, 12, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 6, new DateTime(2024, 12, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventBlocks_TeamId",
                table: "EventBlocks",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EventBlocks_TeamId",
                table: "EventBlocks");

            migrationBuilder.DeleteData(
                table: "EventBlocks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventBlocks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventBlocks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventBlocks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventBlocks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EventBlocks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TeamMembers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "WorkerShifts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkerShifts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkerShifts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkerShifts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkerShifts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkerShifts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Workers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZoneActivations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ZoneActivations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ZoneActivations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ZoneActivations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ZoneActivations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ZoneActivations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Partners",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Administrators",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_EventBlocks_TeamId",
                table: "EventBlocks",
                column: "TeamId",
                unique: true,
                filter: "[TeamId] IS NOT NULL");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Main.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DailyReports",
                columns: new[] { "Id", "Contents", "Date", "Summary" },
                values: new object[,]
                {
                    { 1, "The festival kicked off with SuperCoolBand delivering an electrifying performance on the Main Stage. Attendance was high, and the crowd was enthusiastic. Minor incidents included a lost ticket at the entrance, which was resolved quickly.", new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Successful opening day with great performances." },
                    { 2, "JazzMasters captivated the audience at the Jazz Corner with their soulful tunes. The atmosphere was relaxed and enjoyable. A medical emergency was handled efficiently by the on-site team, ensuring the safety of all attendees.", new DateTime(2024, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second day focused on jazz with smooth performances." }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Arrives_At", "Contact_Number", "Hand_Color", "Name", "Notes", "Transport" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), "555-1234", "Red", "SuperCoolBand", "Requires soundcheck at 3 PM", null },
                    { 2, new DateTime(2024, 7, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), "555-5678", "Blue", "JazzMasters", "Bringing their own equipment", null }
                });

            migrationBuilder.InsertData(
                table: "Partners",
                columns: new[] { "Id", "Contact_Number", "Name" },
                values: new object[,]
                {
                    { 1, "555-2222", "City Radio" },
                    { 2, "555-3333", "Local Eats" }
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "Capacity", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 5000, "Central Park", "Main Stage" },
                    { 2, 1500, "Downtown Plaza", "Jazz Corner" }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Buyer_Name", "Contact_Number", "Entrance_Date", "Qr_Code", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "John Doe", "555-6666", null, "TICKET12345", "Unused", "VIP" },
                    { 2, "Jane Smith", "555-7777", null, "TICKET67890", "Unused", "General" },
                    { 3, "Mike Johnson", "555-8888", null, "TICKET54321", "Unused", "General" }
                });

            migrationBuilder.InsertData(
                table: "Volunteers",
                columns: new[] { "Id", "Contact_Number", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "555-7777", "Frank", "Stage helper" },
                    { 2, "555-8888", "Grace", "Crowd control" }
                });

            migrationBuilder.InsertData(
                table: "Zones",
                columns: new[] { "Id", "Location", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Behind Main Stage", "Backstage", "Restricted" },
                    { 2, "North Gate", "Entrance", "Public" },
                    { 3, "East Side", "Food Court", "Public" }
                });

            migrationBuilder.InsertData(
                table: "ActivationZones",
                columns: new[] { "Id", "Notes", "Partner_Id", "Required_Power", "Zone_Id" },
                values: new object[,]
                {
                    { 1, "Setup live broadcast point", 1, 500, 2 },
                    { 2, "Food stalls area", 2, 200, 3 }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "Description", "Happened_At", "Ticket_Id", "Type", "Zone_Id" },
                values: new object[,]
                {
                    { 1, "Lost ticket", new DateTime(2024, 7, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 2 },
                    { 2, "Medical emergency", new DateTime(2024, 7, 11, 20, 30, 0, 0, DateTimeKind.Unspecified), 2, null, 3 }
                });

            migrationBuilder.InsertData(
                table: "LogisticItems",
                columns: new[] { "Id", "Name", "Quantity", "Zone_Id" },
                values: new object[,]
                {
                    { 1, "Speaker System", 10, 1 },
                    { 2, "Lighting Rig", 5, 1 },
                    { 3, "Barricades", 50, 2 }
                });

            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "Id", "Ends_At", "Participant_Id", "Stage_Id", "Starts_At" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 10, 19, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2024, 7, 10, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2024, 7, 11, 21, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2024, 7, 11, 20, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TeamMembers",
                columns: new[] { "Id", "Contact_Number", "Name", "Participant_Id", "Role" },
                values: new object[,]
                {
                    { 1, "555-4128", "Alice", 1, "Vocalist" },
                    { 2, "555-4312", "Bob", 1, "Guitarist" },
                    { 3, "555-9412", "Charlie", 2, "Saxophonist" },
                    { 4, "555-9481", "Diana", 2, "Drummer" },
                    { 5, "555-4144", "Eve", 1, "Drummer" }
                });

            migrationBuilder.InsertData(
                table: "TechnicalBreaks",
                columns: new[] { "Id", "Ends_At", "Notes", "Stage_Id", "Starts_At" },
                values: new object[] { 1, new DateTime(2024, 7, 10, 20, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2024, 7, 10, 19, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "VolunteersShifts",
                columns: new[] { "Id", "Ends_At", "Starts_At", "Volunteer_Id", "Zone_Id" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 10, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, new DateTime(2024, 7, 11, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Accreditations",
                columns: new[] { "Id", "Team_Member_Id", "Valid_From", "Valid_To" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accreditations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accreditations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accreditations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accreditations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accreditations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActivationZones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActivationZones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyReports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LogisticItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LogisticItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LogisticItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechnicalBreaks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VolunteersShifts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VolunteersShifts",
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
                table: "Stages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stages",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Volunteers",
                keyColumn: "Id",
                keyValue: 2);

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
                table: "Participants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

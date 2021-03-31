using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateEventApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: false),
                    EventDescription = table.Column<string>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Created_User",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => x.EventUserId);
                    table.ForeignKey(
                        name: "FK_Event_Group",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Group_Event",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4bf82c07-349f-4e01-9eaf-95b151e48ea9");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "de1ea766-905c-4c9f-aeba-27ed6aa64f0d");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d6546f3-68d9-40eb-a71d-3f5bac4c30ab", "888e9793-d144-4efb-b7b9-6542440db7a5", "AQAAAAEAACcQAAAAEPxvM6Y9wkiuTRR1ILPTyI2Sb19R8owyxFQykg2+bCxjv8Mt+Szk2GMj3DrmgkMsVw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8f32d590-ade0-434d-8a30-8f74c0d6af16", "bb15274f-dfff-4130-a18e-c8a6306df9cf", "AQAAAAEAACcQAAAAEI1dE++EAaM5fijaCThW2I1czOmHbidM8R+soquDPfa5XmaL4LI367CFcb62sj/8BA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Event_GroupId",
                table: "Event",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventId",
                table: "EventUser",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_GroupId",
                table: "EventUser",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ee2d242b-6adb-46ba-a77a-dfa1a77f2603");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "87487151-a1b0-4500-9fbd-641b40ee06c8");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b81af45d-9dc7-4794-931b-cfd0e2b1bf0d", "53a29bfc-360e-4962-8cfe-53073631c1e0", "AQAAAAEAACcQAAAAEI3cV/paGeDbhjJIovCnrHOD3glhnhFPyiT2o3twMvRHTbKfqm9SNFYQvvO+JQRgJg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20d4d5ad-ef79-4da4-b917-d7fcbf519e0f", "f11b3a01-c12e-4fe7-b643-f16c4288a7df", "AQAAAAEAACcQAAAAEDHeKbKhlhj3i1Nf0TkAmfdTg1QoGanR3/r4o+TFtjt7Infy7Y6l1xMFkogpd+up4A==" });
        }
    }
}

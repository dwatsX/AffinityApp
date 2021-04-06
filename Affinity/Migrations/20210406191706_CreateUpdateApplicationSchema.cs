using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateUpdateApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Created_User",
                table: "Event");

            migrationBuilder.DropTable(
                name: "EventGroup");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "05c7aa9e-f363-45b1-a1a0-73575a19ee7c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "660ce549-c15f-48b3-8730-479bde861a3e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1295fac1-786f-47a9-b05d-72fd79ed2612", "a760620f-aa80-41b3-863d-30ee6f056afb", "AQAAAAEAACcQAAAAEGHOOYcXDG9ZvKjJBmgYVH8hIPPe0LYHiAAJd3TrCeKq5n/XVaCcfUdbuWC18YZDog==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fb38d31c-3df6-4acf-a94b-97e6af0cf618", "8029d6cd-02da-42bc-9169-392dc90a5bfa", "AQAAAAEAACcQAAAAECiBZJ/VV5gLzN3N0gDJM9SglxgrTAwYbhXvZ1CCj51R6Af7Tko50dc0sVKSRUO4Mg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Group",
                table: "Event",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_Group",
                table: "Event");

            migrationBuilder.CreateTable(
                name: "EventGroup",
                columns: table => new
                {
                    EventUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroup", x => x.EventUserId);
                    table.ForeignKey(
                        name: "FK_Event_Group",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventGroup_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "498acd13-86fa-45f6-b223-3a71c2d25532");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "461ce6e2-7d29-4da5-820b-cbb3a084a002");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1e04280b-9af4-4215-a190-fb32294dfa26", "099873b0-ba33-4342-8a47-810c8c2f468f", "AQAAAAEAACcQAAAAEJMryqbShDQz2u79ojL3NuT8UD9Rxu9UBQz/z5b31gplVV+4AEVyJSBVV6LUsXSd1g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "057b5fec-b0d3-4586-92a1-e47b69a9b78a", "001ed66a-c1c5-41bf-a40f-9937eedcf660", "AQAAAAEAACcQAAAAEJUkmogwuXHPBh4ptfto/hV9gbTrnOenfu1LuJPA3AbPi+vPxVKw7Gdd5TNNwVUxPw==" });

            migrationBuilder.CreateIndex(
                name: "IX_EventGroup_EventId",
                table: "EventGroup",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventGroup_GroupId",
                table: "EventGroup",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Created_User",
                table: "Event",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

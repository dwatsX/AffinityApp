using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreatedGroupMessagesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupMessage",
                columns: table => new
                {
                    GroupMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendingUserProfileId = table.Column<int>(nullable: false),
                    SendingUserProfileName = table.Column<string>(nullable: false),
                    MessageContent = table.Column<string>(unicode: false, maxLength: 1500, nullable: false),
                    MessageDateTime = table.Column<string>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMessage", x => x.GroupMessageId);
                    table.ForeignKey(
                        name: "FK_GroupMessage_Group",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "eaa38c30-2738-4566-ade6-b7bde5b6846d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d177b5b1-b496-4905-9e00-b386f2679aab");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02486adf-73cc-4567-b6fc-f3f1859ff8b2", "bd5025cf-2be6-4ad3-971c-851ffe918bbd", "AQAAAAEAACcQAAAAEI/Y98EG5ZGoqEPpgd5IINEWJ9+OJHcm+juZJ17NQ8Ya7RSssSZMUcQ3qQdxL8VjdA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a0225d24-3eb3-4188-abf9-055ad8b91a77", "06585dde-ff0c-44e5-bee8-54bac3655f3f", "AQAAAAEAACcQAAAAEG3GX/xkI9gS7Z5WpQs/KmviAp3u8wwjwJUu7doIqw19yt++mUlcRDPWdKaZMrQUvw==" });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMessage_GroupId",
                table: "GroupMessage",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMessage");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6bcbe66e-254d-415f-804d-6d83a83885c0");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b894e845-2374-4e33-9602-a08d74f94793");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0020a0c7-316b-4580-8310-f0b0701cd7e1", "9d1b345a-a3ca-4d52-be84-7fc0ad63e3e4", "AQAAAAEAACcQAAAAENluwxz67dTrX+2v2tXMNKnr/TFZL/hA7lGD77Bidhb7kHbk6a5z0aeJb1+RQBpPKA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c53ca9cd-76d4-4068-a891-1a66ff6477ea", "b85771e3-9f16-4129-ab94-e7f2fad7efab", "AQAAAAEAACcQAAAAEDr8guMbOWtZN/o+/MAC21v7ZCMnP1SdnS8gRBb5GzRFjsixREey1vKTMcRnkqYkKg==" });
        }
    }
}

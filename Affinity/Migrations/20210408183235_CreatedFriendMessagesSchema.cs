using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreatedFriendMessagesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FriendMessage",
                columns: table => new
                {
                    FriendMessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendingUserId = table.Column<int>(nullable: false),
                    ReceivingUserId = table.Column<int>(nullable: false),
                    MessageContent = table.Column<string>(unicode: false, maxLength: 1500, nullable: false),
                    MessageDateTime = table.Column<string>(nullable: false),
                    UserRelationshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendMessage", x => x.FriendMessageId);
                    table.ForeignKey(
                        name: "FK_FriendMessage_UserRelationship",
                        column: x => x.UserRelationshipId,
                        principalTable: "UserRelationship",
                        principalColumn: "UserRelationshipId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "aa086816-05e7-4ad2-8f88-9ad0e9c61afe");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8b8e15cb-0691-4587-a3fd-d3f08b6310f3");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00f55f76-dfe7-4aa2-98b9-8cd34ecbc910", "91e0c108-b28d-428d-a25a-dbfeb6821729", "AQAAAAEAACcQAAAAENEtOwRzDMarUxVb/Y3Z6Kg9YNjxLeTfHei2OudAe7nqVgYIwByoWaqx5ZyELZrlag==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "294dc910-3787-478e-b881-0b08786e2a07", "80e584fd-0a36-4bb8-b170-07a8b9c0a60f", "AQAAAAEAACcQAAAAEIaAAX+92dSAlPV9jISG2gr5B+rXnPBpPnqVSTgjnXN5LiUVOo38L3yUbmu7p/LNRQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_FriendMessage_UserRelationshipId",
                table: "FriendMessage",
                column: "UserRelationshipId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendMessage");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "53503b67-a20c-4eaf-94fd-ac6bffe62ce8");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "77a58804-76af-46f4-8d16-f3591d08414e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75d3fecc-0951-4ddc-8a2d-b8a2f15762b8", "60b0c7bc-6237-41ab-badd-0b9c277ec0c4", "AQAAAAEAACcQAAAAEGyb6OE5GZvdkZe28F5wTs4yyZ1/qYBzRon/UPzYxdwmYZgD+ffDfR60cpTSJDXwWA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ba4f0b0-9008-44e0-827f-73a199f50b16", "264cc805-6e1d-43e2-868f-6008851af828", "AQAAAAEAACcQAAAAEPo04mp8IMDw+p3pGyi1HCeXBpvYt7aqnhYstl9gLSws8fjWuYQMHUYgDNuyEcbKVA==" });
        }
    }
}

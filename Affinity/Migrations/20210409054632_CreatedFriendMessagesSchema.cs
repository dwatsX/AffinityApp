using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreatedFriendMessagesSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

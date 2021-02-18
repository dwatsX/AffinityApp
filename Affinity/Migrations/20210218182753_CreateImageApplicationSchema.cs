using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateImageApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0f13d7e9-78c9-4a7c-8e28-6c80a3abe632");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "44ad3927-64e5-4a3d-a563-90e1d634d28c");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b87f81c0-fbe1-4096-892f-552485e60a0e", "e7b7213e-90cc-4e9e-b2ed-c3cdf7934711", "AQAAAAEAACcQAAAAEOBPRMci23A/JCklrL4cFVVBwnTHtiaxkMRpqxJBKX7UDbZButRU+yIIapmU7+9Tng==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "23fc1418-c026-4221-bc7b-5585a0e7fd62", "ede16de8-cbc4-4dda-ac2b-632d2e48200c", "AQAAAAEAACcQAAAAEHvabASo16t3S0mzY4WSXBpW6mbl1xojR2voZ5Pftefkyjg3n9h9eBu6D7fHMaHTBw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_UserId",
                table: "Image",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6ea88745-bbee-45b2-897d-9e55d8114037");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "63cb1814-0dcb-49c4-a2b8-5b68d5e782b4");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55cc3dc4-94a5-40aa-886a-4953f8fb60f8", "80adbbce-de9e-4438-b45a-1f789728f975", "AQAAAAEAACcQAAAAEL2j74CKs1QU0qCyBb2Cw+i/pLRwwnnpk4sDnRnDgWE34PvJCFK+MduYPSHGSkf/Cw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0343d2a5-0112-4262-afbf-e8f12c191ac9", "4b05856f-63b9-4125-b5a3-d91c9decf2ab", "AQAAAAEAACcQAAAAEITmTyT6ZuBVxGL11T5ZqrVOk6uOoGgidMW373b0npKvAqGnxCj8rcmlq/qlEEPsig==" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateProfileApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_UserId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Image");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Image",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileID",
                table: "Image",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<int>(nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profile_User",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_User_UserId1",
                        column: x => x.UserId1,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2604bbd7-b0a4-48ce-91e7-edf28835dc29");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7dbb1928-ac92-4181-9e2a-b69230d764fb");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6b13e5e-50f6-4742-850d-9279fc49811a", "c3a7cfee-f4c4-48cb-afc2-7035973b8591", "AQAAAAEAACcQAAAAEBKjpnc4nqJ7FtBuiaHFtrVEAHCLX8kKI6UNwynQ/aZbQ4PyQUzNXejhy2HS3AZPlA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17eccb2c-20c2-4251-91c7-01d7506343ab", "d46834fb-940b-4d87-9e9a-b39f9099686b", "AQAAAAEAACcQAAAAEAi1P5aZzFp3oWTghB/VIoJmFXCdDu3WmayRbZE2cRpvaL67Ul18wSaV9sk12WgqwQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProfileID",
                table: "Image",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId1",
                table: "Profile",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Image",
                table: "Image",
                column: "ProfileID",
                principalTable: "Profile",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image",
                table: "Image");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProfileID",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ProfileID",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Image",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Image",
                table: "Image",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

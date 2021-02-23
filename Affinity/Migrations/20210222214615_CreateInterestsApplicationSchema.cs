using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateInterestsApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InterestCategory",
                columns: table => new
                {
                    InterestCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestCategoryName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestCategory", x => x.InterestCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "InterestSubCategory",
                columns: table => new
                {
                    InterestSubCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestCategoryId = table.Column<int>(nullable: false),
                    InterestSubCategoryName = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestSubCategory", x => x.InterestSubCategoryId);
                    table.ForeignKey(
                        name: "FK_Sub_InterestCategory",
                        column: x => x.InterestCategoryId,
                        principalTable: "InterestCategory",
                        principalColumn: "InterestCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestSubCategoryId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interest_SubCategory",
                        column: x => x.InterestSubCategoryId,
                        principalTable: "InterestSubCategory",
                        principalColumn: "InterestSubCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profile_Interests",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "InterestCategory",
                columns: new[] { "InterestCategoryId", "InterestCategoryName" },
                values: new object[,]
                {
                    { 1, "Music" },
                    { 2, "Food" },
                    { 3, "Gaming" },
                    { 4, "Sports" },
                    { 5, "Literature" }
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ff04d2c1-7e32-4163-880e-dd090682e7c1");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5f721876-0a2c-40ab-8db6-026a90e55a61");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "231c8d54-b557-44b6-a1b7-5185caec36ab", "203f3ffd-c24c-4de2-af76-16246a78eb36", "AQAAAAEAACcQAAAAENRdtu+X6URefJB68vbZhH4vOSkKStcLkxmBiHNg4MqpKP0caJpm1vaaiJCmC+eRjw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f177bc7e-6240-4c17-8561-1a5f0bd7ae25", "1daa1de4-647d-431c-82bb-a2aff4a5d1e6", "AQAAAAEAACcQAAAAEDcFAneXwe5FvRPQ10U4jdQSP/0SqWcVT3QrgMzPJ31I22H5dwlq6IvD07oRNryvrw==" });

            migrationBuilder.InsertData(
                table: "InterestSubCategory",
                columns: new[] { "InterestSubCategoryId", "InterestCategoryId", "InterestSubCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Rock" },
                    { 23, 5, "Non-Fiction" },
                    { 22, 5, "Fantasy" },
                    { 21, 5, "Sci Fi" },
                    { 20, 4, "VolleyBall" },
                    { 19, 4, "Football" },
                    { 18, 4, "Soccer" },
                    { 17, 4, "Hockey" },
                    { 16, 4, "Basketball" },
                    { 15, 3, "Sandbox" },
                    { 14, 3, "Simulation" },
                    { 24, 5, "Fiction" },
                    { 13, 3, "Strategy" },
                    { 11, 3, "RPG" },
                    { 10, 2, "Africa" },
                    { 9, 2, "South American" },
                    { 8, 2, "North American" },
                    { 7, 2, "European" },
                    { 6, 2, "Asian" },
                    { 5, 1, "Jazz" },
                    { 4, 1, "Country" },
                    { 3, 1, "Classical" },
                    { 2, 1, "Rap" },
                    { 12, 3, "Action" },
                    { 25, 5, "Historical" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_InterestSubCategoryId",
                table: "Interests",
                column: "InterestSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_ProfileId",
                table: "Interests",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestSubCategory_InterestCategoryId",
                table: "InterestSubCategory",
                column: "InterestCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "InterestSubCategory");

            migrationBuilder.DropTable(
                name: "InterestCategory");

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
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class ProfileUpdateApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discord",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProfileName",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e8352c42-3d30-46e8-8d2c-5f7c6708d266");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e9149d9c-6bf4-4b6f-a0d8-3835662bf129");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4f6ca1ce-f3c3-4d43-ac78-17b24cd2e858", "424989b1-a8ec-4ab1-b8f5-3fd5540a5a99", "AQAAAAEAACcQAAAAEC5BVzcwJRYy3j8Xt3r3v2e502UK/AvE8FkyeufsZDdXyCByPi+kCFFXum+IS1dWNw==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e92bad1d-76db-40f5-a5e2-8b356f97f6e3", "082c0914-12bf-45e7-8edf-fcadf5d6db43", "AQAAAAEAACcQAAAAENnTtxoebwmybbysIXIQOBqP0X6zq0rbAVoqsuwRXHA4OxnbRHcEM1Zdtd/UhGkrUA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Interests_InterestCategoryId",
                table: "Interests",
                column: "InterestCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interests_InterestCategory_InterestCategoryId",
                table: "Interests",
                column: "InterestCategoryId",
                principalTable: "InterestCategory",
                principalColumn: "InterestCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interests_InterestCategory_InterestCategoryId",
                table: "Interests");

            migrationBuilder.DropIndex(
                name: "IX_Interests_InterestCategoryId",
                table: "Interests");

            migrationBuilder.DropColumn(
                name: "Discord",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "ProfileName",
                table: "Profile");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f5510a41-59c8-41a5-abbc-3fa70385de65");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7740baba-5364-4cde-9936-7751ce06caba");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4e9387b4-7435-4677-a89d-e047f718fa31", "586ffe5b-3f87-40c8-9b34-b665f240b514", "AQAAAAEAACcQAAAAEGIi4Xk1hzztiq/AH3dtV6NuKW3KKzVVanrXwJlvbLnbDCNruthAko2huc3uHxRguA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "859cc78b-b8e3-4e97-806e-8700ad222d74", "f98f7948-43ad-4221-80a1-4daff2bd39d9", "AQAAAAEAACcQAAAAEAgww2JLgfpkQnSIZnzFOMBNlmynIuMeEG2+9MmVatjAJceTnIoyBFSLznX5pswZtA==" });
        }
    }
}

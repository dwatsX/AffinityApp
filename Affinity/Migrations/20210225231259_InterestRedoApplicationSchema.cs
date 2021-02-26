using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class InterestRedoApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InterestCategoryId",
                table: "Interests",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InterestCategoryId",
                table: "Interests");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "53d500c5-8bd6-4551-9bc6-853ee5954bd2");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f1ca58cf-b38f-4863-bd42-17c9d4556b95");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd241818-5fe8-4800-bd7c-2ea674ed3e1b", "f25063ca-faee-42fc-8b6a-27de8ff72e52", "AQAAAAEAACcQAAAAEEr3GdKFAouQWqx1oag8A0+X2dEuawtPbB1IAFymsUZTuBjow8X1MckYBvSW476Row==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d17005f5-ce60-4090-a10d-59d257afcf6e", "444fb478-614d-4b8c-86eb-898ceb2b2f21", "AQAAAAEAACcQAAAAEHK3XpFeN8aZesKEPvEh5nsXM7bSR9GuuTVO2guL9KPqRG4992DiYMOdAuAk4bW2jQ==" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9b9b3508-3b81-4e2e-b531-aa362f6d99a6");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "88ed2477-a4a9-4c7b-8ff5-7c6c843c83f3");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2626137a-bcf2-46e8-9448-d966a2f5af73", "2822a463-0df6-4d1f-be75-41107402e0c0", "AQAAAAEAACcQAAAAELElV4xcXkyDWvYtmwYWoSBGeFAh5+Ja40hEH2DbeShawAUB1wFWDky0+DL0+bfZVA==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e407c2ec-8ab4-4490-b83c-e8eb0db8c45a", "934263f4-2c6d-47e5-aff9-95c41491724d", "AQAAAAEAACcQAAAAENy08X9o2HGZcHXwD5uzlsI3xftFU+J++NeDiFU1SzJZ+reQ1SAl5nK5e66krTYcEw==" });
        }
    }
}

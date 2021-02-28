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
                value: "017b7f8e-970a-4061-8654-20ecc41a8a0b");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1b71df49-aff5-4cdb-b842-f82372ac65df");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "438993d1-76b3-4b01-bd7b-089fc64254a2", "0f40e30f-3241-4d39-ae0a-7724e4a5e2b5", "AQAAAAEAACcQAAAAEP9vrReynJJC1FvuaDSs4ukEGODFuFDqlhlPMrTaq0BeoF8D+UO386vw8bEiKIGeYg==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fec54148-0275-4ef7-b486-54813c5ea095", "c70ddc7e-75ab-455b-b636-22cbc8eff945", "AQAAAAEAACcQAAAAEAC0HFCs098uhxOkTQiZ5i34IRRRWRWRSUL0gsS/FlFi6pB2X0s8S2wYijDysCEvhw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "1999ed13-4cdd-49e9-8171-379caef01ecd");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e16cdf8c-8056-4a5f-9cbd-da5d94109c69");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "31f7678e-c646-47a3-afe4-b3b66fd0f60f", "2da6a9cd-143d-4d21-975a-47d920d9706d", "AQAAAAEAACcQAAAAECX96Q4AEyTkuyMkZU/IpEex3gD/V0janBB/wx3OeGAXVGC+tO6dvW6mHqooiGZi3Q==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e0b410ef-1fa5-49a7-b459-c400a394e0b4", "df7d96eb-6a1e-46b8-8b0d-7f9783a5989c", "AQAAAAEAACcQAAAAEMsr6Zw9X9DVYkjl9N/UXXl7h6Lj/JxMnupVtCp4IOLnHGbdW+SfJivNzuOn+4eBRA==" });
        }
    }
}

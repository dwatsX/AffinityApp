using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class ProfileUpdate2Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fde36ca1-d495-49ad-ab8e-6d324f007950");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b20345bf-2fec-4c11-9341-3426c5c25a0f");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6a59fe80-f215-4730-9682-75401b28ca03", "50d50fb1-8037-451c-95fb-91ca0cbf8ec8", "AQAAAAEAACcQAAAAEH7dg+WgzdmnmJH/k/mqhk2DOvIynytkw3Z9SbHSPKhWhnI9+phFkolREuwE7E4m7g==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "969bd8fe-daee-4830-8adc-604ec727affa", "fe21fe5e-f675-405d-ad6c-728475965524", "AQAAAAEAACcQAAAAEP0EyAnacPcpx2suCFO71RbcyaNnr70Tx9Uk7VR60M/umkF8RGAo9tnamGcDr+4bsw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}

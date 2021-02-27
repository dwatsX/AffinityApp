using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class ProfileUpdate3Schema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Discord",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profile",
                unicode: false,
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)",
                oldUnicode: false,
                oldMaxLength: 150);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Occupation",
                table: "Profile",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Profile",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Instagram",
                table: "Profile",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Discord",
                table: "Profile",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Profile",
                type: "varchar(150)",
                unicode: false,
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 150,
                oldNullable: true);

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
    }
}

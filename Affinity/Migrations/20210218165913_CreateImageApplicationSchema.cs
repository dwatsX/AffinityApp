using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateImageApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameImage",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameImage", x => x.ImageId);
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
                value: "b4b84410-a44a-461a-84bd-f3b79120cb0f");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fcac2923-0d65-49fa-8234-d985f4581ab6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a7404f0-0f91-4688-8666-b872d4e37f70", "c9256f90-b120-43be-ba65-f194602a5f50", "AQAAAAEAACcQAAAAECJuWLuxdKgiqK8Xu+VeeUF5W7Gdbzsp1wasXMcEhSCuNv4H/isNlSMlJHhttpqJTQ==" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AccountNum", "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0cd8c9cf-457c-4968-a488-41edd453714c", "eaa17277-f736-4868-bbb7-e0ee86fa1153", "AQAAAAEAACcQAAAAEJdG18QkVI4J1Rj8IBt1DX2hRxYX8KVJZZG+qOiQi2dj5JBcq8dJhHMPLEQGUcrn0Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_GameImage_UserId",
                table: "GameImage",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameImage");

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

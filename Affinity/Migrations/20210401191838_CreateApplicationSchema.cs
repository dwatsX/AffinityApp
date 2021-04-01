using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Affinity.Migrations
{
    public partial class CreateApplicationSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                });

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
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AccountNum = table.Column<string>(unicode: false, maxLength: 36, nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 128, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(nullable: false),
                    EventName = table.Column<string>(nullable: false),
                    EventDescription = table.Column<string>(nullable: false),
                    EventDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Created_User",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "RoleClaims",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ProfileName = table.Column<string>(unicode: false, maxLength: 150, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Discord = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Instagram = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Occupation = table.Column<string>(unicode: false, maxLength: 150, nullable: true),
                    Education = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: false),
                    Alcohol = table.Column<int>(nullable: false),
                    Marijuana = table.Column<int>(nullable: false),
                    Cigarettes = table.Column<int>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.UserId, x.ProviderKey, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    EventUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => x.EventUserId);
                    table.ForeignKey(
                        name: "FK_Event_Group",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Group_Event",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    MatchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(nullable: false),
                    MatchedProfileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                    table.ForeignKey(
                        name: "FK_Matches_Profile_MatchedProfileId",
                        column: x => x.MatchedProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_Matches",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRelationship",
                columns: table => new
                {
                    UserRelationshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RelatingUserProfile = table.Column<int>(nullable: false),
                    RelatedUserProfile = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false, defaultValue: 0),
                    RelatingUserId = table.Column<int>(nullable: true),
                    RelatedUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelationship", x => x.UserRelationshipId);
                    table.ForeignKey(
                        name: "FK_Profile_Related",
                        column: x => x.RelatedUserProfile,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRelationship_User_RelatedUserId",
                        column: x => x.RelatedUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Profile_Relating",
                        column: x => x.RelatingUserProfile,
                        principalTable: "Profile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRelationship_User_RelatingUserId",
                        column: x => x.RelatingUserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestCategoryId = table.Column<int>(nullable: false),
                    InterestSubCategoryId = table.Column<int>(nullable: false),
                    ProfileId = table.Column<int>(nullable: false),
                    MatchesMatchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                    table.ForeignKey(
                        name: "FK_Interests_InterestCategory_InterestCategoryId",
                        column: x => x.InterestCategoryId,
                        principalTable: "InterestCategory",
                        principalColumn: "InterestCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interest_SubCategory",
                        column: x => x.InterestSubCategoryId,
                        principalTable: "InterestSubCategory",
                        principalColumn: "InterestSubCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interests_Matches_MatchesMatchId",
                        column: x => x.MatchesMatchId,
                        principalTable: "Matches",
                        principalColumn: "MatchId",
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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "856e0304-7cd3-4dc0-945c-587a7ee9e27e", "Admin", "ADMIN" },
                    { 2, "3c9029b0-749a-40df-b5c0-d7b0df87bc2d", "Member", "MEMBER" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AccountNum", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "f1f9f086-3faa-4b8b-ab1c-41bff7391501", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "369af448-cd20-4cb9-b660-05979a72f8f9", "admin@admin.com", true, "Other", false, null, "Admin", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEFD9JFOUsK/2PlEUL4gOwGJFref7ED/qpQP+r2Lq/RcYtaLJWQhAIwo5IQ9bqyu43Q==", "555-555-5555", false, "", false, "admin" },
                    { 2, 0, "ff4f5644-ceed-48fa-b304-0d557a25ac6d", new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "3a17c6bd-9649-4a53-b12a-b3baf52bc91c", "user@user.com", true, "Other", false, null, "User", "USER@USER.COM", "USER", "AQAAAAEAACcQAAAAEEku6ctm4L0wBBF+e55UwFkS825Gc2xJCx3IhS5MmbUuoHkfUI5+dd3FaKDGjK/Yhw==", "555-555-5555", false, "", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "InterestSubCategory",
                columns: new[] { "InterestSubCategoryId", "InterestCategoryId", "InterestSubCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "Rock" },
                    { 25, 5, "Historical" },
                    { 24, 5, "Fiction" },
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
                    { 12, 3, "Action" },
                    { 11, 3, "RPG" },
                    { 10, 2, "African" },
                    { 9, 2, "South American" },
                    { 8, 2, "North American" },
                    { 7, 2, "European" },
                    { 6, 2, "Asian" },
                    { 5, 1, "Jazz" },
                    { 4, 1, "Country" },
                    { 3, 1, "Classical" },
                    { 2, 1, "Rap" },
                    { 13, 3, "Strategy" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_GroupId",
                table: "Event",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventId",
                table: "EventUser",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_GroupId",
                table: "EventUser",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProfileId",
                table: "Image",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_InterestCategoryId",
                table: "Interests",
                column: "InterestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_InterestSubCategoryId",
                table: "Interests",
                column: "InterestSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_MatchesMatchId",
                table: "Interests",
                column: "MatchesMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Interests_ProfileId",
                table: "Interests",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestSubCategory_InterestCategoryId",
                table: "InterestSubCategory",
                column: "InterestCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_MatchedProfileId",
                table: "Matches",
                column: "MatchedProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_ProfileId",
                table: "Matches",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_UserId",
                table: "Profile",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_RelatedUserProfile",
                table: "UserRelationship",
                column: "RelatedUserProfile");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_RelatedUserId",
                table: "UserRelationship",
                column: "RelatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_RelatingUserId",
                table: "UserRelationship",
                column: "RelatingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRelationship_RelatingUserProfile_RelatedUserProfile",
                table: "UserRelationship",
                columns: new[] { "RelatingUserProfile", "RelatedUserProfile" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRelationship");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "InterestSubCategory");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "InterestCategory");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

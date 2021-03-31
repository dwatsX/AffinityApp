﻿// <auto-generated />
using System;
using Affinity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Affinity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Affinity.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("EventId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnName("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnName("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnName("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnName("GroupId")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("GroupId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("Affinity.Models.EventGroup", b =>
                {
                    b.Property<int>("EventUserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnName("EventId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnName("GroupId")
                        .HasColumnType("int");

                    b.HasKey("EventUserId");

                    b.HasIndex("EventId");

                    b.HasIndex("GroupId");

                    b.ToTable("EventUser");
                });

            modelBuilder.Entity("Affinity.Models.Group", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Affinity.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageURL")
                        .HasColumnName("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileId")
                        .HasColumnName("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Affinity.Models.InterestCategory", b =>
                {
                    b.Property<int>("InterestCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InterestCategoryId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("InterestCategoryName")
                        .IsRequired()
                        .HasColumnName("InterestCategoryName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("InterestCategoryId");

                    b.ToTable("InterestCategory");

                    b.HasData(
                        new
                        {
                            InterestCategoryId = 1,
                            InterestCategoryName = "Music"
                        },
                        new
                        {
                            InterestCategoryId = 2,
                            InterestCategoryName = "Food"
                        },
                        new
                        {
                            InterestCategoryId = 3,
                            InterestCategoryName = "Gaming"
                        },
                        new
                        {
                            InterestCategoryId = 4,
                            InterestCategoryName = "Sports"
                        },
                        new
                        {
                            InterestCategoryId = 5,
                            InterestCategoryName = "Literature"
                        });
                });

            modelBuilder.Entity("Affinity.Models.InterestSubCategory", b =>
                {
                    b.Property<int>("InterestSubCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InterestSubCategoryId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestCategoryId")
                        .HasColumnName("InterestCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("InterestSubCategoryName")
                        .IsRequired()
                        .HasColumnName("InterestSubCategoryName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("InterestSubCategoryId");

                    b.HasIndex("InterestCategoryId");

                    b.ToTable("InterestSubCategory");

                    b.HasData(
                        new
                        {
                            InterestSubCategoryId = 1,
                            InterestCategoryId = 1,
                            InterestSubCategoryName = "Rock"
                        },
                        new
                        {
                            InterestSubCategoryId = 2,
                            InterestCategoryId = 1,
                            InterestSubCategoryName = "Rap"
                        },
                        new
                        {
                            InterestSubCategoryId = 3,
                            InterestCategoryId = 1,
                            InterestSubCategoryName = "Classical"
                        },
                        new
                        {
                            InterestSubCategoryId = 4,
                            InterestCategoryId = 1,
                            InterestSubCategoryName = "Country"
                        },
                        new
                        {
                            InterestSubCategoryId = 5,
                            InterestCategoryId = 1,
                            InterestSubCategoryName = "Jazz"
                        },
                        new
                        {
                            InterestSubCategoryId = 6,
                            InterestCategoryId = 2,
                            InterestSubCategoryName = "Asian"
                        },
                        new
                        {
                            InterestSubCategoryId = 7,
                            InterestCategoryId = 2,
                            InterestSubCategoryName = "European"
                        },
                        new
                        {
                            InterestSubCategoryId = 8,
                            InterestCategoryId = 2,
                            InterestSubCategoryName = "North American"
                        },
                        new
                        {
                            InterestSubCategoryId = 9,
                            InterestCategoryId = 2,
                            InterestSubCategoryName = "South American"
                        },
                        new
                        {
                            InterestSubCategoryId = 10,
                            InterestCategoryId = 2,
                            InterestSubCategoryName = "African"
                        },
                        new
                        {
                            InterestSubCategoryId = 11,
                            InterestCategoryId = 3,
                            InterestSubCategoryName = "RPG"
                        },
                        new
                        {
                            InterestSubCategoryId = 12,
                            InterestCategoryId = 3,
                            InterestSubCategoryName = "Action"
                        },
                        new
                        {
                            InterestSubCategoryId = 13,
                            InterestCategoryId = 3,
                            InterestSubCategoryName = "Strategy"
                        },
                        new
                        {
                            InterestSubCategoryId = 14,
                            InterestCategoryId = 3,
                            InterestSubCategoryName = "Simulation"
                        },
                        new
                        {
                            InterestSubCategoryId = 15,
                            InterestCategoryId = 3,
                            InterestSubCategoryName = "Sandbox"
                        },
                        new
                        {
                            InterestSubCategoryId = 16,
                            InterestCategoryId = 4,
                            InterestSubCategoryName = "Basketball"
                        },
                        new
                        {
                            InterestSubCategoryId = 17,
                            InterestCategoryId = 4,
                            InterestSubCategoryName = "Hockey"
                        },
                        new
                        {
                            InterestSubCategoryId = 18,
                            InterestCategoryId = 4,
                            InterestSubCategoryName = "Soccer"
                        },
                        new
                        {
                            InterestSubCategoryId = 19,
                            InterestCategoryId = 4,
                            InterestSubCategoryName = "Football"
                        },
                        new
                        {
                            InterestSubCategoryId = 20,
                            InterestCategoryId = 4,
                            InterestSubCategoryName = "VolleyBall"
                        },
                        new
                        {
                            InterestSubCategoryId = 21,
                            InterestCategoryId = 5,
                            InterestSubCategoryName = "Sci Fi"
                        },
                        new
                        {
                            InterestSubCategoryId = 22,
                            InterestCategoryId = 5,
                            InterestSubCategoryName = "Fantasy"
                        },
                        new
                        {
                            InterestSubCategoryId = 23,
                            InterestCategoryId = 5,
                            InterestSubCategoryName = "Non-Fiction"
                        },
                        new
                        {
                            InterestSubCategoryId = 24,
                            InterestCategoryId = 5,
                            InterestSubCategoryName = "Fiction"
                        },
                        new
                        {
                            InterestSubCategoryId = 25,
                            InterestCategoryId = 5,
                            InterestSubCategoryName = "Historical"
                        });
                });

            modelBuilder.Entity("Affinity.Models.Interests", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("InterestId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestCategoryId")
                        .HasColumnName("InterestCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("InterestSubCategoryId")
                        .HasColumnName("InterestSubCategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("MatchesMatchId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("InterestId");

                    b.HasIndex("InterestCategoryId");

                    b.HasIndex("InterestSubCategoryId");

                    b.HasIndex("MatchesMatchId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("Affinity.Models.Matches", b =>
                {
                    b.Property<int>("MatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("MatchId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchedProfileId")
                        .HasColumnName("MatchedProfileId")
                        .HasColumnType("int");

                    b.Property<int>("ProfileId")
                        .HasColumnName("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("MatchId");

                    b.HasIndex("MatchedProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("Affinity.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Alcohol")
                        .HasColumnType("int");

                    b.Property<int>("Cigarettes")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnName("Description")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Discord")
                        .HasColumnName("Discord")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnName("Instagram")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Location")
                        .HasColumnName("Location")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int>("Marijuana")
                        .HasColumnType("int");

                    b.Property<string>("Occupation")
                        .HasColumnName("Occupation")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("ProfileName")
                        .IsRequired()
                        .HasColumnName("ProfileName")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Profile");
                });

            modelBuilder.Entity("Affinity.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "4bf82c07-349f-4e01-9eaf-95b151e48ea9",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "de1ea766-905c-4c9f-aeba-27ed6aa64f0d",
                            Name = "Member",
                            NormalizedName = "MEMBER"
                        });
                });

            modelBuilder.Entity("Affinity.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("AccountNum")
                        .IsRequired()
                        .HasColumnName("AccountNum")
                        .HasColumnType("varchar(36)")
                        .HasMaxLength(36)
                        .IsUnicode(false);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnName("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("varchar(128)")
                        .HasMaxLength(128)
                        .IsUnicode(false);

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            AccountNum = "8d6546f3-68d9-40eb-a71d-3f5bac4c30ab",
                            BirthDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "888e9793-d144-4efb-b7b9-6542440db7a5",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            Gender = "Other",
                            LockoutEnabled = false,
                            Name = "Admin",
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEPxvM6Y9wkiuTRR1ILPTyI2Sb19R8owyxFQykg2+bCxjv8Mt+Szk2GMj3DrmgkMsVw==",
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            AccountNum = "8f32d590-ade0-434d-8a30-8f74c0d6af16",
                            BirthDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ConcurrencyStamp = "bb15274f-dfff-4130-a18e-c8a6306df9cf",
                            Email = "user@user.com",
                            EmailConfirmed = true,
                            Gender = "Other",
                            LockoutEnabled = false,
                            Name = "User",
                            NormalizedEmail = "USER@USER.COM",
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEI1dE++EAaM5fijaCThW2I1czOmHbidM8R+soquDPfa5XmaL4LI367CFcb62sj/8BA==",
                            PhoneNumber = "555-555-5555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("Affinity.Models.UserRelationship", b =>
                {
                    b.Property<int>("UserRelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserRelationshipId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RelatedProfileId")
                        .HasColumnName("RelatedUserProfile")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("RelatingProfileId")
                        .HasColumnName("RelatingUserProfile")
                        .HasColumnType("int");

                    b.Property<int?>("RelatingUserId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Type")
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("UserRelationshipId");

                    b.HasIndex("RelatedProfileId");

                    b.HasIndex("RelatedUserId");

                    b.HasIndex("RelatingUserId");

                    b.HasIndex("RelatingProfileId", "RelatedProfileId")
                        .IsUnique();

                    b.ToTable("UserRelationship");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("RoleId");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "ProviderKey", "LoginProvider");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Affinity.Models.Event", b =>
                {
                    b.HasOne("Affinity.Models.Group", "Group")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Event_Created_User")
                        .IsRequired();
                });

            modelBuilder.Entity("Affinity.Models.EventGroup", b =>
                {
                    b.HasOne("Affinity.Models.Event", "Event")
                        .WithMany("EventGroups")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_Event_Group")
                        .IsRequired();

                    b.HasOne("Affinity.Models.Group", "Group")
                        .WithMany("JoinedEvents")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Group_Event")
                        .IsRequired();
                });

            modelBuilder.Entity("Affinity.Models.Image", b =>
                {
                    b.HasOne("Affinity.Models.Profile", "Profile")
                        .WithMany("Images")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Affinity.Models.InterestSubCategory", b =>
                {
                    b.HasOne("Affinity.Models.InterestCategory", "InterestCategory")
                        .WithMany("InterestSubCategories")
                        .HasForeignKey("InterestCategoryId")
                        .HasConstraintName("FK_Sub_InterestCategory")
                        .IsRequired();
                });

            modelBuilder.Entity("Affinity.Models.Interests", b =>
                {
                    b.HasOne("Affinity.Models.InterestCategory", "InterestCategory")
                        .WithMany()
                        .HasForeignKey("InterestCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Affinity.Models.InterestSubCategory", "InterestSubCategory")
                        .WithMany("Interests")
                        .HasForeignKey("InterestSubCategoryId")
                        .HasConstraintName("FK_Interest_SubCategory")
                        .IsRequired();

                    b.HasOne("Affinity.Models.Matches", null)
                        .WithMany("SharedInterests")
                        .HasForeignKey("MatchesMatchId");

                    b.HasOne("Affinity.Models.Profile", "Profile")
                        .WithMany("Interests")
                        .HasForeignKey("ProfileId")
                        .HasConstraintName("FK_Profile_Interests")
                        .IsRequired();
                });

            modelBuilder.Entity("Affinity.Models.Matches", b =>
                {
                    b.HasOne("Affinity.Models.Profile", "MatchedProfile")
                        .WithMany()
                        .HasForeignKey("MatchedProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Affinity.Models.Profile", "Profile")
                        .WithMany("Matches")
                        .HasForeignKey("ProfileId")
                        .HasConstraintName("FK_Profile_Matches")
                        .IsRequired();
                });

            modelBuilder.Entity("Affinity.Models.Profile", b =>
                {
                    b.HasOne("Affinity.Models.User", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Affinity.Models.Profile", "UserId")
                        .HasConstraintName("FK_Profile_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Affinity.Models.UserRelationship", b =>
                {
                    b.HasOne("Affinity.Models.Profile", "RelatedProfile")
                        .WithMany("RelatedRelationships")
                        .HasForeignKey("RelatedProfileId")
                        .HasConstraintName("FK_Profile_Related")
                        .IsRequired();

                    b.HasOne("Affinity.Models.User", "RelatedUser")
                        .WithMany()
                        .HasForeignKey("RelatedUserId");

                    b.HasOne("Affinity.Models.Profile", "RelatingProfile")
                        .WithMany("RelatingRelationships")
                        .HasForeignKey("RelatingProfileId")
                        .HasConstraintName("FK_Profile_Relating")
                        .IsRequired();

                    b.HasOne("Affinity.Models.User", "RelatingUser")
                        .WithMany()
                        .HasForeignKey("RelatingUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Affinity.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Affinity.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Affinity.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Affinity.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Affinity.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Affinity.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

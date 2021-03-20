using Affinity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Affinity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int>
    {
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Profile> Profile { get; set; }
        public virtual DbSet<Interests> Interests { get; set; }
        public virtual DbSet<InterestCategory> InterestCategory { get; set; }
        public virtual DbSet<InterestSubCategory> InterestSubCategory { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<UserRelationship> UserRelationships { get; set; }



        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MsSqlLocalDb;Database=Affinity;Trusted_Connection=True;");
            }
        }

        protected virtual void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new Role { Id = 2, Name = "Member", NormalizedName = "MEMBER" }
            );

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@admin.com",
                    NormalizedEmail = "ADMIN@ADMIN.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password1!"),
                    SecurityStamp = string.Empty,
                    AccountNum = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    Gender = "Other",
                    PhoneNumber = "555-555-5555",
                    BirthDate = new DateTime(1970, 01, 01)
                },
                new User
                {
                    Id = 2,
                    UserName = "user",
                    NormalizedUserName = "USER",
                    Email = "user@user.com",
                    NormalizedEmail = "USER@USER.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Password1!"),
                    SecurityStamp = string.Empty,
                    AccountNum = Guid.NewGuid().ToString(),
                    Name = "User",
                    Gender = "Other",
                    PhoneNumber = "555-555-5555",
                    BirthDate = new DateTime(1970, 01, 01)
                }
                //new User
                //{
                //    Id = 3,
                //    UserName = "profileA",
                //    NormalizedUserName = "PROFILEA",
                //    Email = "profileA@profileA.com",
                //    NormalizedEmail = "PROFILEA@PROFILEA.COM",
                //    EmailConfirmed = true,
                //    PasswordHash = hasher.HashPassword(null, "Password1!"),
                //    SecurityStamp = string.Empty,
                //    AccountNum = Guid.NewGuid().ToString(),
                //    Name = "ProfileA",
                //    Gender = "Other",
                //    PhoneNumber = "555-555-5555",
                //    BirthDate = new DateTime(1970, 01, 01)
                //},
                //new User
                //{
                //    Id = 4,
                //    UserName = "profileB",
                //    NormalizedUserName = "PROFILEB",
                //    Email = "profileB@profileB.com",
                //    NormalizedEmail = "PROFILEA@PROFILEA.COM",
                //    EmailConfirmed = true,
                //    PasswordHash = hasher.HashPassword(null, "Password1!"),
                //    SecurityStamp = string.Empty,
                //    AccountNum = Guid.NewGuid().ToString(),
                //    Name = "ProfileB",
                //    Gender = "Other",
                //    PhoneNumber = "555-555-5555",
                //    BirthDate = new DateTime(1970, 01, 01)
                //}
                );

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int> { RoleId = 2, UserId = 2 }
                );

            modelBuilder.Entity<InterestCategory>().HasData(

                new InterestCategory { InterestCategoryId = 1, InterestCategoryName = "Music" },

                new InterestCategory { InterestCategoryId = 2, InterestCategoryName = "Food" },

                new InterestCategory { InterestCategoryId = 3, InterestCategoryName = "Gaming"},

                new InterestCategory { InterestCategoryId = 4, InterestCategoryName = "Sports" },

                new InterestCategory { InterestCategoryId = 5, InterestCategoryName = "Literature" }

                );

            modelBuilder.Entity<InterestSubCategory>().HasData(

                new InterestSubCategory { InterestSubCategoryId = 1, InterestCategoryId = 1, InterestSubCategoryName ="Rock"},
                new InterestSubCategory { InterestSubCategoryId = 2, InterestCategoryId = 1, InterestSubCategoryName = "Rap" },
                new InterestSubCategory { InterestSubCategoryId = 3, InterestCategoryId = 1, InterestSubCategoryName = "Classical" },
                new InterestSubCategory { InterestSubCategoryId = 4, InterestCategoryId = 1, InterestSubCategoryName = "Country" },
                new InterestSubCategory { InterestSubCategoryId = 5, InterestCategoryId = 1, InterestSubCategoryName = "Jazz" },

                new InterestSubCategory { InterestSubCategoryId = 6, InterestCategoryId = 2, InterestSubCategoryName = "Asian" },
                new InterestSubCategory { InterestSubCategoryId = 7, InterestCategoryId = 2, InterestSubCategoryName = "European" },
                new InterestSubCategory { InterestSubCategoryId = 8, InterestCategoryId = 2, InterestSubCategoryName = "North American" },
                new InterestSubCategory { InterestSubCategoryId = 9, InterestCategoryId = 2, InterestSubCategoryName = "South American" },
                new InterestSubCategory { InterestSubCategoryId = 10, InterestCategoryId = 2, InterestSubCategoryName = "African" },

                new InterestSubCategory { InterestSubCategoryId = 11, InterestCategoryId = 3, InterestSubCategoryName = "RPG" },
                new InterestSubCategory { InterestSubCategoryId = 12, InterestCategoryId = 3, InterestSubCategoryName = "Action" },
                new InterestSubCategory { InterestSubCategoryId = 13, InterestCategoryId = 3, InterestSubCategoryName = "Strategy" },
                new InterestSubCategory { InterestSubCategoryId = 14, InterestCategoryId = 3, InterestSubCategoryName = "Simulation" },
                new InterestSubCategory { InterestSubCategoryId = 15, InterestCategoryId = 3, InterestSubCategoryName = "Sandbox" },

                new InterestSubCategory { InterestSubCategoryId = 16, InterestCategoryId = 4, InterestSubCategoryName = "Basketball" },
                new InterestSubCategory { InterestSubCategoryId = 17, InterestCategoryId = 4, InterestSubCategoryName = "Hockey" },
                new InterestSubCategory { InterestSubCategoryId = 18, InterestCategoryId = 4, InterestSubCategoryName = "Soccer" },
                new InterestSubCategory { InterestSubCategoryId = 19, InterestCategoryId = 4, InterestSubCategoryName = "Football" },
                new InterestSubCategory { InterestSubCategoryId = 20, InterestCategoryId = 4, InterestSubCategoryName = "VolleyBall" },

                new InterestSubCategory { InterestSubCategoryId = 21, InterestCategoryId = 5, InterestSubCategoryName = "Sci Fi" },
                new InterestSubCategory { InterestSubCategoryId = 22, InterestCategoryId = 5, InterestSubCategoryName = "Fantasy" },
                new InterestSubCategory { InterestSubCategoryId = 23, InterestCategoryId = 5, InterestSubCategoryName = "Non-Fiction" },
                new InterestSubCategory { InterestSubCategoryId = 24, InterestCategoryId = 5, InterestSubCategoryName = "Fiction" },
                new InterestSubCategory { InterestSubCategoryId = 25, InterestCategoryId = 5, InterestSubCategoryName = "Historical" }

                );

            //modelBuilder.Entity<Interests>().HasData(
            //    new Interests { InterestId = 1, InterestCategoryId = 1, InterestSubCategoryId = 1, ProfileId = 1 },
            //    new Interests { InterestId = 2, InterestCategoryId = 2, InterestSubCategoryId = 6, ProfileId = 1 },
            //    new Interests { InterestId = 3, InterestCategoryId = 3, InterestSubCategoryId = 11, ProfileId = 1 },
            //    new Interests { InterestId = 4, InterestCategoryId = 1, InterestSubCategoryId = 1, ProfileId = 2 },
            //    new Interests { InterestId = 5, InterestCategoryId = 2, InterestSubCategoryId = 6, ProfileId = 2 },
            //    new Interests { InterestId = 6, InterestCategoryId = 3, InterestSubCategoryId = 11, ProfileId = 2 },
            //    new Interests { InterestId = 7, InterestCategoryId = 1, InterestSubCategoryId = 2, ProfileId = 3 },
            //    new Interests { InterestId = 8, InterestCategoryId = 2, InterestSubCategoryId = 7, ProfileId = 3 },
            //    new Interests { InterestId = 9, InterestCategoryId = 3, InterestSubCategoryId = 12, ProfileId = 3 }
            //    );

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("Id").UseIdentityColumn();

                entity.Property(e => e.AccountNum).HasColumnName("AccountNum")
                    .IsRequired()
                    .HasColumnName("AccountNum")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate)
                    .HasColumnName("BirthDate")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnName("Gender");

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            modelBuilder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
                entity.HasKey(key => new { key.UserId, key.RoleId });
            });

            modelBuilder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
                entity.HasKey(key => new { key.UserId });
            });

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
                entity.HasKey(key => new { key.UserId, key.ProviderKey, key.LoginProvider });
            });

            modelBuilder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
                entity.HasKey(key => new { key.RoleId });
            });

            modelBuilder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
                entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.ToTable("Image");

                entity.Property(p => p.ProfileId).HasColumnName("ProfileId");

                entity.Property(p => p.ImageURL).HasColumnName("ImageURL");

            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.ToTable("Profile");

                entity.Property(e => e.ProfileName).HasColumnName("ProfileName")
                    .IsRequired()
                    .HasColumnName("ProfileName")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnName("Description")
                    .IsRequired(false)
                    .HasColumnName("Description")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Occupation).HasColumnName("Occupation")
                    .IsRequired(false)
                    .HasColumnName("Occupation")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Location).HasColumnName("Location")
                    .IsRequired(false)
                    .HasColumnName("Location")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Discord).HasColumnName("Discord")
                    .IsRequired(false)
                    .HasColumnName("Discord")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Instagram).HasColumnName("Instagram")
                    .IsRequired(false)
                    .HasColumnName("Instagram")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                modelBuilder.Entity<Profile>()
                    .HasOne(u => u.User)
                    .WithOne(p => p.Profile)
                    .HasForeignKey<Profile>(p => p.UserId)
                    .HasConstraintName("FK_Profile_User");

            });

            modelBuilder.Entity<InterestCategory>(entity =>
            {
                entity.HasKey(e => e.InterestCategoryId);

                entity.ToTable("InterestCategory");

                entity.Property(e => e.InterestCategoryId).HasColumnName("InterestCategoryId").UseIdentityColumn();

                entity.Property(e => e.InterestCategoryName).HasColumnName("InterestCategoryName")
                    .IsRequired()
                    .HasColumnName("InterestCategoryName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InterestSubCategory>(entity =>
            {
                entity.HasKey(e => e.InterestSubCategoryId);

                entity.ToTable("InterestSubCategory");

                entity.Property(e => e.InterestSubCategoryId).HasColumnName("InterestSubCategoryId").UseIdentityColumn();

                entity.Property(e => e.InterestCategoryId).HasColumnName("InterestCategoryId");

                entity.HasOne(e => e.InterestCategory)
                    .WithMany(p => p.InterestSubCategories)
                    .HasForeignKey(d => d.InterestCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sub_InterestCategory");

                entity.Property(e => e.InterestSubCategoryName).HasColumnName("InterestSubCategoryName")
                    .IsRequired()
                    .HasColumnName("InterestSubCategoryName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Interests>(entity =>
            {
                entity.HasKey(e => e.InterestId);

                entity.ToTable("Interests");

                entity.Property(e => e.InterestId).HasColumnName("InterestId").UseIdentityColumn();

                entity.Property(e => e.InterestCategoryId).HasColumnName("InterestCategoryId");

                entity.Property(e => e.InterestSubCategoryId).HasColumnName("InterestSubCategoryId");

                entity.HasOne(e => e.InterestSubCategory)
                      .WithMany(p => p.Interests)
                      .HasForeignKey(d => d.InterestSubCategoryId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Interest_SubCategory");

                   entity.HasOne(d => d.Profile)
                        .WithMany(p => p.Interests)
                        .HasForeignKey(d => d.ProfileId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Profile_Interests");

            });

            modelBuilder.Entity<Matches>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.ToTable("Matches");

                entity.Property(e => e.MatchId).HasColumnName("MatchId").UseIdentityColumn();

                entity.Property(e => e.ProfileId).HasColumnName("ProfileId")
                .IsRequired();

                entity.Property(e => e.MatchedProfileId).HasColumnName("MatchedProfileId")
                .IsRequired();

                entity.HasOne(e => e.Profile)
                      .WithMany(p => p.Matches)
                      .HasForeignKey(d => d.ProfileId)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Profile_Matches");
            });

            modelBuilder.Entity<UserRelationship>(entity =>
            {
                entity.HasKey(e => e.UserRelationshipId);

                entity.ToTable("UserRelationship");

                entity.Property(p => p.UserRelationshipId).HasColumnName("UserRelationshipId").UseIdentityColumn();

                entity.Property(e => e.RelatingProfileId).HasColumnName("RelatingUserProfile")
                    .IsRequired();

                entity.Property(e => e.RelatedProfileId).HasColumnName("RelatedUserProfile")
                    .IsRequired();

                entity.Property(e => e.Type).HasColumnName("Type")
                    .IsRequired()
                    .HasDefaultValue(Relationship.Pending);

                entity.HasIndex(b => new { b.RelatingProfileId, b.RelatedProfileId })
                    .IsUnique();

                entity.HasOne(d => d.RelatingProfile)
                    .WithMany(p => p.RelatingRelationships)
                    .HasForeignKey(d => d.RelatingProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profile_Relating");

                entity.HasOne(d => d.RelatedProfile)
                    .WithMany(p => p.RelatedRelationships)
                    .HasForeignKey(d => d.RelatedProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Profile_Related");
            });

            Seed(modelBuilder);
        } 
    }
}
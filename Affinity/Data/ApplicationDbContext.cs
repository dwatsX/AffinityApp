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
                });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 1, UserId = 1 },
                new IdentityUserRole<int> { RoleId = 2, UserId = 2 }
            );
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

            Seed(modelBuilder);
        }
    }
}

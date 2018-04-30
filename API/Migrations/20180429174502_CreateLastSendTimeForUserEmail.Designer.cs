﻿// <auto-generated />
using Aiursoft.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Aiursoft.API.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20180429174502_CreateLastSendTimeForUserEmail")]
    partial class CreateLastSendTimeForUserEmail
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aiursoft.API.Models.AccessToken", b =>
                {
                    b.Property<int>("AccessTokenId")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("AliveTime");

                    b.Property<string>("ApplyAppId");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Value");

                    b.HasKey("AccessTokenId");

                    b.ToTable("AccessToken");
                });

            modelBuilder.Entity("Aiursoft.API.Models.APIUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("AccountCreateTime");

                    b.Property<string>("Bio");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("HeadImgUrl");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NickName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PreferedLanguage");

                    b.Property<string>("SMSPasswordResetToken");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Sex");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Aiursoft.API.Models.AppGrant", b =>
                {
                    b.Property<int>("AppGrantId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("APIUserId");

                    b.Property<string>("AppID");

                    b.Property<DateTime>("GrantTime");

                    b.HasKey("AppGrantId");

                    b.HasIndex("APIUserId");

                    b.ToTable("LocalAppGrant");
                });

            modelBuilder.Entity("Aiursoft.API.Models.OAuthPack", b =>
                {
                    b.Property<int>("OAuthPackId")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("AliveTime");

                    b.Property<string>("ApplyAppId");

                    b.Property<int>("Code");

                    b.Property<DateTime>("CreateTime");

                    b.Property<bool>("IsUsed");

                    b.Property<string>("UserId");

                    b.HasKey("OAuthPackId");

                    b.HasIndex("UserId");

                    b.ToTable("OAuthPack");
                });

            modelBuilder.Entity("Aiursoft.API.Models.UserEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<DateTime>("LastSendTime");

                    b.Property<string>("OwnerId");

                    b.Property<string>("ValidateToken");

                    b.Property<bool>("Validated");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("UserEmails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Aiursoft.API.Models.AppGrant", b =>
                {
                    b.HasOne("Aiursoft.API.Models.APIUser", "User")
                        .WithMany("GrantedApps")
                        .HasForeignKey("APIUserId");
                });

            modelBuilder.Entity("Aiursoft.API.Models.OAuthPack", b =>
                {
                    b.HasOne("Aiursoft.API.Models.APIUser", "User")
                        .WithMany("Packs")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Aiursoft.API.Models.UserEmail", b =>
                {
                    b.HasOne("Aiursoft.API.Models.APIUser", "Owner")
                        .WithMany("Emails")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Aiursoft.API.Models.APIUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Aiursoft.API.Models.APIUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Aiursoft.API.Models.APIUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Aiursoft.API.Models.APIUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
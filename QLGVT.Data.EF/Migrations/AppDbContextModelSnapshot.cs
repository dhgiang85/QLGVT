﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using QLGVT.Data.EF;
using QLGVT.Data.Enums;
using System;

namespace QLGVT.Data.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAlternateKey("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAlternateKey("RoleId", "UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.HasAlternateKey("UserId");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Description")
                        .HasMaxLength(250);

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

            modelBuilder.Entity("QLGVT.Data.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Avatar");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime?>("BirthDay");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("Status");

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

            modelBuilder.Entity("QLGVT.Data.Entities.Benxe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<int>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Benxes");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.DangkyTuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DonviVantaiId");

                    b.Property<int>("Status");

                    b.Property<int>("TuyenId");

                    b.HasKey("Id");

                    b.HasIndex("DonviVantaiId");

                    b.HasIndex("TuyenId");

                    b.ToTable("DangkyTuyens");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.DonviVantai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Diachi")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("GPKinhdoanh")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("LHKinhdoanh");

                    b.Property<string>("SeoAlias");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoPageTitle");

                    b.Property<int>("Status");

                    b.Property<string>("Ten")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("DonviVantais");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.Footer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Content")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Footers");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.Function", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(128)");

                    b.Property<string>("IconCss");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ParentId")
                        .HasMaxLength(128);

                    b.Property<int>("SortOrder");

                    b.Property<int>("Status");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CanCreate");

                    b.Property<bool>("CanDelete");

                    b.Property<bool>("CanRead");

                    b.Property<bool>("CanUpdate");

                    b.Property<string>("FunctionId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.Slide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Description")
                        .HasMaxLength(250);

                    b.Property<int?>("DisplayOrder");

                    b.Property<string>("GroupAlias")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("Status");

                    b.Property<string>("Url")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.SystemConfig", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<int>("Status");

                    b.Property<string>("Value1");

                    b.Property<int?>("Value2");

                    b.Property<bool?>("Value3");

                    b.Property<DateTime?>("Value4");

                    b.Property<decimal?>("Value5");

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("QLGVT.Data.Entities.Tuyen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("DiemdenId");

                    b.Property<int>("Khoangcach");

                    b.Property<int>("Status");

                    b.Property<int>("XuatphatId");

                    b.HasKey("Id");

                    b.HasIndex("DiemdenId");

                    b.HasIndex("XuatphatId");

                    b.ToTable("Tuyens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QLGVT.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QLGVT.Data.Entities.DangkyTuyen", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.DonviVantai", "DonviVantai")
                        .WithMany("DangkyTuyens")
                        .HasForeignKey("DonviVantaiId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QLGVT.Data.Entities.Tuyen", "Tuyen")
                        .WithMany()
                        .HasForeignKey("TuyenId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QLGVT.Data.Entities.Permission", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QLGVT.Data.Entities.AppRole", "AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QLGVT.Data.Entities.Tuyen", b =>
                {
                    b.HasOne("QLGVT.Data.Entities.Benxe", "Diemden")
                        .WithMany()
                        .HasForeignKey("DiemdenId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QLGVT.Data.Entities.Benxe", "Xuatphat")
                        .WithMany()
                        .HasForeignKey("XuatphatId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}

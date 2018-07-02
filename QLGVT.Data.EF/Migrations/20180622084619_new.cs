using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QLGVT.Data.EF.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    BirthDay = table.Column<DateTime>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Benxes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Ten = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DonviVantais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Diachi = table.Column<string>(maxLength: 255, nullable: false),
                    GPKinhdoanh = table.Column<string>(maxLength: 50, nullable: false),
                    LHKinhdoanh = table.Column<int>(nullable: false),
                    SeoAlias = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoPageTitle = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Ten = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonviVantais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Functions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    IconCss = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ParentId = table.Column<string>(maxLength: 128, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    URL = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Functions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KekhaiGiaRates",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", nullable: false),
                    CPBHRate = table.Column<decimal>(nullable: false),
                    CPKHTBRate = table.Column<decimal>(nullable: false),
                    CPNCTTRate = table.Column<decimal>(nullable: false),
                    CPNLRate = table.Column<decimal>(nullable: false),
                    CPQLRate = table.Column<decimal>(nullable: false),
                    CPSXCTRate = table.Column<decimal>(nullable: false),
                    CPSXKDDTRate = table.Column<decimal>(nullable: false),
                    CPTCRate = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    SLTGRate = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KekhaiGiaRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    GroupAlias = table.Column<string>(maxLength: 25, nullable: false),
                    Image = table.Column<string>(maxLength: 250, nullable: false),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemConfigs",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Value1 = table.Column<string>(nullable: true),
                    Value2 = table.Column<int>(nullable: true),
                    Value3 = table.Column<bool>(nullable: true),
                    Value4 = table.Column<DateTime>(nullable: true),
                    Value5 = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.UniqueConstraint("AK_AspNetUserLogins_UserId", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.UniqueConstraint("AK_AspNetUserRoles_RoleId_UserId", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.UniqueConstraint("AK_AspNetUserTokens_UserId", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tuyens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DiemdenId = table.Column<int>(nullable: false),
                    Khoangcach = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    XuatphatId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tuyens_Benxes_DiemdenId",
                        column: x => x.DiemdenId,
                        principalTable: "Benxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tuyens_Benxes_XuatphatId",
                        column: x => x.XuatphatId,
                        principalTable: "Benxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanCreate = table.Column<bool>(nullable: false),
                    CanDelete = table.Column<bool>(nullable: false),
                    CanRead = table.Column<bool>(nullable: false),
                    CanUpdate = table.Column<bool>(nullable: false),
                    FunctionId = table.Column<string>(maxLength: 128, nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_Functions_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "Functions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DangkyTuyens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DonviVantaiId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 128, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TuyenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangkyTuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DangkyTuyens_DonviVantais_DonviVantaiId",
                        column: x => x.DonviVantaiId,
                        principalTable: "DonviVantais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangkyTuyens_Tuyens_TuyenId",
                        column: x => x.TuyenId,
                        principalTable: "Tuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KekhaiGias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CPBH = table.Column<decimal>(nullable: false),
                    CPBHRate = table.Column<decimal>(nullable: true),
                    CPKHTB = table.Column<decimal>(nullable: false),
                    CPKHTBRate = table.Column<decimal>(nullable: true),
                    CPNCTT = table.Column<decimal>(nullable: false),
                    CPNCTTRate = table.Column<decimal>(nullable: true),
                    CPNL = table.Column<decimal>(nullable: false),
                    CPNLRate = table.Column<decimal>(nullable: true),
                    CPQL = table.Column<decimal>(nullable: false),
                    CPQLRate = table.Column<decimal>(nullable: true),
                    CPSXC = table.Column<decimal>(nullable: false),
                    CPSXCRate = table.Column<decimal>(nullable: true),
                    CPSXKDDT = table.Column<decimal>(nullable: false),
                    CPSXKDDTRate = table.Column<decimal>(nullable: true),
                    CPTC = table.Column<decimal>(nullable: false),
                    CPTCRate = table.Column<decimal>(nullable: true),
                    DangkyTuyenId = table.Column<int>(nullable: false),
                    DateAccepted = table.Column<DateTime>(nullable: false),
                    DateApplied = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    GiathanhVe = table.Column<decimal>(nullable: false),
                    KekhaiGiaStatus = table.Column<int>(nullable: false),
                    LoinhuanDukien = table.Column<decimal>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    SLTG = table.Column<decimal>(nullable: false),
                    SLTGRate = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KekhaiGias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KekhaiGias_DangkyTuyens_DangkyTuyenId",
                        column: x => x.DangkyTuyenId,
                        principalTable: "DangkyTuyens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DangkyTuyens_DonviVantaiId",
                table: "DangkyTuyens",
                column: "DonviVantaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DangkyTuyens_TuyenId",
                table: "DangkyTuyens",
                column: "TuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_KekhaiGias_DangkyTuyenId",
                table: "KekhaiGias",
                column: "DangkyTuyenId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_FunctionId",
                table: "Permissions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_RoleId",
                table: "Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuyens_DiemdenId",
                table: "Tuyens",
                column: "DiemdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tuyens_XuatphatId",
                table: "Tuyens",
                column: "XuatphatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "KekhaiGiaRates");

            migrationBuilder.DropTable(
                name: "KekhaiGias");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "SystemConfigs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DangkyTuyens");

            migrationBuilder.DropTable(
                name: "Functions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DonviVantais");

            migrationBuilder.DropTable(
                name: "Tuyens");

            migrationBuilder.DropTable(
                name: "Benxes");
        }
    }
}

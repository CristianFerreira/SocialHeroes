using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialHeroes.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(type: "Varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Color = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "Varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hairs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InstitutionUserId = table.Column<Guid>(nullable: false),
                    DateNotification = table.Column<DateTime>(nullable: false),
                    EnableRequestOnPage = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialNotificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialNotificationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(maxLength: 128, nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
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
                    UserStatus = table.Column<int>(nullable: false),
                    UserType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: false),
                    BloodId = table.Column<Guid>(nullable: false),
                    AmountBlood = table.Column<int>(nullable: false),
                    Actived = table.Column<bool>(nullable: false),
                    ShareOnFacebook = table.Column<bool>(nullable: false),
                    ShareOnLinkedin = table.Column<bool>(nullable: false),
                    ShareOnTwitter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodNotifications_Bloods_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Bloods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreastMilkNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: false),
                    AmountBreastMilk = table.Column<int>(nullable: false),
                    Actived = table.Column<bool>(nullable: false),
                    ShareOnFacebook = table.Column<bool>(nullable: false),
                    ShareOnLinkedin = table.Column<bool>(nullable: false),
                    ShareOnTwitter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreastMilkNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreastMilkNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: false),
                    HairId = table.Column<Guid>(nullable: false),
                    AmountHair = table.Column<int>(nullable: false),
                    Actived = table.Column<bool>(nullable: false),
                    ShareOnFacebook = table.Column<bool>(nullable: false),
                    ShareOnLinkedin = table.Column<bool>(nullable: false),
                    ShareOnTwitter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HairNotifications_Hairs_HairId",
                        column: x => x.HairId,
                        principalTable: "Hairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HairNotifications_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Complement = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    District = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18, 9)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18, 9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    CellPhone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    LastDonatedBlood = table.Column<DateTime>(nullable: true),
                    LastDonatedHair = table.Column<DateTime>(nullable: true),
                    LastDonatedBreastMilk = table.Column<DateTime>(nullable: true),
                    LastBloodNotification = table.Column<DateTime>(nullable: true),
                    LastHairNotification = table.Column<DateTime>(nullable: true),
                    LastBreastMilkNotification = table.Column<DateTime>(nullable: true),
                    ActivedBloodNotification = table.Column<bool>(nullable: false),
                    ActivedHairNotification = table.Column<bool>(nullable: false),
                    ActivedBreastMilkNotification = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BloodId = table.Column<Guid>(nullable: true),
                    HairId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonatorUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUsers_Bloods_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Bloods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUsers_Hairs_HairId",
                        column: x => x.HairId,
                        principalTable: "Hairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstitutionUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SocialReason = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FantasyName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstitutionUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstitutionUsers_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstitutionUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationTypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotificationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotificationTypes_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotificationTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialNotificationTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SocialNotificationTypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialNotificationTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocialNotificationTypes_SocialNotificationTypes_SocialNotificationTypeId",
                        column: x => x.SocialNotificationTypeId,
                        principalTable: "SocialNotificationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSocialNotificationTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUserBloodNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DonatorUserId = table.Column<Guid>(nullable: false),
                    BloodNotificationId = table.Column<Guid>(nullable: false),
                    Appear = table.Column<bool>(nullable: false),
                    DateAppeared = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonatorUserBloodNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUserBloodNotifications_BloodNotifications_BloodNotificationId",
                        column: x => x.BloodNotificationId,
                        principalTable: "BloodNotifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUserBloodNotifications_DonatorUsers_DonatorUserId",
                        column: x => x.DonatorUserId,
                        principalTable: "DonatorUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUserBreastMilkNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DonatorUserId = table.Column<Guid>(nullable: false),
                    BreastMilkNotificationId = table.Column<Guid>(nullable: false),
                    Appear = table.Column<bool>(nullable: false),
                    DateAppeared = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonatorUserBreastMilkNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUserBreastMilkNotifications_BreastMilkNotifications_BreastMilkNotificationId",
                        column: x => x.BreastMilkNotificationId,
                        principalTable: "BreastMilkNotifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUserBreastMilkNotifications_DonatorUsers_DonatorUserId",
                        column: x => x.DonatorUserId,
                        principalTable: "DonatorUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUserHairNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DonatorUserId = table.Column<Guid>(nullable: false),
                    HairNotificationId = table.Column<Guid>(nullable: false),
                    Appear = table.Column<bool>(nullable: false),
                    DateAppeared = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonatorUserHairNotifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUserHairNotifications_DonatorUsers_DonatorUserId",
                        column: x => x.DonatorUserId,
                        principalTable: "DonatorUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUserHairNotifications_HairNotifications_HairNotificationId",
                        column: x => x.HairNotificationId,
                        principalTable: "HairNotifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InstitutionUserId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_InstitutionUsers_InstitutionUserId",
                        column: x => x.InstitutionUserId,
                        principalTable: "InstitutionUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_UserId",
                table: "Adresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodNotifications_BloodId",
                table: "BloodNotifications",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodNotifications_NotificationId",
                table: "BloodNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloods_Type",
                table: "Bloods",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreastMilkNotifications_NotificationId",
                table: "BreastMilkNotifications",
                column: "NotificationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBloodNotifications_BloodNotificationId",
                table: "DonatorUserBloodNotifications",
                column: "BloodNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBloodNotifications_DonatorUserId",
                table: "DonatorUserBloodNotifications",
                column: "DonatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBreastMilkNotifications_BreastMilkNotificationId",
                table: "DonatorUserBreastMilkNotifications",
                column: "BreastMilkNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBreastMilkNotifications_DonatorUserId",
                table: "DonatorUserBreastMilkNotifications",
                column: "DonatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserHairNotifications_DonatorUserId",
                table: "DonatorUserHairNotifications",
                column: "DonatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserHairNotifications_HairNotificationId",
                table: "DonatorUserHairNotifications",
                column: "HairNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUsers_BloodId",
                table: "DonatorUsers",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUsers_HairId",
                table: "DonatorUsers",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUsers_UserId",
                table: "DonatorUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HairNotifications_HairId",
                table: "HairNotifications",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_HairNotifications_NotificationId",
                table: "HairNotifications",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hairs_Color_Type",
                table: "Hairs",
                columns: new[] { "Color", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionUsers_NotificationId",
                table: "InstitutionUsers",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_InstitutionUsers_UserId",
                table: "InstitutionUsers",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_InstitutionUserId",
                table: "Phones",
                column: "InstitutionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationTypes_NotificationTypeId",
                table: "UserNotificationTypes",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationTypes_UserId",
                table: "UserNotificationTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialNotificationTypes_SocialNotificationTypeId",
                table: "UserSocialNotificationTypes",
                column: "SocialNotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialNotificationTypes_UserId",
                table: "UserSocialNotificationTypes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "DonatorUserBloodNotifications");

            migrationBuilder.DropTable(
                name: "DonatorUserBreastMilkNotifications");

            migrationBuilder.DropTable(
                name: "DonatorUserHairNotifications");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserNotificationTypes");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserSocialNotificationTypes");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "BloodNotifications");

            migrationBuilder.DropTable(
                name: "BreastMilkNotifications");

            migrationBuilder.DropTable(
                name: "DonatorUsers");

            migrationBuilder.DropTable(
                name: "HairNotifications");

            migrationBuilder.DropTable(
                name: "InstitutionUsers");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SocialNotificationTypes");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropTable(
                name: "Hairs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

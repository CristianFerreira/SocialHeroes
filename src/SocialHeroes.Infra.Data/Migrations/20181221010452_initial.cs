using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SocialHeroes.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blood",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(type: "Varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hair",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Color = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Type = table.Column<string>(type: "Varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hair", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
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
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaim<Guid>",
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
                    table.PrimaryKey("PK_IdentityRoleClaim<Guid>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<Guid>_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Complement = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Street = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18, 9)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18, 9)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    CellPhone = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Genre = table.Column<int>(nullable: false),
                    DateBirth = table.Column<DateTime>(nullable: false),
                    LastDonation = table.Column<DateTime>(nullable: true),
                    ActivedBloodNotification = table.Column<bool>(nullable: false),
                    ActivedHairNotification = table.Column<bool>(nullable: false),
                    ActivedBreastMilkNotification = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    HairId = table.Column<Guid>(nullable: true),
                    BloodId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonatorUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUser_Blood_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Blood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUser_Hair_HairId",
                        column: x => x.HairId,
                        principalTable: "Hair",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HospitalUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SocialReason = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FantasyName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalUser_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim<Guid>",
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
                    table.PrimaryKey("PK_IdentityUserClaim<Guid>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<Guid>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin<Guid>",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<Guid>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<Guid>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<Guid>",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<Guid>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<Guid>_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<Guid>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken<Guid>",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken<Guid>", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_IdentityUserToken<Guid>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserNotificationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    NotificationTypeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotificationType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotificationType_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "NotificationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserNotificationType_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HospitalUserId = table.Column<Guid>(nullable: false),
                    DateNotification = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_HospitalUser_HospitalUserId",
                        column: x => x.HospitalUserId,
                        principalTable: "HospitalUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HospitalUserId = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_HospitalUser_HospitalUserId",
                        column: x => x.HospitalUserId,
                        principalTable: "HospitalUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BloodNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: false),
                    BloodId = table.Column<Guid>(nullable: false),
                    AmountBlood = table.Column<int>(nullable: false),
                    Actived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodNotification_Blood_BloodId",
                        column: x => x.BloodId,
                        principalTable: "Blood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BloodNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BreastMilkNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: false),
                    AmountBreastMilk = table.Column<int>(nullable: false),
                    Actived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreastMilkNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreastMilkNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HairNotification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NotificationId = table.Column<Guid>(nullable: false),
                    HairId = table.Column<Guid>(nullable: false),
                    AmountHair = table.Column<int>(nullable: false),
                    Actived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HairNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HairNotification_Hair_HairId",
                        column: x => x.HairId,
                        principalTable: "Hair",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HairNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUserBloodNotification",
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
                    table.PrimaryKey("PK_DonatorUserBloodNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUserBloodNotification_BloodNotification_BloodNotificationId",
                        column: x => x.BloodNotificationId,
                        principalTable: "BloodNotification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUserBloodNotification_DonatorUser_DonatorUserId",
                        column: x => x.DonatorUserId,
                        principalTable: "DonatorUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUserBreastMilkNotification",
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
                    table.PrimaryKey("PK_DonatorUserBreastMilkNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUserBreastMilkNotification_BreastMilkNotification_BreastMilkNotificationId",
                        column: x => x.BreastMilkNotificationId,
                        principalTable: "BreastMilkNotification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUserBreastMilkNotification_DonatorUser_DonatorUserId",
                        column: x => x.DonatorUserId,
                        principalTable: "DonatorUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DonatorUserHairNotification",
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
                    table.PrimaryKey("PK_DonatorUserHairNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DonatorUserHairNotification_DonatorUser_DonatorUserId",
                        column: x => x.DonatorUserId,
                        principalTable: "DonatorUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DonatorUserHairNotification_HairNotification_HairNotificationId",
                        column: x => x.HairNotificationId,
                        principalTable: "HairNotification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Blood_Type",
                table: "Blood",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BloodNotification_BloodId",
                table: "BloodNotification",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodNotification_NotificationId",
                table: "BloodNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_BreastMilkNotification_NotificationId",
                table: "BreastMilkNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUser_BloodId",
                table: "DonatorUser",
                column: "BloodId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUser_HairId",
                table: "DonatorUser",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUser_UserId",
                table: "DonatorUser",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBloodNotification_BloodNotificationId",
                table: "DonatorUserBloodNotification",
                column: "BloodNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBloodNotification_DonatorUserId",
                table: "DonatorUserBloodNotification",
                column: "DonatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBreastMilkNotification_BreastMilkNotificationId",
                table: "DonatorUserBreastMilkNotification",
                column: "BreastMilkNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserBreastMilkNotification_DonatorUserId",
                table: "DonatorUserBreastMilkNotification",
                column: "DonatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserHairNotification_DonatorUserId",
                table: "DonatorUserHairNotification",
                column: "DonatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DonatorUserHairNotification_HairNotificationId",
                table: "DonatorUserHairNotification",
                column: "HairNotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hair_Color_Type",
                table: "Hair",
                columns: new[] { "Color", "Type" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HairNotification_HairId",
                table: "HairNotification",
                column: "HairId");

            migrationBuilder.CreateIndex(
                name: "IX_HairNotification_NotificationId",
                table: "HairNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalUser_UserId",
                table: "HospitalUser",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleClaim<Guid>_RoleId",
                table: "IdentityRoleClaim<Guid>",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaim<Guid>_UserId",
                table: "IdentityUserClaim<Guid>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserLogin<Guid>_UserId",
                table: "IdentityUserLogin<Guid>",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole<Guid>_RoleId",
                table: "IdentityUserRole<Guid>",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_HospitalUserId",
                table: "Notification",
                column: "HospitalUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Phone_HospitalUserId",
                table: "Phone",
                column: "HospitalUserId");

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
                name: "IX_UserNotificationType_NotificationTypeId",
                table: "UserNotificationType",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotificationType_UserId",
                table: "UserNotificationType",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "DonatorUserBloodNotification");

            migrationBuilder.DropTable(
                name: "DonatorUserBreastMilkNotification");

            migrationBuilder.DropTable(
                name: "DonatorUserHairNotification");

            migrationBuilder.DropTable(
                name: "IdentityRoleClaim<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<Guid>");

            migrationBuilder.DropTable(
                name: "IdentityUserToken<Guid>");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "UserNotificationType");

            migrationBuilder.DropTable(
                name: "BloodNotification");

            migrationBuilder.DropTable(
                name: "BreastMilkNotification");

            migrationBuilder.DropTable(
                name: "DonatorUser");

            migrationBuilder.DropTable(
                name: "HairNotification");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "NotificationType");

            migrationBuilder.DropTable(
                name: "Blood");

            migrationBuilder.DropTable(
                name: "Hair");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "HospitalUser");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

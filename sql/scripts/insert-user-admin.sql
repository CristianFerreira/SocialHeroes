USE [socialheroes]
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'57754217-2df4-4d7c-a88f-435fbf0dec0e', N'admin@admin.com.br', N'ADMIN@ADMIN.COM.BR', N'admin@admin.com.br', N'ADMIN@ADMIN.COM.BR', 1, N'AQAAAAEAACcQAAAAEIM/oOPGMUccvxdS6g3xDrv8NqNwGWIEAs1M5iABUaljK78Q2hAZ7x9psYqN4B65zg==', N'4VR5IIWX42SD56AEQYJRSVEXW2HVXPJV', N'115f87bc-396b-45d2-9869-09d24e7a12fc', NULL, 0, 0, NULL, 1, 0, 2, 3)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'57754217-2df4-4d7c-a88f-435fbf0dec0e', N'80768c8a-6f2e-47c5-53c9-08d70a3d1473')
GO


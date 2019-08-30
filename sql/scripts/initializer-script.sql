USE [socialheroes]
GO

-- ADICIONANDO ROLES

INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'80768c8a-6f2e-47c5-53c9-08d70a3d1473', N'Admin', N'ADMIN', N'0c1a5f25-f785-461f-b268-06df465966fd')
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'31e1f4d4-f4ce-4926-53ca-08d70a3d1473', N'Institution', N'INSTITUTION', N'0422f8ca-6406-425d-a41c-2d851760fb40')
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'9b821f0e-2811-4f3b-53cb-08d70a3d1473', N'Donator', N'DONATOR', N'483926ab-11bc-4c1a-a0fc-dcc51e13c2b9')
GO

-- ADICIONANDO SANGUES

INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'dfa8498c-2e78-4d5f-986c-8592a117898c', N'A-')
GO
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'92dac864-6429-4ff0-a362-f65fef77921c', N'A+')
GO
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'6d59b1af-47f5-4fe8-9f8d-a6093b849963', N'AB-')
GO
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'1a5dc0ba-6212-48ec-bc63-198af67f9fac', N'AB+')
GO
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'9fc69a50-5bc4-4aa7-907a-c9b99b653763', N'B-')
GO
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'16db9b7f-b7c2-4048-bedb-1544a05f34ee', N'B+')
GO
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'2fb561d8-e04e-4797-af16-3d63f3f9b6ec', N'O-')
GO
INSERT [dbo].[Bloods] ([Id], [Type]) VALUES (N'f65fbec5-5564-431a-aa09-97498ae8adc4', N'O+')
GO

-- ADICIONANDO HAIR

INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'3d7843ac-ed99-4658-a1be-510bf268a947', N'ACOBREADO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'eb1b3d9a-f248-4980-9d40-e4e97bd3c12a', N'ACOBREADO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'3824dac1-7de9-4480-a748-54e4a1cbd84f', N'ACOBREADO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'0d5e5ca2-292a-4dc6-9257-fb3b9238a5ba', N'ACOBREADO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'0d838c36-2f42-499c-9da0-dfb961312d82', N'AZUL', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'ff50164f-4d64-4734-857e-aab33d3a7232', N'AZUL', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'2be6ce06-d353-4cb3-909a-3eaf4206489c', N'AZUL', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'f69ca287-1ba9-41d0-9101-5306d5814eae', N'AZUL', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'f8094cc6-4b36-44be-9b18-d8809604f99c', N'CASTANHO CLARO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'e8acebdc-a3de-4928-9a1d-c075aa11457c', N'CASTANHO CLARO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'976e9b75-a2df-4b20-9fac-0858fedbe498', N'CASTANHO CLARO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'3c39d6cf-f142-4330-9b97-c210719d21e9', N'CASTANHO CLARO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'700fbd78-ddee-4707-9725-196a842fa8ef', N'CASTANHO ESCURO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'58ac40b6-edbf-4708-bc3c-4fd3515e1063', N'CASTANHO ESCURO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'807cdaf7-08cf-496b-8254-8904b1ff35d3', N'CASTANHO ESCURO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'b08a66fb-5dde-4645-931b-db5da6ab29a0', N'CASTANHO ESCURO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'74c387e6-8128-418f-9336-d823a83b894d', N'CASTANHO MÉDIO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'7e8d9805-5a4c-4361-8859-208c6a4df3bb', N'CASTANHO MÉDIO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'abb3a190-b048-429c-8c1a-8463422bab62', N'CASTANHO MÉDIO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'c14cd427-f972-493d-9329-df52aec76433', N'CASTANHO MÉDIO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'65797e58-071b-439d-90ef-c40367308fa5', N'DOURADO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'15f517ad-7c09-4be4-a349-c034e90a17cc', N'DOURADO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'35ca92ef-f6f8-4d13-b3c0-0a18f44b9da6', N'DOURADO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'2c2d4885-d150-4b68-8a89-d982086bd66c', N'DOURADO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'4f8c0849-8970-4179-a3ad-c3e465b8573c', N'LOIRO CLARO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'dd987b50-6509-4e86-aa63-72e9fed04b1a', N'LOIRO CLARO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'b465e5e8-c0d6-446e-9d9c-b1a45a90ab75', N'LOIRO CLARO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'f0db2951-d1e4-4fbd-8e3f-3f84e34b8e6b', N'LOIRO CLARO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'a5f790e4-3872-45d0-9f04-c855999c0d1d', N'LOIRO ESCURO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'e7ddf28c-4bb5-4590-ae5a-24621519864d', N'LOIRO ESCURO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'c4e3ef8a-0df2-4448-bac5-4fcf01b6df88', N'LOIRO ESCURO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'6f6ae4f5-a37f-4c90-89a0-5a1268d2cb0c', N'LOIRO ESCURO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'ea61a955-41b8-4837-929a-9baa517a3e62', N'LOIRO MÉDIO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'08846732-6699-45c6-9241-06e1b272481f', N'LOIRO MÉDIO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'5c4011c6-146d-459a-b883-a6e416480c94', N'LOIRO MÉDIO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'225c5b06-1d39-4883-8a01-87aebc661dc0', N'LOIRO MÉDIO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'62f8cb90-2bfc-401a-965c-434c1e80040f', N'LOIRO ULTRA CLARO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'75e46fec-8f33-41d9-9ddb-1b3e729533a8', N'LOIRO ULTRA CLARO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'2da627cd-0158-4f2b-8665-0fd70610d685', N'LOIRO ULTRA CLARO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'16cedbc9-3507-4083-9420-6bf1f3477f9d', N'LOIRO ULTRA CLARO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'9c9a1026-7fbd-4bec-892f-d2335bc52c04', N'MARROM ', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'7160cbb9-91b9-4935-abb9-f822802e1cf5', N'MARROM', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'a1c36b46-6902-4c7f-8950-c2f30e912036', N'MARROM ', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'd05e5e22-f386-4a29-9def-36a5961a112a', N'MARROM ', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'7a2ecc56-7345-4e73-ad06-74aac09fdd11', N'PRETO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'be80fa55-053d-4ca6-861a-805ed73f76a1', N'PRETO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'b89f9c65-6746-4693-8039-fe2c7742a65c', N'PRETO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'f957be96-88c1-4bb8-8b0c-e8b0ce189321', N'PRETO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'4855d34f-ce8b-49a9-b3f2-77e64926e9cc', N'ULTRA PRETO', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'e68b3b36-418b-4919-9157-2a3fa60f3ebe', N'ULTRA PRETO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'c2f25b16-0afb-4c65-9cfa-9ebd27ca17e6', N'ULTRA PRETO', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'e8b43e8d-dc8b-4007-9814-1da1ff814c46', N'ULTRA PRETO', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'9d12ffe0-a399-48bf-bd35-ed09c937ec0a', N'VERDE ', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'5c91a96b-8ced-4ebd-86af-b2159f3ae186', N'VERDE', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'3996e076-1085-4f77-a829-1c45f07d0605', N'VERDE ', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'a06f3fdd-6304-4628-aa30-1afeae4d1ba1', N'VERDE ', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'ad7d8b4c-8939-48fc-8251-6581b38c97da', N'VERMELHO ', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'9a38da55-d38d-43dc-b469-6dfdc39d85b3', N'VERMELHO', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'8a526b23-9da3-4621-9a13-298e837bc3e5', N'VERMELHO ', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'601da819-a157-4a6e-a788-3df23c3829a3', N'VERMELHO ', N'ONDULADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'b11b69cf-b48a-4652-aa70-81b6726adf95', N'VIOLETA', N'CACHEADO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'f3dbcb9b-c28d-4103-8d27-9ae89e18cd27', N'VIOLETA', N'CRESPO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'db980949-936a-4f2f-a1f7-ef0d13b9ec6f', N'VIOLETA', N'LISO')
GO
INSERT [dbo].[Hairs] ([Id], [Color], [Type]) VALUES (N'5c0600d6-54bf-4df4-85af-5d604e9f4d0f', N'VIOLETA', N'ONDULADO')
GO

-- ADICIONANDO TIPO DE NOTIFICAÇÃO

INSERT [dbo].[NotificationTypes] ([Id], [Name], [Description]) VALUES (N'00808e60-569e-4ffc-9087-266b44a9a851', N'Sangue', N'Notificações de sangue')
GO
INSERT [dbo].[NotificationTypes] ([Id], [Name], [Description]) VALUES (N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'Leite materno', N'Notificações de leite materno')
GO
INSERT [dbo].[NotificationTypes] ([Id], [Name], [Description]) VALUES (N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'Cabelo', N'Notificações de cabelo')
GO

-- ADICIONANDO ADMINISTRADOR

INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'57754217-2df4-4d7c-a88f-435fbf0dec0e', N'admin@admin.com.br', N'ADMIN@ADMIN.COM.BR', N'admin@admin.com.br', N'ADMIN@ADMIN.COM.BR', 1, N'AQAAAAEAACcQAAAAEIM/oOPGMUccvxdS6g3xDrv8NqNwGWIEAs1M5iABUaljK78Q2hAZ7x9psYqN4B65zg==', N'4VR5IIWX42SD56AEQYJRSVEXW2HVXPJV', N'115f87bc-396b-45d2-9869-09d24e7a12fc', NULL, 0, 0, NULL, 1, 0, 2, 3)
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'57754217-2df4-4d7c-a88f-435fbf0dec0e', N'80768c8a-6f2e-47c5-53c9-08d70a3d1473')
GO

-- ADICIONANDO USUARIO


INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'0b0458f6-019a-47b9-90bd-0bee3f2f7146', N'MelissaSilvaCardoso@jourrapide.com', N'MELISSASILVACARDOSO@JOURRAPIDE.COM', N'MelissaSilvaCardoso@jourrapide.com', N'MELISSASILVACARDOSO@JOURRAPIDE.COM', 1, N'AQAAAAEAACcQAAAAENtxxEN7/FhO/I8wgG9fULgr2PaJXgRPkZs7R6WI2dSBR44j6/1ckWGdAeTHio5eeA==', N'EHER2U46QSJR2AI4ZWCXQ35L4DH63275', N'5c5c43f5-6c52-4dbe-8f22-724ef12173ce', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'8b36a6b4-5098-4cba-ba8d-1f4e351d8bda', N'hemocentroRS@hotmail.com', N'HEMOCENTRORS@HOTMAIL.COM', N'hemocentroRS@hotmail.com', N'HEMOCENTRORS@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHgLBj5ScjCajh3g7jZC9yTX0B3G+2n7OYa9Afd0+h/CcXQsNG7/pO4yX0BPYXVgHw==', N'Q52H4KV5MIYKPSFKEQKOUFIXPBJT663W', N'8ede584e-b4b8-4b6b-9617-fe0bae4e11aa', NULL, 0, 0, NULL, 1, 0, 2, 2)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'c59265e0-bf44-4084-9d73-1f6859a8e4cc', N'thaistrindade25@hotmail.com', N'THAISTRINDADE25@HOTMAIL.COM', N'thaistrindade25@hotmail.com', N'THAISTRINDADE25@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEM3TLw0F2OK9LPyt24g8VgEkGpaEDTn0qhAadQtGlD8MArYMXtVROBk9vUu3pIbAQw==', N'WOBQO4ZKFLSHBBIDAEWQ6D5YCHDZWTV7', N'fa5a27f2-e1e2-4db1-b69d-edd3cde5be6b', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'167d3ea5-53b6-48a1-b946-295d9358f039', N'NicolashSantosAzevedo@hotmail.com', N'NICOLASHSANTOSAZEVEDO@HOTMAIL.COM', N'NicolashSantosAzevedo@hotmail.com', N'NICOLASHSANTOSAZEVEDO@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEPBRjQbzPqM+BHDGhImZY+LcHylE/kaiMnVgZL0H8rA5yIb7KKtvfF5+SJEFBmvV7w==', N'ODGYLIMCPBFCQP4CAQJVU33BQ4WKJIDT', N'7a3fe48d-009c-4036-bd9a-40bafbed2558', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'4e4bd76a-09a9-4bb1-bc35-8266c122354a', N'cristianferreira_gks@hotmail.com', N'CRISTIANFERREIRA_GKS@HOTMAIL.COM', N'cristianferreira_gks@hotmail.com', N'CRISTIANFERREIRA_GKS@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHRzbjMrFCmORUYpt7Q1AclUTDfRb6F7h/B14nqOqi3F7IeAxiRnkb/c/yjCg+FPCQ==', N'4R7QZEURXNBGDVTM5X4NCXL7IXLXVCHQ', N'cc6b85ce-539d-44ff-9742-18154b2dd696', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'bc0fcb5f-719a-4e90-99fa-a1f63275e987', N'PedroPereiraMartins@hotmail.com', N'PEDROPEREIRAMARTINS@HOTMAIL.COM', N'PedroPereiraMartins@hotmail.com', N'PEDROPEREIRAMARTINS@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEI4vZUbyovxSJ81j33XXAFzIUQZFGr/uyljNhIeLYzZOcSEPqPszmfarcgab/4VeAQ==', N'32345DWBZ2HKMRNPYX4D4DAHQLCCF276', N'842b7184-bb73-41a2-9b03-2f39eadd6f5a', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'8a2fff91-b219-4c11-abe1-a2a3f0c315c3', N'TiagoMartinsAraujo@hotmail.com', N'TIAGOMARTINSARAUJO@HOTMAIL.COM', N'TiagoMartinsAraujo@hotmail.com', N'TIAGOMARTINSARAUJO@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEKyeaG9tzDoECQaIWjfGBT+qjHl8nsmO44O8KNPfFe9WjkyKqS8QAG9Zxx/stuWPVQ==', N'WRQFNL4MR7JD3SJMI3W7ICERMAPQRRFW', N'fe41cc0a-54bd-4e2c-87e3-ee92ab56e9d5', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'95ea69df-7a21-488f-b692-bfdbc088c76f', N'EvelynSantosAzevedo@jourrapide.com', N'EVELYNSANTOSAZEVEDO@JOURRAPIDE.COM', N'EvelynSantosAzevedo@jourrapide.com', N'EVELYNSANTOSAZEVEDO@JOURRAPIDE.COM', 1, N'AQAAAAEAACcQAAAAEBG2mOVZnrlWfWjz5iOHtta7WxJC8qfjdHBjq8gZnSfpuenbtumHTz8eW91GprQ59g==', N'D33JS2GASUOHM2Y4M23PQKV246URKGKG', N'07d4d037-59b3-4fe4-aad7-96f12eef6857', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'4be2d910-1252-4331-a91d-c3fd32f59f4b', N'CaioOliveiraBarbosa@rhyta.com', N'CAIOOLIVEIRABARBOSA@RHYTA.COM', N'CaioOliveiraBarbosa@rhyta.com', N'CAIOOLIVEIRABARBOSA@RHYTA.COM', 1, N'AQAAAAEAACcQAAAAEC4tMZCICXtGJ1MVn9I7v2k2BfQVaM+zEY5gCpYVDpoAIB437HPAeu1kxSIyW4T4mA==', N'IXT7TWVKZ74SEZYGFUPRYJGXPCXJMCAW', N'c3c4aed5-9a63-4a20-bba3-ed9cfab82020', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'453dcb44-6593-49d5-90e0-d43dd58b59e2', N'LuanaAraujoGoncalves@rhyta.com', N'LUANAARAUJOGONCALVES@RHYTA.COM', N'LuanaAraujoGoncalves@rhyta.com', N'LUANAARAUJOGONCALVES@RHYTA.COM', 1, N'AQAAAAEAACcQAAAAEBhgvqxr8dLYPsHcMjaNrsxV5DD1h+NFdf6tO09Oh5Ho9K7KS1d65ejQc9ENGZvt2Q==', N'PCKCUZBSEQ47VXLY3YYFKO62SEAFKJ6E', N'97e3952f-a448-4ad3-b4ca-b0f3bc4b515e', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'2842e1b9-e136-4c69-9a10-e6126a5d692a', N'JuliaAlvesAraujo@jourrapide.com', N'JULIAALVESARAUJO@JOURRAPIDE.COM', N'JuliaAlvesAraujo@jourrapide.com', N'JULIAALVESARAUJO@JOURRAPIDE.COM', 1, N'AQAAAAEAACcQAAAAEO6MdGL2rbyeOJIgj7nX0Z6n4Nx+5KDyK5dggYeFxpS782ARPQvNtRGyIA3B2XT4VA==', N'GGBQSRBG5GDGJ3VP33MGWTESBK5NAYZ3', N'ba397726-576d-4ee5-adf4-89f5142bd6eb', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'6ff205bb-e935-4d64-92c7-e95f9136bbc9', N'rapunzelsolidaria@hotmail.com', N'RAPUNZELSOLIDARIA@HOTMAIL.COM', N'rapunzelsolidaria@hotmail.com', N'RAPUNZELSOLIDARIA@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEEbYlwK69VkGrhbgss2I5dYzsg6FFuKq3oa9iPOfuiQxCzfnHHzVl8ddSwJ5MAGkRQ==', N'EGWEY25DBH6WXM5QBX4WU7DGWSEL6JTF', N'3ce7954b-9a51-434b-a109-be3987c61ebd', NULL, 0, 0, NULL, 1, 0, 2, 2)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'98051049-2fbc-4c6e-9d18-eca97edc8271', N'LuanaAraujoFerreira@rhyta.com', N'LUANAARAUJOFERREIRA@RHYTA.COM', N'LuanaAraujoFerreira@rhyta.com', N'LUANAARAUJOFERREIRA@RHYTA.COM', 1, N'AQAAAAEAACcQAAAAEJ3Eg/dp21mrnElVp0R5fKfKCAyJl72vpvm9Irrr+gNeYnpxm7MNCUQGDs1Jvt3FLw==', N'FAS763XCIQP6BM4JRVANP7SXA46P7IRA', N'55d878e0-bc24-4656-ae2e-85a3c0099192', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'9adf3a3b-4bd9-4bd6-8765-ee9321edab59', N'LuanaAraujoSantos@rhyta.com', N'LUANAARAUJOSANTOS@RHYTA.COM', N'LuanaAraujoSantos@rhyta.com', N'LUANAARAUJOSANTOS@RHYTA.COM', 1, N'AQAAAAEAACcQAAAAEMkFD26af+Da+3nSRDUoYO2xnX38t+yyhhNmDphTGVkq4WNfZl1uCd0WCaZWs0IH8g==', N'LGN3MAU24ALTAZYDWMNTUTEMISDJE2DD', N'4c60c9b4-64f0-41d0-a67e-cd8215362153', NULL, 0, 0, NULL, 1, 0, 3, 1)
GO
INSERT [dbo].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [UserStatus], [UserType]) VALUES (N'68029763-e08c-4f37-bcc9-fa9af4a24a91', N'saolucas@hotmail.com', N'SAOLUCAS@HOTMAIL.COM', N'saolucas@hotmail.com', N'SAOLUCAS@HOTMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHhvWcLUfal1LTm4Al/V1bAH08U0Vdc0hCyHFaoM3Tgu00xCM+p9lBAJ/MLutLVGTQ==', N'6NPVDJAS7ZVN7X5XHNNSUYI2KJT32SS5', N'92d9b9c0-4940-437c-bc44-bc35c7f2fde6', NULL, 0, 0, NULL, 1, 0, 2, 2)
GO




-- ADICIONANDO USUARIO DOADOR

INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'71696716-f5e6-4bce-a27f-0e6c7ee99714', N'Melissa Silva Cardoso', NULL, NULL, 1, CAST(N'1986-02-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'0b0458f6-019a-47b9-90bd-0bee3f2f7146', N'1a5dc0ba-6212-48ec-bc63-198af67f9fac', N'2be6ce06-d353-4cb3-909a-3eaf4206489c')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'fa303807-6e3e-4b34-adb9-4d0f13a12b54', N'Tiago Martins Araujo', NULL, NULL, 1, CAST(N'1984-11-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'8a2fff91-b219-4c11-abe1-a2a3f0c315c3', N'1a5dc0ba-6212-48ec-bc63-198af67f9fac', N'2be6ce06-d353-4cb3-909a-3eaf4206489c')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'026e8c65-4d74-4325-a416-51b5a4c6dca8', N'Nicolash Santos Azevedo', NULL, NULL, 1, CAST(N'1984-01-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'167d3ea5-53b6-48a1-b946-295d9358f039', N'9fc69a50-5bc4-4aa7-907a-c9b99b653763', N'e8acebdc-a3de-4928-9a1d-c075aa11457c')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'3551274c-0f73-4e64-90a8-70b058ac8e3c', N'Pedro Pereira Martins', NULL, NULL, 1, CAST(N'1984-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'bc0fcb5f-719a-4e90-99fa-a1f63275e987', N'9fc69a50-5bc4-4aa7-907a-c9b99b653763', N'e8acebdc-a3de-4928-9a1d-c075aa11457c')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'd6c2662d-6cc7-4b96-bbdb-87a1263ac75b', N'Luana Araujo Goncalves', NULL, NULL, 2, CAST(N'1957-02-07T00:00:00.0000000' AS DateTime2), CAST(N'2019-02-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'453dcb44-6593-49d5-90e0-d43dd58b59e2', N'f65fbec5-5564-431a-aa09-97498ae8adc4', N'b465e5e8-c0d6-446e-9d9c-b1a45a90ab75')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'3c197150-8c64-456e-8d18-9327307c0500', N'Luana Araujo Santos', NULL, NULL, 2, CAST(N'1957-02-07T00:00:00.0000000' AS DateTime2), CAST(N'2019-02-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'9adf3a3b-4bd9-4bd6-8765-ee9321edab59', N'f65fbec5-5564-431a-aa09-97498ae8adc4', N'b465e5e8-c0d6-446e-9d9c-b1a45a90ab75')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'a63ce2f9-66d7-4145-a6ac-946c58dfd6f1', N'Caio Oliveira Barbosa', NULL, NULL, 1, CAST(N'1966-04-11T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'4be2d910-1252-4331-a91d-c3fd32f59f4b', N'6d59b1af-47f5-4fe8-9f8d-a6093b849963', N'7a2ecc56-7345-4e73-ad06-74aac09fdd11')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'dadd9bd5-d3c2-4bf5-b1b6-a1c1be91e779', N'Cristian Santos Ferreira', NULL, NULL, 1, CAST(N'1993-09-22T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, CAST(N'2019-07-16T23:29:06.0686556' AS DateTime2), 1, 1, 1, N'4e4bd76a-09a9-4bb1-bc35-8266c122354a', N'2fb561d8-e04e-4797-af16-3d63f3f9b6ec', NULL)
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'f9b87785-e47f-44c9-bc7e-b98f08a9412e', N'Evelyn Santos Azevedo', NULL, NULL, 1, CAST(N'1986-04-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'95ea69df-7a21-488f-b692-bfdbc088c76f', N'6d59b1af-47f5-4fe8-9f8d-a6093b849963', N'7a2ecc56-7345-4e73-ad06-74aac09fdd11')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'92812473-59bb-4395-bc82-d1147ef4cedb', N'Júlia Alves Araujo', NULL, NULL, 1, CAST(N'1935-02-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'2842e1b9-e136-4c69-9a10-e6126a5d692a', N'92dac864-6429-4ff0-a362-f65fef77921c', N'b89f9c65-6746-4693-8039-fe2c7742a65c')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'79afebc1-6136-4ef1-9ff9-e336dbc5bb17', N'Thais da Rosa Lima', NULL, NULL, 2, CAST(N'1994-11-25T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, CAST(N'2019-07-16T23:29:06.0913025' AS DateTime2), 1, 1, 1, N'c59265e0-bf44-4084-9d73-1f6859a8e4cc', N'2fb561d8-e04e-4797-af16-3d63f3f9b6ec', N'3d7843ac-ed99-4658-a1be-510bf268a947')
GO
INSERT [dbo].[DonatorUsers] ([Id], [Name], [CPF], [CellPhone], [Genre], [DateBirth], [LastDonatedBlood], [LastDonatedHair], [LastDonatedBreastMilk], [LastBloodNotification], [LastHairNotification], [LastBreastMilkNotification], [ActivedBloodNotification], [ActivedHairNotification], [ActivedBreastMilkNotification], [UserId], [BloodId], [HairId]) VALUES (N'3fd93205-d393-4054-b2d0-f9675fd879d2', N'Luana Araujo Ferreira', NULL, NULL, 2, CAST(N'1957-02-07T00:00:00.0000000' AS DateTime2), CAST(N'2019-02-07T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, NULL, NULL, 1, 1, 1, N'98051049-2fbc-4c6e-9d18-eca97edc8271', N'92dac864-6429-4ff0-a362-f65fef77921c', N'b89f9c65-6746-4693-8039-fe2c7742a65c')


-- ADICIONANDO INSTITUICAO
INSERT [dbo].[InstitutionUsers] ([Id], [SocialReason], [FantasyName], [CNPJ], [UserId], [NotificationId]) VALUES (N'135f48df-bd15-453d-98cf-309a721792b4', N'Hemocentro do Estado do Rio Grande do Sul - Secretaria da Saúde', N'Hemocentro RS', N'14825489000145', N'8b36a6b4-5098-4cba-ba8d-1f4e351d8bda', NULL)
GO
INSERT [dbo].[InstitutionUsers] ([Id], [SocialReason], [FantasyName], [CNPJ], [UserId], [NotificationId]) VALUES (N'b4b0db9c-0c69-4e6a-9498-59f7e07aa62b', N'Rapunzel Solidária', N'Rapunzel Solidária', N'71082823000151', N'6ff205bb-e935-4d64-92c7-e95f9136bbc9', NULL)
GO
INSERT [dbo].[InstitutionUsers] ([Id], [SocialReason], [FantasyName], [CNPJ], [UserId], [NotificationId]) VALUES (N'4a84c0fc-4be9-476b-adaf-69192590d00a', N'Hospital São Lucas da Pontifícia Universidade Católica do Rio Grande do Sul', N'Hospital São Lucas - PUCRS', N'12344510000165', N'68029763-e08c-4f37-bcc9-fa9af4a24a91', NULL)
GO


-- ADICIONANDO TIPO DE NOTIFICAÇÃO DO USUARIO

INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'40c8aaf3-7181-4640-aa21-089b35828e9d', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'453dcb44-6593-49d5-90e0-d43dd58b59e2')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'7e4edcf7-0d7e-481b-a600-0faef7fbe110', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'9adf3a3b-4bd9-4bd6-8765-ee9321edab59')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'dd5b222e-0285-4858-853c-14177af8240e', N'00808e60-569e-4ffc-9087-266b44a9a851', N'68029763-e08c-4f37-bcc9-fa9af4a24a91')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'2687b61a-7898-446c-875f-17860992cf3f', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'c59265e0-bf44-4084-9d73-1f6859a8e4cc')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'ba1d7325-4691-4a47-8374-18d01814c6ee', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'8a2fff91-b219-4c11-abe1-a2a3f0c315c3')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'8b0c333e-8ccd-4a0b-88e1-192f4ab8784c', N'00808e60-569e-4ffc-9087-266b44a9a851', N'4be2d910-1252-4331-a91d-c3fd32f59f4b')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'32e28854-7803-4002-a694-1c5894bf5d26', N'00808e60-569e-4ffc-9087-266b44a9a851', N'4e4bd76a-09a9-4bb1-bc35-8266c122354a')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'825422db-bfaf-4d73-89ef-219e68627b68', N'00808e60-569e-4ffc-9087-266b44a9a851', N'95ea69df-7a21-488f-b692-bfdbc088c76f')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'259f38dd-148f-49d2-a769-22e7fe7e7b4f', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'4be2d910-1252-4331-a91d-c3fd32f59f4b')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'c5c0873d-c4c1-4457-bad9-36a130eca17e', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'4be2d910-1252-4331-a91d-c3fd32f59f4b')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'53bc0aab-ac74-4993-a28a-49259c0b74af', N'00808e60-569e-4ffc-9087-266b44a9a851', N'bc0fcb5f-719a-4e90-99fa-a1f63275e987')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'6b6bb0c4-0682-42ad-8e78-51e42ee7fd1c', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'2842e1b9-e136-4c69-9a10-e6126a5d692a')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'4245bfb6-6271-45b8-9e54-5f7a0fddcc2d', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'2842e1b9-e136-4c69-9a10-e6126a5d692a')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'de24aab8-06ba-470d-8545-63245367a650', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'68029763-e08c-4f37-bcc9-fa9af4a24a91')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'1ac35d1a-de61-457c-beae-64ab86b0cb45', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'167d3ea5-53b6-48a1-b946-295d9358f039')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'e7990d54-5466-4d6e-bd48-6aa8660c1955', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'0b0458f6-019a-47b9-90bd-0bee3f2f7146')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'2ba0bbbf-5e59-4bdf-b89f-767dfb4b345d', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'453dcb44-6593-49d5-90e0-d43dd58b59e2')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'f8831203-1229-4d5f-86fa-8291c717ab1e', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'c59265e0-bf44-4084-9d73-1f6859a8e4cc')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'f34301e7-90ed-456c-a49c-84e3b5719562', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'0b0458f6-019a-47b9-90bd-0bee3f2f7146')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'40c00cc7-a18a-4e9d-b6c6-851153634333', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'98051049-2fbc-4c6e-9d18-eca97edc8271')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'11d8b223-a9c2-4acf-813c-89d4bc4af418', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'68029763-e08c-4f37-bcc9-fa9af4a24a91')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'2a7621ed-c775-4380-ae96-8e9fa4517d5f', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'bc0fcb5f-719a-4e90-99fa-a1f63275e987')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'013fc721-d9c3-4ce5-9c1f-8ee9181c3372', N'00808e60-569e-4ffc-9087-266b44a9a851', N'2842e1b9-e136-4c69-9a10-e6126a5d692a')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'f47198b0-32d1-490a-ab66-90d89daf0630', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'bc0fcb5f-719a-4e90-99fa-a1f63275e987')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'aeb0f49f-495b-4de7-9de1-92f6f55eb727', N'00808e60-569e-4ffc-9087-266b44a9a851', N'9adf3a3b-4bd9-4bd6-8765-ee9321edab59')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'ccbd1139-32be-4fbd-8a26-95b564601696', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'6ff205bb-e935-4d64-92c7-e95f9136bbc9')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'01f9ed0a-3fab-4d85-9bf5-a948cfaf74cb', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'98051049-2fbc-4c6e-9d18-eca97edc8271')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'980d3438-0712-489e-a149-ac40f99aeb50', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'8a2fff91-b219-4c11-abe1-a2a3f0c315c3')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'72f3ac48-d793-42c4-942d-b9ec7708ad18', N'00808e60-569e-4ffc-9087-266b44a9a851', N'167d3ea5-53b6-48a1-b946-295d9358f039')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'46eb49b8-b464-437b-bf6a-bdfdbdfbac3f', N'00808e60-569e-4ffc-9087-266b44a9a851', N'0b0458f6-019a-47b9-90bd-0bee3f2f7146')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'39360d31-182f-4c29-a9b1-be50f3c0e09f', N'00808e60-569e-4ffc-9087-266b44a9a851', N'c59265e0-bf44-4084-9d73-1f6859a8e4cc')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'd051ab9b-309e-4c50-9289-c1dbc213b6c6', N'00808e60-569e-4ffc-9087-266b44a9a851', N'453dcb44-6593-49d5-90e0-d43dd58b59e2')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'5bb44327-88b1-4e84-8a64-c7f79a85331e', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'95ea69df-7a21-488f-b692-bfdbc088c76f')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'0ee70d80-2658-4212-8da8-d2e579336788', N'00808e60-569e-4ffc-9087-266b44a9a851', N'98051049-2fbc-4c6e-9d18-eca97edc8271')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'981098b4-dc57-4498-b5e5-e1ac9b21e1c7', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'167d3ea5-53b6-48a1-b946-295d9358f039')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'7d8b8e8b-572e-4e75-ab16-e3e7be537aa3', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'95ea69df-7a21-488f-b692-bfdbc088c76f')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'c5044067-3f1d-486d-aadc-e3f879b5c263', N'ca893e9c-4fa2-4998-baf9-d653f39b45ba', N'9adf3a3b-4bd9-4bd6-8765-ee9321edab59')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'13e45a65-cabb-4e32-9a1c-e845a252ba64', N'87ea13b8-581f-4151-b4c0-90ee0e321a2e', N'4e4bd76a-09a9-4bb1-bc35-8266c122354a')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'81086667-437b-4f4f-b4be-f29cbf990f59', N'00808e60-569e-4ffc-9087-266b44a9a851', N'8a2fff91-b219-4c11-abe1-a2a3f0c315c3')
GO
INSERT [dbo].[UserNotificationTypes] ([Id], [NotificationTypeId], [UserId]) VALUES (N'1d202977-eeab-4078-a8d4-fd4b6a8e0e9d', N'00808e60-569e-4ffc-9087-266b44a9a851', N'8b36a6b4-5098-4cba-ba8d-1f4e351d8bda')
GO



--ADD Adresses

INSERT [dbo].[Adresses] ([Id], [UserId], [Number], [Complement], [Street], [City], [District], [State], [Country], [ZipCode], [Latitude], [Longitude]) VALUES ('a6360650-78cb-4656-ae9e-7b023cfce331', '8b36a6b4-5098-4cba-ba8d-1f4e351d8bda', N'3722', NULL, N'Av. Bento Gonçalves', N'Porto Alegre', 'Partenon ', N'RS', N'Brasil', N'90650000', CAST(-30.062012400 AS Decimal(18, 9)), CAST(-51.179140820 AS Decimal(18, 9)))
GO
INSERT [dbo].[Adresses] ([Id], [UserId], [Number], [Complement], [Street], [City], [District], [State], [Country], [ZipCode], [Latitude], [Longitude]) VALUES (N'31ad5ac4-4c5d-486f-a629-7f56c164f842', N'6ff205bb-e935-4d64-92c7-e95f9136bbc9', N'140', NULL, N'R. Amaro Cavalheiro', N'São Paulo','Pinheiros ', N'SP', N'Brasil', N'05425011', CAST(-23.566584000 AS Decimal(18, 9)), CAST(-46.699332300 AS Decimal(18, 9)))
GO
INSERT [dbo].[Adresses] ([Id], [UserId], [Number], [Complement], [Street], [City], [District], [State], [Country], [ZipCode], [Latitude], [Longitude]) VALUES (N'4f93dd0e-eb59-49ee-a805-9aa24cbf60a0', N'68029763-e08c-4f37-bcc9-fa9af4a24a91', N'6690', NULL, N'Av. Ipiranga', N'Porto Alegre','Partenon', N'RS', N'Brasil', N'90619900', CAST(-30.055169700 AS Decimal(18, 9)), CAST(-51.173509430 AS Decimal(18, 9)))
GO


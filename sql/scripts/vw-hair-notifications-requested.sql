USE [socialheroes]
GO

/****** Object:  View [vw].[HairNotificationsRequested]    Script Date: 03/08/2019 00:23:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS(SELECT name FROM sys.schemas WHERE name = N'vw')
EXEC('CREATE SCHEMA [vw]')
GO

CREATE VIEW [vw].[HairNotificationsRequested] AS
SELECT 
ntf.InstitutionUserId,
ntf.DateNotification,
h.Color as ColorRequested,
h.Type as TypeRequested, 
hn.AmountHair as CountHairRequested, 
count(duhn.Id) as CountDonatorNotified
FROM Notifications AS ntf
JOIN HairNotifications AS hn ON hn.NotificationId = ntf.Id
JOIN Hairs AS h ON h.Id = hn.HairId
JOIN DonatorUserHairNotifications as duhn ON duhn.HairNotificationId = hn.Id
GROUP BY ntf.InstitutionUserId, ntf.DateNotification,h.Color, h.Type, hn.AmountHair
GO



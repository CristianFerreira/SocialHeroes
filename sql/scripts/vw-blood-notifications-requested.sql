USE [socialheroes]
GO

/****** Object:  View [vw].[BloodNotificationsRequested]    Script Date: 03/08/2019 00:23:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [vw].[BloodNotificationsRequested] AS
SELECT 
ntf.InstitutionUserId,
ntf.DateNotification,
b.Type as BloodRequested, 
bn.AmountBlood as CountBloodRequested, 
count(dubn.Id) as CountDonatorNotified
FROM Notifications AS ntf
JOIN BloodNotifications AS bn ON bn.NotificationId = ntf.Id
JOIN Bloods AS b ON b.Id = bn.BloodId
JOIN DonatorUserBloodNotifications as dubn ON dubn.BloodNotificationId = bn.Id
GROUP BY ntf.InstitutionUserId, ntf.DateNotification, b.Type, bn.AmountBlood
GO



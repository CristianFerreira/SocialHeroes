USE [socialheroes]
GO

/****** Object:  View [dbo].[vwDonatorUserBloodNotificationRequested]    Script Date: 02/09/2019 20:14:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vwDonatorUserBloodNotificationRequested] AS
select 
  n.Id as NotificationId, 
  dubn.DonatorUserId,
  n.DateNotification, 
  i.FantasyName as InstitutionName
  from DonatorUserBloodNotifications as dubn
join BloodNotifications as bntf on dubn.BloodNotificationId = bntf.Id
join Notifications as n on n.Id = bntf.NotificationId
join InstitutionUsers as i on i.Id = n.InstitutionUserId
where bntf.Actived = 1
GO



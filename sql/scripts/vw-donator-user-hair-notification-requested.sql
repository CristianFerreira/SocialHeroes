USE [socialheroes]
GO

/****** Object:  View [dbo].[vwDonatorUserHairNotificationRequested]    Script Date: 02/09/2019 20:14:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vwDonatorUserHairNotificationRequested] AS
select 
  n.Id as NotificationId, 
  dubh.DonatorUserId,
  n.DateNotification, 
  i.FantasyName as InstitutionName
  from DonatorUserHairNotifications as dubh
join BloodNotifications as bntf on dubh.HairNotificationId = bntf.Id
join Notifications as n on n.Id = bntf.NotificationId
join InstitutionUsers as i on i.Id = n.InstitutionUserId
where bntf.Actived = 1
GO



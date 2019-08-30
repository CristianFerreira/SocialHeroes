USE [socialheroes]
GO

/****** Object:  View [vw].[[NotificationsRequestedEnableOnPage]]    Script Date: 03/08/2019 00:23:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS(SELECT name FROM sys.schemas WHERE name = N'vw')
EXEC('CREATE SCHEMA [vw]')
GO

CREATE VIEW [vw].[NotificationsRequestedEnableOnPage] AS
select distinct ntf.Id as NotificationId, ntf.DateNotification, bntf.ShareOnFacebook, bntf.ShareOnLinkedin, bntf.ShareOnTwitter, i.FantasyName as InstitutionName
 ,SUBSTRING(
        (
            SELECT ', '+b.Type  AS [text()]
            FROM dbo.Bloods b
			join BloodNotifications bn on bn.BloodId = b.Id
            WHERE bn.NotificationId = ntf.Id
			order by b.Type asc
            FOR XML PATH ('')
        ), 2, 1000) BloodType
  from Notifications as ntf
join BloodNotifications as bntf on bntf.NotificationId = ntf.Id
join InstitutionUsers as i on i.Id = ntf.InstitutionUserId
join Users as u on u.Id = i.UserId
where u.UserType = 2 and ntf.EnableRequestOnPage = 1
GO



USE [socialheroes]
GO

/****** Object:  View [dbo].[vwBloodNotificationsRequestedEnableOnPage]    Script Date: 01/09/2019 20:43:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwInfoHairNotificationsRequestedEnableOnPage] AS
select distinct ntf.Id as NotificationId, 
ntf.DateNotification, 
hntf.ShareOnFacebook, 
hntf.ShareOnLinkedin, 
hntf.ShareOnTwitter, 
i.FantasyName as InstitutionName
 ,SUBSTRING(
        (
            SELECT ', '+h.Type + ' - ' + h.Color  AS [text()]
            FROM dbo.Hairs h
			join HairNotifications hn on hn.HairId = h.Id
            WHERE hn.NotificationId = ntf.Id
			order by h.Type asc
            FOR XML PATH ('')
        ), 2, 1000) Type
  from Notifications as ntf
join HairNotifications as hntf on hntf.NotificationId = ntf.Id
join InstitutionUsers as i on i.Id = ntf.InstitutionUserId
join Users as u on u.Id = i.UserId
where u.UserType = 2 and ntf.EnableRequestOnPage = 1
GO



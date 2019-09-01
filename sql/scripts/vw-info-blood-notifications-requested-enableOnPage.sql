USE [socialheroes]
GO


CREATE VIEW [vwInfoBloodNotificationsRequestedEnableOnPage] AS
select distinct ntf.Id as NotificationId, ntf.DateNotification, bntf.ShareOnFacebook, bntf.ShareOnLinkedin, bntf.ShareOnTwitter, i.FantasyName as InstitutionName
 ,SUBSTRING(
        (
            SELECT ', '+b.Type  AS [text()]
            FROM dbo.Bloods b
			join BloodNotifications bn on bn.BloodId = b.Id
            WHERE bn.NotificationId = ntf.Id
			order by b.Type asc
            FOR XML PATH ('')
        ), 2, 1000) Type
  from Notifications as ntf
join BloodNotifications as bntf on bntf.NotificationId = ntf.Id
join InstitutionUsers as i on i.Id = ntf.InstitutionUserId
join Users as u on u.Id = i.UserId
where u.UserType = 2 and ntf.EnableRequestOnPage = 1
GO



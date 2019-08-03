USE [socialheroes]
GO

/****** Object:  View [vw].[NotificationsFromInstitutions]    Script Date: 03/08/2019 00:23:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS(SELECT name FROM sys.schemas WHERE name = N'vw')
EXEC('CREATE SCHEMA [vw]')
GO

CREATE VIEW [vw].[NotificationsFromInstitutions] AS
SELECT * FROM (SELECT TOP 5
ntf.InstitutionUserId,
ntf.DateNotification,
'Cabelo' as TypeNotification,
(h.Color + ' - ' + h.Type) as TypeRequested, 
hn.AmountHair as CountRequested, 
iu.FantasyName as InstitutionName,
u.Email as InstitutionEmail,
a.State,
a.City,
a.Street,
a.Number
FROM Notifications AS ntf
JOIN HairNotifications AS hn ON hn.NotificationId = ntf.Id
JOIN Hairs AS h ON h.Id = hn.HairId
JOIN InstitutionUsers AS iu on iu.Id = ntf.InstitutionUserId
JOIN Users AS u on u.Id = iu.UserId
JOIN Adresses AS a on a.UserId = u.Id
ORDER BY ntf.DateNotification desc) AS HairNotifications

UNION

SELECT * FROM (SELECT TOP 5 
ntf.InstitutionUserId,
ntf.DateNotification,
'Sangue' as TypeNotification,
b.Type as TypeRequested, 
bn.AmountBlood as CountRequested,
iu.FantasyName as InstitutionName,
u.Email as InstitutionEmail,
a.State,
a.City,
a.Street,
a.Number
FROM Notifications AS ntf
JOIN BloodNotifications AS bn ON bn.NotificationId = ntf.Id
JOIN Bloods AS b ON b.Id = bn.BloodId
JOIN InstitutionUsers AS iu on iu.Id = ntf.InstitutionUserId
JOIN Users AS u on u.Id = iu.UserId
JOIN Adresses AS a on a.UserId = u.Id
ORDER BY ntf.DateNotification desc) AS BloodNotifications

GO



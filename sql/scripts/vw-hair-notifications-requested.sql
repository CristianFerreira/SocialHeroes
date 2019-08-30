USE [socialheroes]
GO


CREATE VIEW [vwHairNotificationsRequested] AS
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



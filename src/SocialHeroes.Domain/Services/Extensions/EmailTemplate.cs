namespace SocialHeroes.Domain.Services.Extensions
{
    public class EmailTemplate
    {
        public static string EmailDonatorNotification(string type, string institutionName)
        {
            return $"<div style=\"color: #ff0000; background-color: #999999; width: 100%; heigth: 60px;\"><p style=\"text-align: center;\"><span style=\"font-size: 20px;\">&nbsp;<em><span style=\"text-decoration: underline;\"><strong><span style=\"background-color: #999999; color: #333333; text-decoration: underline;\">Social Heroes</span></strong></span></em></span></p><p style=\"text-align: left;\"><span style=\"font-size: 20px;\">&nbsp;</span></p><p style=\"text-align: center;\"><span style=\"font-size: 20px; color: #333333;\">Voc&ecirc; Recebeu uma notifica&ccedil;&atilde;o de {type}, da instituição: {institutionName}!&nbsp;</span></p><p style=\"text-align: center;\"><span style=\"font-size: 20px; color: #333333;\">Acesse sua conta na plataforma:&nbsp;<a href=\"http://www.socialheroes.com.br\">www.socialheroes.com.br</a></span></p><p style=\"text-align: center;\">&nbsp;</p><p style=\"text-align: center;\">&nbsp;</p></div>";
        }
    }
}

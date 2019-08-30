using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SocialHeroes.Domain.Services
{
    public class WhatsappService
    {
        public void SendWhatsappDonator(string fromName, string toName,  string type, string phone)
        {
            try
            {
                const string accountSid = "AC36cd014add4fc202353fd1d272026aa4";
                const string authToken = "161cdde2b4d1f29888e3841eab5637f5";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(body: $@"Ola {toName}, 
                                                            você recebeu uma solicitação de {type} da instituição {fromName}. 
                                                            Para saber maiores informações: {new Uri("http://www.google.com.br")}",
                                                     from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                                                     to: new Twilio.Types.PhoneNumber("whatsapp:+555198585486"));
            }
            catch (Exception ex) { throw ex; };
        }
    }
}

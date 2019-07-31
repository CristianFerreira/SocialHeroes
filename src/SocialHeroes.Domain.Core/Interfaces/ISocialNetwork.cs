using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHeroes.Domain.Core.Interfaces
{
    public interface ISocialNetwork
    {
        bool ShareOnFacebook { get; }
        bool ShareOnInstagram { get; }
        bool ShareOnTwitter { get; }
        bool ShareOnWhatsapp { get; }
    }
}

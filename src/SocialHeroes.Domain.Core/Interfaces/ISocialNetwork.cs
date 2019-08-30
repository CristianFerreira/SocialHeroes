using System;
using System.Collections.Generic;
using System.Text;

namespace SocialHeroes.Domain.Core.Interfaces
{
    public interface ISocialNetwork
    {
        bool ShareOnFacebook { get; }
        bool ShareOnLinkedin { get; }
        bool ShareOnTwitter { get; }
    }
}

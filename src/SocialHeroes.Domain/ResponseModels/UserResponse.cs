using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.ResponseModels
{
    public class UserResponse
    {
        public UserResponse(Guid userId, string name, EUserType userType)
        {
            UserId = userId;
            Name = name;
            UserType = userType.ToString();
        }

        public Guid UserId { get; }
        public string Name { get; }
        public string UserType { get; }
    }
}

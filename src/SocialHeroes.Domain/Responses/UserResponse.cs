using SocialHeroes.Domain.Enums;
using System;

namespace SocialHeroes.Domain.Responses
{
    public class UserResponse
    {
        public UserResponse(Guid userId, string name, EUserType userType)
        {
            Id = userId;
            Name = name;
            UserType = userType.ToString();
        }

        public Guid Id { get; }
        public string Name { get; }
        public string UserType { get; }
    }
}

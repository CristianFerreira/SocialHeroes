using SocialHeroes.Domain.Queries;

namespace SocialHeroes.Domain.ResponseModels
{
    public class HospitalUser
    {
        public HospitalUser(UserQueryResponse userResponse, string fantasyName)
        {
            UserResponse = userResponse;
            FantasyName = fantasyName;
        }

        UserQueryResponse UserResponse { get; }
        string FantasyName { get; }
    }
}

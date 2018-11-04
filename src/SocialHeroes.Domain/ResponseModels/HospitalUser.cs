namespace SocialHeroes.Domain.ResponseModels
{
    public class HospitalUser
    {
        public HospitalUser(UserResponse userResponse, string fantasyName)
        {
            UserResponse = userResponse;
            FantasyName = fantasyName;
        }

        UserResponse UserResponse { get; }
        string FantasyName { get; }
    }
}

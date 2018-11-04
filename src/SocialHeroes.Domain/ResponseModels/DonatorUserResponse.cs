namespace SocialHeroes.Domain.ResponseModels
{
    public class DonatorUserResponse
    {
        public DonatorUserResponse(UserResponse userResponse, string name)
        {
            UserResponse = userResponse;
            Name = name;
        }

        UserResponse UserResponse { get; }
        string Name { get; }
    }
}

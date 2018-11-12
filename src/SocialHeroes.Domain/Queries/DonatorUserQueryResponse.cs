namespace SocialHeroes.Domain.Queries
{
    public class DonatorUserQueryResponse
    {
        public DonatorUserQueryResponse(UserQueryResponse userResponse, string name)
        {
            UserResponse = userResponse;
            Name = name;
        }

        UserQueryResponse UserResponse { get; }
        string Name { get; }
    }
}

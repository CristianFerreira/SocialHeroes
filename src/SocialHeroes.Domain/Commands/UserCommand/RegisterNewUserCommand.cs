namespace SocialHeroes.Domain.Commands.UserCommand
{
    public class RegisterNewUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

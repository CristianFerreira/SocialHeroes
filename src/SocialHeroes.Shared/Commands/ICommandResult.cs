namespace SocialHeroes.Shared.Commands
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}

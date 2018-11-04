namespace SocialHeroes.Domain.Core.Interfaces
{
    public interface ICommandResult
    {
        bool Sucess { get; set; }
        object Data { get; set; }
    }
}

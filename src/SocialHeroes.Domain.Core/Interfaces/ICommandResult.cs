namespace SocialHeroes.Domain.Core.Interfaces
{
    public interface ICommandResult
    {
        IEntity Data { get; set; }
    }
}

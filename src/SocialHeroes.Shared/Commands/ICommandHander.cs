namespace SocialHeroes.Shared.Commands
{
    public interface ICommandHander<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}

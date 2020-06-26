using Medgrupo.Siscolar.Domain.Commands.Contracts;

namespace Medgrupo.Siscolar.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
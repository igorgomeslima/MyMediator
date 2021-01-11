using MyMediator.Commands;
using System.Threading.Tasks;

namespace MyMediator.Handlers
{
    public interface ICommandHandler<in TCommand, TCommandResult> 
        where TCommand : ICommand<TCommandResult>
    {
        Task<TCommandResult> HandleAsync(TCommand command);
    }
}

using MyMediator.Handlers;
using System.Threading.Tasks;
using MyMediator.Api.Commands;

namespace MyMediator.Api.CommandsHandlers
{
    public class MyCommandHandler : ICommandHandler<MyCommand, string>
    {
        public Task<string> HandleAsync(MyCommand command)
        {
            return Task.FromResult($"The message is: {command.Message}");
        }
    }
}

using System;
using MyMediator.Commands;
using MyMediator.Handlers;
using System.Threading.Tasks;

namespace MyMediator
{
    public interface IMyMediator
    {
        Task<TResult> SendAsync<TResult>(ICommand<TResult> command);
    }

    public class MyMediator : IMyMediator
    {
        public MyMediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        readonly IServiceProvider _serviceProvider;

        public async Task<TResult> SendAsync<TResult>(ICommand<TResult> command)
        {
            var genericCommandHandlerType = typeof(ICommandHandler<,>);

            var requestCommandHandlerType =
                genericCommandHandlerType.MakeGenericType(command.GetType(), typeof(TResult));

            //var handler = _serviceProvider.GetService(requestCommandHandlerType);
            //var handleResult = await (Task<TResult>)handler.GetType().GetMethod("HandleAsync").Invoke(handler, new[] { command });
            //return handleResult;

            var handler = (dynamic)_serviceProvider.GetService(requestCommandHandlerType);
            var handleResult = await (Task<TResult>)handler.HandleAsync((dynamic)command);

            return handleResult;
        }
    }
}

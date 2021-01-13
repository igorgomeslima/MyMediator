using MyMediator.Commands;

namespace MyMediator.Api.Commands
{
    public class MyCommand : ICommand<string>
    {
        public string Message { get; set; }
    }
}

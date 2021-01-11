using MyMediator.Commands;

namespace MyMediator.Worker.Commands
{
    public class MyCommand : ICommand<string>
    {
        public string Message { get; set; }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyMediator.Worker.Commands;
using MyMediator.Handlers;
using MyMediator.Commands;
using MyMediator.Worker.CommandsHandlers;

namespace MyMediator.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.AddTransient<IMyMediator, MyMediator>();
                    //services.AddMyMediator(new[] { typeof(MyCommand).Assembly });

                    services.AddSingleton<ICommandHandler<MyCommand, string>, MyCommandHandler>();
                });
    }
}

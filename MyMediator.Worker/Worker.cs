using System;
using System.Threading;
using System.Threading.Tasks;
using MyMediator.Worker.Commands;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyMediator.Worker
{
    public class Worker : BackgroundService
    {
        readonly ILogger<Worker> _logger;
        readonly IMyMediator _myMediator;

        public Worker(ILogger<Worker> logger, IMyMediator myMediator)
        {
            _logger = logger;
            _myMediator = myMediator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var result = await _myMediator.SendAsync(new MyCommand() { Message = "O bagui é loko..." });

            _logger.LogInformation(result);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}

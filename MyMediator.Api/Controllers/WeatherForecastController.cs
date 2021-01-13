using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMediator.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMediator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        readonly IMyMediator _myMediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMyMediator myMediator)
        {
            _logger = logger;
            _myMediator = myMediator;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _myMediator.SendAsync(new MyCommand { Message = "Q" });
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();

            return default;
        }
    }
}

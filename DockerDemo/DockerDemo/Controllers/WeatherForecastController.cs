using MassTransit;
using Microsoft.AspNetCore.Mvc;
using static MassTransit.Monitoring.Performance.BuiltInCounters;

namespace DockerDemo.Controllers
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

        private readonly IBus _bus;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast> >Get()
        {
            await _bus.Publish<IMyMessage>(new { Message = "Hello" });


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public interface IMyMessage
    {
        string Message { get; }
    }
}

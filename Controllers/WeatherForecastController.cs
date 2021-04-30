using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace students_back.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("~/getWeatherForecast")]
        public IEnumerable<WeatherForecast> getWeatherForecast()
        {
            var rng = new Random();
            _logger.LogInformation("test logovani informace");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /*[HttpPost("~/postJson")]
        [Consumes("application/json")]
        public IActionResult postJson(IEnumerable<int> values) =>
            Ok(new { Consumes = "application/json", Values = values });

        [HttpPost("~/postForm")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult postForm([FromForm] IEnumerable<int> values) =>
            Ok(new { Consumes = "application/x-www-form-urlencoded", Values = values });*/
    }
}

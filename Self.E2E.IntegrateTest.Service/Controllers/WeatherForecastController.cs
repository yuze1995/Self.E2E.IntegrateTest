using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Self.E2E.IntegrateTest.Service.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly Version _version;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IOptions<Version> version, ILogger<WeatherForecastController> logger)
    {
        _version = version.Value;
        _logger = logger;
    }

    [HttpGet("Version")]
    public string Version()
    {
        return $"{_version.Prefix}{_version.Number}";
    }

    [HttpGet("True")]
    public bool True()
    {
        return true;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
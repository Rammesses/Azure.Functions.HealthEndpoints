using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Shared;

namespace ASPNet.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _forecastService;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IWeatherForecastService forecastService,
        ILogger<WeatherForecastController> logger)
    {
        _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast.Shared.WeatherForecast> Get() =>
        _forecastService.Get(5);
}

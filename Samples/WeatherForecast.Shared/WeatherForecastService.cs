namespace WeatherForecast.Shared;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Get(int days = 1);
}

public enum ForecastSummaries
{
    Freezing, Bracing, Chilly, Cool, Mild, Warm, Balmy, Hot, Sweltering, Scorching
}

public class WeatherForecastService : IWeatherForecastService
{
    public static readonly string[] Summaries = Enum.GetNames<ForecastSummaries>();

    public IEnumerable<WeatherForecast> Get(int days = 1) => 
        Enumerable.Range(1, days).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
}
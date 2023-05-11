using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace WeatherForecast.Shared
{
    public class WeatherForecastCheck : IHealthCheck
    {
        private readonly IWeatherForecastService _forecastService;
        private readonly ILogger<WeatherForecastCheck> _logger;

        public WeatherForecastCheck(
            IWeatherForecastService forecastService, 
            ILogger<WeatherForecastCheck> logger)
        {
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, 
            CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Checking the weather...");

            var todaysForecast = _forecastService.Get();
            var summary = todaysForecast.FirstOrDefault().Summary;
            var summaryValue = Enum.Parse<ForecastSummaries>(summary);

            switch(summaryValue)
            {
                case ForecastSummaries.Freezing:
                case ForecastSummaries.Bracing:
                    return Task.FromResult(HealthCheckResult.Unhealthy($"{summary} - Too cold!"));

                case ForecastSummaries.Sweltering:
                case ForecastSummaries.Scorching:
                    return Task.FromResult(HealthCheckResult.Unhealthy($"{summary} - Too hot!"));

                case ForecastSummaries.Cool:
                case ForecastSummaries.Hot:
                    return Task.FromResult(HealthCheckResult.Degraded($"{summary} - Not sure."));

                default:
                    return Task.FromResult(HealthCheckResult.Healthy($"{summary} - Just right!"));

            }
        }
    }
}

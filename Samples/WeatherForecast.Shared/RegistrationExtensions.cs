using Microsoft.Extensions.DependencyInjection;

namespace WeatherForecast.Shared;

public static class RegistrationExtensions
{
    public static IServiceCollection AddWeatherForecast(this IServiceCollection services)
    {
        // make this method idempotent
        if (services.Any(s => s.ServiceType == typeof(IWeatherForecastService)))
            return services;

        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
        services.AddHealthChecks().AddCheck<WeatherForecastCheck>("Weather Forecast");
        return services;
    }
}

using Microsoft.Azure.Functions.Extensions.DependencyInjection;

using WeatherForecast.Shared;

[assembly: FunctionsStartup(typeof(Azure.FunctionApp.InProcess.Startup))]

namespace Azure.FunctionApp.InProcess;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddWeatherForecast();
    }
}


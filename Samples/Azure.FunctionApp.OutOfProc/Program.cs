using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WeatherForecast.Shared;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services => {
        services.AddWeatherForecast();
    })
    .Build();

host.Run();

using Microsoft.Azure.Functions.Worker.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Azure.Functions.Worker.Extensions.Health;

public class HealthEndpointFunctionsWorkerStartup : WorkerExtensionStartup
{
    /// <inheritdoc />
    public override void Configure(IFunctionsWorkerApplicationBuilder applicationBuilder)
    {
        // var config = ConfigurationResolver.Resolve();
        // var settings = config.Get<OpenApiSettings>(OpenApiSettings.Name);
        // applicationBuilder.Services.AddSingleton(settings);

        applicationBuilder.Services.AddSingleton<IHealthEndpointHttpTriggerContext, HealthEndpointHttpTriggerContext>();
        applicationBuilder.Services.AddSingleton<IHealthEndpointFunctions, HealthEndpointFunctions>();
    }
}
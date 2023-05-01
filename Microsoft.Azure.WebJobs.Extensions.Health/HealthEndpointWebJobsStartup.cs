using Microsoft.Azure.WebJobs.Extensions.Health;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Azure.WebJobs.Script.Description;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(HealthEndpointWebJobsStartup))]

namespace Microsoft.Azure.WebJobs.Extensions.Health;

/// <summary>
/// This represents the startup entity for Health Endpoints registrations
/// </summary>
public class HealthEndpointWebJobsStartup : IWebJobsStartup
{
    /// <inheritdoc />
    public void Configure(IWebJobsBuilder builder)
    {
        // var config = ConfigurationResolver.Resolve();
        // var settings = config.Get<OpenApiSettings>(OpenApiSettings.Name);
        // builder.Services.AddSingleton(settings);

        builder.Services.AddSingleton<IFunctionProvider, HealthEndpointTriggerFunctionProvider>();
        builder.Services.AddSingleton<IHealthEndpointHttpTriggerContext, HealthEndpointHttpTriggerContext>();

        builder.AddExtension<HealthEndpointHttpTriggerContextBinding>();
    }
}

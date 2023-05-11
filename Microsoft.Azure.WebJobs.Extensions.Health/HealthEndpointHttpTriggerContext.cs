using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Health;

public interface IHealthEndpointHttpTriggerContext
{
    HealthCheckService? HealthCheckService { get; }
}

public class HealthEndpointHttpTriggerContext : IHealthEndpointHttpTriggerContext
{
    private readonly HealthCheckService? _healthCheckService;
    private readonly ILogger<HealthEndpointHttpTriggerContext> _logger;

    public HealthEndpointHttpTriggerContext(
        HealthCheckService healthCheckService,
        ILogger<HealthEndpointHttpTriggerContext> logger)
    {
        _healthCheckService = healthCheckService;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        if (_healthCheckService == null)
        {
            _logger.LogWarning("No HealthCheckService registered so cannot report health check results");
        }
    }

    public HealthCheckService? HealthCheckService => _healthCheckService;
}
using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Health;

public class HealthEndpointTriggerFunctions
{
    public const string HealthFunctionName = "health";

    public static async Task<IActionResult> RenderHealthDocument(
        [HealthEndpointHttpTriggerContext] HealthEndpointHttpTriggerContext healthEndpointContext,
        HttpRequest req,
        ExecutionContext ctx,
        ILogger log)
    {
        log.LogInformation($"Health status was requested.");

        var healthCheckService = healthEndpointContext.HealthCheckService;
        if (healthCheckService == null )
            return (IActionResult)new ContentResult()
            {
                Content = "Healthy",
                ContentType = "text/plain",
                StatusCode = (int)HttpStatusCode.OK,
            };

        var healthReport = await healthCheckService.CheckHealthAsync();

        // if everything is healthy then just return 200 OK
        if (healthReport.Status == HealthStatus.Healthy)
            return (IActionResult)new ContentResult()
            {
                Content = "Healthy",
                ContentType = "text/plain",
                StatusCode = (int)HttpStatusCode.OK,
            };

        var statusCode = healthReport.Status == HealthStatus.Degraded ? HttpStatusCode.OK : HttpStatusCode.ServiceUnavailable;
        return (IActionResult)new ObjectResult(healthReport) { StatusCode = (int)statusCode };
    }
}

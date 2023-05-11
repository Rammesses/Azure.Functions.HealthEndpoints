using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Extensions.Health;

public class HealthEndpointTriggerFunctions
{
    public const string HealthFunctionName = "health";

    public static Task<IActionResult> RenderHealthDocument(
        [HealthEndpointHttpTriggerContext] HealthEndpointHttpTriggerContext healthEndpointContext,
        HttpRequest req,
        ExecutionContext ctx,
        ILogger log)
    {
        log.LogInformation($"health status was requested.");

        // TODO: Get the health check result

        var content = new ContentResult()
        {
            Content = "Healthy",
            ContentType = "text/json",
            StatusCode = (int)HttpStatusCode.OK,
        };

        return Task.FromResult((IActionResult)content);
    }
}

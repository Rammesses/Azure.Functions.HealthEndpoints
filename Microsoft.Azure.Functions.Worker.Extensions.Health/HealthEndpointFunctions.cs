using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.Functions.Worker.Extensions.Health;

public interface IHealthEndpointFunctions
{
    Task<HttpResponseData> GetHealth(HttpRequestData req, FunctionContext ctx);
}

public class HealthEndpointFunctions : IHealthEndpointFunctions
{
    public const string HealthFunctionName = "health";

    private readonly IHealthEndpointHttpTriggerContext _context;

    public HealthEndpointFunctions(IHealthEndpointHttpTriggerContext context)
    {
        this._context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<HttpResponseData> GetHealth(HttpRequestData req, FunctionContext ctx)
    {
        // TODO: Get the health check result
        var result = @"healthy";

        var response = default(HttpResponseData);
        response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/json");
        await response.WriteStringAsync(result).ConfigureAwait(false);

        return response;
    }

}

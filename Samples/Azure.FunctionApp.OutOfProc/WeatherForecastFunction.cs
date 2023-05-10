using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using WeatherForecast.Shared;

namespace Azure.FunctionApp.OutOfProc
{
    public class WeatherForecastFunction
    {
        private readonly WeatherForecastService _forecastService;
        private readonly ILogger _logger;

        public WeatherForecastFunction(
            WeatherForecastService forecastService,
            ILoggerFactory loggerFactory)
        {
            _forecastService = forecastService;
            _logger = loggerFactory.CreateLogger<WeatherForecastFunction>();
        }
        
        [OpenApiOperation(operationId: "weatherForecast", tags: new[] { "weatherForecast" }, Summary = "Gets the weather forecast", Description = "This gets the weather forecast.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(string), Summary = "The response", Description = "This returns the response")]        
        
        [Function("WeatherForecast")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var forecast = _forecastService.Get();

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(forecast);
            return response;
        }
    }
}

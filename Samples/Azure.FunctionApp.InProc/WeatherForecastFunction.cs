using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System.Net;

using WeatherForecast.Shared;

namespace Azure.FunctionApp
{
    public class WeatherForecastFunction
    {
        private readonly IWeatherForecastService _forecastService;

        public WeatherForecastFunction(
            IWeatherForecastService forecastService)
        {
            _forecastService = forecastService ?? throw new ArgumentNullException(nameof(forecastService)); ;
        }

        [OpenApiOperation(operationId: "weatherForecast", tags: new[] { "weatherForecast" }, Summary = "Gets the weather forecast", Description = "This gets the weather forecast.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(string), Summary = "The response", Description = "This returns the response")]        
        [FunctionName("WeatherForecast")]
        public Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var forecast = _forecastService.Get(5);
            var response = (IActionResult)new OkObjectResult(forecast);
            return Task.FromResult(response);
        }
    }
}

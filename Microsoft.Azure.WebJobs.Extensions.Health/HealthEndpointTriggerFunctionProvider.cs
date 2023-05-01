using System.Collections.Immutable;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Health.Abstractions;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Script.Description;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.WebJobs.Extensions.Health
{
    public class HealthEndpointTriggerFunctionProvider : IFunctionProvider
    {
        private readonly List<FunctionMetadata> functionMetadata
            = new List<FunctionMetadata>();

        public HealthEndpointTriggerFunctionProvider()
        { 
            functionMetadata.Add(GetHealthEndpointFunctionMetadata());
        }

        /// <inheritdoc />
        public ImmutableDictionary<string, ImmutableArray<string>> FunctionErrors { get; } = new Dictionary<string, ImmutableArray<string>>().ToImmutableDictionary();

        public async Task<ImmutableArray<FunctionMetadata>> GetFunctionMetadataAsync()
        {
            return await Task.FromResult(functionMetadata.ToImmutableArray()).ConfigureAwait(false);
        }
            

        private FunctionMetadata GetHealthEndpointFunctionMetadata()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var functionMetadata = new FunctionMetadata()
            {
                Name = HealthEndpointTriggerFunctions.HealthFunctionName,
                FunctionDirectory = null,
                ScriptFile = $"assembly:{assembly.FullName}",
                EntryPoint = $"{assembly.GetName().Name}.{typeof(HealthEndpointTriggerFunctions).Name}.{nameof(HealthEndpointTriggerFunctions.RenderHealthDocument)}",
                Language = "DotNetAssembly"
            };

            AddBindingMetadata(functionMetadata, new HttpBindingMetadata()
            {
                Methods = new List<string>() { HttpMethods.Get },
                Route = "health",
                AuthLevel = AuthorizationLevel.Anonymous,
            });
            AddBindingMetadata(functionMetadata, new HealthEndpointTriggerContextBindingMetadata());

            return functionMetadata;
        }

        private static void AddBindingMetadata(FunctionMetadata functionMetadata, object bindingInfo)
        {
            var jsonObject = JObject.FromObject(bindingInfo);
            var bindingMetadata = BindingMetadata.Create(jsonObject);
            functionMetadata.Bindings.Add(bindingMetadata);
        }
    }
}
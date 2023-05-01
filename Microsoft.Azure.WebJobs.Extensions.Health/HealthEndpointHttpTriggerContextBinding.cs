using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Config;

namespace Microsoft.Azure.WebJobs.Extensions.Health;

[Extension(nameof(HealthEndpointHttpTriggerContextBinding))]
public class HealthEndpointHttpTriggerContextBinding : IExtensionConfigProvider
{
    public void Initialize(ExtensionConfigContext context)
    {
        var rule = context.AddBindingRule<HealthEndpointHttpTriggerContextAttribute>();
        rule.BindToInput((attr, vbContext) =>
        {
            var httpContext = vbContext.FunctionContext.CreateObjectInstance<HealthEndpointHttpTriggerContext>();
            return Task.FromResult(httpContext);
        });
    }
}
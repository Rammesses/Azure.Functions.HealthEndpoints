using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.Health;

/// <summary>
/// This represents the parameter binding attribute that injects the
/// <see cref="HealthEndpointHttpTriggerContext"/> instance to each
/// Health HTTP trigger endpoint.
/// </summary>
[Binding]
[AttributeUsage(AttributeTargets.Parameter)]
public class HealthEndpointHttpTriggerContextAttribute : Attribute
{
}
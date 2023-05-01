using Microsoft.Azure.WebJobs.Extensions.Health.Abstractions;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.Health;

public class HealthEndpointTriggerContextBindingMetadata
{
    /// <summary>
    /// Gets or sets the name of the binding parameter. Default value is <c>openApiContext</c>.
    /// </summary>
    [JsonRequired]
    [JsonProperty("name")]
    public virtual string Name { get; set; } = "healthEndpointContext";

    /// <summary>
    /// Gets or sets the binding type. Default value is <c>openApiHttpTriggerContext</c>.
    /// </summary>
    [JsonRequired]
    [JsonProperty("type")]
    public virtual string Type { get; set; } = "healthEndpointHttpTriggerContext";

    /// <summary>
    /// Gets or sets the binding direction. Default value is <see cref="BindingDirectionType.In"/>.
    /// </summary>
    [JsonRequired]
    [JsonProperty("direction")]
    public virtual BindingDirectionType Direction { get; set; } = BindingDirectionType.In;
}
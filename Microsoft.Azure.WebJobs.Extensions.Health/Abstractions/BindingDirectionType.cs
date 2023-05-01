using System;
namespace Microsoft.Azure.WebJobs.Extensions.Health.Abstractions;

/// <summary>
/// This specifies the binding direction type
/// </summary>
/// <remarks>
/// This has to be duplicated because the equivalent in the Azure Functions SDK
/// is internal.
/// </remarks>
public enum BindingDirectionType
{
    /// <summary>
    /// Identifies <c>In</c>.
    /// </summary>
    In = 0,

    /// <summary>
    /// Identifies <c>Out</c>.
    /// </summary>
    Out = 1,

    /// <summary>
    /// Identifies <c>In/Out</c>.
    /// </summary>
    InOut = 2,
}

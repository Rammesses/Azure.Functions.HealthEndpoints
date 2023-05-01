using System;
namespace Microsoft.Azure.WebJobs.Extensions.Health.Abstractions;

/// <summary>
/// This specifies the binding data type.
/// </summary>
/// <remarks>
/// This has to be duplicated because the equivalent in the Azure Functions SDK
/// is internal.
/// </remarks>
public enum BindingDataType
{
    /// <summary>
    /// Identifies <c>Undefined</c>.
    /// </summary>
    Undefined = 0,

    /// <summary>
    /// Identifies <c>String</c>.
    /// </summary>
    String = 1,

    /// <summary>
    /// Identifies <c>Binary</c>.
    /// </summary>
    Binary = 2,

    /// <summary>
    /// Identifies <c>Undefined</c>.
    /// </summary>
    Stream = 3,
}

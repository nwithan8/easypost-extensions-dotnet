using Xunit.Sdk;

namespace EasyPost.Extensions.Test.Utilities.Assertions;

/// <summary>
/// Exception thrown when a KeyPathValueEqualsException assertion has one or more items fail an assertion.
/// </summary>
public class KeyPathValueEqualsException : XunitException
{
    /// <summary>
    /// Creates a new instance of the <see cref="KeyPathValueEqualsException"/> class.
    /// </summary>
    public KeyPathValueEqualsException()
        : base("Assert.KeyPathValueEquals() Failure")
    {
    }

    public KeyPathValueEqualsException(string[] path, object? expected, object actual)
        : base($"Assert.KeyPathValueEquals() Failure: Key path '{string.Join(" -> ", path)}' does not have the expected value. Expected: {expected}, Actual: {actual}")
    {
    }

    public KeyPathValueEqualsException(string[] path)
        : base($"" +
               $"Assert.KeyPathValueEquals() Failure: Key path '{string.Join(" -> ", path)}' does not exist.")
    {
    }
}

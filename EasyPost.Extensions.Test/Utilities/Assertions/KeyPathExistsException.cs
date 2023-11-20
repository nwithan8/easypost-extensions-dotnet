using Xunit.Sdk;

namespace EasyPost.Extensions.Test.Utilities.Assertions;

/// <summary>
/// Exception thrown when a KeyPathExists assertion has one or more items fail an assertion.
/// </summary>
public class KeyPathExistsException : XunitException
{
    /// <summary>
    /// Creates a new instance of the <see cref="KeyPathExistsException"/> class.
    /// </summary>
    public KeyPathExistsException()
        : base("Assert.KeyPathExists() Failure")
    {
    }
    
    public KeyPathExistsException(string[] path)
        : base($"Assert.KeyPathExists() Failure: Key path '{string.Join(" -> ", path)}' does not exist.")
    {
    }
}

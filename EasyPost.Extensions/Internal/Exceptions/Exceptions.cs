using System.Reflection;

namespace EasyPost.Extensions.Internal.Exceptions;

/// <summary>
///     A base exception for all exceptions in the EasyPost.Extensions library.
/// </summary>
public abstract class BaseException : Exception
{
    /// <summary>
    ///     Constructs a new <see cref="BaseException"/> with the given message.
    /// </summary>
    /// <param name="message">A message to display with the exception.</param>
    internal BaseException(string? message) : base(message)
    {
    }

    /// <summary>
    ///     Constructs a new <see cref="BaseException"/> with the given message and inner exception.
    /// </summary>
    /// <param name="message">A message to display with the exception.</param>
    /// <param name="innerException">An inner <see cref="Exception"/> to pass down for a stack trace.</param>
    internal BaseException(string? message, Exception innerException) : base(message, innerException)
    {
    }

    /// <summary>
    ///     Populates a message template with the given elements.
    /// </summary>
    /// <param name="messageTemplate">A message template string.</param>
    /// <param name="elements">A list of elements to insert into the message template.</param>
    /// <returns>A formatted message string.</returns>
    internal static string PopulateMessage(string messageTemplate, params object?[]? elements)
    {
        return elements == null ? messageTemplate : string.Format(messageTemplate, elements);
    }
}

/// <summary>
///     An exception to be thrown when a required parameter is missing.
/// </summary>
[Serializable]
public class MissingRequiredParameterException : BaseException
{
    /// <summary>
    ///     The message template for this exception.
    /// </summary>
    internal static string MessageTemplate => "{0} is a required parameter.";

    /// <summary>
    ///     Constructs a new <see cref="MissingRequiredParameterException"/> with the given property.
    /// </summary>
    /// <param name="property">The <see cref="PropertyInfo"/> of the missing property.</param>
    internal MissingRequiredParameterException(PropertyInfo property) : base(PopulateMessage(MessageTemplate, property.Name))
    {
    }

    /// <summary>
    ///     Constructs a new <see cref="MissingRequiredParameterException"/> with the given property and inner exception.
    /// </summary>
    /// <param name="innerException">An inner <see cref="Exception"/> to pass down for a stack trace.</param>
    /// <param name="property">The <see cref="PropertyInfo"/> of the missing property.</param>
    internal MissingRequiredParameterException(Exception innerException, PropertyInfo property) : base(PopulateMessage(MessageTemplate, property.Name), innerException)
    {
    }
}

/// <summary>
///     An exception to be thrown when a parameter group is incomplete.
/// </summary>
[Serializable]
public class IncompleteParameterGroupsException : BaseException
{
    /// <summary>
    ///     The message template for this exception.
    /// </summary>
    internal static string MessageTemplate => "The following parameter groups are missing some or all of their respective required properties: {0}";

    /// <summary>
    ///     Constructs a new <see cref="IncompleteParameterGroupsException"/> with the given group names.
    /// </summary>
    /// <param name="groupNames">A list of names of groups that are incomplete.</param>
    internal IncompleteParameterGroupsException(IEnumerable<string> groupNames) : base(PopulateMessage(MessageTemplate, string.Join(", ", groupNames)))
    {
    }

    /// <summary>
    ///     Constructs a new <see cref="IncompleteParameterGroupsException"/> with the given group names and inner exception.
    /// </summary>
    /// <param name="innerException">An inner <see cref="Exception"/> to pass down for a stack trace.</param>
    /// <param name="groupNames">A list of names of groups that are incomplete.</param>
    internal IncompleteParameterGroupsException(Exception innerException, List<string> groupNames) : base(PopulateMessage(MessageTemplate, string.Join(", ", groupNames)), innerException)
    {
    }
}

/// <summary>
///     An exception to be thrown when there are no more pages to iterate through.
/// </summary>
[Serializable]
public class EndOfPaginationException : BaseException
{
    /// <summary>
    ///     The message template for this exception.
    /// </summary>
    internal static string MessageTemplate => "There are no more items to iterate through.";

    /// <summary>
    ///     Constructs a new <see cref="EndOfPaginationException"/>.
    /// </summary>
    internal EndOfPaginationException() : base(PopulateMessage(MessageTemplate))
    {
    }

    /// <summary>
    ///     Constructs a new <see cref="EndOfPaginationException"/> with the given inner exception.
    /// </summary>
    /// <param name="innerException">An inner <see cref="Exception"/> to pass down for a stack trace.</param>
    internal EndOfPaginationException(Exception innerException) : base(PopulateMessage(MessageTemplate), innerException)
    {
    }
}

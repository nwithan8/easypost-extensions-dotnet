using System;
using System.Collections.Generic;
using System.Reflection;

namespace EasyPost.Extensions.Exceptions;

public abstract class BaseException : Exception
{
    internal BaseException(string? message) : base(message)
    {
    }

    internal BaseException(string? message, Exception innerException) : base(message, innerException)
    {
    }

    internal static string PopulateMessage(string messageTemplate, params object?[]? elements)
    {
        return elements == null ? messageTemplate : string.Format(messageTemplate, elements);
    }
}

[Serializable]
public class MissingRequiredParameterException : BaseException
{
    internal static string MessageTemplate => "{0} is a required parameter.";

    internal MissingRequiredParameterException(PropertyInfo property) : base(PopulateMessage(MessageTemplate, property.Name))
    {
    }

    internal MissingRequiredParameterException(Exception innerException, PropertyInfo property) : base(PopulateMessage(MessageTemplate, property.Name), innerException)
    {
    }
}

[Serializable]
public class IncompleteParameterGroupsException: BaseException
{
    internal static string MessageTemplate => "The following parameter groups are missing some or all of their respective required properties: {0}";

    internal IncompleteParameterGroupsException(IEnumerable<string> groupNames) : base(PopulateMessage(MessageTemplate, string.Join(", ", groupNames)))
    {
    }
    
    internal IncompleteParameterGroupsException(Exception innerException, List<string> groupNames) : base(PopulateMessage(MessageTemplate, string.Join(", ", groupNames)), innerException)
    {
    }
}

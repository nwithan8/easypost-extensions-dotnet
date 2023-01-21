using System.Reflection;

namespace EasyPost.Extensions.Internal.Exceptions;

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

[Serializable]
public class IncompatibleApiVersionException : BaseException
{
    internal static string MessageTemplate => "The provided API version {0} is not compatible with this object. The object requires {1}.";

    internal IncompatibleApiVersionException(string providedApiVersion, string requiredApiVersion) : base(PopulateMessage(MessageTemplate, providedApiVersion, requiredApiVersion))
    {
    }
    
    internal IncompatibleApiVersionException(ApiVersion providedApiVersion, ApiVersion requiredApiVersion) : base(PopulateMessage(MessageTemplate, providedApiVersion.ToString(), requiredApiVersion.ToString()))
    {
    }

    internal IncompatibleApiVersionException(Exception innerException, string providedApiVersion, string requiredApiVersion) : base(PopulateMessage(MessageTemplate, providedApiVersion, requiredApiVersion), innerException)
    {
    }
    
    internal IncompatibleApiVersionException(Exception innerException, ApiVersion providedApiVersion, ApiVersion requiredApiVersion) : base(PopulateMessage(MessageTemplate, providedApiVersion.ToString(), requiredApiVersion.ToString()), innerException)
    {
    }
}

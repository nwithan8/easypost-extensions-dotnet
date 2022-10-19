using System;
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
internal class MissingRequiredParameterException : BaseException
{
    public static string MessageTemplate => "{0} is a required parameter.";

    internal MissingRequiredParameterException(PropertyInfo property) : base(PopulateMessage(MessageTemplate, property.Name))
    {
    }

    internal MissingRequiredParameterException(Exception innerException, PropertyInfo property) : base(PopulateMessage(MessageTemplate, property.Name), innerException)
    {
    }
}

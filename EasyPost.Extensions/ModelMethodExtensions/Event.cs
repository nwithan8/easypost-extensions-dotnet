using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Event"/>.
/// </summary>
public static class EventModelExtensions
{
    public static Enums.EventType? Type(this Event @event)
    {
        return Enums.EventType.FromEvent(@event);
    }
}

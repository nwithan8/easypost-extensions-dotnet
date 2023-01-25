using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.EventService" /> class.
/// </summary>
public static class EventServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Event"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.EventService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Events.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An <see cref="EasyPost.Models.API.EventCollection"/> object.</returns>
    public static async Task<EventCollection> All(this EventService service, Events.All parameters, ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    // TODO: Add payload retrieval methods(?)
    
    /// <summary>
    ///     Retrieve the next page of an <see cref="EasyPost.Models.API.EventCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.EventService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.EventCollection"/> to iterate on.</param>
    /// <returns>An <see cref="EasyPost.Models.API.EventCollection"/> object.</returns>
    public static async Task<EventCollection> GetNextPage(this EventService service, EventCollection collection)
    {
        var events = collection.Events;

        var parameters = collection.BuildNextPageParameters<Parameters.V2.Events.All, Event>(events);

        return await service.All(parameters);
    }
}

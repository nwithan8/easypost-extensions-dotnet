using EasyPost.Extensions.Internal.Exceptions;
using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.TrackerService" /> class.
/// </summary>
public static class TrackerServiceExtensions
{
    /// <summary>
    ///     List all <see cref="EasyPost.Models.API.Tracker"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.TrackerService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Trackers.All"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>A <see cref="EasyPost.Models.API.TrackerCollection"/> object.</returns>
    public static async Task<TrackerCollection> All(this TrackerService service, Trackers.All parameters, Enums.ApiVersion? apiVersion = null)
    {
        return await service.All(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.Tracker"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.TrackerService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Trackers.Create"/> parameters to use for the API call.</param>
    /// <returns>A <see cref="EasyPost.Models.API.Tracker"/> object.</returns>
    public static async Task<Tracker> Create(this TrackerService service, Trackers.Create parameters)
    {
        parameters.Validate();
        return await service.Create(parameters.Carrier!, parameters.TrackingCode!);
    }

    /// <summary>
    ///     Create a list of <see cref="EasyPost.Models.API.Tracker"/>s.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.TrackerService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Trackers.CreateList"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="Enums.ApiVersion"/> to target.</param>
    /// <returns>None</returns>
    public static async Task CreateList(this TrackerService service, Trackers.CreateList parameters, Enums.ApiVersion? apiVersion = null)
    {
        await service.CreateList(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Retrieve the next page of a <see cref="EasyPost.Models.API.TrackerCollection"/>.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.TrackerService"/> to use for the API call.</param>
    /// <param name="collection">The <see cref="EasyPost.Models.API.TrackerCollection"/> to iterate on.</param>
    /// <returns>A <see cref="EasyPost.Models.API.TrackerCollection"/> object.</returns>
    public static async Task<TrackerCollection> GetNextPage(this TrackerService service, TrackerCollection collection)
    {
        var trackers = collection.Trackers;

        if (trackers == null || trackers.Count == 0)
        {
            throw new EndOfPaginationException();
        }

        var hasNextPage = (bool)collection.HasMore!;

        if (!hasNextPage)
        {
            throw new EndOfPaginationException();
        }

        var lastId = trackers.Last()!.Id;

        var parameters = new Parameters.V2.Trackers.All
        {
            AfterId = lastId,
        };

        return await service.All(parameters);
    }
}

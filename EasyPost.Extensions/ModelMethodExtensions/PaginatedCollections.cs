using EasyPost.Extensions.Internal.Exceptions;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.Shared;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Models.Shared.Collection"/> class, specifically for paginated collections.
/// </summary>
internal static class PaginatedCollections
{
    /// <summary>
    ///     Build the parameters to retrieve the next page of a paginated collection.
    /// </summary>
    /// <param name="collection">The current collection.</param>
    /// <param name="entries">The entries of the collection.</param>
    /// <typeparam name="T">The subtype of <see cref="AllRequestParameters"/> to build.</typeparam>
    /// <typeparam name="T2">The type of <see cref="EasyPost._base.EasyPostObject"/> the entries are.</typeparam>
    /// <returns>A T-type parameters object.</returns>
    /// <exception cref="EndOfPaginationException">Thrown if there are no more items to retrieve for the paginated collection.</exception>
    internal static T BuildNextPageParameters<T, T2>(this Collection collection, List<T2>? entries) where T : AllRequestParameters, new() where T2 : EasyPost._base.EasyPostObject
    {
        if (entries == null || entries.Count == 0)
        {
            throw new EndOfPaginationException();
        }

        var hasNextPage = (bool)collection.HasMore!;

        if (!hasNextPage)
        {
            throw new EndOfPaginationException();
        }

        var lastId = entries.Last()!.Id;

        return new T
        {
            AfterId = lastId,
        };
    }
}

using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="Parcel"/>s.
/// </summary>
public abstract class Parcels : DummyDataCreator
{
    /// <summary>
    ///     Create a dummy <see cref="Parcel"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="Parcel"/> object.</returns>
    public static async Task<Parcel> CreateParcel(Client client)
    {
        var parameters = new EasyPost.Parameters.Parcel.Create
        {
            Length = Internal.Random.RandomIntInRange(0, 100),
            Width = Internal.Random.RandomIntInRange(0, 100),
            Height = Internal.Random.RandomIntInRange(0, 100),
            Weight = Internal.Random.RandomIntInRange(0, 100),
        };

        return await client.Parcel.Create(parameters);
    }

    /// <summary>
    ///     <see cref="EasyPost.Extensions.Parameters.Parcel.Create"/> parameter sets for common <see cref="Parcel"/>s.
    /// </summary>
    public static class Common
    {
        public static EasyPost.Extensions.Parameters.Parcel.Create Documents => new()
        {
            PredefinedPackage = "FlatRateEnvelope",
        };
        
        public static EasyPost.Extensions.Parameters.Parcel.Create LegalDocuments => new()
        {
            PredefinedPackage = "FlatRateLegalEnvelope",
        };
        
        public static EasyPost.Extensions.Parameters.Parcel.Create Shoes => new()
        {
            PredefinedPackage = "MediumFlatRateBox",
        };
        
        public static EasyPost.Extensions.Parameters.Parcel.Create Shirt => new()
        {
            PredefinedPackage = "MediumFlatRateBox",
        };
        
        public static EasyPost.Extensions.Parameters.Parcel.Create GiftCards => new()
        {
            PredefinedPackage = "SmallFlatRateBox",
        };
    }
}

using EasyPost.Extensions.ServiceMethodExtensions;

namespace EasyPost.Extensions.Testing.DummyData;

public abstract class Insurance : DummyDataCreator
{
    /// <summary>
    ///     Create a dummy <see cref="EasyPost.Models.API.Insurance"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <returns>A <see cref="Insurance"/> object.</returns>
    public static async Task<EasyPost.Models.API.Insurance> CreateInsurance(Client client)
    {
        var parameters = new Parameters.V2.Insurance.Create
        {
            Amount = Internal.Random.RandomIntInRange(0, 100),
        };

        return await client.Insurance.Create(parameters);
    }
}

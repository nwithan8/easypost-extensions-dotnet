using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Shipment"/>.
/// </summary>
public static class ShipmentModelExtensions
{
    /// <summary>
    ///     Buy a <see cref="EasyPost.Models.API.Shipment"/>.
    /// </summary>
    /// <param name="shipment">The <see cref="EasyPost.Models.API.Shipment"/> to buy.</param>
    /// <param name="parameters">The <see cref="Shipments.Buy"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>True if the purchase was successful, false otherwise.</returns>
    public static async Task Buy(this Shipment shipment, Shipments.Buy parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        await shipment.Buy(parameters.Rate!, parameters.InsuranceValue, parameters.AddCarbonOffset, parameters.EndShipper?.Id);
    }

    /// <summary>
    ///     Generate a <see cref="EasyPost.Models.API.PostageLabel"/> for a <see cref="EasyPost.Models.API.Shipment"/>.
    /// </summary>
    /// <param name="shipment">The <see cref="EasyPost.Models.API.Shipment"/> to generate a label for.</param>
    /// <param name="parameters">The <see cref="Shipments.CreateDocument"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Shipment"/> object.</returns>
    public static async Task<Shipment> GenerateLabel(this Shipment shipment, Shipments.CreateDocument parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await shipment.GenerateLabel(parameters.FileFormat!.ToString()!);
    }

    /// <summary>
    ///     Insure a <see cref="EasyPost.Models.API.Shipment"/>.
    /// </summary>
    /// <param name="shipment">The <see cref="EasyPost.Models.API.Shipment"/> to insure.</param>
    /// <param name="parameters">The <see cref="Shipments.Insure"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Shipment"/> object.</returns>
    public static async Task<Shipment> Insure(this Shipment shipment, Shipments.Insure parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await shipment.Insure((double)parameters.Amount!);
    }

    /// <summary>
    ///     Regenerate the <see cref="EasyPost.Models.API.Rate"/>s of a <see cref="EasyPost.Models.API.Shipment"/>.
    /// </summary>
    /// <param name="shipment">The <see cref="EasyPost.Models.API.Shipment"/> to regenerate rates for.</param>
    /// <param name="parameters">The <see cref="Shipments.RegenerateRates"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Shipment"/> object.</returns>
    public static async Task<Shipment> RegenerateRates(this Shipment shipment, Shipments.RegenerateRates parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        await shipment.RegenerateRates(null, parameters.AddCarbonOffset);
        return shipment;
    }
}

public static class ShipmentCollectionModelExtensions
{}

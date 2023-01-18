using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class ShipmentModelExtensions
{
    public static async Task Buy(this Shipment obj, Shipments.Buy parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        await obj.Buy(parameters.Rate!, parameters.InsuranceValue, parameters.WithCarbonOffset ?? false, parameters.EndShipper?.Id);
    }

    public static async Task<Shipment> GenerateLabel(this Shipment obj, Shipments.CreateDocument parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await obj.GenerateLabel(parameters.FileFormat!);
    }

    public static async Task<Shipment> Insure(this Shipment obj, Shipments.Insure parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await obj.Insure((double)parameters.Amount!);
    }

    /*
    public static async Task RegenerateRates(this Shipment obj, Shipments.RegenerateRates parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await obj.RegenerateRates(parameters.Amount!);
    }
    */
}

public static class ShipmentCollectionModelExtensions
{}

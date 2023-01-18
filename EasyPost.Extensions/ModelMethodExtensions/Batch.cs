using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class BatchModelExtensions
{
    public static async Task<Batch> AddShipments(this Batch obj, Batches.UpdateShipments parameters, ApiVersion? apiVersion = null)
    {
        return await obj.AddShipments(parameters.ToDictionary(apiVersion));
    }

    public static async Task<Batch> GenerateLabel(this Batch obj, Batches.CreateDocument parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await obj.GenerateLabel(parameters.FileFormat!);
    }

    public static async Task<Batch> GenerateScanForm(this Batch obj, Batches.CreateDocument parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await obj.GenerateLabel(parameters.FileFormat!);
    }

    public static async Task<Batch> RemoveShipments(this Batch obj, Batches.UpdateShipments parameters, ApiVersion? apiVersion = null)
    {
        return await obj.RemoveShipments(parameters.ToDictionary(apiVersion));
    }
}

public static class BatchCollectionModelExtensions
{}

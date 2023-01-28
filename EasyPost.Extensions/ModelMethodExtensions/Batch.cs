using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;
using NetTools.Common;

namespace EasyPost.Extensions.ModelMethodExtensions;

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.Batch"/>.
/// </summary>
public static class BatchModelExtensions
{
    /// <summary>
    ///     Add <see cref="EasyPost.Models.API.Shipment"/>s to a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="batch">The <see cref="EasyPost.Models.API.Batch"/> to add shipments to.</param>
    /// <param name="parameters">The <see cref="Batches.UpdateShipments"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<Batch> AddShipments(this Batch batch, Batches.UpdateShipments parameters, ApiVersion? apiVersion = null)
    {
        return await batch.AddShipments(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Generate a <see cref="EasyPost.Models.API.PostageLabel"/> for a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="batch">The <see cref="EasyPost.Models.API.Batch"/> to generate a label for.</param>
    /// <param name="parameters">The <see cref="Batches.CreateDocument"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<Batch> GenerateLabel(this Batch batch, Batches.CreateDocument parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await batch.GenerateLabel(parameters.FileFormat!.ToString()!);
    }

    /// <summary>
    ///     Generate a <see cref="EasyPost.Models.API.ScanForm"/> for a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="batch">The <see cref="EasyPost.Models.API.Batch"/> to generate a label for.</param>
    /// <param name="parameters">The <see cref="Batches.CreateDocument"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<Batch> GenerateScanForm(this Batch batch, Batches.CreateDocument parameters, ApiVersion? apiVersion = null)
    {
        parameters.Validate();
        return await batch.GenerateLabel(parameters.FileFormat!.ToString()!);
    }

    /// <summary>
    ///     Remove <see cref="EasyPost.Models.API.Shipment"/>s from a <see cref="EasyPost.Models.API.Batch"/>.
    /// </summary>
    /// <param name="batch">The <see cref="EasyPost.Models.API.Batch"/> to remove shipments from.</param>
    /// <param name="parameters">The <see cref="Batches.UpdateShipments"/> parameters to use for the API call.</param>
    /// <param name="apiVersion">The <see cref="ApiVersion"/> to target.</param>
    /// <returns>An updated <see cref="EasyPost.Models.API.Batch"/> object.</returns>
    public static async Task<Batch> RemoveShipments(this Batch batch, Batches.UpdateShipments parameters, ApiVersion? apiVersion = null)
    {
        return await batch.RemoveShipments(parameters.ToDictionary(apiVersion));
    }

    /// <summary>
    ///     Get the <see cref="EasyPost.Models.API.Batch.State"/> as a <see cref="EasyPost.Extensions.BatchState"/> enum.
    /// </summary>
    /// <returns>The related <see cref="EasyPost.Extensions.BatchState"/> enum.</returns>
    public static BatchState? FormTypeEnum(this Batch batch)
    {
        return ValueEnum.FromValue<BatchState>(batch.State);
    }
}

/// <summary>
///     Extension methods for a <see cref="EasyPost.Models.API.BatchCollection"/>.
/// </summary>
public static class BatchCollectionModelExtensions
{
}

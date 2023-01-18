using System.Threading.Tasks;
using EasyPost.Extensions.Parameters;
using EasyPost.Extensions.Parameters.V2;
using EasyPost.Models.API;

namespace EasyPost.Extensions.ModelMethodExtensions;

public static class EndShipperModelExtensions
{
    public static async Task<EndShipper> Update(this EndShipper obj, EndShippers.Update parameters, ApiVersion? apiVersion = null)
    {
        return await obj.Update(parameters.ToDictionary(apiVersion));
    }
}

public static class EndShipperCollectionModelExtensions
{}

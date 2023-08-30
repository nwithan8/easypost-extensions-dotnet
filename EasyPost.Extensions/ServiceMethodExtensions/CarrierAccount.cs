using EasyPost.Models.API;
using EasyPost.Services;

namespace EasyPost.Extensions.ServiceMethodExtensions;

/// <summary>
///     Extensions for the <see cref="EasyPost.Services.CarrierAccountService" /> class.
/// </summary>
public static class CarrierAccountServiceExtensions
{ 
    /// <summary>
    ///     Create a <see cref="EasyPost.Models.API.CarrierAccount"/> tied to a carrier account with a custom parameter set.
    ///     Use this method rather than <see cref="EasyPost.Services.CarrierAccountService.Create(EasyPost.Parameters.CarrierAccount.Create,CancellationToken)"/> when you need to specify carrier-specific parameters.
    /// </summary>
    /// <param name="service">The <see cref="EasyPost.Services.CarrierAccountService"/> to use for the API call.</param>
    /// <param name="parameters">The <see cref="Parameters.CarrierAccount.CreateCustom"/> parameters to use for the API call.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> to use for the HTTP request.</param>
    /// <returns>A <see cref="EasyPost.Models.API.CarrierAccount"/> object.</returns>
    public static async Task<CarrierAccount> CreateCustom(this CarrierAccountService service, Parameters.CarrierAccount.CreateCustom parameters, CancellationToken cancellationToken = default)
    {
        // base function accepts child-Create classes of parameters, as well as Create class. Does not accept Create + FedEx/UPS account type.
        return await service.Create(parameters, cancellationToken);
    }
}

using System.Diagnostics.CodeAnalysis;

namespace EasyPost.Extensions.Parameters.EndShipper
{
    /// <summary>
    ///     <a href="https://www.easypost.com/docs/api#update-an-endshipper">Parameters</a> for <see cref="EasyPost.Services.EndShipperService.Update(string, Update, System.Threading.CancellationToken)"/> API calls.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Update : EasyPost.Parameters.EndShipper.Update
    {
        public static Update FromObject(EasyPost.Models.API.EndShipper obj)
        {
            return new Update
            {
                City = obj.City,
                Country = obj.Country,
                Company = obj.Company,
                Email = obj.Email,
                Name = obj.Name,
                Phone = obj.Phone,
                State = obj.State,
                Street1 = obj.Street1,
                Street2 = obj.Street2,
                Zip = obj.Zip,
            };
        }
    }
}

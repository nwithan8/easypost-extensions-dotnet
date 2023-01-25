using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class ReferralCustomers
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.ReferralCustomer"/> creation API calls.
    /// </summary>
    public class Create : CreateRequestParameters
    {
        #region Request Parameters

        [JsonRequestParameter(Necessity.Optional, "user", "email")]
        public string? Email { get; set; }

        [JsonRequestParameter(Necessity.Optional, "user", "name")]
        public string? Name { get; set; }

        [JsonRequestParameter(Necessity.Optional, "user", "phone")]
        public string? PhoneNumber { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Create"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public override bool MatchesExistingObject(EasyPostObject existingObject)
        {
            if (existingObject is not EasyPost.Models.API.ReferralCustomer customer)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { customer.Name, this.Name },
                { customer.Email, this.Email },
                { customer.PhoneNumber, this.PhoneNumber },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.ReferralCustomer"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}
}

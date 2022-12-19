using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class ReferralCustomers
{
    public class Create : CreateRequestParameters
    {
        #region Request Parameters

        [RequestParameter(Necessity.Optional, "user", "email")]
        public string? Email { get; set; }

        [RequestParameter(Necessity.Optional, "user", "name")]
        public string? Name { get; set; }

        [RequestParameter(Necessity.Optional, "user", "phone")]
        public string? PhoneNumber { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.ReferralCustomer customer)
        {
            var pairs = new Pairs
            {
                { customer.Name, this.Name },
                { customer.Email, this.Email },
                { customer.PhoneNumber, this.PhoneNumber },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class All : AllRequestParameters
    {}
}

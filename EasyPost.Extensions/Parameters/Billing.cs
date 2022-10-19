using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Billing
{
    public sealed class Fund : RequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Required, "amount")]
        public string? Amount { get; set; }

        #endregion

        public Fund(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}

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
    
    public sealed class Refund : RequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "amount")]
        public int? Amount { get; set; }
        
        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "payment_log_id")]
        public string? PaymentLogId { get; set; }

        #endregion

        public Refund(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}

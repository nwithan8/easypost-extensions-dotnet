using EasyPost.Extensions.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.V2;

public static class Billing
{
    public sealed class Fund : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public string? Amount { get; set; }

        #endregion

        public Fund(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    public sealed class Refund : RequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "amount")]
        public int? Amount { get; set; }
        
        
        [JsonRequestParameter(Necessity.Optional, "payment_log_id")]
        public string? PaymentLogId { get; set; }

        #endregion

        public Refund(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}

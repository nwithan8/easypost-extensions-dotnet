using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Parameters;

namespace EasyPost.Extensions.Parameters.Billing;

/// <summary>
///     Parameters for refunding API calls.
/// </summary>
public class Refund : BaseParameters
{
    #region Request Parameters
    
    [JsonRequestParameter(Necessity.Optional, "amount")]
    public int? Amount { get; set; }
        
        
    [JsonRequestParameter(Necessity.Optional, "payment_log_id")]
    public string? PaymentLogId { get; set; }

    #endregion

    /// <summary>
    ///     Construct a new set of <see cref="Billing.Refund"/> parameters.
    /// </summary>
    public Refund()
    {
    }
}

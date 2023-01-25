using EasyPost.Extensions.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.V2;

public static class Billing
{
    /// <summary>
    ///     Parameters for funding API calls.
    /// </summary>
    public sealed class Fund : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public string? Amount { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Fund"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Fund(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    /// <summary>
    ///     Parameters for refunding API calls.
    /// </summary>
    public sealed class Refund : RequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "amount")]
        public int? Amount { get; set; }
        
        
        [JsonRequestParameter(Necessity.Optional, "payment_log_id")]
        public string? PaymentLogId { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Refund"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Refund(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}

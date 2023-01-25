using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2
{
    /// <summary>
    ///     Base class for all parameters used in requests to <see cref="EasyPost.Extensions.ApiVersion.V2"/> endpoints.
    /// </summary>
    public abstract class RequestParameters : Parameters
    {
        /// <summary>
        ///     The <see cref="EasyPost.Extensions.ApiVersion"/> this set of parameters is intended for.
        /// </summary>
        public override ApiVersion ApiVersion => ApiVersion.V2;
        
        /// <summary>
        ///     Construct a new set of <see cref="RequestParameters"/>.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        internal RequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    /// <summary>
    ///     Base class for all parameters used in "create" requests to <see cref="EasyPost.Extensions.ApiVersion.V2"/> endpoints.
    /// </summary>
    public abstract class CreateRequestParameters : RequestParameters
    {
        /// <summary>
        ///     Construct a new set of <see cref="CreateRequestParameters"/>.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        internal CreateRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public abstract bool MatchesExistingObject(EasyPost._base.EasyPostObject existingObject);
    }

    /// <summary>
    ///     Base class for all parameters used in "update" requests to <see cref="EasyPost.Extensions.ApiVersion.V2"/> endpoints.
    /// </summary>
    public abstract class UpdateRequestParameters : RequestParameters
    {
        /// <summary>
        ///     Construct a new set of <see cref="UpdateRequestParameters"/>.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        internal UpdateRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    /// <summary>
    ///     Base class for all parameters used in "list" requests to <see cref="EasyPost.Extensions.ApiVersion.V2"/> endpoints.
    /// </summary>
    public abstract class AllRequestParameters : RequestParameters
    {
        #region Request Parameters
        
        /// <summary>
        ///     Only records created after the given ID will be included. May not be used with <see cref="EasyPost.Extensions.Parameters.Beta.AllRequestParameters.BeforeId"/>.
        /// </summary>
        [JsonRequestParameter(Necessity.Optional, "after_id")]
        public string? AfterId { get; set; }

        /// <summary>
        ///     Only records created before the given ID will be included. May not be used with <see cref="EasyPost.Extensions.Parameters.Beta.AllRequestParameters.AfterId"/>.
        /// </summary>
        [JsonRequestParameter(Necessity.Optional, "before_id")]
        public string? BeforeId { get; set; }

        /// <summary>
        ///     Only return records created before this timestamp. Defaults to 1 month ago, or 1 month before a passed <see cref="EasyPost.Extensions.Parameters.Beta.AllRequestParameters.StartDatetime"/>.
        /// </summary>
        [JsonRequestParameter(Necessity.Optional, "end_datetime")]
        public string? EndDatetime { get; set; }

        /// <summary>
        ///     The number of records to return on each page. The maximum value is 100, and default is 20.
        /// </summary>
        [JsonRequestParameter(Necessity.Optional, "page_size")]
        public int PageSize { get; set; } = 20;

        /// <summary>
        ///     Only return records created after this timestamp. Defaults to 1 month ago, or 1 month before a passed <see cref="EasyPost.Extensions.Parameters.Beta.AllRequestParameters.EndDatetime"/>.
        /// </summary>
        [JsonRequestParameter(Necessity.Optional, "start_datetime")]
        public string? StartDatetime { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="AllRequestParameters"/>.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        internal AllRequestParameters(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}

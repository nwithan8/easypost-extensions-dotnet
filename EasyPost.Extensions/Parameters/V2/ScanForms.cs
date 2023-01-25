using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class ScanForms
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.ScanForm"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

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
            if (existingObject is not EasyPost.Models.API.ScanForm scanForm)
            {
                return false;
            }

            var pairs = new Pairs
            {
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.ScanForm"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}
}

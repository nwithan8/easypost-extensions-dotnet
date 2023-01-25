using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Parcels
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Parcel"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "parcel", "height")]
        public double? Height { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "parcel", "length")]
        public double? Length { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "parcel", "weight")]
        public double? Weight { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "parcel", "width")]
        public double? Width { get; set; }

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
            if (existingObject is not EasyPost.Models.API.Parcel parcel)
            {
                return false;
            }
                
            var pairs = new Pairs
            {
                { parcel.Length, Length },
                { parcel.Width, Width },
                { parcel.Height, Height },
                { parcel.Weight, Weight },
            };

            return pairs.AllMatch();
        }
    }
}

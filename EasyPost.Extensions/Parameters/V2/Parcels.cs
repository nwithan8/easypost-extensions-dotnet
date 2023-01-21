using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Parcels
{
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

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.Parcel parcel)
        {
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

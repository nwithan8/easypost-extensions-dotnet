using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Parcels
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "parcel", "length")]
        public double? Length { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "parcel", "width")]
        public double? Width { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "parcel", "height")]
        public double? Height { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "parcel", "weight")]
        public double? Weight { get; set; }

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

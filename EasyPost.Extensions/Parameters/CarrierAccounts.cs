using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class CarrierAccounts
{
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "type")]
        public string? Type { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "credentials")]
        public Dictionary<string, object?>? Credentials { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "test_credentials")]
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, object?>? TestCredentials { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
        
        public bool MatchesExistingObject(EasyPost.Models.API.CarrierAccount carrierAccount)
        {
            var pairs = new Pairs
            {
                { carrierAccount.Credentials, Credentials },
                { carrierAccount.Description, Description },
                { carrierAccount.TestCredentials, TestCredentials },
                { carrierAccount.Type, Type }
            };

            return pairs.AllMatch();
        }
    }

    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "description")]
        public string? Description { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "credentials")]
        public Dictionary<string, object?>? Credentials { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "test_credentials")]
        // ReSharper disable once InconsistentNaming
        public Dictionary<string, object?>? TestCredentials { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "carrier_account", "reference")]
        public string? Reference { get; set; }

        #endregion

        public Update(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    public sealed class All : AllRequestParameters
    {
    }
}

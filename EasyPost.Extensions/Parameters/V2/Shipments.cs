using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;
using EasyPost.Models.API;

namespace EasyPost.Extensions.Parameters.V2;

public static class Shipments
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Shipment"/> creation API calls.
    /// </summary>
    public class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "carbon_offset")]
        public bool AddCarbonOffset { get; set; }
        

        [JsonRequestParameter(Necessity.Optional, "shipment", "carrier_accounts")]
        public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "customs_info")]
        public EasyPost.Models.API.CustomsInfo? CustomsInfo { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "from_address")]
        public EasyPost.Models.API.Address? FromAddress { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "insurance")]
        public double Insurance { get; set; }


        [JsonRequestParameter(Necessity.Optional, "shipment", "is_return")]
        public bool IsReturn { get; set; } = false;

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "options")]
        public EasyPost.Models.API.Options? Options { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "parcel")]
        public EasyPost.Models.API.Parcel? Parcel { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "reference")]
        public string? Reference { get; set; }


        [JsonRequestParameter(Necessity.Optional, "shipment", "tax_identifiers")]
        public List<EasyPost.Models.API.TaxIdentifier>? TaxIdentifiers { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "shipment", "to_address")]
        public EasyPost.Models.API.Address? ToAddress { get; set; }

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
            if (existingObject is not EasyPost.Models.API.Shipment shipment)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { shipment.CustomsInfo, CustomsInfo },
                { shipment.FromAddress, FromAddress },
                { shipment.Insurance, Insurance },
                { shipment.IsReturn, IsReturn },
                { shipment.Options, Options },
                { shipment.Parcel, Parcel },
                { shipment.Reference, Reference },
                { shipment.ToAddress, ToAddress },
            };

            return pairs.AllMatch();
        }
    }
    
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Shipment"/> one-call buy API calls.
    /// </summary>
    public sealed class OneCallBuy : Create
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Required, "shipment", "carrier")]
        public string? Carrier { get; set; }


        [JsonRequestParameter(Necessity.Required, "shipment", "service")]
        public string? Service { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="OneCallBuy"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public OneCallBuy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
        
        public override bool MatchesExistingObject(EasyPostObject existingObject)
        {
            if (existingObject is not EasyPost.Models.API.Shipment shipment)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { shipment.CustomsInfo, CustomsInfo },
                { shipment.FromAddress, FromAddress },
                { shipment.Insurance, Insurance },
                { shipment.IsReturn, IsReturn },
                { shipment.Options, Options },
                { shipment.Parcel, Parcel },
                { shipment.Reference, Reference },
                { shipment.ToAddress, ToAddress },
                { shipment.Service, Service },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Shipment"/> document creation API calls.
    /// </summary>
    public sealed class CreateDocument : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public string? FileFormat { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="CreateDocument"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public CreateDocument(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Shipment"/> insure API calls.
    /// </summary>
    public sealed class Insure : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Required)]
        public double? Amount { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Insure"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Insure(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Shipment"/> buy API calls.
    /// </summary>
    public sealed class Buy : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Optional)]
        public EndShipper? EndShipper { get; set; }

        
        [Parameter(Necessity.Optional)]
        public string? InsuranceValue { get; set; }

        
        [Parameter(Necessity.Required)]
        public EasyPost.Models.API.Rate? Rate { get; set; }


        [Parameter(Necessity.Optional)]
        public bool AddCarbonOffset { get; set; } = false;

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Buy"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>        
        public Buy(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
    
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Shipment"/> rate generation API calls.
    /// </summary>
    public sealed class RegenerateRates : RequestParameters
    {
        #region Request Parameters

        
        [Parameter(Necessity.Optional)]
        public bool AddCarbonOffset { get; set; } = false;

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="RegenerateRates"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public RegenerateRates(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Shipment"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}
}

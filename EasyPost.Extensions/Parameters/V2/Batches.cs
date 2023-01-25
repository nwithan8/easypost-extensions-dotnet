using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Batches
    {
        /// <summary>
        ///     Parameters for <see cref="EasyPost.Models.API.Batch"/> creation API calls.
        /// </summary>
        public sealed class Create : CreateRequestParameters
        {
            #region Request Parameters

            
            [JsonRequestParameter(Necessity.Optional, "shipment", "carrier")]
            public string? Carrier { get; set; }

            
            [JsonRequestParameter(Necessity.Optional, "shipment", "carrier_accounts")]
            public List<EasyPost.Models.API.CarrierAccount>? CarrierAccounts { get; set; }

            
            [JsonRequestParameter(Necessity.Optional, "shipment", "service")]
            public string? Service { get; set; }

            
            [JsonRequestParameter(Necessity.Required, "batch", "shipments")]
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
                if (existingObject is not EasyPost.Models.API.Batch batch)
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
        ///     Parameters for <see cref="EasyPost.Models.API.Batch"/> shipment update API calls.
        /// </summary>
        public sealed class UpdateShipments : RequestParameters
        {
            #region Request Parameters

            
            [JsonRequestParameter(Necessity.Required, "shipments")]
            public List<EasyPost.Models.API.Shipment>? Shipments { get; set; }

            #endregion

            /// <summary>
            ///     Construct a new set of <see cref="UpdateShipments"/> parameters.
            /// </summary>
            /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
            public UpdateShipments(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
            {
            }
        }

        /// <summary>
        ///     Parameters for <see cref="EasyPost.Models.API.Batch"/> document creation API calls.
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
        ///     Parameters for <see cref="EasyPost.Models.API.Batch"/> list API calls.
        /// </summary>
        public sealed class All : AllRequestParameters
        {}
    }

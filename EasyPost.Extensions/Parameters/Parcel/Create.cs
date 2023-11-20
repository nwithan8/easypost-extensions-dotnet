using EasyPost.Models.API;
using EasyPost.Utilities.Internal.Attributes;

namespace EasyPost.Extensions.Parameters.Parcel
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.Parcel"/> creation API calls.
    /// </summary>
    public class Create : EasyPost.Parameters.Parcel.Create
    {
        #region Request Parameters
        
        public PredefinedPackage? PredefinedPackageMetadata { get; set; }

        [TopLevelRequestParameter(Necessity.Optional, "parcel", "predefined_package")]
        [NestedRequestParameter(typeof(EasyPost.Parameters.Shipment.Create), Necessity.Optional, "predefined_package")]
        [NestedRequestParameter(typeof(EasyPost.Parameters.Beta.Rate.Retrieve), Necessity.Optional, "predefined_package")]
        public new string? PredefinedPackage
        {
            get => PredefinedPackageMetadata?.Name;
            set => PredefinedPackageMetadata = value == null ? null : new PredefinedPackage { Name = value };
        }

        #endregion
    }
}

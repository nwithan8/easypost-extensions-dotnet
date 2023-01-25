using EasyPost._base;
using EasyPost.Extensions.Internal.Attributes;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class Users
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.User"/> update API calls.
    /// </summary>
    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "user", "current_password")]
        public string? CurrentPassword { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "email")]
        public string? Email { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "name")]
        public string? Name { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "password")]
        public string? Password { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "password_confirmation")]
        public string? PasswordConfirmation { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "phone_number")]
        public string? PhoneNumber { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "recharge_amount")]
        public string? RechargeAmount { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "recharge_threshold")]
        public string? RechargeThreshold { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "user", "secondary_recharge_amount")]
        public string? SecondaryRechargeAmount { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="Update"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Update(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.User"/> brand update API calls.
    /// </summary>
    public sealed class UpdateBrand : RequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "brand", "ad")]
        public string? AdBase64 { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "brand", "ad_href")]
        public string? AdUrl { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "brand", "background_color")]
        public string? BackgroundColorHexCode { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "brand", "color")]
        public string? ColorHexCode { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "brand", "logo")]
        public string? LogoBase64 { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "brand", "logo_href")]
        public string? LogoUrl { get; set; }

        
        [JsonRequestParameter(Necessity.Optional, "brand", "theme")]
        public string? Theme { get; set; }

        #endregion

        /// <summary>
        ///     Construct a new set of <see cref="UpdateBrand"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public UpdateBrand(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.User"/> creation API calls.
    /// </summary>
    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        
        [JsonRequestParameter(Necessity.Optional, "user", "name")]
        public string? Name { get; set; }

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
            if (existingObject is not EasyPost.Models.API.User user)
            {
                return false;
            }

            var pairs = new Pairs
            {
                { user.Name, Name },
            };

            return pairs.AllMatch();
        }
    }
}

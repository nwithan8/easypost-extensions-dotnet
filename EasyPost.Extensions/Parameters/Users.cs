using System.Collections.Generic;
using EasyPost.Extensions.Attributes;

namespace EasyPost.Extensions.Parameters;

public static class Users
{
    public sealed class Update : UpdateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "current_password")]
        public string? CurrentPassword { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "email")]
        public string? Email { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "name")]
        public string? Name { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "password")]
        public string? Password { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "password_confirmation")]
        public string? PasswordConfirmation { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "phone_number")]
        public string? PhoneNumber { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "recharge_amount")]
        public string? RechargeAmount { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "recharge_threshold")]
        public string? RechargeThreshold { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "secondary_recharge_amount")]
        public string? SecondaryRechargeAmount { get; set; }

        #endregion

        public Update(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }

        public bool MatchesExistingObject(EasyPost.Models.API.User user)
        {
            var pairs = new Pairs
            {
                { user.Email, Email },
                { user.Name, Name },
                { user.PhoneNumber, PhoneNumber },
                { user.RechargeAmount, RechargeAmount },
                { user.SecondaryRechargeAmount, SecondaryRechargeAmount },
                { user.RechargeThreshold, RechargeThreshold },
            };

            return pairs.AllMatch();
        }
    }

    public sealed class UpdateBrand : RequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "brand", "ad")]
        public string? AdBase64 { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "brand", "ad_href")]
        public string? AdUrl { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "brand", "background_color")]
        public string? BackgroundColorHexCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "brand", "color")]
        public string? ColorHexCode { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "brand", "logo")]
        public string? LogoBase64 { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "brand", "logo_href")]
        public string? LogoUrl { get; set; }

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "brand", "theme")]
        public string? Theme { get; set; }

        #endregion

        public UpdateBrand(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class Create : CreateRequestParameters
    {
        #region Request Parameters

        [ApiCompatibility(ApiVersionEnum.V2)]
        [RequestParameter(Necessity.Optional, "user", "name")]
        public string? Name { get; set; }

        #endregion

        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }
}

using EasyPost._base;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Parameters.V2;

public static class EndShippers
{
    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.EndShipper"/> creation API calls.
    /// </summary>
    public sealed class Create : Addresses.Create
    {
        /// <summary>
        ///     Construct a new set of <see cref="Create"/> parameters.
        /// </summary>
        /// <param name="overrideParameters">A <see cref="Dictionary{TKey,TValue}"/> of values to use as a base.</param>
        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
        
        public override bool MatchesExistingObject(EasyPostObject existingObject)
        {
            if (existingObject is not EasyPost.Models.API.EndShipper endShipper)
            {
                return false;
            }
            
            var pairs = new Pairs
            {
                { endShipper.Street1, this.Street1 },
                { endShipper.Street2, this.Street2 },
                { endShipper.City, this.City },
                { endShipper.State, this.State },
                { endShipper.Zip, this.Zip },
                { endShipper.Country, this.Country },
                { endShipper.Name, this.Name },
                { endShipper.Company, this.Company },
                { endShipper.Phone, this.Phone },
                { endShipper.Email, this.Email },
            };

            return pairs.AllMatch();
        }
    }

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.EndShipper"/> list API calls.
    /// </summary>
    public sealed class All : AllRequestParameters
    {}

    /// <summary>
    ///     Parameters for <see cref="EasyPost.Models.API.EndShipper"/> update API calls.
    /// </summary>
    public sealed class Update: Addresses.Update
    {}
}

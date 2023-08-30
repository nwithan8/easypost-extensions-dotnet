namespace EasyPost.Extensions.Parameters.CarrierAccount
{
    /// <summary>
    ///     Parameters for custom <see cref="EasyPost.Models.API.CarrierAccount"/> creation API calls.
    /// </summary>
    public abstract class CreateCustom : EasyPost.Parameters.CarrierAccount.Create
    {
        /// <summary>
        ///     Construct a new set of <see cref="CreateCustom"/> parameters.
        /// </summary>
        protected CreateCustom(string type)
        {
            Type = type;
        }
    }
}


namespace EasyPost.Extensions.Exceptions
{
#pragma warning disable SA1649
    /// <summary>
    ///     Base class for all EasyPost Extensions exceptions.
    /// </summary>
    public abstract class EasyPostExtensionsError : Exception
#pragma warning restore SA1649
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EasyPostExtensionsError" /> class.
        /// </summary>
        /// <param name="message">The error message to print to console.</param>
        internal EasyPostExtensionsError(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Get a formatted error string with expanded details about the EasyPost API error.
        /// </summary>
        /// <returns>A formatted error string.</returns>
        public abstract string PrettyPrint { get; }
    }
}

using System.Collections.Generic;

namespace EasyPost.Extensions.Parameters;

public static class EndShippers
{
    public sealed class Create : Addresses.Create
    {
        public Create(Dictionary<string, object>? overrideParameters = null) : base(overrideParameters)
        {
        }
    }

    public sealed class All : AllRequestParameters
    {}

    public sealed class Update: Addresses.Update
    {}
}

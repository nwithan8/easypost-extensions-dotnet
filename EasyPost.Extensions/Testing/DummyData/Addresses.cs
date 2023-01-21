using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

public abstract class Addresses : DummyDataCreator
{
    public class State : NetTools.Common.ValueEnum
    {
        public static readonly State Arizona = new State(1, "assets/dummy_data/addresses/united_states/az-addresses.json");
        public static readonly State California = new State(2, "assets/dummy_data/addresses/united_states/ca-addresses.json");
        public static readonly State Idaho = new State(3, "assets/dummy_data/addresses/united_states/id-addresses.json");
        public static readonly State Kansas = new State(4, "assets/dummy_data/addresses/united_states/ks-addresses.json");
        public static readonly State Nevada = new State(5, "assets/dummy_data/addresses/united_states/nv-addresses.json");
        public static readonly State NewYork = new State(6, "assets/dummy_data/addresses/united_states/ny-addresses.json");
        public static readonly State Oregon = new State(7, "assets/dummy_data/addresses/united_states/or-addresses.json");
        public static readonly State Texas = new State(8, "assets/dummy_data/addresses/united_states/tx-addresses.json");
        public static readonly State Utah = new State(9, "assets/dummy_data/addresses/united_states/ut-addresses.json");
        public static readonly State Washington = new State(10, "assets/dummy_data/addresses/united_states/wa-addresses.json");
        public static readonly State Australia = new State(11, "assets/dummy_data/addresses/australia/vt-addresses.json");
        public static readonly State Canada = new State(11, "assets/dummy_data/addresses/canada/bc-addresses.json");
        public static readonly State China = new State(12, "assets/dummy_data/addresses/china/bj-addresses.json");
        public static readonly State HongKong = new State(13, "assets/dummy_data/addresses/china/hk-addresses.json");
        public static readonly State UnitedKingdom = new State(14, "assets/dummy_data/addresses/europe/uk-addresses.json");
        public static readonly State Germany = new State(15, "assets/dummy_data/addresses/europe/de-addresses.json");
        public static readonly State Spain = new State(16, "assets/dummy_data/addresses/europe/es-addresses.json");
        public static readonly State Mexico = new State(17, "assets/dummy_data/addresses/mexico/mx-addresses.json");

        private State(int value, string filePath) : base(value, filePath)
        {
        }

        private static List<State> Choices => new()
        {
            Arizona,
            California,
            Idaho,
            Kansas,
            Nevada,
            NewYork,
            Oregon,
            Texas,
            Utah,
            Washington,
            Australia,
            Canada,
            China,
            HongKong,
            UnitedKingdom,
            Germany,
            Spain,
            Mexico,
        };

        internal static State GetRandom()
        {
            return (State)Internal.Random.RandomItemFromList(Choices);
        }

        internal static List<State> GetTwoDifferentRandom()
        {
            var items = Internal.Random.RandomItemsFromList(Choices, 2, false);

            return new List<State>
            {
                (State)items[0],
                (State)items[1],
            };
        }
    }

    private static string GetJsonFilePath(State state)
    {
        return state.Value!.ToString()!;
    }

    /// <summary>
    ///     Create a dummy <see cref="Address"/>.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API call with.</param>
    /// <param name="state">Optional specific <see cref="State"/> to pull an address from. Will be random (possibly international) otherwise.</param>
    /// <returns>An <see cref="Address"/> object.</returns>
    public static async Task<Address> CreateAddress(Client client, State? state = null)
    {
        state ??= State.GetRandom();

        var stateDataPath = GetJsonFilePath(state);

        var data = GetRandomMapsFromJsonFile(stateDataPath, 1, true);
        var addressData = data[0];

        return await client.Address.Create(addressData);
    }

    /// <summary>
    ///     Create a pair of dummy <see cref="Address"/>es.
    /// </summary>
    /// <param name="client">The <see cref="EasyPost.Client"/> to make the API calls with.</param>
    /// <param name="differentStates">Optional whether the two addresses should be in different states.
    ///     True will use two different states (including possibly an international pair), false will use the same state for both addresses. Defaults to false.
    /// </param>
    /// <returns>A list of two <see cref="Address"/> objects.</returns>
    public static async Task<List<Address>> CreateAddressPair(Client client, bool? differentStates = false)
    {
        var addresses = new List<Address>();

        List<State> states;
        if (differentStates == true)
        {
            states = State.GetTwoDifferentRandom();
        }
        else
        {
            var state = State.GetRandom();
            states = new List<State> { state, state };
        }

        foreach (var state in states)
        {
            var stateDataPath = GetJsonFilePath(state);

            var data = GetRandomMapsFromJsonFile(stateDataPath, 1, true);
            var addressData = data[0];

            var address = await client.Address.Create(addressData);

            addresses.Add(address);
        }

        return addresses;
    }
}

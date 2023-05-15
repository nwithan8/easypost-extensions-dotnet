namespace EasyPost.Extensions;

/// <summary>
///     A ClientManager is a container for your EasyPost API keys and EasyPost API client,
///     to assist with constructing a Client and switching between test and production modes.
/// </summary>
public class ClientManager
{
    private readonly string _testApiKey;

    private readonly string _productionApiKey;

    private readonly TimeSpan? _customTimeout;

    private readonly HttpClient? _customHttpClient;

    private bool _inTestMode;

    /// <summary>
    ///     The EasyPost API client, configured with the appropriate API key.
    /// </summary>
    public EasyPost.Client Client { get; private set; }

    /// <summary>
    ///     Create a new ClientManager with the given API keys.
    ///     The ClientManager will set up a new <see cref="EasyPost.Client"/> with the test API key by default.
    /// </summary>
    /// <param name="testApiKey">The test API key for EasyPost.</param>
    /// <param name="productionApiKey">The test API key for EasyPost.</param>
    /// <param name="customTimeout">Optional override for the HTTP request timeout.</param>
    /// <param name="customHttpClient">Optional override for the underlying <see cref="HttpClient"/> used to make HTTP calls. Useful for VCR solutions.</param>
    public ClientManager(string testApiKey, string productionApiKey, TimeSpan? customTimeout = null, HttpClient? customHttpClient = null)
    {
        _testApiKey = testApiKey;
        _productionApiKey = productionApiKey;
        _inTestMode = true;

        _customTimeout = customTimeout;
        _customHttpClient = customHttpClient;
        
        var clientConfiguration = CraftClientConfiguration();

        Client = new EasyPost.Client(clientConfiguration);
    }

    /// <summary>
    ///     Switch to production mode.
    /// </summary>
    public void EnableProductionMode()
    {
        if (!_inTestMode) return;
        
        var clientConfiguration = CraftClientConfiguration();

        Client = new EasyPost.Client(clientConfiguration);
        _inTestMode = false;
    }

    /// <summary>
    ///     Switch to test mode.
    /// </summary>
    public void EnableTestMode()
    {
        if (_inTestMode) return;

        var clientConfiguration = CraftClientConfiguration();

        Client = new EasyPost.Client(clientConfiguration);
        _inTestMode = true;
    }

    private ClientConfiguration CraftClientConfiguration()
    {
        return new ClientConfiguration(apiKey: _inTestMode ? _testApiKey : _productionApiKey)
        {
            CustomHttpClient = _customHttpClient,
            Timeout = _customTimeout ?? TimeSpan.FromSeconds(60), // default to 60 seconds if not specified by the user
        };
    }
}

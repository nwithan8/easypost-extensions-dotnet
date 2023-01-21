namespace EasyPost.Extensions;

/// <summary>
///     A ClientManager is a container for your EasyPost API keys and EasyPost API client,
///     to assist with constructing a Client and switching between test and production modes.
/// </summary>
public class ClientManager
{
    private readonly string _testApiKey;

    private readonly string _productionApiKey;

    private readonly string? _customBaseUrl;

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
    /// <param name="customBaseApiUrl">Optional override for the base URL of the EasyPost API.</param>
    /// <param name="customHttpClient">Optional override for the underlying <see cref="HttpClient"/> used to make HTTP calls. Useful for VCR solutions.</param>
    public ClientManager(string testApiKey, string productionApiKey, string? customBaseApiUrl = null, HttpClient? customHttpClient = null)
    {
        _testApiKey = testApiKey;
        _productionApiKey = productionApiKey;
        _inTestMode = true;

        _customBaseUrl = customBaseApiUrl;
        _customHttpClient = customHttpClient;

        Client = new EasyPost.Client(apiKey: _testApiKey, baseUrl: _customBaseUrl, customHttpClient: _customHttpClient);
    }

    /// <summary>
    ///     Switch to production mode.
    /// </summary>
    public void EnableProductionMode()
    {
        if (!_inTestMode) return;

        Client = new EasyPost.Client(apiKey: _testApiKey, baseUrl: _customBaseUrl, customHttpClient: _customHttpClient);
        _inTestMode = false;
    }

    /// <summary>
    ///     Switch to test mode.
    /// </summary>
    public void EnableTestMode()
    {
        if (_inTestMode) return;

        Client = new EasyPost.Client(apiKey: _testApiKey, baseUrl: _customBaseUrl, customHttpClient: _customHttpClient);
        _inTestMode = true;
    }
}

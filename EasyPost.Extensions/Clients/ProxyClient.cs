using System.Net;

namespace EasyPost.Extensions.Clients;

/// <summary>
///     An EasyPost API client that can be configured to use a proxy for all requests.
/// </summary>
public class ProxyClient : EasyPost.Client
{
    private readonly IWebProxy _defaultProxy;
    
    /// <summary>
    ///     Initialize a new ProxyClient with the given configuration and proxy.
    /// </summary>
    /// <param name="configuration">The <see cref="ClientConfiguration"/> to use with this client.</param>
    /// <param name="proxy">The <see cref="IWebProxy"/> to use for API requests.</param>
    public ProxyClient(ClientConfiguration configuration, IWebProxy proxy) : base(configuration)
    {
        // Would prefer to use the HttpClientHandler, but the constructor/access to HttpClient is private to extended classes
        // https://www.scrapingbee.com/blog/csharp-httpclient-proxy/
        // Instead, using global proxy:
        // https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.defaultproxy?view=net-7.0
        #if NETSTANDARD2_0
        throw new Exception("ProxyClient is not supported on .NET Standard 2.0");
        #elif NETSTANDARD2_1
        throw new Exception("ProxyClient is not supported on .NET Standard 2.1");
        #else
        _defaultProxy = proxy;
        #endif
    }

    /// <summary>
    ///     Override the base ExecuteRequest method to set the proxy prior to executing the request and reset it after.
    /// </summary>
    /// <param name="request">The in-flight <see cref="HttpRequestMessage"/></param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to cancel the request.</param>
    /// <returns></returns>
    public override async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request, CancellationToken cancellationToken)
    {
#if NETSTANDARD2_0
        throw new Exception("ProxyClient is not supported on .NET Standard 2.0");
#elif NETSTANDARD2_1
        throw new Exception("ProxyClient is not supported on .NET Standard 2.1");
#else
        HttpResponseMessage response;
        try
        {
            // set the proxy prior to executing the request
            HttpClient.DefaultProxy = _defaultProxy;
            response = await base.ExecuteRequest(request, cancellationToken);
        }
        finally
        {
            // reset the proxy after executing the request
            HttpClient.DefaultProxy = new WebProxy();
        }
        
        return response;
#endif
    }
}

using System.Net;
using EasyPost._base;

namespace EasyPost.Extensions.Clients;

public class ProxyClient : EasyPostClient
{
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
        HttpClient.DefaultProxy = proxy;
        #endif
    }
}

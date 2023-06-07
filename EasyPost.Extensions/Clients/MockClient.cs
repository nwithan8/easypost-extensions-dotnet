using System.Net;
using System.Text.RegularExpressions;

namespace EasyPost.Extensions.Clients;

/// <summary>
///     An EasyPost API client that can be configured to simulate responses to requests without actually making any network calls.
/// </summary>
public sealed class MockClient : EasyPost.Client
{
    private readonly List<MockRequest> _mockRequests = new();

    /// <summary>
    ///     Override the base ExecuteRequest method to return a mock response instead of making a network call.
    /// </summary>
    /// <param name="request">The in-flight <see cref="HttpRequestMessage"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to cancel this request.</param>
    /// <returns>The mocked <see cref="HttpResponseMessage"/>.</returns>
    /// <exception cref="Exception">Thrown when no mocked request found.</exception>
#pragma warning disable CS1998
    public override async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request, CancellationToken cancellationToken)
#pragma warning restore CS1998
    {
        var mockRequest = FindMatchingMockRequest(request);

        if (mockRequest == null)
        {
#pragma warning disable CA2201
            throw new Exception("No matching mock request found");
#pragma warning restore CA2201
        }

        return new HttpResponseMessage
        {
            Content = new StringContent(mockRequest.ResponseInfo.Content),
            StatusCode = mockRequest.ResponseInfo.StatusCode,
        };
    }

    /// <summary>
    ///     Initialize a new MockClient with the given configuration and optional mock requests.
    /// </summary>
    /// <param name="configuration">The <see cref="ClientConfiguration"/> to use for this client.</param>
    /// <param name="mockRequests">An optional list of <see cref="MockRequest"/>s to use.</param>
    public MockClient(ClientConfiguration configuration, IReadOnlyCollection<MockRequest>? mockRequests = null) : base(configuration)
    {
        if (mockRequests != null)
        {
            AddMockRequests(mockRequests);
        }
    }

    /// <summary>
    ///     Add a mock request to the list of mock requests.
    /// </summary>
    /// <param name="mockRequest">A <see cref="MockRequest"/> to use with this client.</param>
    public void AddMockRequest(MockRequest mockRequest) => _mockRequests.Add(mockRequest);

    /// <summary>
    ///     Add a list of mock requests to the list of mock requests.
    /// </summary>
    /// <param name="mockRequests">A list of <see cref="MockRequest"/>s to use with this client.</param>
    public void AddMockRequests(IEnumerable<MockRequest> mockRequests) => _mockRequests.AddRange(mockRequests);

    private MockRequest? FindMatchingMockRequest(HttpRequestMessage request) => _mockRequests.FirstOrDefault(mock => mock.MatchRules.Method == request.Method && EndpointMatches(request.RequestUri.AbsoluteUri, mock.MatchRules.ResourceRegex));

    private static bool EndpointMatches(string endpoint, string pattern)
    {
        try
        {
            return Regex.IsMatch(endpoint,
                pattern,
                RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.Singleline,
                TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException)
        {
            return false;
        }
    }
}

/// <summary>
///     A set of rules that a request must match in order to be considered a match for a mock request.
/// </summary>
public class MockRequestMatchRules
{
    internal HttpMethod Method { get; set; }

    internal string ResourceRegex { get; set; }

    /// <summary>
    ///     Initialize a new set of mock request match rules with the given method and resource regex.
    ///     Both the method and resource regex must match for a request to be considered a match.
    /// </summary>
    /// <param name="method">The <see cref="HttpMethod"/> to match against.</param>
    /// <param name="resourceRegex">A regular expression pattern to match the request URL against.</param>
    public MockRequestMatchRules(HttpMethod method, string resourceRegex)
    {
        Method = method;
        ResourceRegex = resourceRegex;
    }
}

/// <summary>
///     Information about the response that should be returned for a mock request.
/// </summary>
public class MockRequestResponseInfo
{
    internal HttpStatusCode StatusCode { get; set; }

    internal string? Content { get; set; }

    /// <summary>
    ///     Initialize a new set of mock request response info with the given status code, content, and data.
    /// </summary>
    /// <param name="statusCode">The <see cref="HttpStatusCode"/> to return in the response.</param>
    /// <param name="content">The raw content to return in the response.</param>
    /// <param name="data">The data object to deserialize and return in the response.</param>
    public MockRequestResponseInfo(HttpStatusCode statusCode, string? content = null, object? data = null)
    {
        StatusCode = statusCode;
        Content = content ?? NetTools.JSON.JsonSerialization.ConvertObjectToJson(data);
    }
}

/// <summary>
///     A mock request that can be used to simulate responses to requests without actually making any network calls.
/// </summary>
public class MockRequest
{
    /// <summary>
    ///     The <see cref="MockRequestMatchRules"/> to use for this specific mock request.
    /// </summary>
    public MockRequestMatchRules MatchRules { get; }

    /// <summary>
    ///     The <see cref="MockRequestResponseInfo"/> to use if the associated request matches.
    /// </summary>
    public MockRequestResponseInfo ResponseInfo { get; }

    /// <summary>
    ///     Initialize a new mock request with the given match rules and response info.
    /// </summary>
    /// <param name="matchRules">The <see cref="MockRequestMatchRules"/> to use for this specific mock request.</param>
    /// <param name="responseInfo">The <see cref="MockRequestResponseInfo"/> to use if the associated request matches.</param>
    public MockRequest(MockRequestMatchRules matchRules, MockRequestResponseInfo responseInfo)
    {
        MatchRules = matchRules;
        ResponseInfo = responseInfo;
    }
}

using System.Net;
using System.Text.RegularExpressions;
using EasyPost._base;
using EasyPost.Extensions.Utilities;

namespace EasyPost.Extensions.Clients;

/// <summary>
///     An EasyPost API client that can be configured to simulate responses to requests without actually making any network calls.
/// </summary>
public sealed class MockClient : Client
{
    private readonly List<MockRequest> _mockRequests = new();

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

    internal MockClient(EasyPostClient client) : base(new ClientConfiguration(client.ApiKeyInUse)
    {
        ApiBase = client.ApiBaseInUse,
        CustomHttpClient = client.CustomHttpClient,
    })
    {
    }

    internal void AddMockRequest(MockRequest mockRequest) => _mockRequests.Add(mockRequest);

    internal void AddMockRequests(IEnumerable<MockRequest> mockRequests) => _mockRequests.AddRange(mockRequests);

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

    public MockRequestResponseInfo(HttpStatusCode statusCode, string? content = null, object? data = null)
    {
        StatusCode = statusCode;
        Content = content ?? JsonSerialization.ConvertObjectToJson(data);
    }
}

/// <summary>
///     A mock request that can be used to simulate responses to requests without actually making any network calls.
/// </summary>
public class MockRequest
{
    public MockRequestMatchRules MatchRules { get; }

    public MockRequestResponseInfo ResponseInfo { get; }

    internal MockRequest(MockRequestMatchRules matchRules, MockRequestResponseInfo responseInfo)
    {
        MatchRules = matchRules;
        ResponseInfo = responseInfo;
    }
}

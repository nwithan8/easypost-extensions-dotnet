namespace EasyPost.Extensions.Clients;

/// <summary>
///     An EasyPost API client that can be configured to run hooks before and after each request.
/// </summary>
public sealed class AuditableClient : EasyPost.Client
{
    public AuditableClientHooks Hooks { get; set; }

    public AuditableClient(ClientConfiguration configuration, AuditableClientHooks hooks) : base(configuration)
    {
        Hooks = hooks;
    }

    public override async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request, CancellationToken cancellationToken)
#pragma warning restore CS1998
    {
        Hooks.PreRequest?.Invoke(request);
        var response = await base.ExecuteRequest(request, cancellationToken); // this may throw an exception if the request is cancelled
        Hooks.PostRequest?.Invoke(response);
        
        return response;
    }
}

/// <summary>
///     A set of hooks that can be run during the execution of an EasyPost API request.
/// </summary>
public class AuditableClientHooks
{
    public Action<HttpRequestMessage>? PreRequest { get; set; }

    public Action<HttpResponseMessage>? PostRequest { get; set; }

    public AuditableClientHooks()
    {
    }
}

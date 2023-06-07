namespace EasyPost.Extensions.Clients;

/// <summary>
///     An EasyPost API client that can be configured to run hooks before and after each request.
/// </summary>
public class IntrospectiveClient : EasyPost.Client
{
    /// <summary>
    ///     A set of hooks that can be run during the execution of an EasyPost API request.
    /// </summary>
    public IntrospectiveClientHooks Hooks { get; set; }

    /// <summary>
    ///     Initialize a new IntrospectiveClient with the given configuration.
    /// </summary>
    /// <param name="configuration">The <see cref="ClientConfiguration"/> to use for this client.</param>
    /// <param name="hooks">The <see cref="IntrospectiveClientHooks"/> to use when executing requests.</param>
    public IntrospectiveClient(ClientConfiguration configuration, IntrospectiveClientHooks hooks) : base(configuration)
    {
        Hooks = hooks;
    }

    /// <summary>
    ///     Override the base ExecuteRequest method to run the configured hooks before and after each request.
    /// </summary>
    /// <param name="request">The in-flight <see cref="HttpRequestMessage"/>.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/> to cancel this request.</param>
    /// <returns>The <see cref="HttpResponseMessage"/> for the request.</returns>
    public override async Task<HttpResponseMessage> ExecuteRequest(HttpRequestMessage request, CancellationToken cancellationToken)
#pragma warning restore CS1998
    {
        // if a pre-request editor has been set, invoke it
        request = Hooks.RequestEditor?.Invoke(request) ?? request;
        // if a pre-request auditor has been set, invoke it
        Hooks.RequestViewer?.Invoke(request);
        var response = await base.ExecuteRequest(request, cancellationToken); // this may throw an exception if the request is cancelled
        // if a post-request auditor has been set, invoke it
        Hooks.ResponseViewer?.Invoke(response);
        
        return response;
    }
}

/// <summary>
///     A set of hooks that can be run during the execution of an EasyPost API request.
/// </summary>
public class IntrospectiveClientHooks
{
    /// <summary>
    ///     A <see cref="Action{HttpRequestMessage}"/> to view an HTTP request by the client prior to being sent.
    ///     The <see cref="HttpRequestMessage"/> about to be executed by the client is passed into this action.
    ///     Editing the <see cref="HttpRequestMessage"/> in this action does not impact the <see cref="HttpRequestMessage"/> being executed (passed by value, not reference).
    /// </summary>
    public Action<HttpRequestMessage>? RequestViewer { get; set; }
    
    /// <summary>
    ///     A <see cref="Func{HttpRequestMessage, HttpRequestMessage}"/> to view and edit an HTTP request by the client prior to being sent.
    ///     The <see cref="HttpRequestMessage"/> about to be executed by the client is passed into this action.
    ///     The <see cref="HttpRequestMessage"/> returned by this action is the <see cref="HttpRequestMessage"/> that will be executed by the client.
    /// </summary>
    public Func<HttpRequestMessage, HttpRequestMessage>? RequestEditor { get; set; }

    /// <summary>
    ///     A <see cref="Action{HttpResponseMessage}"/> to view an HTTP response received by the client.
    ///     The <see cref="HttpResponseMessage"/> received by the client is passed into this action.
    /// </summary>
    public Action<HttpResponseMessage>? ResponseViewer { get; set; }

    /// <summary>
    ///     Initialize a new set of hooks.
    /// </summary>
    public IntrospectiveClientHooks()
    {
    }
}

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
        // if a request editor has been set, invoke it
        request = Hooks.PreFlightRequestEditor?.Invoke(request) ?? request;
        
        // generate a UUID and starting timestamp for this request
        var requestId = Guid.NewGuid();
        var requestTimestamp = Environment.TickCount;
        
        // if a request event has been set, invoke it
        Hooks.OnRequestExecuting?.Invoke(this, new OnRequestExecutingEventArgs(request, requestTimestamp, requestId));
        
        // execute the request
        var response = await base.ExecuteRequest(request, cancellationToken); // this may throw an exception if the request is cancelled
        
        // if a response editor has been set, invoke it
        response = Hooks.PostFlightResponseEditor?.Invoke(response) ?? response;
        
        // if a response event has been set, invoke it
        var responseTimestamp = Environment.TickCount;
        Hooks.OnRequestResponseReceived?.Invoke(this, new OnRequestResponseReceivedEventArgs(response, requestTimestamp, responseTimestamp, requestId));

        return response;
    }
}

public class OnRequestExecutingEventArgs : EventArgs
{
    /// <summary>
    ///     The <see cref="HttpRequestMessage"/> about to be executed by the HTTP request.
    /// </summary>
    public HttpRequestMessage Request { get; }

    /// <summary>
    ///     The timestamp of the HTTP request.
    /// </summary>
    public int Timestamp { get; }

    /// <summary>
    ///     A unique identifier for the HTTP request-response pair.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Constructs a new instance of the <see cref="OnRequestExecutingEventArgs"/> class.
    /// </summary>
    /// <param name="request">The <see cref="HttpRequestMessage"/> about to be executed by the HTTP request.</param>
    /// <param name="timestamp">The timestamp of the HTTP request.</param>
    /// <param name="guid">A unique identifier for the HTTP request-response pair.</param>
    internal OnRequestExecutingEventArgs(HttpRequestMessage request, int timestamp, Guid guid)
    {
        Request = request;
        Timestamp = timestamp;
        Id = guid;
    }
}

public class OnRequestResponseReceivedEventArgs : EventArgs
{
    /// <summary>
    ///     The <see cref="HttpResponseMessage"/> returned by the HTTP request.
    /// </summary>
    public HttpResponseMessage Response { get; }

    /// <summary>
    ///     The timestamp of the HTTP request.
    /// </summary>
    public int RequestTimestamp { get; }

    /// <summary>
    ///     The timestamp of the HTTP response.
    /// </summary>
    public int ResponseTimestamp { get; }

    /// <summary>
    ///     A unique identifier for the HTTP request-response pair.
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    ///     Constructs a new instance of the <see cref="OnRequestResponseReceivedEventArgs"/> class.
    /// </summary>
    /// <param name="response">The <see cref="HttpResponseMessage"/> returned by the HTTP request.</param>
    /// <param name="requestTimestamp">The timestamp of the HTTP request.</param>
    /// <param name="responseTimestamp">The timestamp of the HTTP response.</param>
    /// <param name="guid">A unique identifier for the HTTP request-response pair.</param>
    internal OnRequestResponseReceivedEventArgs(HttpResponseMessage response, int requestTimestamp, int responseTimestamp, Guid guid)
    {
        Response = response;
        RequestTimestamp = requestTimestamp;
        ResponseTimestamp = responseTimestamp;
        Id = guid;
    }
}

/// <summary>
///     A set of hooks that can be run during the execution of an EasyPost API request.
/// </summary>
public class IntrospectiveClientHooks
{
    /// <summary>
    ///     A <see cref="Func{HttpRequestMessage, HttpRequestMessage}"/> to view and edit an HTTP request by the client prior to being sent.
    ///     The <see cref="HttpRequestMessage"/> about to be executed by the client is passed into this action.
    ///     The <see cref="HttpRequestMessage"/> returned by this action is the <see cref="HttpRequestMessage"/> that will be executed by the client.
    ///     This function fires before <see cref="OnRequestExecuting"/>.
    /// </summary>
    public Func<HttpRequestMessage, HttpRequestMessage>? PreFlightRequestEditor { get; set; }
    
    /// <summary>
    ///     An <see cref="EventHandler{OnRequestExecutingEventArgs}"/> to view an HTTP request by the client prior to being sent.
    ///     Editing the <see cref="HttpRequestMessage"/> in this callback does not impact the <see cref="HttpRequestMessage"/> being executed.
    ///     This function fires after <see cref="PreFlightRequestEditor"/>.
    /// </summary>
    public EventHandler<OnRequestExecutingEventArgs>? OnRequestExecuting { get; set; }
    
    /// <summary>
    ///     A <see cref="Func{HttpResponseMessage, HttpResponseMessage}"/> to view and edit an HTTP response after being received by the client.
    ///     The <see cref="HttpResponseMessage"/> initially received by the client is passed into this action.
    ///     The <see cref="HttpResponseMessage"/> returned by this action is the <see cref="HttpResponseMessage"/> that will be used in downstream processing, including JSON deserialization.
    ///     This function fires before <see cref="OnRequestResponseReceived"/>.
    /// </summary>
    public Func<HttpResponseMessage, HttpResponseMessage>? PostFlightResponseEditor { get; set; }

    /// <summary>
    ///     An <see cref="EventHandler{OnRequestResponseReceivedEventArgs}"/> to view an HTTP response received by the client.
    ///     Editing the <see cref="HttpResponseMessage"/> in this callback does not impact the <see cref="HttpResponseMessage"/> being processed by the client.
    ///     This function fires after <see cref="PostFlightResponseEditor"/>.
    /// </summary>
    public EventHandler<OnRequestResponseReceivedEventArgs>? OnRequestResponseReceived { get; set; }
}

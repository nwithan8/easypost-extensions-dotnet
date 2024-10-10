using EasyPost.Exceptions.General;
using EasyPost.Extensions.Enums;
using EasyPost.Extensions.Internal;
using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Models.API;
using EasyPost.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetTools.Common;
using NetTools.JSON;

namespace EasyPost.Extensions.Webhooks;

internal static class EasyPostWebhookControllerFunctions
{
    /// <summary>
    ///     Process the webhook from EasyPost.
    /// </summary>
    /// <param name="client">A <see cref="Client"/> instance to use for HMAC validation.</param>
    /// <param name="enableTestMode">If true, skip signature verification.</param>
    /// <param name="bodyData">The request body as a byte array.</param>
    /// <param name="headers">The request headers.</param>
    /// <param name="webhookSecret">The webhook secret to validate the webhook.</param>
    /// <param name="eventProcessor">The event processor to handle different types of events.</param>
    /// <param name="logger">An <see cref="ILogger"/> instance.</param>
    internal static async Task ProcessWebhook(Client client, bool enableTestMode, byte[] bodyData,
        Dictionary<string, object?> headers, string webhookSecret, EasyPostEventProcessor eventProcessor,
        ILogger? logger)
    {
        Event @event;
        // skip validation if test mode is enabled
        if (enableTestMode)
        {
            try
            {
                @event = JsonSerialization.ConvertJsonToObject<Event>(bodyData.AsString());
            } catch (Exception e)
            {
                if (e is JsonDeserializationException or JsonNoDataException)
                {
                    if (eventProcessor.OnEventParsingError != null)
                    {
                        await eventProcessor.OnEventParsingError.Invoke(logger);
                    }
                }
                else
                {
                    throw;
                }
                

                return;
            }
        }
        else
        {
            // validate the webhook, will throw SignatureVerificationException if secret is incorrect
            try
            {
                @event = client.Webhook.ValidateWebhook(bodyData, headers, webhookSecret);
            }
            catch (SignatureVerificationError error)
            {
                if (eventProcessor.OnSignatureVerificationError != null)
                {
                    await eventProcessor.OnSignatureVerificationError.Invoke(bodyData, headers, webhookSecret, logger);
                }

                return;
            }
        }

        await eventProcessor.Process(@event, logger)!;
    }
}

public abstract class EasyPostWebhookControllerBase : ControllerBase
{
    // used to access the validate webhook method, no API calls are made
    private readonly Client _client = new(new ClientConfiguration("not-used"));

    private readonly ILogger? _logger;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EasyPostWebhookControllerBase"/> class.
    /// </summary>
    /// <param name="logger">An <see cref="ILogger"/> instance.</param>
    protected EasyPostWebhookControllerBase(ILogger<EasyPostWebhookControllerBase>? logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///     Retrieve the webhook secret to validate incoming webhooks.
    /// </summary>
    protected abstract string WebhookSecret { get; }

    /// <summary>
    ///     If true, skip signature verification.
    /// </summary>
    protected abstract bool EnableTestMode { get; }

    /// <summary>
    ///     Process different types of webhook events.
    /// </summary>
    protected abstract EasyPostEventProcessor EventProcessor { get; }

    /// <summary>
    ///     The endpoint to receive webhooks from EasyPost.
    /// </summary>
    /// <returns>Returns a 200 OK response.</returns>
    [HttpPost]
    public IActionResult ReceiveEventFromEasyPost()
    {
        // First make a copy of the logger to avoid issues with disposal
        var logger = _logger;

        // get the request content body as a byte array
        var bodyData = HttpRequests.ReadRequestBody(HttpContext.Request).Result;

        // get the request headers
        var headers = new Dictionary<string, object?>();
        foreach (var header in HttpContext.Request.Headers)
        {
            headers.Add(header.Key, header.Value.ToString());
        }

        // process the webhook in a separate thread
        _ = Task.Run(async () =>
        {
            await EasyPostWebhookControllerFunctions.ProcessWebhook(_client, EnableTestMode, bodyData, headers,
                WebhookSecret, EventProcessor, logger);
        });

        // return a 200 OK response back to EasyPost
        return Ok();
    }
}

public abstract class EasyPostWebhookController : Controller
{
    // used to access the validate webhook method, no API calls are made
    private readonly Client _client = new(new ClientConfiguration("not-used"));

    private readonly ILogger? _logger;

    /// <summary>
    ///     Initializes a new instance of the <see cref="EasyPostWebhookController"/> class.
    /// </summary>
    /// <param name="logger">An <see cref="ILogger"/> instance.</param>
    protected EasyPostWebhookController(ILogger<EasyPostWebhookController>? logger)
    {
        _logger = logger;
    }

    /// <summary>
    ///     Retrieve the webhook secret to validate incoming webhooks.
    /// </summary>
    protected abstract string WebhookSecret { get; }

    /// <summary>
    ///     If true, skip signature verification.
    /// </summary>
    protected abstract bool EnableTestMode { get; }

    /// <summary>
    ///     Process different types of webhook events.
    /// </summary>
    protected abstract EasyPostEventProcessor EventProcessor { get; }

    /// <summary>
    ///     The endpoint to receive webhooks from EasyPost.
    /// </summary>
    /// <returns>Returns a 200 OK response.</returns>
    [HttpPost]
    public IActionResult ReceiveEventFromEasyPost()
    {
        // First make a copy of the logger to avoid issues with disposal
        var logger = _logger;

        // get the request content body as a byte array
        var bodyData = HttpRequests.ReadRequestBody(HttpContext.Request).Result;

        // get the request headers
        var headers = new Dictionary<string, object?>();
        foreach (var header in HttpContext.Request.Headers)
        {
            headers.Add(header.Key, header.Value.ToString());
        }

        // process the webhook in a separate thread
        _ = Task.Run(async () =>
        {
            await EasyPostWebhookControllerFunctions.ProcessWebhook(_client, EnableTestMode, bodyData, headers,
                WebhookSecret, EventProcessor, logger);
        });

        // return a 200 OK response back to EasyPost
        return Ok();
    }
}

public class EasyPostEventProcessor
{
    public Func<Event, ILogger?, Task>? OnBatchCreated { get; set; }

    public Func<Event, ILogger?, Task>? OnBatchUpdated { get; set; }

    public Func<Event, ILogger?, Task>? OnClaimSubmitted { get; set; }

    public Func<Event, ILogger?, Task>? OnClaimUpdated { get; set; }

    public Func<Event, ILogger?, Task>? OnClaimCancelled { get; set; }

    public Func<Event, ILogger?, Task>? OnClaimRejected { get; set; }

    public Func<Event, ILogger?, Task>? OnClaimApproved { get; set; }

    public Func<Event, ILogger?, Task>? OnInsurancePurchased { get; set; }

    public Func<Event, ILogger?, Task>? OnInsuranceCancelled { get; set; }

    public Func<Event, ILogger?, Task>? OnPaymentCreated { get; set; }

    public Func<Event, ILogger?, Task>? OnPaymentCompleted { get; set; }

    public Func<Event, ILogger?, Task>? OnPaymentFailed { get; set; }

    public Func<Event, ILogger?, Task>? OnRefundSuccessful { get; set; }

    public Func<Event, ILogger?, Task>? OnReportCreated { get; set; }

    public Func<Event, ILogger?, Task>? OnReportEmpty { get; set; }

    public Func<Event, ILogger?, Task>? OnReportAvailable { get; set; }

    public Func<Event, ILogger?, Task>? OnReportFailed { get; set; }

    public Func<Event, ILogger?, Task>? OnScanFormCreated { get; set; }

    public Func<Event, ILogger?, Task>? OnScanFormUpdated { get; set; }

    public Func<Event, ILogger?, Task>? OnShipmentInvoiceCreated { get; set; }

    public Func<Event, ILogger?, Task>? OnShipmentInvoiceUpdated { get; set; }

    public Func<Event, ILogger?, Task>? OnTrackerCreated { get; set; }

    public Func<Event, ILogger?, Task>? OnTrackerUpdated { get; set; }

    public Func<byte[], Dictionary<string, object?>, string, ILogger?, Task>? OnSignatureVerificationError { get; set; }

    public Func<Event, ILogger?, Task>? OnUnknownEvent { get; set; }
    
    public Func<ILogger?, Task>? OnEventParsingError { get; set; }
    
    public Func<ILogger?, Task>? OnEmptyEvent { get; set; }

    internal Task? Process(Event? @event, ILogger? logger)
    {
        if (@event == null)
        {
            return OnEmptyEvent != null ? OnEmptyEvent.Invoke(logger) : Task.CompletedTask;
        }
        
        var eventType = @event.Type();
        if (eventType == null)
        {
            return OnUnknownEvent != null ? OnUnknownEvent.Invoke(@event, logger) : Task.CompletedTask;
        }

        Task? task = null;

        var @switch = new SwitchCase
        {
            { EventType.BatchCreated, () => task = OnBatchCreated?.Invoke(@event, logger) },
            { EventType.BatchUpdated, () => task = OnBatchUpdated?.Invoke(@event, logger) },
            { EventType.ClaimSubmitted, () => task = OnClaimSubmitted?.Invoke(@event, logger) },
            { EventType.ClaimUpdated, () => task = OnClaimUpdated?.Invoke(@event, logger) },
            { EventType.ClaimCancelled, () => task = OnClaimCancelled?.Invoke(@event, logger) },
            { EventType.ClaimRejected, () => task = OnClaimRejected?.Invoke(@event, logger) },
            { EventType.ClaimApproved, () => task = OnClaimApproved?.Invoke(@event, logger) },
            { EventType.InsurancePurchased, () => task = OnInsurancePurchased?.Invoke(@event, logger) },
            { EventType.InsuranceCancelled, () => task = OnInsuranceCancelled?.Invoke(@event, logger) },
            { EventType.PaymentCreated, () => task = OnPaymentCreated?.Invoke(@event, logger) },
            { EventType.PaymentCompleted, () => task = OnPaymentCompleted?.Invoke(@event, logger) },
            { EventType.PaymentFailed, () => task = OnPaymentFailed?.Invoke(@event, logger) },
            { EventType.RefundSuccessful, () => task = OnRefundSuccessful?.Invoke(@event, logger) },
            { EventType.BatchUpdated, () => task = OnBatchUpdated?.Invoke(@event, logger) },
            { EventType.ReportCreated, () => task = OnReportCreated?.Invoke(@event, logger) },
            { EventType.ReportEmpty, () => task = OnReportEmpty?.Invoke(@event, logger) },
            { EventType.ReportAvailable, () => task = OnReportAvailable?.Invoke(@event, logger) },
            { EventType.ReportFailed, () => task = OnReportFailed?.Invoke(@event, logger) },
            { EventType.ScanFormCreated, () => task = OnScanFormCreated?.Invoke(@event, logger) },
            { EventType.ScanFormUpdated, () => task = OnScanFormUpdated?.Invoke(@event, logger) },
            { EventType.ShipmentInvoiceCreated, () => task = OnShipmentInvoiceCreated?.Invoke(@event, logger) },
            { EventType.ShipmentInvoiceUpdated, () => task = OnShipmentInvoiceUpdated?.Invoke(@event, logger) },
            { EventType.TrackerCreated, () => task = OnTrackerCreated?.Invoke(@event, logger) },
            { EventType.TrackerUpdated, () => task = OnTrackerUpdated?.Invoke(@event, logger) },
        };

        @switch.MatchFirst(eventType);

        return task;
    }
}
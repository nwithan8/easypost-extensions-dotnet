using EasyPost.Exceptions.General;
using EasyPost.Extensions.Enums;
using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Models.API;
using EasyPost.Utilities;
using Microsoft.AspNetCore.Mvc;
using NetTools.Common;
using NetTools.JSON;

namespace EasyPost.Extensions.Webhooks;

public abstract class EasyPostWebhookController : Controller
{
    // used to access the validate webhook method, no API calls are made
    private readonly Client _client = new(new ClientConfiguration("not-used"));
    
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

    [HttpPost]
    public async Task<IActionResult> ReceiveEventFromEasyPost()
    {
        // get the request content body as a byte array
        byte[] bodyData;
        using (MemoryStream ms = new())
        {
            await HttpContext.Request.Body.CopyToAsync(ms);
            bodyData = ms.ToArray();
        }

        var headers = new Dictionary<string, object?>();

        // get the request headers
        foreach (var header in HttpContext.Request.Headers)
        {
            headers.Add(header.Key, header.Value.ToString());
        }
        
        Event @event;
        // skip validation if test mode is enabled
        if (EnableTestMode)
        {
            @event = JsonSerialization.ConvertJsonToObject<Event>(bodyData.AsString());
        }
        else
        {
            // validate the webhook, will throw SignatureVerificationException if secret is incorrect
            try
            {
                @event = _client.Webhook.ValidateWebhook(bodyData, headers, WebhookSecret);
            } 
            catch (SignatureVerificationError error)
            {
                if (EventProcessor.OnSignatureVerificationError != null)
                {
                    await EventProcessor.OnSignatureVerificationError.Invoke(bodyData, headers, WebhookSecret);
                }
                return BadRequest(error.Message);
            }
        }
        
        await EventProcessor.Process(@event)!;
            
        return Ok();
    }
}

public class EasyPostEventProcessor
{
    public Func<Event, Task>? OnBatchCreated { get; set; }
    
    public Func<Event, Task>? OnBatchUpdated { get; set; }
    
    public Func<Event, Task>? OnClaimSubmitted { get; set; }
    
    public Func<Event, Task>? OnClaimUpdated { get; set; }
    
    public Func<Event, Task>? OnClaimCancelled { get; set; }
    
    public Func<Event, Task>? OnClaimRejected { get; set; }
    
    public Func<Event, Task>? OnClaimApproved { get; set; }
    
    public Func<Event, Task>? OnInsurancePurchased { get; set; }
    
    public Func<Event, Task>? OnInsuranceCancelled { get; set; }
    
    public Func<Event, Task>? OnPaymentCreated { get; set; }
    
    public Func<Event, Task>? OnPaymentCompleted { get; set; }
    
    public Func<Event, Task>? OnPaymentFailed { get; set; }
    
    public Func<Event, Task>? OnRefundSuccessful { get; set; }
    
    public Func<Event, Task>? OnReportCreated { get; set; }
    
    public Func<Event, Task>? OnReportEmpty { get; set; }
    
    public Func<Event, Task>? OnReportAvailable { get; set; }
    
    public Func<Event, Task>? OnReportFailed { get; set; }
    
    public Func<Event, Task>? OnScanFormCreated { get; set; }
    
    public Func<Event, Task>? OnScanFormUpdated { get; set; }
    
    public Func<Event, Task>? OnShipmentInvoiceCreated { get; set; }
    
    public Func<Event, Task>? OnShipmentInvoiceUpdated { get; set; }
    
    public Func<Event, Task>? OnTrackerCreated { get; set; }
    
    public Func<Event, Task>? OnTrackerUpdated { get; set; }
    
    public Func<byte[], Dictionary<string, object?>, string, Task>? OnSignatureVerificationError { get; set; }
    
    public Func<Event, Task>? OnUnknownEvent { get; set; }

    internal Task? Process(Event @event)
    {
        var eventType = @event.Type();
        if (eventType == null)
        {
            return OnUnknownEvent != null ? OnUnknownEvent.Invoke(@event) : Task.CompletedTask;
        }

        Task? task = null;

        var @switch = new SwitchCase
        {
            { EventType.BatchCreated, () => task = OnBatchCreated?.Invoke(@event) },
            { EventType.BatchUpdated, () => task = OnBatchUpdated?.Invoke(@event) },
            { EventType.ClaimSubmitted, () => task = OnClaimSubmitted?.Invoke(@event) },
            { EventType.ClaimUpdated, () => task = OnClaimUpdated?.Invoke(@event) },
            { EventType.ClaimCancelled, () => task = OnClaimCancelled?.Invoke(@event) },
            { EventType.ClaimRejected, () => task = OnClaimRejected?.Invoke(@event) },
            { EventType.ClaimApproved, () => task = OnClaimApproved?.Invoke(@event) },
            { EventType.InsurancePurchased, () => task = OnInsurancePurchased?.Invoke(@event) },
            { EventType.InsuranceCancelled, () => task = OnInsuranceCancelled?.Invoke(@event) },
            { EventType.PaymentCreated, () => task = OnPaymentCreated?.Invoke(@event) },
            { EventType.PaymentCompleted, () => task = OnPaymentCompleted?.Invoke(@event) },
            { EventType.PaymentFailed, () => task = OnPaymentFailed?.Invoke(@event) },
            { EventType.RefundSuccessful, () => task = OnRefundSuccessful?.Invoke(@event) },
            { EventType.BatchUpdated, () => task = OnBatchUpdated?.Invoke(@event) },
            { EventType.ReportCreated, () => task = OnReportCreated?.Invoke(@event) },
            { EventType.ReportEmpty, () => task = OnReportEmpty?.Invoke(@event) },
            { EventType.ReportAvailable, () => task = OnReportAvailable?.Invoke(@event) },
            { EventType.ReportFailed, () => task = OnReportFailed?.Invoke(@event) },
            { EventType.ScanFormCreated, () => task = OnScanFormCreated?.Invoke(@event) },
            { EventType.ScanFormUpdated, () => task = OnScanFormUpdated?.Invoke(@event) },
            { EventType.ShipmentInvoiceCreated, () => task = OnShipmentInvoiceCreated?.Invoke(@event) },
            { EventType.ShipmentInvoiceUpdated, () => task = OnShipmentInvoiceUpdated?.Invoke(@event) },
            { EventType.TrackerCreated, () => task = OnTrackerCreated?.Invoke(@event) },
            { EventType.TrackerUpdated, () => task = OnTrackerUpdated?.Invoke(@event) },
        };
        
        @switch.MatchFirst(eventType);

        return task;
    }
}
using EasyPost.Exceptions.General;
using EasyPost.Extensions.Enums;
using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Models.API;
using Microsoft.AspNetCore.Mvc;
using NetTools.Common;

namespace EasyPost.Extensions.Webhooks;

public abstract class EasyPostWebhookController : Controller
{
    // used to access the validate webhook method, no API calls are made
    private readonly Client _client = new(new ClientConfiguration("not-used"));
    
    protected abstract string WebhookSecret { get; }
    
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
        
        // validate the webhook, will throw SignatureVerificationException if secret is incorrect
        try
        {
            var @event = _client.Webhook.ValidateWebhook(bodyData, headers, WebhookSecret);
            await EventProcessor.Process(@event)!;
            
            return Ok();
        } 
        catch (SignatureVerificationError error)
        {
            return BadRequest(error.Message);
        }
    }
}

public class EasyPostEventProcessor
{
    public Func<EasyPost.Models.API.Event, Task>? OnBatchCreated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnBatchUpdated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnInsurancePurchased { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnInsuranceCancelled { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnPaymentCreated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnPaymentCompleted { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnPaymentFailed { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnRefundSuccessful { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnReportCreated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnReportEmpty { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnReportAvailable { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnReportFailed { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnScanFormCreated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnScanFormUpdated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnShipmentInvoiceCreated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnShipmentInvoiceUpdated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnTrackerCreated { get; set; }
    
    public Func<EasyPost.Models.API.Event, Task>? OnTrackerUpdated { get; set; }

    internal Task? Process(Event @event)
    {
        var eventType = @event.Type();
        if (eventType == null) return Task.CompletedTask;

        Task? task = null;

        var @switch = new SwitchCase
        {
            { EventType.BatchCreated, () => task = OnBatchCreated?.Invoke(@event) },
            { EventType.BatchUpdated, () => task = OnBatchUpdated?.Invoke(@event) },
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
using EasyPost.Models.API;
using NetTools.Common;

namespace EasyPost.Extensions.Enums;

/// <summary>
///     An enum that represents the different event types available for EasyPost.
/// </summary>
public class EventType : ValueEnum
{
    public static readonly EventType BatchCreated = new(0, "batch.created");
    
    public static readonly EventType BatchUpdated = new(1, "batch.updated");
    
    public static readonly EventType InsurancePurchased = new(2, "insurance.purchased");
    
    public static readonly EventType InsuranceCancelled = new(3, "insurance.cancelled");
    
    public static readonly EventType PaymentCreated = new(4, "payment.created");
    
    public static readonly EventType PaymentCompleted = new(5, "payment.completed");
    
    public static readonly EventType PaymentFailed = new(6, "payment.failed");
    
    public static readonly EventType RefundSuccessful = new(7, "refund.successful");
    
    public static readonly EventType ReportCreated  = new(8, "report.new");
    
    public static readonly EventType ReportEmpty = new(9, "report.empty");
    
    public static readonly EventType ReportAvailable = new(10, "report.available");
    
    public static readonly EventType ReportFailed = new(11, "report.failed");
    
    public static readonly EventType ScanFormCreated = new(12, "scan_form.created");
    
    public static readonly EventType ScanFormUpdated = new(13, "scan_form.updated");
    
    public static readonly EventType ShipmentInvoiceCreated = new(14, "shipment.invoice.created");
    
    public static readonly EventType ShipmentInvoiceUpdated = new(15, "shipment.invoice.updated");
    
    public static readonly EventType TrackerCreated = new(16, "tracker.created");
    
    public static readonly EventType TrackerUpdated = new(17, "tracker.updated");
    
    public static readonly EventType ClaimSubmitted = new(18, "claim.submitted");
    
    public static readonly EventType ClaimUpdated = new(19, "claim.updated");
    
    public static readonly EventType ClaimCancelled = new(19, "claim.cancelled");
    
    public static readonly EventType ClaimRejected = new(20, "claim.rejected");
    
    public static readonly EventType ClaimApproved = new(21, "claim.approved");

    private EventType(int id, string eventType) : base(id, eventType)
    {
    }

    public static implicit operator EventType?(string description)
    {
        return FromValue<EventType>(description);
    }

    public static implicit operator EventType?(Event @event)
    {
        return FromEvent(@event);
    }

    public static EventType? FromEvent(Event @event)
    {
        var description = @event.Description;

        return FromValue<EventType>(description);
    }
}

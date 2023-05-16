using EasyPost.Parameters;
using EasyPost.Utilities.Internal.Attributes;
using Newtonsoft.Json;

namespace EasyPost.Extensions.Parameters.Shipment;

public class GenerateRmaQrCode : EasyPost.Parameters.Shipment.GenerateForm
{
    private const string TypeValue = "rma_qr_code";
    
    [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "form", "type")]
    // the base class has a Type property, but it's not marked as a TopLevelRequestParameter, so we need to replace it with our own.
    // the base Type is still visible and settable by the user, but will be ignored entirely.
    internal new string? Type { get; set; }
    
    [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "form", "rma")]
    public RmaSummary? RmaSummary { get; set; }

    public GenerateRmaQrCode()
    {
        Type = TypeValue;
    }
    
    public override Dictionary<string, object> ToDictionary()
    {
        // set the type parameter to the correct value, in case the user accidentally set it to something else.
        Type = TypeValue;
        
        // Need to access the base-base class's ToDictionary method, since the GenerateForm class overrides it to something we don't want.
        // ref: https://stackoverflow.com/a/32562464
        var ptr = typeof(BaseParameters).GetMethod("ToDictionary").MethodHandle.GetFunctionPointer();
        var func = (Func<Dictionary<string, object>>)Activator.CreateInstance(typeof(Func<Dictionary<string, object>>), this, ptr);
        return func();
    }
}

public class RmaSummary
{
    [JsonProperty("pack_and_return")]
    public bool? PackAndReturn { get; set; }
    
    [JsonProperty("label_image_data")]
    public string? LabelImageData { get; set; }
    
    [JsonProperty("include_packing_slip")]
    public bool? IncludePackingSlip { get; set; }
    
    [JsonProperty("email_notification")]
    public bool? EmailNotification { get; set; }
    
    [JsonProperty("affiliated_merchant")]
    public string? AffiliatedMerchant { get; set; }
    
    [JsonProperty("order")]
    public RmaOrder? Order { get; set; }
}

public class RmaOrder
{
    [JsonProperty("order_date")]
    public string? OrderDate { get; set; }
    
    [JsonProperty("order_number")]
    public string? OrderNumber { get; set; }
    
    [JsonProperty("line_items")]
    public List<RmaOrderItem>? LineItems { get; set; }
}

public class RmaOrderItem
{
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }
    
    [JsonProperty("return_reason")]
    public string? ReturnReason { get; set; }
    
    [JsonProperty("sku")]
    public string? Sku { get; set; }
}
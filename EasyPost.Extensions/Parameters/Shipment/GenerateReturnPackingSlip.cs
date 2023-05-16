using EasyPost.Parameters;
using EasyPost.Utilities.Internal.Attributes;
using Newtonsoft.Json;

namespace EasyPost.Extensions.Parameters.Shipment;

public class GenerateReturnPackingSlip : EasyPost.Parameters.Shipment.GenerateForm
{
    private const string TypeValue = "return_packing_slip";
    
    [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "form", "type")]
    // the base class has a Type property, but it's not marked as a TopLevelRequestParameter, so we need to replace it with our own.
    // the base Type is still visible and settable by the user, but will be ignored entirely.
    internal new string? Type { get; set; }
    
    [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "form", "barcode")]
    public string? Barcode { get; set; }
    
    [TopLevelRequestParameter(EasyPost.Utilities.Internal.Attributes.Necessity.Required, "form", "line_items")]
    public List<ReturnPackingSlipLineItem>? LineItems { get; set; }
    
    public GenerateReturnPackingSlip()
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

public class ReturnPackingSlipLineItem
{
    [JsonProperty("product")]
    public ReturnPackingSlipLineItemProduct? Product { get; set; }
    
    [JsonProperty("units")]
    public int? Units { get; set; }
}

public class ReturnPackingSlipLineItemProduct
{
    [JsonProperty("title")]
    public string? Title { get; set; }
    
    [JsonProperty("barcode")]
    public string? Barcode { get; set; }
}

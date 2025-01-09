### Archive Announcement:

https://gist.github.com/nwithan8/42282d6a63d80b87a4ebe905f1c1fef4

---

# EasyPost Extensions (.NET)

---

A collection of helper utilities for the [EasyPost .NET Client](https://github.com/EasyPost/easypost-csharp).

This project is unaffiliated with EasyPost.

## Installation

The easiest way to install the EasyPost Extensions is via [NuGet](https://www.nuget.org/packages/EasyPost.Extensions/):

    Install-Package EasyPost-Extensions

## Usage

The information below is only highlights of this package's capabilities. For full reference, see the docs: http://www.nateharr.is/easypost-extensions-dotnet/api/index.html

### Parameter Sets

The EasyPost .NET library provides a set of first-party parameter sets for each API-calling function.

The EasyPost Extensions library provides additional sets for specific functions, including:

- Sets for various forms (label QR codes, RMA QR codes, return packing slips) that can be used in the `myClient.Shipment.GenerateForm()` function
- Sets for creating FedEx and UPS carrier accounts
- Sets for updating a `User`, `EndShipper` or `CarrierAccount` using an existing object
- A `Refund` set for simplifying the refunding of a referral customer

### Service Extension Methods

The EasyPost Extensions library provides a set of extension methods for EasyPost services to make them easier to work with.

- Create FedEx or UPS accounts with `myClient.CarrierAccount.CreateFedEx()` or `myClient.CarrierAccount.CreateUps()`
- Simplify refunding a referral customer with `myClient.ReferralCustomer.Refund()`
- Return a shipment with `myClient.Shipment.Return()`
- Toggle a webhook with `myClient.Webhook.Toggle()`

### Model Extension Methods

The EasyPost Extensions library provides a set of extension methods for EasyPost models to make them easier to work with.

- Get the state of a `Batch` object as an enum with `myBatch.BatchStateEnum()`
- Get the form type of a `CustomsInfo` object as an enum with `myCustomsInfo.FormTypeEnum()`
- Get the non-delivery option of a `CustomsInfo` object as an enum with `myCustomsInfo.NonDeliveryOptionEnum()`
- Get the restriction type of a `CustomsItem` object as an enum with `myCustomsItem.RestrictionTypeEnum()`
- Get the type of an `Event` object as an enum with `myEvent.Type()`
- Get the type of a `Form` object as an enum with `myForm.Type()`

### Custom Clients

The EasyPost Extensions library provides a set of custom clients to make working with the EasyPost API easier.

- `ProxyClient` - An extension of `EasyPostClient` that uses a proxy server to make API requests
- `IntrospectiveClient` - An extension of `EasyPostClient` that supports pre- and post-request hooks
- `MockClient` - An extension of `EasyPostClient` that allows you to mock API requests and responses

### Client Manager

The EasyPost Extensions library provides a `ClientManager` class to help manage the EasyPost API client.

The `ClientManager` class wraps the EasyPost .NET library `Client` class, storing both your test and production API keys
to make it easier to switch between the two modes.

```csharp
// Create a new ClientManager instance
var clientManager = new EasyPost.Extensions.ClientManager("test_123", "prod_123");

// Access the EasyPost .NET library Client instance to use as normal
var address = await clientManager.Client.Address.Create(parameters);

// Switch between test and production modes
clientManager.EnableTestMode();
clientManager.EnableProductionMode();

// It is recommended to always access the Client instance via the Client property directly, rather than storing it as a variable.
// When switching between test and production modes, the Client is re-initialized. Storing the Client as a variable may cause it to not be updated when switching modes.

// Yes
var address = await clientManager.Client.Address.Create(parameters);

// No
var client = clientManager.Client;
var address = await client.Address.Create(parameters);
```

### Webhook Handler

The EasyPost Extensions library provides an `EasyPostWebhookController` class to help manage EasyPost webhooks.

The controller, paired with an `EasyPostEventProcessor`, will automatically execute specific actions based on the type of event received.

End-users should implement their own controller that inherits from `EasyPostWebhookController` and override the `WebhookSecret`, `EnableTestMode` and `EventProcessor` properties.
```csharp
[Route("api/incoming_easypost_webhook")]
public class MyWebhookController : EasyPostWebhookController
{
    protected override string WebhookSecret => "my-webhook-secret";
    
    protected override bool EnableTestMode => false;
    
    protected override EasyPostEventProcessor EventProcessor => new()
    {
        OnBatchCreated = async (@event) =>
        {
            // Do something when a "batch.created" event is received
        },
    };
    
    public MyWebhookController(ILogger<MyWebhookController>? logger) : base(logger)
    {
    }
}
```

### Test Data Generators

The EasyPost Extensions library provides a set of helper functions to generate test data for you.

```csharp
// Generate a random shipment

var shipment = EasyPost.Extensions.Testing.DummyData.Shipments.CreateShipment(myEasyPostClient);
```

This library allows you to generate the following test data:

- Address objects
- Batch objects
- Carrier strings
- CustomsInfo objects
- CustomsItem objects
- Insurance objects
- Parcel objects
- Pickup objects
- Rate objects
- SmartRate objects
- Shipment objects
- TaxIdentifier parameters
- Tracker objects
- Webhook objects

# EasyPost Extensions (.NET)

---

A collection of helper utilities for the [EasyPost .NET Client](https://github.com/EasyPost/easypost-csharp).

This project is unaffiliated with EasyPost.

## Installation

The easiest way to install the EasyPost Extensions is via [NuGet](https://www.nuget.org/packages/EasyPost.Extensions/):

    Install-Package EasyPost-Extensions

## Usage

### Parameter Dictionary Creation

Currently, the EasyPost .NET library requires end-users to pass in pre-formatted dictionaries of key-value pairs of data
to the functions.

Example:

```csharp
var parameters = new Dictionary<string, object> {
    { "name", "My Name" },
    { "street1", "123 Main St" },
    { "city", "San Francisco" },
    { "state", "CA" },
    { "zip", "94105" },
    { "country", "US" },
    { "phone", "415-123-4567" }
};

var address = await myClient.Address.Create(parameters);
```

This can lead to some confusion when end-users are not familiar
with [what JSON key-value pairs are expected](https://www.easypost.com/docs/api/csharp) for a given function.

This can also lead to errors if the end-user were to accidentally misspell a key, or if the key were to change in a
future version of the library.

The EasyPost Extensions library provides a set of helper functions to create these dictionaries for you, ensuring that:

- The correct keys are used
- The correct value types are used
- The data is formatted correctly
- All required parameters are included
- The schema is valid for a specific API version

Example:

```csharp
// Use an object constructor to create the address creation parameters
var addressCreateParameters = new EasyPost.Extensions.Parameters.V2.Address.Create {
    Name = "My Name",
    Street1 = "123 Main St",
    City = "San Francisco",
    State = "CA",
    Zip = "94105",
    Country = "US",
    Phone = "415-123-4567"
};

// You can add additional parameters as needed outside of the constructor
addressCreateParameters.Company = "My Company";

// Then convert the object to a dictionary
// This step will validate the data and throw an exception if there are any errors (i.e. missing required parameters)
var addressCreateDictionary = addressCreateParameters.ToDictionary();

// Pass the dictionary into the EasyPost .NET library method as normal
var address = await myClient.Address.Create(addressCreateDictionary);
```

The parameter object models are divided by object type (i.e. Address, Parcel, etc.) and by function (i.e. Create,
Retrieve, etc.).

#### Service and Model Extension Methods

Users can utilize the parameter objects above, passing the `.ToDictionary()` results into the first-party EasyPost .NET
library methods.

```csharp
var endShipperCreateParameters = new EasyPost.Extensions.Parameters.V2.EndShipper.Create {
    Name = "My Name",
    Street1 = "123 Main St",
    City = "San Francisco",
    State = "CA",
    Zip = "94105",
    Country = "US",
    Phone = "415-123-4567"
};

// Pass the parameter object as a dictionary into the EasyPost .NET library
var endShipper = await myClient.EndShipper.Create(endShipperCreateParameters.ToDictionary());
```

The EasyPost Extensions library also provides a set of extension methods for EasyPost services and models to make this
process easier, allowing users to pass in the parameter objects directly.

```csharp
// import the proper namespaces to use the extension methods
using EasyPost.Extensions.ServiceMethodExtensions;
using EasyPost.Extensions.ModelMethodExtensions;

var endShipperCreateParameters = new EasyPost.Extensions.Parameters.V2.EndShipper.Create {
    Name = "My Name",
    Street1 = "123 Main St",
    City = "San Francisco",
    State = "CA",
    Zip = "94105",
    Country = "US",
    Phone = "415-123-4567"
};

// Pass the parameter object directly into the EasyPost service extension method (no need to call .ToDictionary())
var endShipper = await myClient.EndShipper.Create(endShipperCreateParameters);

// You can also use the extension methods on the EasyPost models themselves
var endShipperUpdateParameters = new EasyPost.Extensions.Parameters.V2.EndShipper.Update {
    Name = "My New Name"
};

// Pass the parameter object directly into the EasyPost model extension method (no need to call .ToDictionary())
await endShipper.Update(endShipperUpdateParameters);
```

Behind the scenes, these extension methods will simply validate the parameter object and convert it to a dictionary
before passing it into the first-party EasyPost .NET library methods.

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

### API URL Generator

The EasyPost API is currently on `v2`, but there is also the `beta` version for beta features.

In case the EasyPost API base URL ever changes (either to a new subdomain or to a new version), the EasyPost Extensions
library provides a helper function to generate the API URL for you.

Example:

```csharp
// Generate the API URL for the v2 API

var apiVersionV2Enum = EasyPost.Extensions.ApiVersion.V2;
var apiV2Url = = EasyPost.Extensions.General.BuildApiBaseUrl(apiVersionV2Enum);

// apiV2Url will be, e.g. "https://api.easypost.com/v2/"
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
- Smartrate objects
- Shipment objects
- TaxIdentifier parameters
- Tracker objects
- Webhook objects

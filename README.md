## EasyPost Extensions (.NET)

---

A collection of helper utilities for the [EasyPost .NET Client](https://github.com/EasyPost/easypost-csharp).

This project is unaffiliated with EasyPost.

### Installation

The easiest way to install the EasyPost Extensions is via [NuGet](https://www.nuget.org/packages/EasyPost.Extensions/):

    Install-Package EasyPost-Extensions

### Usage

#### Parameter Dictionary Creation

Currently, the EasyPost .NET library requires end-users to pass in pre-formatted dictionaries of key-value pairs of data to the functions.

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

var address = myClient.Address.Create(parameters);
```

This can lead to some confusion when end-users are not familiar with [what JSON key-value pairs are expected](https://www.easypost.com/docs/api/csharp) for a given function.

This can also lead to errors if the end-user were to accidentally misspell a key, or if the key were to change in a future version of the library.

The EasyPost Extensions library provides a set of helper functions to create these dictionaries for you, ensuring that:
- The correct keys are used
- The correct value types are used
- The data is formatted correctly
- All required parameters are included

Example:
```csharp
// Use an object constructor to create the address creation parameters
var addressCreateParameters = new EasyPost.Extensions.Parameters.Address.Create {
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
var address = myClient.Address.Create(addressCreateDictionary);
```

The parameter object models are divided by object type (i.e. Address, Parcel, etc.) and by function (i.e. Create, Retrieve, etc.).

Optionally, the `ToDictionary()` method can accept an `ApiVersion` enum value to specify the API version to use when validating the data.

Internally, each parameter is marked with an `ApiCompatibility` attribute that specifies the API version(s) that the parameter is compatible with. The provided API version can be utilized for compatibility checks during validation if provided. This can be useful if the EasyPost API parameters ever change in the future.

#### Service and Model Extension Methods

Users can utilize the parameter objects above, passing the `.ToDictionary()` results into the first-party EasyPost .NET library methods.

```csharp
var endShipperCreateParameters = new EasyPost.Extensions.Parameters.EndShipper.Create {
    Name = "My Name",
    Street1 = "123 Main St",
    City = "San Francisco",
    State = "CA",
    Zip = "94105",
    Country = "US",
    Phone = "415-123-4567"
};

// Pass the parameter object as a dictionary into the EasyPost .NET library
var endShipper = myClient.EndShipper.Create(endShipperCreateParameters.ToDictionary());
```

The EasyPost Extensions library also provides a set of extension methods for EasyPost services and models to make this process easier, allowing users to pass in the parameter objects directly.

```csharp
// import the proper namespaces to use the extension methods
using EasyPost.Extensions.ServiceMethodExtensions;
using EasyPost.Extensions.ModelMethodExtensions;

var endShipperCreateParameters = new EasyPost.Extensions.Parameters.EndShipper.Create {
    Name = "My Name",
    Street1 = "123 Main St",
    City = "San Francisco",
    State = "CA",
    Zip = "94105",
    Country = "US",
    Phone = "415-123-4567"
};

// Pass the parameter object directly into the EasyPost service extension method (no need to call .ToDictionary())
var endShipper = myClient.EndShipper.Create(endShipperCreateParameters);

// You can also use the extension methods on the EasyPost models themselves
var endShipperUpdateParameters = new EasyPost.Extensions.Parameters.EndShipper.Update {
    Name = "My New Name"
};

// Pass the parameter object directly into the EasyPost model extension method (no need to call .ToDictionary())
endShipper.Update(endShipperUpdateParameters);
```

Behind the scenes, these extension methods will simply validate the parameter object and convert it to a dictionary before passing it into the first-party EasyPost .NET library methods.

#### API URL Generator

The EasyPost API is currently on `v2`, but there is also the `beta` version for beta features.

In case the EasyPost API base URL ever changes (either to a new subdomain or to a new version), the EasyPost Extensions library provides a helper function to generate the API URL for you.

Example:
```csharp
// Generate the API URL for the v2 API

var apiVersionV2Enum = EasyPost.Extensions.ApiVersion.V2;
var apiV2Url = = EasyPost.Extensions.General.BuildApiBaseUrl(apiVersionV2Enum);

// apiV2Url will be, e.g. "https://api.easypost.com/v2/"
```
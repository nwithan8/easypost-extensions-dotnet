# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [1.5.0] - 2024-06-05

### Added

- New `GetBestRate` method on `Shipment` service to use rules to find the best smart rate
  - Can automatically filter out rates by min/max cost, service level, carrier or min/max estimated delivery time
  - Can fall back to fastest, slowest, cheapest, or most expensive rate in event of a tie
- New `Create` parameter sets for GIO Express and CS Logistics carrier accounts
- New `Create` parameter sets for common parcel types
- New dummy data for parcel types
- Add .NET 8.0 support

### Changed

- **BREAKING**: Minimum EasyPost SDK version is now v6.5.0

## [1.4.0] - 2023-11-06

### Added

- New `Money` class for representing monetary values
- New `GetAccountBalance` function for getting the balance of an EasyPost account
- New methods on a `User` instance to retrieve monetary values as `Money` instances

## [1.3.0] - 2023-08-30

### Added

- New `Create` parameter sets for all carrier accounts
  - Use `EasyPost.Services.CarrierAccountService.CreateCustom` to use
- New enums for all available report columns

### Changed

- **BREAKING**: Minimum EasyPost SDK version is now v5.5.0

## [1.2.0] - 2023-07-06

### Changed

- `IntrospectiveClient` now uses event handlers for readonly pre- and post-request hooks/callbacks
- `IntrospectiveClient` now has a post-request read-write callback for modifying the response before it is returned

## [1.1.0] - 2023-06-06

### Added

- New `ProxyClient` to funnel API requests through a proxy server
- New `MockClient` to mock API requests and responses
- New `IntrospectiveClient` to provide pre- and post-request hooks

### Changed

- **BREAKING**: Library now supports EasyPost SDK v5.1.0 as a minimum

## [1.0.0] - 2023-05-16

### Added

- New `EasyPostWebhookController` class for handling EasyPost webhooks
- New enum for `Event` type
- New parameter sets for creating various shipment forms

### Changed

- **BREAKING**: Library now supports EasyPost SDK v5 as a minimum
- **BREAKING**: Most parameter sets removed in favor of using the EasyPost SDK's built-in parameter classes
- **BREAKING**: API URL generator has been removed, since any given version of an EasyPost SDK will never target multiple API versions

## [0.6.0] - 2023-01-29

### Added

- New enums for common "one-of" values, used for both parameter creation and extraction from models
- New auto-generated docs, docstrings for all classes and methods
- New "one-call buy" method for shipments and orders

### Changed

- **BREAKING CHANGE**: Enums have been consolidated into a new namespace, `EasyPost.Extensions.Enums`

## [0.5.0] - 2023-01-21

### Added

- New `ClientManager` class, a wrapper for an EasyPost client that allows for easy switching between API keys
- New `Testing.DummyData` namespace with classes and functions for generating dummy data for testing
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
- Doc strings for many classes and methods

## [0.4.0] - 2023-01-18

### Added

- Extension method for `client.Pickup.All()` method

### Changed

- **BREAKING**: All parameters models are now grouped by API version, affecting the namespace:

```csharp
// old
var params = new EasyPost.Extensions.Parameters.Address.Create { };

// new
var params = new EasyPost.Extensions.Parameters.V2.Address.Create {};
```

- Bump compatibility to EasyPost C# 4.3.0
- Under-the-hood improvements to parameters

## [0.3.0] - 2023-01-18

### Added

- Refund functions for shipments
- Enums for report types
- Doc strings to all extension methods

### Changed

- Improvements to changelog

## [0.2.0] - 2022-12-19

### Added

- Extension methods for EasyPost services (static functions) and models (instance functions), allowing user to use the
  parameter objects directly in function calls
- Support for .NET 7
- Optional `Reference` property for Carrier Account creation parameters

### Changed

- Update dependencies
- Internal file organization

## [0.1.0] - 2022-10-19

### Added

- `BuildApiBaseUrl` method for generating EasyPost API URLs
- Parameter objects for constructing EasyPost API request parameters using typed objects

[Unreleased]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.4.0...HEAD

[1.5.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.4.0...1.5.0

[1.4.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.3.0...1.4.0

[1.3.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.2.0...1.3.0

[1.2.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.1.0...1.2.0

[1.1.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.0.0...1.1.0

[1.0.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.6.0...1.0.0

[0.6.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.5.0...0.6.0

[0.5.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.4.0...0.5.0

[0.4.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.3.0...0.4.0

[0.3.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.2.0...0.3.0

[0.2.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.1.0...0.2.0

[0.1.0]: https://github.com/nwithan8/easypost-extensions-dotnet/releases/tag/0.1.0

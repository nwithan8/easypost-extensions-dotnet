# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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

[Unreleased]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.1.0...HEAD

[1.1.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/1.0.0...1.1.0

[1.0.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.6.0...1.0.0

[0.6.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.5.0...0.6.0

[0.5.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.4.0...0.5.0

[0.4.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.3.0...0.4.0

[0.3.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.2.0...0.3.0

[0.2.0]: https://github.com/nwithan8/easypost-extensions-dotnet/compare/0.1.0...0.2.0

[0.1.0]: https://github.com/nwithan8/easypost-extensions-dotnet/releases/tag/0.1.0

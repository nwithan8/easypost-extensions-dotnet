using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EasyPost._base;
using EasyPost.Exceptions.API;
using EasyPost.Extensions.Clients;
using EasyPost.Extensions.Parameters.Shipment;
using EasyPost.Extensions.Testing.DummyData;
using EasyPost.Extensions.Webhooks;
using EasyPost.Models.API;
using EasyPost.Parameters.EndShipper;
using Xunit;
using Create = EasyPost.Extensions.Parameters.Parcel.Create;
using CustomAssert = EasyPost.Extensions.Test.Utilities.Assertions.Assert;
using Enum = NetTools.Common.Enum;

namespace EasyPost.Extensions.Test;

public class UnitTests
{
    [Fact]
    public async Task TestDummyDataObject()
    {
        var client = new Client(new ClientConfiguration("some_api_key")); // We're not going to make a real API call

        // Should throw an exception because the API key is fake
        await Assert.ThrowsAnyAsync<Exception>(() => Addresses.CreateAddressPair(client, false));
        await Assert.ThrowsAnyAsync<Exception>(() => Parcels.CreateParcel(client));
    }

    [Fact]
    public async Task TestDummyDataNoAPICallNeeded()
    {
        var carrierString = Carriers.GetCarrier();
        Assert.NotNull(carrierString);

        var taxIdentifierParameters = TaxIdentifiers.CreateTaxIdentifierParameters(TaxIdentifiers.Entity.Sender);
        Assert.NotNull(taxIdentifierParameters);
    }

    [Fact]
    public async Task TestParameterSetOverride()
    {
        const string predefinedPackageName = "not_a_real_package_name";
        
        // use a "new" parameter overriding the base parameter from the SDK
        var parameters = new Create
        {
            PredefinedPackage = predefinedPackageName,
        };
        
        var dictionary = parameters.ToDictionary();
        
        CustomAssert.KeyPathValueEquals(dictionary, new[] {"parcel", "predefined_package"}, predefinedPackageName);
        
        const string predefinedPackageName2 = "not_a_real_package_name_2";
        
        // use a newly-existing parameter, see if the getter/setter override works
        parameters = new Create
        {
            PredefinedPackageMetadata = new PredefinedPackage
            {
                Name = predefinedPackageName2,
            },
        };
        
        dictionary = parameters.ToDictionary();
        
        CustomAssert.KeyPathValueEquals(dictionary, new[] {"parcel", "predefined_package"}, predefinedPackageName2);
    }

    [Fact]
    public void TestClientManager()
    {
        const string key1 = "key1";
        const string key2 = "key2";

        var httpClient = new HttpClient();

        var clientManager = new ClientManager(key1, key2, customTimeout: TimeSpan.FromSeconds(20), httpClient);
        Assert.Equal(key1, clientManager.Client.ApiKeyInUse);
        Assert.Equal(20, clientManager.Client.Timeout.TotalSeconds);
        Assert.Equal(httpClient, clientManager.Client.CustomHttpClient);
    }

    [Fact]
    public async Task TestExtensionParameters()
    {
        var client = new Client(new ClientConfiguration("some_api_key")); // We're don't care about the API call results
        const string endShipperId = "not_a_real_endshipper_id";

        // first-party parameter set
        Update firstPartyUpdateParameters = new()
        {
            Name = "Test Name",
        };
        // should throw an exception because the API key is fake and the data is fake
        await Assert.ThrowsAsync<UnauthorizedError>(() => client.EndShipper.Update(endShipperId, firstPartyUpdateParameters));

        // third-party parameter set
        Parameters.EndShipper.Update thirdPartyUpdateParameters = new()
        {
            Name = "Test Name",
        };
        // should throw an exception because the API key is fake and the data is fake
        // the fact that this function compiles means we can pass our third-party extension parameter sets to first-party EasyPost functions
        await Assert.ThrowsAsync<UnauthorizedError>(() => client.EndShipper.Update(endShipperId, thirdPartyUpdateParameters));
    }

    [Fact]
    public async Task TestParametersFromObject()
    {
        return;
    }

    [Fact]
    public async Task TestExtensionParameterToDictionaryOverride()
    {
        var parameters = new GenerateReturnPackingSlip
        {
            Type = "return_packing_slip",
            Barcode = "1234567890",
            LineItems = new List<ReturnPackingSlipLineItem>
            {
                new()
                {
                    Product = new()
                    {
                        Title = "Test Product",
                        Barcode = "1234567890",
                    },
                },
            },
        };

        var dictionary = parameters.ToDictionary();

        var client = new Client(new ClientConfiguration("some_api_key"));

        const string shipmentId = "not_a_real_shipment_id";

        // should throw an exception because the API key is fake and the data is fake
        await Assert.ThrowsAsync<UnauthorizedError>(() => client.Shipment.GenerateForm(shipmentId, parameters));
    }

    [Fact]
    public async Task TestIntrospectiveClient()
    {
        var requestEditorFired = false;
        var requestViewerFired = false;
        var responseEditorFired = false;
        var responseViewerFired = false;

        var hooks = new IntrospectiveClientHooks
        {
            PreFlightRequestEditor = request =>
            {
                requestEditorFired = true;
                return request;
            },
            OnRequestExecuting = (sender, args) => { requestViewerFired = true; },
            PostFlightResponseEditor = response =>
            {
                responseEditorFired = true;
                return response;
            },
            OnRequestResponseReceived = (sender, args) => { responseViewerFired = true; },
        };

        var client = new IntrospectiveClient(new ClientConfiguration("some_api_key"), hooks);

        // Make a request, doesn't matter what it is (catch the exception due to invalid API key)
        await Assert.ThrowsAsync<UnauthorizedError>(async () => await client.Address.Create(new EasyPost.Parameters.Address.Create()));

        Assert.True(requestEditorFired);
        Assert.True(requestViewerFired);
        Assert.True(responseEditorFired);
        Assert.True(responseViewerFired);
    }

    [Fact]
    public async Task TestIntrospectiveClientEditorFunctions()
    {
        var hooks = new IntrospectiveClientHooks
        {
            PreFlightRequestEditor = request => new HttpRequestMessage(), // replace the request object with a blank one
        };

        var client = new IntrospectiveClient(new ClientConfiguration("some_api_key"), hooks);

        // Making a request should fail because the URL is invalid (not set)
        await Assert.ThrowsAsync<InvalidOperationException>(async () => await client.Address.Create(new EasyPost.Parameters.Address.Create()));

        hooks = new IntrospectiveClientHooks
        {
            PostFlightResponseEditor = response => new HttpResponseMessage(), // replace the response object with a blank one
        };

        client = new IntrospectiveClient(new ClientConfiguration("some_api_key"), hooks);

        // Making a request should fail because the response is invalid (not set) (JSON deserialization fails)
        await Assert.ThrowsAsync<NullReferenceException>(async () => await client.Address.Create(new EasyPost.Parameters.Address.Create()));
    }

    [Fact]
    public async Task TestIntrospectiveClientReplaceCallbacks()
    {
        var hooks = new IntrospectiveClientHooks
        {
            PreFlightRequestEditor = request => request,
        };
        
        var client = new IntrospectiveClient(new ClientConfiguration("some_api_key"), hooks);
        
        // Making request should only fail because the API key is invalid
        await Assert.ThrowsAsync<UnauthorizedError>(async () => await client.Address.Create(new EasyPost.Parameters.Address.Create()));
        
        // replace the hook with one that should trigger a different error
        hooks.PreFlightRequestEditor = request => throw new Exception("Test Exception");
        
        // Making request should fail because the hook throws an exception
        await Assert.ThrowsAsync<Exception>(async () => await client.Address.Create(new EasyPost.Parameters.Address.Create()));
    }

    [Fact]
    public async Task TestMockClient()
    {
        const HttpStatusCode statusCode = HttpStatusCode.PaymentRequired;
        const string content = "{'this': 'is a test'}";

        var mockRequests = new List<MockRequest>
        {
            new(
                new MockRequestMatchRules(HttpMethod.Post, @"addresses"),
                new MockRequestResponseInfo(statusCode, content)
            ),
        };

        var mockClient = new MockClient(new ClientConfiguration("fake_api_key"));
        mockClient.AddMockRequests(mockRequests);

        // endpoint wouldn't normally throw this error, so if we get it, we know the mock request was used
        await Assert.ThrowsAsync<PaymentError>(async () => await mockClient.Address.Create(new EasyPost.Parameters.Address.Create()));
    }

    [Fact]
    public async Task TestProxyClient()
    {
        // just testing construction exception
        var proxy = new WebProxy("49.51.189.190:443");
        var config = new ClientConfiguration("some_api_key");

#if NET462
        Assert.Throws<Exception>(() => new ProxyClient(config, proxy));
#else
        try {
            var client = new ProxyClient(config, proxy);
            // construction succeeded
            Assert.True(true);
            
            // Make a request, doesn't matter what it is (catch the exception due to proxy being unavailable)
            await Assert.ThrowsAsync<System.Net.Http.HttpRequestException>(async () => await client.Address.Create(new EasyPost.Parameters.Address.Create()));
        } catch (Exception e) {
            // construction failed
            Assert.True(false);
        }

#endif
    }
}

public class FakeWebhookController : EasyPostWebhookController
{
    private readonly Client _client = new(new ClientConfiguration("my-api-key"));

    protected override string WebhookSecret => "my-secret";
    
    protected override bool EnableTestMode => false;

    protected override EasyPostEventProcessor EventProcessor => new()
    {
        OnBatchCreated = async (@event) => { await _client.Batch.Buy("fake_id"); },
    };
}

public class FakeService
{
    public async Task<FakeServiceEnums> UpdateObject<T>(string objectId, Dictionary<string, object?> data)
    {
        return FakeServiceEnums.UpdateSuccess;
    }

    public async Task DeleteObject(string objectId)
    {
        return;
    }
}

public class FakeClient
{
    public FakeService Service { get; }

    public FakeClient()
    {
        Service = new FakeService();
    }
}

public class EasyPostObjectMock : EasyPostObject
{
    public new string? Id { get; set; }
}

public class FakeServiceEnums : Enum
{
    public static readonly FakeServiceEnums UpdateSuccess = new FakeServiceEnums(1);
    public static readonly FakeServiceEnums UpdateFailure = new FakeServiceEnums(2);
    public static readonly FakeServiceEnums DeleteSuccess = new FakeServiceEnums(3);
    public static readonly FakeServiceEnums DeleteFailure = new FakeServiceEnums(4);

    public FakeServiceEnums(int value) : base(value)
    {
    }
}

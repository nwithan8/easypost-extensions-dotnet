using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EasyPost.Extensions.Clients;
using EasyPost.Extensions.Webhooks;
using EasyVCR;
using Xunit;

namespace EasyPost.Extensions.Test;

public class UnitTests
{
    [Fact]
    public async Task TestDummyDataObject()
    {
        var client = new Client(new ClientConfiguration("some_api_key")); // We're not going to make a real API call

        // Should throw an exception because the API key is fake
        await Assert.ThrowsAnyAsync<Exception>(() => Testing.DummyData.Addresses.CreateAddressPair(client, false));
        await Assert.ThrowsAnyAsync<Exception>(() => Testing.DummyData.Parcels.CreateParcel(client));
    }

    [Fact]
    public async Task TestDummyDataNoAPICallNeeded()
    {
        var carrierString = Testing.DummyData.Carriers.GetCarrier();
        Assert.NotNull(carrierString);

        var taxIdentifierParameters = Testing.DummyData.TaxIdentifiers.CreateTaxIdentifierParameters(Testing.DummyData.TaxIdentifiers.Entity.Sender);
        Assert.NotNull(taxIdentifierParameters);
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
        EasyPost.Parameters.EndShipper.Update firstPartyUpdateParameters = new()
        {
            Name = "Test Name",
        };
        // should throw an exception because the API key is fake and the data is fake
        await Assert.ThrowsAsync<EasyPost.Exceptions.API.UnauthorizedError>(() => client.EndShipper.Update(endShipperId, firstPartyUpdateParameters));

        // third-party parameter set
        EasyPost.Extensions.Parameters.EndShipper.Update thirdPartyUpdateParameters = new()
        {
            Name = "Test Name",
        };
        // should throw an exception because the API key is fake and the data is fake
        // the fact that this function compiles means we can pass our third-party extension parameter sets to first-party EasyPost functions
        await Assert.ThrowsAsync<EasyPost.Exceptions.API.UnauthorizedError>(() => client.EndShipper.Update(endShipperId, thirdPartyUpdateParameters));
    }

    [Fact]
    public async Task TestParametersFromObject()
    {
        return;
    }

    [Fact]
    public async Task TestExtensionParameterToDictionaryOverride()
    {
        var parameters = new EasyPost.Extensions.Parameters.Shipment.GenerateReturnPackingSlip
        {
            Type = "return_packing_slip",
            Barcode = "1234567890",
            LineItems = new List<EasyPost.Extensions.Parameters.Shipment.ReturnPackingSlipLineItem>
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

        var cassette = new EasyVCR.Cassette("/Users/nharris/code/personal/easypost_extensions_dotnet/EasyPost.Extensions.Test/cassettes", "TestExtensionParameterToDictionaryOverride");
        var vcrClient = EasyVCR.HttpClients.NewHttpClient(cassette, Mode.Record);

        var client = new Client(new ClientConfiguration("some_api_key") // We're don't care about the API call results
        {
            CustomHttpClient = vcrClient,
        });
        
        const string shipmentId = "not_a_real_shipment_id";
        
        // should throw an exception because the API key is fake and the data is fake
        await Assert.ThrowsAsync<EasyPost.Exceptions.API.UnauthorizedError>(() => client.Shipment.GenerateForm(shipmentId, parameters));
    }

    [Fact]
    public async Task TestIntrospectiveClient()
    {
        var requestViewerCount = 0;
        var requestEditorCount = 0;
        var responseViewerCount = 0;
        
        void RequestViewer(HttpRequestMessage request)
        {
            requestViewerCount++;
        }
        
        HttpRequestMessage RequestEditor(HttpRequestMessage request)
        {
            requestEditorCount++;
            return request;
        }
        
        void ResponseViewer(HttpResponseMessage response)
        {
            responseViewerCount++;
        }

        var hooks = new IntrospectiveClientHooks
        {
            RequestViewer = RequestViewer,
            RequestEditor = RequestEditor,
            ResponseViewer = ResponseViewer,
        };
        
        var client = new IntrospectiveClient(new ClientConfiguration("some_api_key"), hooks);
        
        // Make a request, doesn't matter what it is (catch the exception due to invalid API key)
        await Assert.ThrowsAsync<EasyPost.Exceptions.API.UnauthorizedError>(async () => await client.Address.Create(new EasyPost.Parameters.Address.Create()));

        // Assert that the request viewer was called
        Assert.Equal(1, requestViewerCount);
        // Assert that the request editor was called
        Assert.Equal(1, requestEditorCount);
        // Assert that the response viewer was called
        Assert.Equal(1, responseViewerCount);
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
        await Assert.ThrowsAsync<EasyPost.Exceptions.API.PaymentError>(async () => await mockClient.Address.Create(new EasyPost.Parameters.Address.Create()));
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
    protected override EasyPostEventProcessor EventProcessor => new()
    {
        OnBatchCreated = async (@event) =>
        {
            await _client.Batch.Buy("fake_id");
        },
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

public class EasyPostObjectMock : EasyPost._base.EasyPostObject
{
    public new string? Id { get; set; }
}

public class FakeServiceEnums : NetTools.Common.Enum
{
    public static readonly FakeServiceEnums UpdateSuccess = new FakeServiceEnums(1);
    public static readonly FakeServiceEnums UpdateFailure = new FakeServiceEnums(2);
    public static readonly FakeServiceEnums DeleteSuccess = new FakeServiceEnums(3);
    public static readonly FakeServiceEnums DeleteFailure = new FakeServiceEnums(4);

    public FakeServiceEnums(int value) : base(value)
    {
    }
}

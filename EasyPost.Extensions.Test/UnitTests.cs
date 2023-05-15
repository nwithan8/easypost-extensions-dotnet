using EasyVCR;

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
        await Assert.ThrowsAsync<Exception>(() => client.EndShipper.Update(endShipperId, firstPartyUpdateParameters));

        // third-party parameter set
        EasyPost.Extensions.Parameters.EndShipper.Update thirdPartyUpdateParameters = new()
        {
            Name = "Test Name",
        };
        // should throw an exception because the API key is fake and the data is fake
        // the fact that this function compiles means we can pass our third-party extension parameter sets to first-party EasyPost functions
        await Assert.ThrowsAsync<Exception>(() => client.EndShipper.Update(endShipperId, thirdPartyUpdateParameters));
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
        await Assert.ThrowsAsync<Exception>(() => client.Shipment.GenerateForm(shipmentId, parameters));
    }
}

public class ServiceMock
{
    public async Task<MockEnums> UpdateObject<T>(string objectId, Dictionary<string, object?> data)
    {
        return MockEnums.UpdateSuccess;
    }

    public async Task DeleteObject(string objectId)
    {
        return;
    }
}

public class ClientMock
{
    public ServiceMock Service { get; }

    public ClientMock()
    {
        Service = new ServiceMock();
    }
}

public class EasyPostObjectMock : EasyPost._base.EasyPostObject
{
    public new string? Id { get; set; }
}

public class MockEnums : NetTools.Common.Enum
{
    public static readonly MockEnums UpdateSuccess = new MockEnums(1);
    public static readonly MockEnums UpdateFailure = new MockEnums(2);
    public static readonly MockEnums DeleteSuccess = new MockEnums(3);
    public static readonly MockEnums DeleteFailure = new MockEnums(4);

    public MockEnums(int value) : base(value)
    {
    }
}

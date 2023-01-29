using EasyPost._base;
using EasyPost.Extensions.ServiceMethodExtensions;
using EasyPost.Extensions.ModelMethodExtensions;
using EasyPost.Extensions.Internal.Exceptions;
using EasyPost.Extensions.Testing;
using EasyPost.Extensions.Testing.DummyData;

namespace EasyPost.Extensions.Test;

public class UnitTests
{
    [Fact]
    public void TestJsonParameters()
    {
        // Declare properties via constructor
        // ReSharper disable once UseObjectOrCollectionInitializer
        var addressCreateParameters = new Parameters.V2.Addresses.Create
        {
            City = "San Francisco",
            Company = "EasyPost",
        };

        // Add properties after construction (set accessible, not just init)
        addressCreateParameters.Name = "John Smith";

        // Can get properties after they're set
        Assert.Equal("John Smith", addressCreateParameters.Name);

        // Use the parameters object to make a dictionary
        var dictionary = addressCreateParameters.ToDictionary();

        // Pass the dictionary into the method in the EasyPost library
        var client = new Client("my_api_key");
        // var address = client.Address.Create(dictionary); // API call is made here, would fail because key is fake
    }

    [Fact]
    public void TestParameterGroups()
    {
        // set all normal required properties
        var parameters = new Parameters.V2.CarrierAccounts.CreateUps
        {
            AccountNumber = "something",
            City = "something",
            CompanyName = "something",
            Country = "something",
            Email = "something",
            RegistrarName = "something",
            PhoneNumber = "something",
            PostalCode = "something",
            State = "something",
            Street = "something",
            RegistrarJobTitle = "something",
            Website = "something"
        };
        
        // with all the parameters in the "ups_invoice_info" group not set, this should be fine
        Assert.NotNull(parameters.ToDictionary());
        
        // if we set only one of the parameters in the "ups_invoice_info" group, it should throw an exception
        parameters.InvoiceAmount = "something";
        Assert.Throws<IncompleteParameterGroupsException>(() => parameters.ToDictionary());

        // if we set all the parameters in the "ups_invoice_info" group, it should be fine
        parameters.InvoiceControlId = "something";
        parameters.InvoiceCurrency = "something";
        parameters.InvoiceDate = "something";
        parameters.InvoiceNumber = "something";
        Assert.NotNull(parameters.ToDictionary());
    }

    [Fact]
    public async Task TestServiceExtensionMethod()
    {
        var client = new Client("some_api_key");
        
        // this will throw an exception because the API key is fake
        var addressCreateParameters = new Parameters.V2.Addresses.Create
        {
            City = "San Francisco",
            Company = "EasyPost",
        };
        
        await Assert.ThrowsAnyAsync<Exception>(() => client.Address.Create(addressCreateParameters));
    }
    
    [Fact(Skip = "This test requires a valid API key")]
    public async Task TestModelExtensionMethod()
    {
        var client = new Client("some_api_key");
        
        // can't test because we can't get a real model object to test with (API key is fake)
        /*
        var endShipperCreateParameters = new Parameters.EndShipper.Create
        {
            City = "San Francisco",
            Company = "EasyPost",
        };
        var endShipper = await client.EndShipper.Create(endShipperCreateParameters);
        
        var endShipperUpdateParameters = new Parameters.EndShipper.Update
        {
            City = "Atlanta",
            Company = "Not EasyPost",
        };
        
        // this will throw an exception because the API key is fake
        await Assert.ThrowsAnyAsync<Exception>(() => endShipper.Update(endShipperUpdateParameters));
        */
    }
    
    [Fact]
    public void TestApiUrlBuild()
    {
        var apiVersion = Enums.ApiVersion.V2;

        var apiUrl = EasyPost.Extensions.General.BuildApiBaseUrl(apiVersion);
        
        Assert.Equal("https://api.easypost.com/v2/", apiUrl);
    }

    [Fact]
    public async Task TestUpdateInstanceMethod()
    {
        var client = new ClientMock();

        var easyPostObjectMock = new EasyPostObjectMock
        {
            Id = "id",
        };

        // test with explicit Update function
        var result = await easyPostObjectMock.Update(client.Service.UpdateObject<EasyPostObjectMock>, new Dictionary<string, object?>());
        Assert.Equal(MockEnums.UpdateSuccess, result);
        
        // test with implicit Update function
        result = await easyPostObjectMock.InstanceMethodWithData(client.Service.UpdateObject<EasyPostObjectMock>, new Dictionary<string, object?>());
        Assert.Equal(MockEnums.UpdateSuccess, result);
    }
    
    [Fact]
    public async Task TestDeleteInstanceMethod()
    {
        var client = new ClientMock();

        var easyPostObjectMock = new EasyPostObjectMock
        {
            Id = "id",
        };

        // test with explicit Delete function
        await easyPostObjectMock.Delete(client.Service.DeleteObject);
        
        // test with implicit Delete function
        await easyPostObjectMock.InstanceMethod(client.Service.DeleteObject);
    }

    [Fact]
    public async Task TestDummyDataObject()
    {
        var client = new Client("some_api_key"); // We're not going to make a real API call

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

using EasyPost.Extensions.Internal.Exceptions;

namespace EasyPost.Extensions.Test;

public class UnitTests
{
    [Fact]
    public void TestParameterGroups()
    {
        // set all normal required properties
        var parameters = new Parameters.CarrierAccounts.CreateUps
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

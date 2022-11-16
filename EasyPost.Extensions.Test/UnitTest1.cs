using EasyPost._base;

namespace EasyPost.Extensions.Test;

public class UnitTest1
{
    [Fact]
    public void TestParameters()
    {
        // Declare properties via constructor
        // ReSharper disable once UseObjectOrCollectionInitializer
        var shipmentCreateParameters = new Parameters.Addresses.Create
        {
            City = "San Francisco",
            Company = "EasyPost",
        };

        // Add properties after construction (set accessible, not just init)
        shipmentCreateParameters.Name = "John Smith";

        // Can get properties after they're set
        Assert.Equal("John Smith", shipmentCreateParameters.Name);

        // Use the parameters object to make a dictionary
        var dictionary = shipmentCreateParameters.ToDictionary();

        // Pass the dictionary into the method in the EasyPost library
        var client = new Client("my_api_key");
        // var address = client.Address.Create(dictionary); // API call is made here, would fail because key is fake
    }
    
    [Fact]
    public void TestApiUrlBuild()
    {
        var apiVersion = ApiVersion.V2;

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
        var worked = await easyPostObjectMock.Update(client.Service.UpdateObject<EasyPostObjectMock>, new Dictionary<string, object?>());
        Assert.True(worked);
        
        // test with implicit Update function
        worked = await easyPostObjectMock.InstanceMethodWithData(client.Service.UpdateObject<EasyPostObjectMock>, new Dictionary<string, object?>());
        Assert.True(worked);
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
}

public class ServiceMock
{
    public async Task<bool> UpdateObject<T>(string objectId, Dictionary<string, object?> data)
    {
        return true;
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

public class EasyPostObjectMock : EasyPostObject
{
    public new string? Id { get; set; }
}

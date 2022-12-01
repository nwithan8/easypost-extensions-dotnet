using EasyPost._base;

namespace EasyPost.Extensions.Test;

public class UnitTests
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

public class EasyPostObjectMock : EasyPostObject
{
    public new string? Id { get; set; }
}

public class MockEnums : NetTools.Enum
{
    public static readonly MockEnums UpdateSuccess = new MockEnums(1);
    public static readonly MockEnums UpdateFailure = new MockEnums(2);
    public static readonly MockEnums DeleteSuccess = new MockEnums(3);
    public static readonly MockEnums DeleteFailure = new MockEnums(4);
    
    public MockEnums(int value) : base(value)
    {
    }
}

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
}

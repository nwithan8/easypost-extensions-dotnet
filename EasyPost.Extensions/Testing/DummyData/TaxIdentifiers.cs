using EasyPost.Models.API;

namespace EasyPost.Extensions.Testing.DummyData;

/// <summary>
///     Functions for dummy <see cref="TaxIdentifier"/>s.
/// </summary>
public abstract class TaxIdentifiers : DummyDataCreator
{
    public class Entity : NetTools.Common.ValueEnum
    {
        public static readonly Entity Sender = new Entity(1, "SENDER");
        public static readonly Entity Receiver = new Entity(2, "RECEIVER");

        private Entity(int id, string value) : base(id, value)
        {
        }
    }
    
    private static string JsonFile => "assets/dummy_data/tax_identifiers.json";

    /// <summary>
    ///     Create a dummy <see cref="TaxIdentifier"/> parameters set.
    /// </summary>
    /// <param name="entity">The <see cref="Entity"/> the <see cref="TaxIdentifier"/> belongs to.</param>
    /// <returns>A <see cref="Dictionary{TKey,TValue}"/> of parameters representing a tax identifier.</returns>
    public static Dictionary<string, object> CreateTaxIdentifierParameters(Entity entity)
    {
        var data = GetRandomMapsFromJsonFile(JsonFile, 1, true);
        var entityData = data[0];
        entityData["entity"] = entity.Value!;

        return entityData;
    }
}

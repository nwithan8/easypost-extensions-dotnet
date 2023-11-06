// ReSharper disable InconsistentNaming
using System.Globalization;

namespace EasyPost.Extensions.Models;

public class Currency : NetTools.Common.ValueEnum
{
    /// <summary>
    ///     Represents the United States Dollar.
    /// </summary>
    public static readonly Currency USD = new(0, "USD");
    
    private Currency(int id, string abbreviation) : base(id, abbreviation)
    {
    }
}

public class Money
{
    private decimal Amount { get; set; }
    
    private Currency Currency { get; set; }
    
    public Money(decimal amount, Currency? currency = null)
    {
        Amount = amount;
        Currency = currency ?? Currency.USD;
    }
    
    public Money(string amount, Currency? currency = null)
    {
        Amount = decimal.Parse(amount);
        Currency = currency ?? Currency.USD;
    }

    public override string ToString()
    {
        return Amount.ToString(CultureInfo.InvariantCulture);
    }
    
    public static Money? FromString(string? amount, Currency? currency = null)
    {
        return amount == null ? null : new Money(amount, currency);
    }
}

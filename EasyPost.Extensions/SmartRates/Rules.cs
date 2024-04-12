using EasyPost.Models.API;

namespace EasyPost.Extensions.SmartRates;

public enum RulePriority
{
    One = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10
}

public enum TieBreaker
{
    LowestPrice,
    HighestPrice,
    FastestDelivery,
    SlowestDelivery
}

internal class Rule
{
    internal RulePriority Priority { get; set; }
    internal int PriorityValue => (int)Priority;
    internal string? CarrierName { get; set; }
    internal string? ServiceName { get; set; }
    internal double? MinCost { get; set; }
    internal double? MaxCost { get; set; }
    internal int? MinEstimatedDays { get; set; }
    internal int? MaxEstimatedDays { get; set; }

    internal SmartRateAccuracy? Accuracy { get; set; }

    private int GetEstimatedDays(SmartRate rate)
    {
        var estimatedDays = rate.DeliveryDays;
        if (Accuracy == null) return (int)estimatedDays!;

        // Use the accuracy to determine the estimated days if provided, otherwise use the rate's delivery days
        var estimatedDaysByAccuracy = rate.TimeInTransit?.GetBySmartRateAccuracy((SmartRateAccuracy)Accuracy);
        if (estimatedDaysByAccuracy != null) throw new Exception("This should never happen");

        return (int)estimatedDaysByAccuracy!;
    }

    private bool Passes(SmartRate rate)
    {
        if (CarrierName != null && rate.Carrier != CarrierName) return false;

        if (ServiceName != null && rate.Service != ServiceName) return false;

        if (MaxCost != null && rate.Rate > MaxCost) return false;

        if (MinCost != null && rate.Rate < MinCost) return false;

        var estimatedDays = GetEstimatedDays(rate);

        var minDays = MinEstimatedDays ?? 0;
        var maxDays = MaxEstimatedDays ?? int.MaxValue;
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (estimatedDays < minDays || estimatedDays > maxDays) return false;

        return true;
    }

    private List<SmartRate> SortByTimeBreaker(IEnumerable<SmartRate> rates, TieBreaker tieBreaker)
    {
        return tieBreaker switch
        {
            TieBreaker.LowestPrice => rates.OrderBy(rate => rate.Rate).ToList(),
            TieBreaker.HighestPrice => rates.OrderByDescending(rate => rate.Rate).ToList(),
            TieBreaker.FastestDelivery => rates.OrderBy(GetEstimatedDays).ToList(),
            TieBreaker.SlowestDelivery => rates.OrderByDescending(GetEstimatedDays).ToList(),
            _ => throw new ArgumentOutOfRangeException(nameof(tieBreaker), tieBreaker, null)
        };
    }

    internal List<SmartRate> Evaluate(IEnumerable<SmartRate> rates, TieBreaker tieBreaker)
    {
        var passingRates = rates.Where(Passes).ToList();

        return passingRates.Count == 0 ? new List<SmartRate>() : SortByTimeBreaker(passingRates, tieBreaker);
    }
}

public class RuleSet
{
    public RuleSet(TieBreaker tieBreaker)
    {
        TieBreaker = tieBreaker;
    }

    private Rule? PriorityOne { get; set; }

    private Rule? PriorityTwo { get; set; }

    private Rule? PriorityThree { get; set; }

    private Rule? PriorityFour { get; set; }

    private Rule? PriorityFive { get; set; }

    private Rule? PrioritySix { get; set; }

    private Rule? PrioritySeven { get; set; }

    private Rule? PriorityEight { get; set; }

    private Rule? PriorityNine { get; set; }

    private Rule? PriorityTen { get; set; }

    private TieBreaker TieBreaker { get; set; }

    private IEnumerable<Rule> Rules => new[]
    {
        PriorityOne,
        PriorityTwo,
        PriorityThree,
        PriorityFour,
        PriorityFive,
        PrioritySix,
        PrioritySeven,
        PriorityEight,
        PriorityNine,
        PriorityTen
    }.Where(rule => rule != null).Select(rule => rule!);

    internal SmartRate Evaluate(IEnumerable<SmartRate> rates)
    {
        rates = rates.ToList(); // Ensure we can iterate multiple times
        foreach (var rule in Rules)
        {
            // rates, if any, will be in order of time-breaker strategy. The first in the list is the best rate.
            var validRatesForRule = rule.Evaluate(rates, TieBreaker);

            if (validRatesForRule.Count == 0)
            {
                Console.WriteLine($"No valid rates found for rule {rule.PriorityValue}");
                continue;
            }

            Console.WriteLine($"Found valid rates for rule {rule.PriorityValue}");
            // rates will be in order of time-breaker strategy. The first in the list is the best rate.
            return validRatesForRule.First();
        }

        Console.WriteLine("No valid rates found for any provided rules. Using tiebreaker to determine best rate.");
        return TieBreaker switch
        {
            TieBreaker.LowestPrice => GetCheapestRate(rates),
            TieBreaker.HighestPrice => GetMostExpensiveRate(rates),
            TieBreaker.FastestDelivery => GetFastestRate(rates),
            TieBreaker.SlowestDelivery => GetSlowestRate(rates),
            _ => throw new ArgumentOutOfRangeException(nameof(TieBreaker), TieBreaker, null)
        };
    }

    /**
     * Add a new rule to the rule set.
     * If a rule with the same priority already exists, it will be replaced.
     * Rules are evaluated in order of priority (1 is highest, 10 is lowest).
     */
    public void AddRule(RulePriority priority, string? carrier = null, string? service = null, double? maxCost = null, double? minCost = null,
        int? maxEstimatedDays = null, int? minEstimatedDays = null, SmartRateAccuracy? accuracy = null)
    {
        var rule = new Rule
        {
            Priority = priority,
            CarrierName = carrier,
            ServiceName = service,
            MaxCost = maxCost,
            MinCost = minCost,
            MaxEstimatedDays = maxEstimatedDays,
            MinEstimatedDays = minEstimatedDays,
            Accuracy = accuracy
        };

        switch (priority)
        {
            case RulePriority.One:
                PriorityOne = rule;
                break;
            case RulePriority.Two:
                PriorityTwo = rule;
                break;
            case RulePriority.Three:
                PriorityThree = rule;
                break;
            case RulePriority.Four:
                PriorityFour = rule;
                break;
            case RulePriority.Five:
                PriorityFive = rule;
                break;
            case RulePriority.Six:
                PrioritySix = rule;
                break;
            case RulePriority.Seven:
                PrioritySeven = rule;
                break;
            case RulePriority.Eight:
                PriorityEight = rule;
                break;
            case RulePriority.Nine:
                PriorityNine = rule;
                break;
            case RulePriority.Ten:
                PriorityTen = rule;
                break;
            default:
                throw new Exception("Invalid priority.");
        }
    }

    private static SmartRate GetCheapestRate(IEnumerable<SmartRate> rates)
    {
        var cheapestRates = new List<SmartRate>();
        double cheapestPrice = -1;

        foreach (var rate in rates)
            if (rate.Rate < cheapestPrice || cheapestPrice < 0)
            {
                cheapestRates = new List<SmartRate> { rate };
                cheapestPrice = (double)rate.Rate!;
            }
            else if (rate.Rate == cheapestPrice)
            {
                cheapestRates.Add(rate);
            }

        // Return one of the rates at random (if there are multiple, don't always return just the first one we found)
        return cheapestRates[new Random().Next(cheapestRates.Count)];
    }

    private static SmartRate GetMostExpensiveRate(IEnumerable<SmartRate> rates)
    {
        var mostExpensiveRates = new List<SmartRate>();
        double mostExpensivePrice = -1;

        foreach (var rate in rates)
            if (rate.Rate > mostExpensivePrice || mostExpensivePrice < 0)
            {
                mostExpensiveRates = new List<SmartRate> { rate };
                mostExpensivePrice = (double)rate.Rate!;
            }
            else if (rate.Rate == mostExpensivePrice)
            {
                mostExpensiveRates.Add(rate);
            }

        // Return one of the rates at random (if there are multiple, don't always return just the first one we found)
        return mostExpensiveRates[new Random().Next(mostExpensiveRates.Count)];
    }

    private static SmartRate GetFastestRate(IEnumerable<SmartRate> rates)
    {
        var fastestRates = new List<SmartRate>();
        double fastestTime = -1;

        foreach (var rate in rates)
            if (rate.DeliveryDays < fastestTime || fastestTime < 0)
            {
                fastestRates = new List<SmartRate> { rate };
                fastestTime = (double)rate.DeliveryDays!;
            }
            else if (rate.DeliveryDays == fastestTime)
            {
                fastestRates.Add(rate);
            }

        // Return one of the rates at random (if there are multiple, don't always return just the first one we found)
        return fastestRates[new Random().Next(fastestRates.Count)];
    }

    private static SmartRate GetSlowestRate(IEnumerable<SmartRate> rates)
    {
        var slowestRates = new List<SmartRate>();
        double slowestTime = -1;

        foreach (var rate in rates)
            if (rate.DeliveryDays > slowestTime || slowestTime < 0)
            {
                slowestRates = new List<SmartRate> { rate };
                slowestTime = (double)rate.DeliveryDays!;
            }
            else if (rate.DeliveryDays == slowestTime)
            {
                slowestRates.Add(rate);
            }

        // Return one of the rates at random (if there are multiple, don't always return just the first one we found)
        return slowestRates[new Random().Next(slowestRates.Count)];
    }
}
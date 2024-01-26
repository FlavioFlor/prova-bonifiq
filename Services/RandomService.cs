using ProvaPub.Contracts.Services;

namespace ProvaPub.Services;

public sealed class RandomService : IRandomService
{
    private readonly Random _random;

    public RandomService()
    {
        var seed = Guid.NewGuid().GetHashCode();
        _random = new Random(seed);
    }
    public int GetRandom() => _random.Next(100);
}
using csharp.Domain;

namespace csharp.StrategyRepository
{
    public interface IDegradeStrategy
    {
        void Degrade(Item item);
    }
}

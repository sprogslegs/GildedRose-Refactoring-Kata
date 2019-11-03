using csharp.Domain;

namespace csharp.StrategyRepository
{
    public class ConjuredDegradationStrategy : IDegradeStrategy
    {
        public void Degrade(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality -= 4;
            }
            else
            {
                item.Quality -= 2;

            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

        }
    }
}
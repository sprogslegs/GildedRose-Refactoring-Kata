using csharp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.StrategyRepository
{
    public class BackstagePassDegradationStrategy : IDegradeStrategy
    {
        public void Degrade(Item item)
        {

            if (item.SellIn > 10)
            {
                item.Quality++;
            }
            else if (item.SellIn > 5)
            {
                item.Quality += 2;
            }
            else if (item.SellIn <= 5)
            {
                item.Quality += 3;
            }
            else if (item.SellIn < 0)
            {
                item.Quality += 6;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }

        }
    }
}

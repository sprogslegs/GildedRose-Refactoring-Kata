using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class BackstagePassDegradationStrategy : StandardDegrador, IDegradeStrategy
    {
        public override void Degrade(Item item)
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
            
            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}

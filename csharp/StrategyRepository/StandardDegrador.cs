using csharp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.StrategyRepository
{
    public class StandardDegrador : IDegradeStrategy
    {
        public virtual void Degrade(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality -= 2;
            }
            else
            {
                item.Quality--;

            }

            if (item.Quality < 0)
            {
                item.Quality = 0;
            }


        }
    }
}

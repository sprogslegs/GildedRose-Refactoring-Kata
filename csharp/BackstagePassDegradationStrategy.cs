using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class BackstagePassDegradationStrategy : IDegradeStrategy
    {
        public void Degrade(Item item)
        {
            item.Quality++;
        }
    }
}

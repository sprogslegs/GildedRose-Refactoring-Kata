using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp
{
    public class DegradationStrategyFactory
    {
        Dictionary<string, IDegradeStrategy> itemStrategies = new Dictionary<string, IDegradeStrategy>
        {
            ["Brie"] = new BackstagePassDegradationStrategy()

        };

        public IDegradeStrategy Create(Item item)
        {
            var standardDegrador = new StandardDegrador();
            itemStrategies.TryGetValue(item.Name, out IDegradeStrategy strategy);



            return standardDegrador;
        }
    }
}

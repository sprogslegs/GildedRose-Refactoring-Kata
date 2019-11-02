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
            ["Standard"] = new StandardDegrador(),
            ["Backstage"] = new BackstagePassDegradationStrategy(),
            //["Legendary"] = new LegendaryDegrationStrategy()

        };

        Dictionary<string, string> itemNameKeywords = new Dictionary<string, string>
        {
            ["backstage"] = "Backstage",
            ["brie"] = "Backstage",
            //["legendary"] = "Legendary",
            //["conjured"] = "Conjured"

        };

        public IDegradeStrategy GetDegradeStrategy(Item item)
        {
            var itemNickname = GenerateItemNickname(item.Name);
            itemStrategies.TryGetValue(itemNickname, out IDegradeStrategy strategy); 

            return strategy;
        }


        private string GenerateItemNickname(string itemName)
        {
            string nameContains = string.Empty;
            var lowerCaseName = itemName.ToLower();

            // see if you can use LINQ for this?
            foreach (var keyword in itemNameKeywords)
            {
                if (lowerCaseName.Contains(keyword.Key))
                {
                    nameContains = keyword.Value;

                }

            }
            
            switch (nameContains)
            {
                case "Brie":
                    return "Backstage";
                case "Backstage":
                    return "Backstage";
                //case "Legendary":
                //    return "Legendary";
                //case "Conjured":
                //    return "Conjured";
                default:
                    return "Standard";
            }

        }
    }
}

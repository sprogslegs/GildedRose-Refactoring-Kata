using csharp.Domain;
using csharp.Source;
using csharp.StrategyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Source
{
    public class DegradationStrategyFactory
    {
        Dictionary<string, IDegradeStrategy> itemStrategies = new Dictionary<string, IDegradeStrategy>
        {
            ["Standard"] = new StandardDegrador(),
            ["Backstage"] = new BackstagePassDegradationStrategy(),
            ["Conjured"] = new ConjuredDegradationStrategy(),
            ["Legendary"] = new LegendaryDegradationStrategy()

        };

        Dictionary<string, string> itemNameKeywords = new Dictionary<string, string>
        {
            ["backstage"] = "Backstage",
            ["brie"] = "Backstage",
            ["sulfuras"] = "Legendary",
            ["conjured"] = "Conjured"

        };

        public IDegradeStrategy GetDegradeStrategy(Item item)
        {
            var itemNickname = GenerateItemNickname(item.Name);
            itemStrategies.TryGetValue(itemNickname, out IDegradeStrategy strategy); 

            return strategy;
        }


        private string GenerateItemNickname(string itemName)
        {
            var lowerCaseName = itemName.ToLower();
            string nameContains;

            try
            {
                nameContains = itemNameKeywords.FirstOrDefault(keyword => lowerCaseName.Contains(keyword.Key)).Value.ToString();
                
            }
            catch
            {
                nameContains = string.Empty;
            }
            
            
            switch (nameContains)
            {
                case "Brie":
                    return "Backstage";
                case "Backstage":
                    return "Backstage";
                case "Legendary":
                    return "Legendary";
                case "Conjured":
                    return "Conjured";
                default:
                    return "Standard";
            }

        }
    }
}

using csharp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp.Source
{
    public class InventoryUpdater
    {
        private DegradationStrategyFactory strategyFactory;
        public InventoryUpdater()
        {
            strategyFactory = new DegradationStrategyFactory();
        }

        /// <summary>
        /// Update inventory items in a list at the specified frequency (in days).
        /// </summary>
        /// <param name="frequency"></param>
        /// <param name="items"></param>
        public void UpdateInventoryPeriodically(int frequency, IList<Item> items)
        {
            for (int i = 0; i < frequency; i++)
            {
                UpdateInventory(items);
            }



        }
        
        private void UpdateInventory(IList<Item> items)
        {
            foreach (var item in items)
            {
                var itemDegradeStrategy = strategyFactory.GetDegradeStrategy(item);
                itemDegradeStrategy.Degrade(item);
                item.SellIn--;
            }

        }
    }
}

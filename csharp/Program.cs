using csharp.Domain;
using csharp.Source;
using System;
using System.Collections.Generic;

// https://github.com/emilybache/GildedRose-Refactoring-Kata
// http://iamnotmyself.com/2011/02/13/refactor-this-the-gilded-rose-kata/
// https://www.youtube.com/watch?v=8bZh5LMaSmE

namespace csharp
{
    public class Program
    {
        // public static IList<Item> Items { get; private set; }
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var inventory = new Inventory();
            var inventoryUpdater = new InventoryUpdater();

            var itemList = inventory.ItemList;
            inventoryUpdater.UpdateInventoryPeriodically(31, itemList);



            #region Legacy
            //        Items = new List<Item>{
            //            new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
            //            new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
            //            new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
            //            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
            //            new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
            //            new Item
            //            {
            //                Name = "Backstage passes to a TAFKAL80ETC concert",
            //                SellIn = 15,
            //                Quality = 20
            //            },
            //            new Item
            //            {
            //                Name = "Backstage passes to a TAFKAL80ETC concert",
            //                SellIn = 10,
            //                Quality = 49
            //            },
            //            new Item
            //            {
            //                Name = "Backstage passes to a TAFKAL80ETC concert",
            //                SellIn = 5,
            //                Quality = 49
            //            },
            //// this conjured item does not work properly yet
            //new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            //        };

            // var app = new GildedRose(itemList);
            
            //for (var i = 0; i < 31; i++)
            //{
            //    Console.WriteLine("-------- day " + i + " --------");
            //    Console.WriteLine("name, sellIn, quality");
            //    for (var j = 0; j < itemList.Count; j++)
            //    {
            //        System.Console.WriteLine(itemList[j]);
            //    }
            //    Console.WriteLine("");
            //    app.UpdateQuality();
            //}

            #endregion

        }
    }
}

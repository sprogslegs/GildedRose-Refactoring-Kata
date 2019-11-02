using csharp;
using System;
using System.Linq;
using Xunit;

namespace GildedRoseTests
{
    public class UnitTests
    {
        [Fact]
        public void ShouldDecreaseQualityOverTime()
        {

            var item = new Item()
            {
                Quality = 10
            };

            var standardDegrador = new StandardDegrador();

            standardDegrador.Degrade(item);

            Assert.Equal(9, item.Quality);
        }

        // Once the sell by date has passed, Quality degrades twice as fast
        [Fact]
        public void ShouldDecreaseDoubleAfterSellBy()
        {
            var item = new Item
            {
                Quality = 10,
                SellIn = -3
            };            
            
            var standardDegrador = new StandardDegrador();

            standardDegrador.Degrade(item);

            Assert.Equal(8, item.Quality);


        }

        // The Quality of an item is never negative
        [Fact]
        public void QualityShouldNotBeNegative()
        {
            var item = new Item
            {
                Quality = 1,
                SellIn = -1
            };

            var standardDegrador = new StandardDegrador();

            standardDegrador.Degrade(item);

            // if quality is due to go negative, set value as zero
            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData("Aged Brie", 15, 6)]
        [InlineData("Backstage Passes", 10, 7)]
        [InlineData("Aged Brie", 7, 7)]
        [InlineData("Backstage Passes", 5, 8)]
        [InlineData("Backstage Passes", -2, 8)]
        [InlineData("Elixir of Mongoose", 5, 4)] // Regression- quality decrements for non-backstage pass items

        // �Aged Brie� actually increases in Quality the older it gets
        // �Backstage passes�, like aged brie, increases in Quality as it�s SellIn value approaches; 
        // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert
        public void SomeProductsIncreaseInQualityOverTime(string itemName, int sellIn, int expectedQuality)
        {
            var item = new Item()
            {
                Quality = 5,
                Name = itemName,
                SellIn = sellIn
            };
            
            var strategyFactory = new DegradationStrategyFactory();
            var strategy = strategyFactory.GetDegradeStrategy(item);
            strategy.Degrade(item);

            Assert.Equal(expectedQuality, item.Quality);
        }

        // The Quality of an item is never more than 50
        [Fact]
        public void QualityShouldNeverExceedThreshold()
        {
            var item = new Item()
            {
                Quality = 50,
            };

            var degrador = new BackstagePassDegradationStrategy();

            degrador.Degrade(item);

            Assert.Equal(50, item.Quality);

        }
        // �Sulfuras�, being a legendary item, never has to be sold or decreases in Quality
        [Fact]
        public void LegendaryItemsNeverDecreaseInQuality()
        {
            var item = new Item()
            {
                Name = "Sulfuras",
                Quality = 25
            };

            var legendaryDegrador = new LegendaryDegrationStrategy();

            legendaryDegrador.Degrade(item);

            Assert.Equal(25, item.Quality);
        }

        
        // �Conjured� items degrade in Quality twice as fast as normal items
        [Theory]
        [InlineData(8, 5)]
        [InlineData(-3, 3)]
        public void ConjuredItemsDegradeTwiceAsFast(int sellIn, int expectedQuality)
        {
            var item = new Item()
            {
                Name = "Conjured Mana Cake",
                Quality = 7,
                SellIn = sellIn
            };

            var conjuredDegrador = new ConjuredDegradationStrategy();

            conjuredDegrador.Degrade(item);

            Assert.Equal(expectedQuality, item.Quality);
        }

        [Fact]
        // TODO how can I make this test use a Theory?
        //[InlineData("Aged Brie")]
        //[InlineData("Backstage passes to a TAFKAL80ETC concert")]
        //[InlineData("Generic sword")]
        public void DegradationStrategyFactoryReturnsCorrectStrategy()
        {
            var strategyFactory = new DegradationStrategyFactory();
            var item = new Item() { Name = "Aged Brie"};

            var strategy = strategyFactory.GetDegradeStrategy(item);

            Assert.IsType<BackstagePassDegradationStrategy>(strategy);
        }


    }
}

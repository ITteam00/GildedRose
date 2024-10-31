using GildedRose;
using System.Xml.Linq;
using Xunit;
using Xunit.Abstractions;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_OthersItem_DecreasesQualityAndSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(19, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_IncreasesQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_IncreasesQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateQuality();

            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Sulfuras_NoChangeInQualityOrSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 } };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateQuality();

            Assert.Equal(10, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]

        public void UpdateQuality_BackstagePasses_QualityDropsToZeroAfterConcert()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }
        
        [Fact]
        public void UpdateQuality_With_benchmark()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49,
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49,
                },
            };

            var service = new GildedRose.GildedRose(items);


            for (var i = 0; i < 30; i++)
            {
                service.UpdateQuality();
            }

            Assert.Equal("+5 Dexterity Vest", items[0].Name);
            Assert.Equal(-20, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);

            Assert.Equal("Aged Brie", items[1].Name);
            Assert.Equal(-28, items[1].SellIn);
            Assert.Equal(50, items[1].Quality);

            Assert.Equal("Elixir of the Mongoose", items[2].Name);
            Assert.Equal(-25, items[2].SellIn);
            Assert.Equal(0, items[2].Quality);

            Assert.Equal("Sulfuras, Hand of Ragnaros", items[3].Name);
            Assert.Equal(0, items[3].SellIn);
            Assert.Equal(80, items[3].Quality);

            Assert.Equal("Sulfuras, Hand of Ragnaros", items[4].Name);
            Assert.Equal(-1, items[4].SellIn);
            Assert.Equal(80, items[4].Quality);

            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[5].Name);
            Assert.Equal(-15, items[5].SellIn);
            Assert.Equal(0, items[5].Quality);

            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[6].Name);
            Assert.Equal(-20, items[6].SellIn);
            Assert.Equal(0, items[6].Quality);

            Assert.Equal("Backstage passes to a TAFKAL80ETC concert", items[7].Name);
            Assert.Equal(-25, items[7].SellIn);
            Assert.Equal(0, items[7].Quality);
        }
    }
}
using GildedRose;
using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void TestDexterityVest()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(19, items[0].Quality);
        }

        [Fact]
        public void TestAgedBrie()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(1, items[0].SellIn);
            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void TestElixirOfTheMongoose()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void TestSulfuras()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(0, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePasses()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePassesCloseToConcert()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePassesVeryCloseToConcert()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePassesAfterConcert()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void TestAgedBrieAfterSellIn()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void TestNormalItemAfterSellIn()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void TestAgedBrieQualityIncreases()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(1, items[0].SellIn);
            Assert.Equal(1, items[0].Quality);
        }

        [Fact]
        public void TestAgedBrieQualityIncreasesAfterSellIn()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePassesQualityIncreases()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePassesQualityIncreasesCloseToConcert()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 49 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePassesQualityIncreasesVeryCloseToConcert()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 49 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void TestBackstagePassesQualityDropsAfterConcert()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }
    }
}

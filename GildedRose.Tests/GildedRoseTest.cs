using GildedRoseNamespace;
using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void Test()
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

            var app = new GildedRose(items);
            string result = app.GetFormattedText();
            string text = System.IO.File.ReadAllText("sample.approved.txt");
            Console.WriteLine(result);

            Assert.Equal(text, result);
        }

        [Fact]
        public void NormalItem_QualityDecreases()
        {
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(19, items[0].Quality);
            Assert.Equal(9, items[0].SellIn);
        }

        [Fact]
        public void AgedBrie_QualityIncreases()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(1, items[0].Quality);
            Assert.Equal(1, items[0].SellIn);
        }

        [Fact]
        public void Sulfuras_QualityRemainsConstant()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
            Assert.Equal(0, items[0].SellIn);
        }

        [Fact]
        public void BackstagePasses_QualityIncreases()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(21, items[0].Quality);
            Assert.Equal(14, items[0].SellIn);
        }

        [Fact]
        public void BackstagePasses_QualityDropsToZeroAfterConcert()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
            Assert.Equal(-1, items[0].SellIn);
        }

        [Fact]
        public void NormalItem_QualityDecreasesTwiceAsFastAfterSellIn()
        {
            IList<Item> items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(18, items[0].Quality);
            Assert.Equal(-1, items[0].SellIn);
        }

    }
}

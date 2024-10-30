using GildedRose;
using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQualityTest_Day1()
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
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();
            var expectResult = "+5 Dexterity Vest, 9, 19";
            var actualResult = items[0].Name + ", " + items[0].SellIn + ", " + items[0].Quality;
            Assert.Equal(actualResult, expectResult);
        }

        [Fact]
        public void UpdateQualityTest_Day2()
        {
            IList<Item> items = new List<Item>
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 },
                new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 50 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 50 },
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);
            service.UpdateQuality();

            Assert.Equal("+5 Dexterity Vest, 8, 18", $"{items[0].Name}, {items[0].SellIn}, {items[0].Quality}");
            Assert.Equal("Aged Brie, 0, 2", $"{items[1].Name}, {items[1].SellIn}, {items[1].Quality}");
            Assert.Equal("Elixir of the Mongoose, 3, 5", $"{items[2].Name}, {items[2].SellIn}, {items[2].Quality}");
            Assert.Equal("Sulfuras, Hand of Ragnaros, 0, 80", $"{items[3].Name}, {items[3].SellIn}, {items[3].Quality}");
            Assert.Equal("Sulfuras, Hand of Ragnaros, -1, 80", $"{items[4].Name}, {items[4].SellIn}, {items[4].Quality}");
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert, 13, 22", $"{items[5].Name}, {items[5].SellIn}, {items[5].Quality}");
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert, 8, 50", $"{items[6].Name}, {items[6].SellIn}, {items[6].Quality}");
            Assert.Equal("Backstage passes to a TAFKAL80ETC concert, 3, 50", $"{items[7].Name}, {items[7].SellIn}, {items[7].Quality}");
        }

        
        [Fact]
        public void UpdateItem_NormalItem_DecreasesQuality()
        {
            IList<Item> items = new List<Item>
            { new Item { Name = "Normal Item", SellIn = 10, Quality = 20 } };
            Item item =  new Item{
                Name = "Normal Item",
                SellIn = 10,
                Quality = 20
            };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(item);

            Assert.Equal(19, item.Quality);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void Should_add_quality_when_item_is_aged_brie_and_item_quality_less_than_max_quality()
        {
            IList<Item> items = new List<Item>{ };
            Item dummyItem = new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(dummyItem);

            Assert.Equal(21, dummyItem.Quality);
        }

        [Fact]
        public void Should_add_quality_when_item_is_aged_brie_and_item_quality_less_than_max_quality_and_SellIn_less_than_0()
        {
            IList<Item> items = new List<Item> { };
            Item dummyItem = new Item { Name = "Aged Brie", SellIn = -1, Quality = 20 };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(dummyItem);

            Assert.Equal(22, dummyItem.Quality);
        }

        [Fact]
        public void Should_add_quality_when_item_is_Backstage_and_item_quality_less_than_max_quality_and_SellIn_less_than_eleven()
        {
            IList<Item> items = new List<Item> { };
            Item dummyItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(dummyItem);

            Assert.Equal(22, dummyItem.Quality);
        }

        [Fact]
        public void Should_add_quality_when_item_is_Backstage_and_item_quality_less_than_max_quality_and_SellIn_less_than_six()
        {
            IList<Item> items = new List<Item> { };
            Item dummyItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(dummyItem);

            Assert.Equal(23, dummyItem.Quality);
        }

        [Fact]
        public void Should_add_quality_when_item_is_Backstage_and_item_quality_less_than_max_quality_and_SellIn_less_than_0()
        {
            IList<Item> items = new List<Item> { };
            Item dummyItem = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -1, Quality = 20 };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(dummyItem);

            Assert.Equal(0, dummyItem.Quality);
        }

        [Fact]
        public void Should_add_quality_when_item_is_Sulfuras_and_item_quality_bigger_than_min_quality()
        {
            IList<Item> items = new List<Item> { };
            Item dummyItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 20 };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(dummyItem);

            Assert.Equal(20, dummyItem.Quality);
        }

        [Fact]
        public void Should_add_quality_when_item_is_Sulfuras_and_item_quality_bigger_than_min_quality_and_sellin_less_than_0()
        {
            IList<Item> items = new List<Item> { };
            Item dummyItem = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 20 };
            GildedRose.GildedRose service = new GildedRose.GildedRose(items);

            service.UpdateItem(dummyItem);

            Assert.Equal(20, dummyItem.Quality);
        }


    }
}
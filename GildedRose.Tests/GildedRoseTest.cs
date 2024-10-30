using GildedRose;
using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQualityTest()
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
    }
}
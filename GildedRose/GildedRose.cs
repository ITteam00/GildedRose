using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                UpdateItemQuality(item);
                UpdateItemSellIn(item);
                HandleExpiredItem(item);
            }
        }

        private void UpdateItemQuality(Item item)
        {
            if (IsSpecialItem(item))
            {
                IncreaseQuality(item);
                if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    UpdateBackstagePassQuality(item);
                }
            }
            else
            {
                DecreaseQuality(item);
            }
        }

        private void UpdateItemSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn--;
            }
        }

        private void HandleExpiredItem(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Name == "Aged Brie")
                {
                    IncreaseQuality(item);
                }
                else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality = 0;
                }
                else
                {
                    DecreaseQuality(item);
                }
            }
        }

        private bool IsSpecialItem(Item item)
        {
            return item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private void DecreaseQuality(Item item)
        {
            if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.Quality--;
            }
        }

        private void UpdateBackstagePassQuality(Item item)
        {
            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }
            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }
        }

    }
}

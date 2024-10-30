using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        private const int MaxQuality = 50;
        private const int MinQuality = 0;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < items.Count; i++)
            {
                UpdateItem(items[i]);
            }
        }

        public void UpdateItem(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                UpdateQualityForAged(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                UpdateQualityForBackstage(item);
            }
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {

            }
            else
            {
                if (item.Quality > MinQuality)
                {
                    item.Quality = item.Quality - 1;
                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            DecreaseSellIn(item);

        }

        private static void UpdateQualityForBackstage(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality = item.Quality + 1;

                if (item.SellIn < 11)
                {
                    item.Quality = item.Quality + 1;
                }

                if (item.SellIn < 6)
                {
                    item.Quality = item.Quality + 1;

                }
            }
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private static void UpdateQualityForAged(Item item)
        {
            if (item.Quality >= MaxQuality) return;
            item.Quality = item.Quality + 1;

            if (item.SellIn >= 0) return;
            item.Quality = item.Quality + 1;

        }

        private static void DecreaseSellIn(Item item)
        {
            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return;
            }

            item.SellIn = item.SellIn - 1;
        }
    }
}

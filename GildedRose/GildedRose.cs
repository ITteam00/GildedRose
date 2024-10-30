using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        private Dictionary<string, IItemUpdater> updaters;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
            updaters = new Dictionary<string, IItemUpdater>
            {
                { "+5 Dexterity Vest", new NormalItemUpdater() },
                { "Aged Brie", new AgedBrieUpdater() },
                { "Elixir of the Mongoose", new NormalItemUpdater() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassUpdater() }
            };
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                if (item.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue; 
                }
                if (updaters.ContainsKey(item.Name))
                {
                    updaters[item.Name].UpdateQuality(item);
                    updaters[item.Name].UpdateSellIn(item);
                    updaters[item.Name].HandleExpired(item);
                }
            }
        }

        public interface IItemUpdater
        {
            void UpdateQuality(Item item);
            void UpdateSellIn(Item item);
            void HandleExpired(Item item);
        }

        public class NormalItemUpdater : IItemUpdater
        {
            public void UpdateQuality(Item item)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }

            public void UpdateSellIn(Item item)
            {
                item.SellIn--;
            }

            public void HandleExpired(Item item)
            {
                if (item.SellIn < 0 && item.Quality > 0)
                {
                    item.Quality--;
                }
            }
        }

        public class AgedBrieUpdater : IItemUpdater
        {
            public void UpdateQuality(Item item)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                }
            }

            public void UpdateSellIn(Item item)
            {
                item.SellIn--;
            }

            public void HandleExpired(Item item)
            {
                if (item.SellIn < 0 && item.Quality < 50)
                {
                    item.Quality++;
                }
            }
        }

        public class BackstagePassUpdater : IItemUpdater
        {
            public void UpdateQuality(Item item)
            {
                if (item.Quality < 50)
                {
                    item.Quality++;
                    if (item.SellIn < 11 && item.Quality < 50)
                    {
                        item.Quality++;
                    }
                    if (item.SellIn < 6 && item.Quality < 50)
                    {
                        item.Quality++;
                    }
                }
            }

            public void UpdateSellIn(Item item)
            {
                item.SellIn--;
            }

            public void HandleExpired(Item item)
            {
                if (item.SellIn < 0)
                {
                    item.Quality = 0;
                }
            }
        }

    }
}

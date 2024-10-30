using System;
using System.Collections.Generic;

namespace GildedRoseNamespace
{
    public interface IUpdateStrategy
    {
        void Update(Item item);
    }

    public class NormalItemUpdateStrategy : IUpdateStrategy
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public void Update(Item item)
        {
            if (item.Quality > MinQuality)
            {
                item.Quality--;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality > MinQuality)
            {
                item.Quality--;
            }
        }
    }

    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }
    }

    public class BackstagePassUpdateStrategy : IUpdateStrategy
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public void Update(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
                if (item.SellIn < 11 && item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
                if (item.SellIn < 6 && item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = MinQuality;
            }
        }
    }

    public class SulfurasUpdateStrategy : IUpdateStrategy
    {
        public void Update(Item item)
        {
            // Sulfuras does not change
        }
    }

    public class GildedRose
    {
        private IList<Item> items;
        private Dictionary<string, IUpdateStrategy> strategies;

        public GildedRose(IList<Item> items)
        {
            this.items = items;
            strategies = new Dictionary<string, IUpdateStrategy>
            {
                { "Aged Brie", new AgedBrieUpdateStrategy() },
                { "Backstage passes to a TAFKAL80ETC concert", new BackstagePassUpdateStrategy() },
                { "Sulfuras, Hand of Ragnaros", new SulfurasUpdateStrategy() }
            };
        }

        public string GetFormattedText()
        {
            List<string> outputStrArray = new List<string> { "OMGHAI!" };

            for (var i = 0; i < 31; i++)
            {
                outputStrArray.Add("-------- day " + i + " --------");
                outputStrArray.Add("name, sellIn, quality");
                foreach (var item in items)
                {
                    outputStrArray.Add($"{item.Name}, {item.SellIn}, {item.Quality}");
                }
                outputStrArray.Add(string.Empty);
                UpdateQuality();
            }
            return string.Join(Environment.NewLine, outputStrArray);
        }

        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                if (strategies.ContainsKey(item.Name))
                {
                    strategies[item.Name].Update(item);
                }
                else
                {
                    new NormalItemUpdateStrategy().Update(item);
                }
            }
        }
    }

}

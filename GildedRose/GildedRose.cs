using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        private Dictionary<string, IItemUpdater> updaters = new Dictionary<string, IItemUpdater>(); 
        private OtherItemUpdater otherItemUpdater = new OtherItemUpdater();
        public GildedRose(IList<Item> items)
        {
            this.updaters.Add("Aged Brie", new AgedUpdater());
            this.updaters.Add("Backstage passes to a TAFKAL80ETC concert", new BackstageUpdater());
            this.updaters.Add("Sulfuras, Hand of Ragnaros", new SulfurasUpdater());
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
            var updater = updaters.GetValueOrDefault(item.Name, this.otherItemUpdater);
            updater.UpdateItem(item);
            DecreaseSellIn(item);

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

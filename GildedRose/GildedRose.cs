using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        private AgedUpdater agedUpdater = new AgedUpdater();
        private BackstageUpdater backstageUpdater = new BackstageUpdater();
        private SulfurasUpdater sulfurasUpdater =new SulfurasUpdater();
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
                agedUpdater.UpdateItem(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                backstageUpdater.UpdateItem(item);
            }
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                sulfurasUpdater.UpdateItem(item);
            }
            else
            {
                OtherItemUpdater.UpdateQualityForOtherItem(item);
            }
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

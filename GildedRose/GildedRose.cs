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
                var updater=ItemUpdaterSelector.GetUpdater(item);
                updater.Update(item);
            }
        }
    }
}
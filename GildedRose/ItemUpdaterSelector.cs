using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    internal class ItemUpdaterSelector
    {
        public static IUpdater GetUpdater(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgeBrieUpdater(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassUpdater(),
                "Sulfuras, Hand of Ragnaros" => new SurFurasUpdater(),
                _ => new OthersUpdater(),
            };
        }
    }
}

using GildedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    public class ItemFactory
    {
        public static Item CreateItem(string name, int sellIn, int quality)
        {
            switch (name)
            {
                case "Aged Brie":
                    return new AgedBrie(name, sellIn, quality);
                case "Backstage passes to a TAFKAL80ETC concert":
                    return new BackstagePasses(name, sellIn, quality);
                case "Sulfuras, Hand of Ragnaros":
                    return new Sulfuras(name, sellIn, quality);
                case "Conjured Mana Cake":
                    return new ConjuredMC(name, sellIn, quality);
                default:
                    return new StandardItem(name, sellIn, quality);
            }
        }
    }
}

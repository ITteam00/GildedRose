using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models
{
    public class BackstagePasses : Item
    {
        public BackstagePasses(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (SellIn < 0)
            {
                Quality = 0;
            }
            else if (SellIn <= 5)
            {
                Quality = Quality + 3;
            }
            else if (SellIn <= 10)
            {
                Quality = Quality + 2;
            }
            else
            {
                Quality = Quality + 1;
            }

            base.UpdateQuality();
        }
    }
}
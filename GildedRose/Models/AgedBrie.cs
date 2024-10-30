using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models
{
    public class AgedBrie : Item
    {
        public AgedBrie(string name, int sellIn, int quality)
            : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            Quality = Quality + 1;
            base.UpdateQuality();
        }
    }
}
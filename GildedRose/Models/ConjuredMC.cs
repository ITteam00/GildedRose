using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Models
{
    public class ConjuredMC : Item
    {
        public ConjuredMC(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            Quality = Quality - 4;
            base.UpdateQuality();
        }
    }
}
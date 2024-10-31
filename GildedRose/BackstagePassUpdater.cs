using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    internal class BackstagePassUpdater:IUpdater
    {
        public void Update(Item item) {
            item.SellIn--;
            item.increaseQuantity();
            if (item.SellIn < 11)
            {
                item.increaseQuantity();
            }
            if (item.SellIn < 6)
            {
                item.increaseQuantity();
            }


            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }

        }
    }
}

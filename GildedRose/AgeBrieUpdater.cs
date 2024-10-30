using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose
{
    internal class AgeBrieUpdater:IUpdater
    {
        public void Update(Item item) {
            item.SellIn--;
            if (item.Quality < 50)
            {
                item.increaseQuantity();
            }
            if (item.SellIn < 0) {
                item.increaseQuantity();
            }
        }
    }
}

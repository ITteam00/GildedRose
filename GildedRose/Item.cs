using System;
namespace GildedRose
{
    public class Item
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        private const int MAXQUANTITY = 50;
        private const int MINQUANTITY = 0;

        public void increaseQuantity()
        {
            this.Quality= this.Quality+1 <= MAXQUANTITY? this.Quality + 1 : MAXQUANTITY;
        }
        internal void DecrementQuality()
        {
            this.Quality = this.Quality - 1 >= MINQUANTITY ? this.Quality - 1 : MINQUANTITY;
        }

    }


}

using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRoseProgram
    {
        private const int TotalDays = 31;
        public static void Main(string[] args)
        {

            Console.WriteLine("OMGHAI!");

            IList<Item> items = ItemsData.GetItems();

            var app = new GildedRose(items);

            for (var currentDay = 0; currentDay < TotalDays; currentDay++)
            {
                Console.WriteLine("-------- day " + currentDay + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }
                Console.WriteLine(string.Empty);
                app.UpdateQuality();
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> items = new List<Item>
            {
                ItemFactory.CreateItem("+5 Dexterity Vest", 10, 20),
                ItemFactory.CreateItem("Aged Brie", 2, 0),
                ItemFactory.CreateItem("Elixir of the Mongoose", 5, 7),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", 0, 80),
                ItemFactory.CreateItem("Sulfuras, Hand of Ragnaros", -1, 80),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 10, 49),
                ItemFactory.CreateItem("Backstage passes to a TAFKAL80ETC concert", 5, 49),
                ItemFactory.CreateItem("Conjured Mana Cake", 3, 6),
            };

            var app = new GildedRose(items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    System.Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }

                Console.WriteLine(string.Empty);
                app.UpdateQuality();
            }
        }
    }
}
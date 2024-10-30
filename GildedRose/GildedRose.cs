using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        private IList<Item> items;
        public GildedRose(IList<Item> items)
        {
            this.items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to a TAFKAL80ETC concert" && items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    if (items[i].Quality > 0)
                    {
                        items[i].Quality--;
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality++;

                        if (items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].SellIn < 11)
                            {
                                    items[i].Quality++;
                            }

                            if (items[i].SellIn < 6)
                            {
                                    items[i].Quality ++;
                            }
                        }
                    }
                }

                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    items[i].SellIn--;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (items[i].Quality > 0)
                        {
                            if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                            {
                                items[i].Quality = items[i].Quality - 1;
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}

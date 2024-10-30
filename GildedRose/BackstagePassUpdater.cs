namespace GildedRose
{
    public class BackstagePassUpdater : IItemUpdater
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
                IncreaseQualityIfSellInLessThan(item, 11);
                IncreaseQualityIfSellInLessThan(item, 6);
            }
        }

        private void IncreaseQualityIfSellInLessThan(Item item, int threshold)
        {
            if (item.SellIn < threshold && item.Quality < 50)
            {
                item.Quality++;
            }
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        public void HandleExpired(Item item)
        {
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }
    }
}

namespace GildedRose
{
    public class BackstagePassUpdater : IItemUpdater
    {
        private const int MaxQuality = 50;

        public void UpdateQuality(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
                IncreaseQualityIfSellInLessThan(item, 11);
                IncreaseQualityIfSellInLessThan(item, 6);
            }
        }

        private void IncreaseQualityIfSellInLessThan(Item item, int threshold)
        {
            if (item.SellIn < threshold && item.Quality < MaxQuality)
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

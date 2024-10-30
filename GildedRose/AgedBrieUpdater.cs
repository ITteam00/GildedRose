namespace GildedRose
{
    public class AgedBrieUpdater : IItemUpdater
    {
        private const int MaxQuality = 50;

        public void UpdateQuality(Item item)
        {
            if (item.Quality < MaxQuality)
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
            if (item.SellIn < 0 && item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }
    }
}

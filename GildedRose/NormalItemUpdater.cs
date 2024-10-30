namespace GildedRose
{
    public class NormalItemUpdater : IItemUpdater
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        public void UpdateSellIn(Item item)
        {
            item.SellIn--;
        }

        public void HandleExpired(Item item)
        {
            if (item.SellIn < 0 && item.Quality > 0)
            {
                item.Quality--;
            }
        }
    }
}

namespace GildedRose
{
    internal class BackstageUpdater : IItemUpdater
    {
        private const int MaxQuality = 50;
        public void UpdateItem(Item item)
        {
            if (item.Quality >= MaxQuality) return;

            item.Quality = item.Quality + 1;

            if (item.SellIn < 11)
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn < 6)
            {
                item.Quality = item.Quality + 1;

            }
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }
    }
}
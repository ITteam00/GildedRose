namespace GildedRose
{
    internal static class BackstageUpdater
    {
        private const int MaxQuality = 50;
        public static void UpdateQualityForBackstage(Item item)
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
namespace GildedRose
{
    internal static class AgedUpdater
    {
        private const int MaxQuality = 50;

        public static void UpdateQualityForAged(Item item)
        {
            if (item.Quality >= MaxQuality) return;
            item.Quality = item.Quality + 1;

            if (item.SellIn >= 0) return;
            item.Quality = item.Quality + 1;

        }
    }
}
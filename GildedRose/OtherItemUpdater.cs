namespace GildedRose
{
    internal static class OtherItemUpdater
    {
        private const int MinQuality = 0;
        public static void UpdateQualityForOtherItem(Item item)
        {
            if (item.Quality <= MinQuality) return;
            item.Quality = item.Quality - 1;
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - 1;
            }
        }
    }
}
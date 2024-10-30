namespace GildedRose
{
    internal class AgedUpdater : IItemUpdater
    {
        private const int MaxQuality = 50;

        public void UpdateItem(Item item)
        {
            if (item.Quality >= MaxQuality) return;
            item.Quality = item.Quality + 1;

            if (item.SellIn >= 0) return;
            item.Quality = item.Quality + 1;

        }
    }
}
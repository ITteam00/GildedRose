namespace GildedRose
{
    internal class OtherItemUpdater : IItemUpdater
    {
        private const int MinQuality = 0;
        public void UpdateItem(Item item)
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
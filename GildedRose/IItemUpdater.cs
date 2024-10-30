namespace GildedRose
{
    public interface IItemUpdater
    {
        void UpdateQuality(Item item);
        void UpdateSellIn(Item item);
        void HandleExpired(Item item);
    }
}

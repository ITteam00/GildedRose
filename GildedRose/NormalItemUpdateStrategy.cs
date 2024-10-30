namespace GildedRoseNamespace
{
    public class NormalItemUpdateStrategy : IUpdateStrategy
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public void Update(Item item)
        {
            if (item.Quality > MinQuality)
            {
                item.Quality--;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality > MinQuality)
            {
                item.Quality--;
            }
        }
    }

}

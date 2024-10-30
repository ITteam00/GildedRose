namespace GildedRoseNamespace
{
    public class AgedBrieUpdateStrategy : IUpdateStrategy
    {
        private const int MaxQuality = 50;

        public void Update(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
            }
            item.SellIn--;
            if (item.SellIn < 0 && item.Quality < MaxQuality)
            {
                item.Quality++;
            }
        }
    }

}

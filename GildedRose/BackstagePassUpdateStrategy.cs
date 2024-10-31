namespace GildedRoseNamespace
{
    public class BackstagePassUpdateStrategy : IUpdateStrategy
    {
        private const int MaxQuality = 50;
        private const int MinQuality = 0;

        public void Update(Item item)
        {
            if (item.Quality < MaxQuality)
            {
                item.Quality++;
                if (item.SellIn < 11 && item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
                if (item.SellIn < 6 && item.Quality < MaxQuality)
                {
                    item.Quality++;
                }
            }
            item.SellIn--;
            if (item.SellIn < 0)
            {
                item.Quality = MinQuality;
            }
        }
    }

}

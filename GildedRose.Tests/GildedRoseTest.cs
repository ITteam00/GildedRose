using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void Test()
        {
            string text = System.IO.File.ReadAllText("C://Users//YYu26//Source//Repos//GildedRose//GildedRose.Tests//sample.approved.txt");

            Assert.Equal("Approved result", text);

        }
    }
}

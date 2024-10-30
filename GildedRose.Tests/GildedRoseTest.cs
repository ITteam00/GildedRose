using Xunit;

namespace GildedRoseTest
{
    public class GildedRoseTest
    {
        [Fact]
        public void Test()
        {
            string text = System.IO.File.ReadAllText("sample.approved.txt");

            Assert.Equal("Approved result", text);
        }
    }
}

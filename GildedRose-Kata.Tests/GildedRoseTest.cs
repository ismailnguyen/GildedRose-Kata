using NFluent;
using NUnit.Framework;

namespace GildedRose_Kata.Tests
{
    public class GildedRoseTest
    {
        [TestCase(23, 17, 22, 16)]
        [TestCase(-1, 17, -2, 15)]
        public void Should_Update_Quality_Of_Axe_Item(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // GIVEN
            var item = new NormalItem("Axe", sellIn, quality);

            var gildedRose = new GildedRose(item);

            // WHEN
            var resultItem = gildedRose.UpdateQuality();

            // THEN
            Check.That(resultItem.SellIn).IsEqualTo(expectedSellIn);
            Check.That(resultItem.Quality).IsEqualTo(expectedQuality);
        }

        [TestCase(10, 17, 9, 15)]
        [TestCase(-2, 23, -3, 19)]
        public void Should_Update_Quality_Of_Conjured_Item(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // GIVEN
            var conjuredItem = new ConjuredItem(sellIn, quality);

            var gildedRose = new GildedRose(conjuredItem);

            // WHEN
            var resultConjuredItem = gildedRose.UpdateQuality();

            // THEN
            Check.That(resultConjuredItem.SellIn).IsEqualTo(expectedSellIn);
            Check.That(resultConjuredItem.Quality).IsEqualTo(expectedQuality);
        }

        [TestCase(23, 21, 22, 22)]
        [TestCase(-1, 17, -2, 19)]
        public void Should_Update_Quality_Of_Aged_Brie_Item(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // GIVEN
            var agedBrieItem = new AgedBrieItem(sellIn, quality);

            var gildedRose = new GildedRose(agedBrieItem);

            // WHEN
            var resultAgedBrieItem = gildedRose.UpdateQuality();

            // THEN
            Check.That(resultAgedBrieItem.SellIn).IsEqualTo(expectedSellIn);
            Check.That(resultAgedBrieItem.Quality).IsEqualTo(expectedQuality);
        }

        [TestCase(23, 21, 22, 22)]
        [TestCase(10, 21, 9, 23)]
        [TestCase( 5, 21, 4, 24)]
        [TestCase(-1, 17, -2, 0)]
        public void Should_Update_Quality_Of_Backstage_Item(int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // GIVEN
            var backstageItem = new BackstageItem(sellIn, quality);

            var gildedRose = new GildedRose(backstageItem);

            // WHEN
            var resultBackstageItem = gildedRose.UpdateQuality();

            // THEN
            Check.That(resultBackstageItem.SellIn).IsEqualTo(expectedSellIn);
            Check.That(resultBackstageItem.Quality).IsEqualTo(expectedQuality);
        }
    }
}

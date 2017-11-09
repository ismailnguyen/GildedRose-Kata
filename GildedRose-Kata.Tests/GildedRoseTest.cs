using NFluent;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose_Kata.Tests
{
    public class GildedRoseTest
    {
        [TestCase("Axe", 23, 17, 22, 16)]
        [TestCase("Aged Brie", 23, 21, 22, 22)]
        [TestCase("Backstage passes to a TAFKAL80ETC concerts", 23, 21, 22, 20)]
        public void Should(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // GIVEN
            Item axe = new Item()
            {
                Name = name,
                SellIn = sellIn,
                Quality = quality
            };

            GildedRose ap = new GildedRose(new List<Item> { axe });

            // WHEN
            ap.UpdateQuality();

            // THEN
            Check.That(axe.SellIn).IsEqualTo(expectedSellIn);
            Check.That(axe.Quality).IsEqualTo(expectedQuality);
        }
    }
}

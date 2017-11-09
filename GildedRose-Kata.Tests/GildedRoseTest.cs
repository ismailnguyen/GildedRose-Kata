using NFluent;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose_Kata.Tests
{
    public class GildedRoseTest
    {
        [TestCase("Axe", 23, 17)]
        //[TestCase("Aged Brie", 23, 21)]
        public void Should(string name, int sellIn, int quality)
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
            Check.That(axe.SellIn).IsEqualTo(22);
            Check.That(axe.Quality).IsEqualTo(16);
        }
    }
}

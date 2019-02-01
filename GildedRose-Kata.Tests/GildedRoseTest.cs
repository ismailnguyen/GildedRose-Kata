﻿using NFluent;
using NUnit.Framework;

namespace GildedRose_Kata.Tests
{
    public class GildedRoseTest
    {
        [TestCase("Axe", 23, 17, 22, 16)]
        [TestCase("Aged Brie", 23, 21, 22, 22)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 23, 21, 22, 22)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 10, 21, 9, 23)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 5, 21, 4, 24)]
        [TestCase("Axe", -1, 17, -2, 15)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", -1, 17, -2, 0)]
        [TestCase("Aged Brie", -1, 17, -2, 19)]
        public void Should(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            // GIVEN
            var item = new Item(name, sellIn, quality);

            var gildedRose = new GildedRose(item);

            // WHEN
            gildedRose.UpdateQuality();

            // THEN
            Check.That(item.SellIn).IsEqualTo(expectedSellIn);
            Check.That(item.Quality).IsEqualTo(expectedQuality);
        }
    }
}

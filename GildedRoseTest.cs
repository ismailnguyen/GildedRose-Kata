using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void Given_SellIn_And_Quality_When_UpdateQuality_Then_Both_Decrease()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 1,
                    Quality = 1
                }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void Given_SellIn_And_Quality_Zero_When_UpdateQuality_Then_SellIn_Decrease_By_1_And_Quality_Is_Zero()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = 0
                }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void Given_SellIn_Zero_And_Quality_Less_Than_2_When_UpdateQuality_Then_SellIn_Decrease_By_1_And_Quality_Is_Zero()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "foo",
                    SellIn = 0,
                    Quality = 1
                },
                new Item
                {
                    Name = "bar",
                    SellIn = 0,
                    Quality = 2
                },
                new Item
                {
                    Name = "toto",
                    SellIn = 0,
                    Quality = 3
                }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual("foo", Items[0].Name);
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);

            Assert.AreEqual("bar", Items[1].Name);
            Assert.AreEqual(-1, Items[1].SellIn);
            Assert.AreEqual(0, Items[1].Quality);

            Assert.AreEqual("toto", Items[2].Name);
            Assert.AreEqual(-1, Items[2].SellIn);
            Assert.AreEqual(1, Items[2].Quality);
        }

        [Test]
        public void Given_Aged_Brie_When_UpdateQuality_Then_Quality_Increase_And_SellIn_Decrease()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = 1
                },
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 0,
                    Quality = 1
                }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(2, Items[0].Quality);

            Assert.AreEqual(-1, Items[1].SellIn);
            Assert.AreEqual(3, Items[1].Quality);
        }

        [Test]
        public void Given_Quality_50_When_Quality_Shoud_Increase_Then_Quality_Is_Still_50()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 1,
                    Quality = 50
                }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void Given_Sulfuras_When_UpdateQuality_Then_SellIn_And_Quality_No_Change()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80}
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(80, Items[0].Quality);

            Assert.AreEqual(-1, Items[1].SellIn);
            Assert.AreEqual(80, Items[1].Quality);
        }

        [Test]
        public void Given_Backstage_When_UpdateQuality_Then_SellIn_And_Quality_Updated()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 0,
                    Quality = 49
                }
            };
            IList<Item> ExpectedItems = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 14,
                    Quality = 21
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 14,
                    Quality = 50
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 50
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 22
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 4,
                    Quality = 50
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 4,
                    Quality = 23
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = -1,
                    Quality = 0
                }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            for (var i = 0; i < Items.Count; i++)
            {
                Assert.AreEqual(ExpectedItems[i].SellIn, Items[i].SellIn);
                Assert.AreEqual(ExpectedItems[i].Quality, Items[i].Quality);
            }
        }

        [Test]
        public void Given_Conjured_When_UpdateQuality_Then_Quality_Decrease_Twice()
        {
            IList<Item> Items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 1,
                    Quality = 50
                },
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 50
                },
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 1,
                    Quality = 1
                },
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 0,
                    Quality = 1
                }
            };

            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Assert.AreEqual(0, Items[0].SellIn);
            Assert.AreEqual(48, Items[0].Quality);

            Assert.AreEqual(-1, Items[1].SellIn);
            Assert.AreEqual(46, Items[1].Quality);

            Assert.AreEqual(0, Items[2].SellIn);
            Assert.AreEqual(0, Items[2].Quality);

            Assert.AreEqual(-1, Items[3].SellIn);
            Assert.AreEqual(0, Items[3].Quality);
        }
    }
}

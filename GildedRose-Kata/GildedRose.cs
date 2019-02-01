using System.Collections.Generic;

namespace GildedRose_Kata
{
    public class GildedRose
    {
        private readonly IList<Item> _items;

        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string BackstageItemName = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrieItemName = "Aged Brie";

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name != AgedBrieItemName && _items[i].Name != BackstageItemName)
                {
                    if (_items[i].Quality > 0)
                    {
                        if (_items[i].Name != SulfurasItemName)
                        {
                            _items[i].Quality--;
                        }
                    }
                }
                else
                {
                    if (_items[i].Quality < 50)
                    {
                        _items[i].Quality++;

                        if (_items[i].Name == BackstageItemName)
                        {
                            if (_items[i].SellIn < 11)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality++;
                                }
                            }

                            if (_items[i].SellIn < 6)
                            {
                                if (_items[i].Quality < 50)
                                {
                                    _items[i].Quality++;
                                }
                            }
                        }
                    }
                }

                if (_items[i].Name != SulfurasItemName)
                {
                    _items[i].SellIn--;
                }

                if (_items[i].SellIn < 0)
                {
                    if (_items[i].Name != AgedBrieItemName)
                    {
                        if (_items[i].Name != BackstageItemName)
                        {
                            if (_items[i].Quality > 0)
                            {
                                if (_items[i].Name != SulfurasItemName)
                                {
                                    _items[i].Quality--;
                                }
                            }
                        }
                        else
                        {
                            _items[i].Quality = 0;
                        }
                    }
                    else
                    {
                        if (_items[i].Quality < 50)
                        {
                            _items[i].Quality++;
                        }
                    }
                }
            }
        }

    }

    
}

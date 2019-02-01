using System;
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
                if (_items[i].Name == BackstageItemName)
                {
                    UpdateQualityBackstage(_items[i]);
                }
                else if (_items[i].Name == AgedBrieItemName)
                {
                    UpdateQualityAgedBrie(_items[i]);
                }
                else if (_items[i].Quality > 0 && _items[i].Name != SulfurasItemName)
                {
                    _items[i].ReduceQuality();
                }

                if (_items[i].Name != SulfurasItemName)
                {
                    _items[i].ReduceSellIn();
                }

                if (_items[i].SellIn < 0)
                {
                    if (_items[i].Name == AgedBrieItemName)
                    {
                        if (_items[i].Quality < 50 && _items[i].SellIn < 0)
                        _items[i].RaiseQuality();
                    }
                    else
                    {
                        if (_items[i].Name != BackstageItemName && _items[i].Quality > 0 && _items[i].Name != SulfurasItemName)
                        {
                            _items[i].ReduceQuality();
                        }
                        else
                        {
                            _items[i].ResetQuality();
                        }
                    }
                }
            }
        }

        private void UpdateQualityAgedBrie(Item item)
        {
            if (item.Quality < 50)
            {
                item.RaiseQuality();
            }
        }

        private void UpdateQualityBackstage(Item item)
        {
            if (item.Quality >= 50)
                return;

            item.RaiseQuality();

            if (item.SellIn < 11)
            {
                item.RaiseQuality();
            }

            if (item.SellIn < 6)
            {
                item.RaiseQuality();
            }

        }
    }
}

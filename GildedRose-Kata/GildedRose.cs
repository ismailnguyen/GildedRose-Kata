namespace GildedRose_Kata
{
    public class GildedRose
    {
        private readonly Item _item;

        private const string SulfurasItemName = "Sulfuras, Hand of Ragnaros";
        private const string BackstageItemName = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrieItemName = "Aged Brie";

        public GildedRose(Item item)
        {
            _item = item;
        }

        public void UpdateQuality()
        {
            if (_item.Name == BackstageItemName)
            {
                UpdateQualityBackstage(_item);
            }
            else if (_item.Name == AgedBrieItemName)
            {
                UpdateQualityAgedBrie(_item);
            }
            else if (_item.Quality > 0 && _item.Name != SulfurasItemName)
            {
                _item.ReduceQuality();
            }

            if (_item.Name != SulfurasItemName)
            {
                _item.ReduceSellIn();
            }

            if (_item.SellIn < 0)
            {
                if (_item.Name == AgedBrieItemName)
                {
                    if (_item.Quality < 50 && _item.SellIn < 0)
                        _item.RaiseQuality();
                }
                else
                {
                    if (_item.Name != BackstageItemName && _item.Quality > 0 && _item.Name != SulfurasItemName)
                    {
                        _item.ReduceQuality();
                    }
                    else
                    {
                        _item.ResetQuality();
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

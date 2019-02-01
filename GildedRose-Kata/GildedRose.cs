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
                UpdateBackstageQuality();
            }
            else if (_item.Name == AgedBrieItemName)
            {
                UpdateAgedBrieQuality();
            }
            else if (_item.Quality > 0 && _item.Name != SulfurasItemName)
            {
                UpdateNormalItemQuality();
            }

            if (_item.Name != SulfurasItemName && _item.Name != BackstageItemName  && _item.Name != AgedBrieItemName)
            {
                _item.ReduceSellIn();
            }

            if (_item.SellIn < 0 && _item.Quality > 0
                && _item.Name != AgedBrieItemName &&  _item.Name != BackstageItemName && _item.Name != SulfurasItemName)
            {
                _item.ReduceQuality();
            }
        }

        private void UpdateNormalItemQuality()
        {
            if (_item.Quality > 0 && _item.Name != SulfurasItemName)
            {
                _item.ReduceQuality();
            }
        }

        private void UpdateAgedBrieQuality()
        {
            if (_item.Quality < 50)
            {
                _item.RaiseQuality();
            }

            _item.ReduceSellIn();

            if (_item.Quality < 50 && _item.SellIn < 0)
                _item.RaiseQuality();
        }

        private void UpdateBackstageQuality()
        {
            if (_item.Quality < 50)
            {
                _item.RaiseQuality();

                if (_item.SellIn < 11)
                {
                    _item.RaiseQuality();
                }

                if (_item.SellIn < 6)
                {
                    _item.RaiseQuality();
                }
            }

            _item.ReduceSellIn();

            if (_item.SellIn < 0)
            {
                _item.ResetQuality();
            }
        }
    }
}

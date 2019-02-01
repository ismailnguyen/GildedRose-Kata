namespace GildedRose_Kata
{
    public class GildedRose
    {
        private readonly Item _item;

        private const string BackstageItemName = "Backstage passes to a TAFKAL80ETC concert";
        private const string AgedBrieItemName = "Aged Brie";

        public GildedRose(Item item)
        {
            _item = item;
        }

        public void UpdateQuality()
        {
            switch (_item.Name)
            {
                case BackstageItemName:
                    UpdateBackstageQuality();
                    break;
                case AgedBrieItemName:
                    UpdateAgedBrieQuality();
                    break;
                default:
                    _item.UpdateQuality();
                    break;
            }
        }

        private void UpdateAgedBrieQuality()
        {
            if (_item.Quality < 50)
            {
                _item.RaiseQuality();
            }

            _item.ReduceSellIn();

            if (_item.SellIn < 0)
            {
                _item.RaiseQuality();
            }
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

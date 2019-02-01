namespace GildedRose_Kata
{
    public class BackstageItem : Item
    {
        public BackstageItem(int sellIn, int quality) 
            : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                RaiseQuality();

                if (SellIn < 11)
                {
                    RaiseQuality();
                }

                if (SellIn < 6)
                {
                    RaiseQuality();
                }
            }

            ReduceSellIn();

            if (SellIn < 0)
            {
                ResetQuality();
            }
        }
    }
}

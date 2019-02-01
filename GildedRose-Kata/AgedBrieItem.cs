namespace GildedRose_Kata
{
    public class AgedBrieItem : Item
    {
        public AgedBrieItem(int sellIn, int quality) 
            : base("Aged Brie", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                RaiseQuality();
            }

            ReduceSellIn();

            if (SellIn < 0)
            {
                RaiseQuality();
            }
        }
    }
}

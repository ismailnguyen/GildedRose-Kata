namespace GildedRose_Kata
{
    public class ConjuredItem : Item
    {
        public ConjuredItem(int sellIn, int quality) : base("Conjured", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                ReduceQuality();
                ReduceQuality();
            }

            ReduceSellIn();

            if (SellIn < 0)
            {
                ReduceQuality();
                ReduceQuality();
            }
        }
    }
}

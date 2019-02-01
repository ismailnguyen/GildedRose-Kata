namespace GildedRose_Kata
{
    public class NormalItem : Item
    {
        public NormalItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                ReduceQuality();
            }

            ReduceSellIn();

            if (SellIn < 0)
            {
                ReduceQuality();
            }
        }
    }
}

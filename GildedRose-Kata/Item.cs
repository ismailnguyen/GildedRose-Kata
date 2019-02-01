namespace GildedRose_Kata
{
    public class Item
    {
        public string Name { get; private set; }

        public int SellIn { get; private set; }

        public int Quality { get; private set; }

        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void ReduceQuality()
        {
            Quality--;
        }

        public void RaiseQuality()
        {
            Quality++;
        }

        public void ResetQuality()
        {
            Quality = 0;
        }

        public void ReduceSellIn()
        {
            SellIn--;
        }
    }
}

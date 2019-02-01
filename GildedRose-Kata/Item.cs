namespace GildedRose_Kata
{
    public abstract class Item
    {
        public string Name { get; private set; }
        public int SellIn { get; private set; }
        public int Quality { get; private set; }

        protected Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public abstract void UpdateQuality();

        protected void ReduceQuality()
        {
            Quality--;
        }

        protected void RaiseQuality()
        {
            Quality++;
        }

        protected void ResetQuality()
        {
            Quality = 0;
        }

        protected void ReduceSellIn()
        {
            SellIn--;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

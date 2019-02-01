namespace GildedRose_Kata
{
    public class GildedRose
    {
        private readonly Item _item;

        public GildedRose(Item item)
        {
            _item = item;
        }

        public Item UpdateQuality()
        {
            _item.UpdateQuality();

            return _item;
        }
    }
}

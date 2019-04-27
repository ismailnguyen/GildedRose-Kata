using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateQuality(Items[i]);
                UpdateSellIn(Items[i]);
            }
        }

        private void UpdateSellIn(Item item)
        {
            if (item.Name.StartsWith("Sulfuras"))
            {
                return;
            }
            else
            { 
                item.SellIn--;
            }
        }

        private void UpdateQuality(Item item)
        {
            if (item.Name.StartsWith("Aged Brie"))
            {
                UpdateBrie(item);
            }
            else if (item.Name.StartsWith("Sulfuras"))
            {
                return;
            }
            else if (item.Name.StartsWith("Backstage"))
            {
                UpdateBackstage(item);
            }
            else if (item.Name.StartsWith("Conjured"))
            {
                UpdateConjured(item);
            }
            else
            {
                UpdateAsDefault(item);
            }
        }

        private void UpdateConjured(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality = Math.Max(item.Quality - 2, 0);
            }
            else
            {
                item.Quality = Math.Max(item.Quality -4, 0);
            }
        }

        private void UpdateBackstage(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality = Math.Min(item.Quality + 1, 50);
            }
            else if (item.SellIn > 5 && item.SellIn <= 10)
            {
                item.Quality = Math.Min(item.Quality + 2, 50);
            }
            else if (item.SellIn > 0 && item.SellIn <= 5)
            {
                item.Quality = Math.Min(item.Quality + 3, 50);
            }
            else if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
        }

        private void UpdateBrie(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = Math.Min(item.Quality + 2, 50);
            }
            else
            {
                item.Quality = Math.Min(item.Quality + 1, 50);
            }
        }

        private void UpdateAsDefault(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = Math.Max(item.Quality - 2, 0);
            }
            else
            {
                item.Quality = Math.Max(item.Quality - 1, 0);
            }
        }
    }
}

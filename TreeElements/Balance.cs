using System.Collections.Generic;

namespace TreeElements
{
    public class Balance
    {
        public Balance(List<Item> items)
        {
            this.Items = items;
        }

        public List<Item> Items { get; }
    }
}
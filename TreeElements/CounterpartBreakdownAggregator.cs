using System;
using System.Collections.Generic;

namespace TreeElements
{
    public class CounterpartBreakdownAggregator : DetailBreakdownBase
    {
        public CounterpartBreakdownAggregator(IBreakdownAggregator secondAggregator)
            : base(secondAggregator)
        {
        }

        public override List<Func<Item, string>> GetAggregationKeys()
        {
            return new List<Func<Item, string>>
            {
                item => item.Group[0],
                item => item.Group[1],
                item => item.Category,
                item => item.Code
            };
        }
    }
}

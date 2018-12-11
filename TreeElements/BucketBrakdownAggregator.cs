using System;
using System.Collections.Generic;

namespace TreeElements
{
    public class BucketBrakdownAggregator : DetailBreakdownBase
    {
        public BucketBrakdownAggregator(IBreakdownAggregator secondAggregator)
            : base(secondAggregator)
        {
        }

        public override List<Func<Item, string>> GetAggregationKeys()
        {
            return new List<Func<Item, string>> { item => item.Bucket};
        }
    }
}

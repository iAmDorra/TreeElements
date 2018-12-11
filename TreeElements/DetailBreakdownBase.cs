using System;
using System.Collections.Generic;
using System.Linq;

namespace TreeElements
{
    public interface IBreakdownAggregator
    {
        List<AggregatedRow> GetAggregatedRow(Balance balance);
        List<AggregatedCell> GetAggregatedCells(List<Item> items);
        List<Func<Item, string>> GetAggregationKeys();
    }
    public abstract class DetailBreakdownBase : IBreakdownAggregator
    {
        private readonly IBreakdownAggregator _secondAggregator;
        public DetailBreakdownBase(IBreakdownAggregator secondAggregator)
        {
            this._secondAggregator = secondAggregator;
        }

        public List<AggregatedCell> GetAggregatedCells(List<Item> items)
        {
            List<AggregatedCell> cells = new List<AggregatedCell>();
            if(items == null || items.Count == 0)
            {
                return cells;
            }

            var axe = GetAggregationKeys();
            var groups = items.GroupBy(axe[0]);
            foreach (var group in groups)
            {
                var sideGroups = group.GroupBy(g => g.Side);
                cells.AddRange(
                    sideGroups.Select(sideGroup =>
                    new AggregatedCell
                    {
                        Side = sideGroup.Key.Substring(0, 1),
                        Column = group.Key,
                        Value = sideGroup.Sum(g => Math.Abs(g.Amount))
                    }));
            }
            return cells;
        }

        public List<AggregatedRow> GetAggregatedRow(Balance balance)
        {
            if (balance?.Items == null)
            {
                return new List<AggregatedRow>();
            }

            var aggregatedRows = new List<AggregatedRow>();
            var aggregationKeys = GetAggregationKeys();
            var items = balance.Items;
            List<string> rowAxes = new List<string>();
            GroupByAxe(aggregatedRows, items, rowAxes, aggregationKeys, 0);
            return aggregatedRows;

        }

        private void GroupByAxe(List<AggregatedRow> aggregatedRows, List<Item> items, List<string> rowAxes, List<Func<Item, string>> axes, int index)
        {
            if (index >= axes.Count)
            {
                GroupBySecondAggregation(aggregatedRows, rowAxes, items);
                return;
            }

            var groups = items.GroupBy(axes[index]);
            foreach (var group in groups)
            {
                rowAxes.Add(group.Key);
                GroupByAxe(aggregatedRows, group.ToList(), rowAxes, axes, index + 1);
                rowAxes.Remove(group.Key);
            }
        }

        private void GroupBySecondAggregation(List<AggregatedRow> aggregatedRows, List<string> axes, List<Item> elements)
        {
            var row = new AggregatedRow();
            row.RowHeaders.AddRange(axes);
            if (_secondAggregator == null)
            {
                return;
            }
            row.Cells.AddRange(_secondAggregator.GetAggregatedCells(elements));
            aggregatedRows.Add(row);
        }

        public abstract List<Func<Item, string>> GetAggregationKeys();
    }
}

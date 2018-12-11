using System.Collections.Generic;

namespace TreeElements
{
    public class AggregatedRow
    {
        public AggregatedRow()
        {
            RowHeaders = new List<string>();
            SubRows = new List<AggregatedRow>();
            Cells = new List<AggregatedCell>();
        }
        public List<string> RowHeaders { get; private set; }
        public List<AggregatedRow> SubRows { get; private set; }
        public List<AggregatedCell> Cells { get; private set; }
    }
}
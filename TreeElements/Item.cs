using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeElements
{
    public class Item
    {
        public string Side { get; set; }
        public string Bucket { get; set; }
        public double Amount { get; set; }

        public List<string> Group { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
    }
}

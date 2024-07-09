using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Models
{
    public class TaxProEwayItemList
    {
        public string productName { get; set; }
        public string productDesc { get; set; }
        public int hsnCode { get; set; }
        public int quantity { get; set; }
        public string qtyUnit { get; set; }
        public int cgstRate { get; set; }
        public int sgstRate { get; set; }
        public int igstRate { get; set; }
        public int cessRate { get; set; }
        public int cessNonadvol { get; set; }
        public int taxableAmount { get; set; }
    }
}
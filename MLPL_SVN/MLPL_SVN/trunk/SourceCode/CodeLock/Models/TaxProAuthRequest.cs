using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Models
{
    public class TaxProAuthRequest
    {
        public string gstin { get; set; }
        public string username { get; set; }
        public string ewbpwd { get; set; }
    }
}
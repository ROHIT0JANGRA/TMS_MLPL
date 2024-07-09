using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Models
{
    public class TaxProAuthApiResponse
    {

        public int status { get; set; }
        public string authtoken { get; set; }
        public string sek { get; set; }
    }
}
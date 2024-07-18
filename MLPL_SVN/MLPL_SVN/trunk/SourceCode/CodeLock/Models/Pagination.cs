using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Models
{
    public class Pagination
    {
        public DTPostData data { get; set; }
        public int TotalVehicle { get; set; }
        public int FilterVehcile { get; set; }

    }

    public class DTPostData
    {
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public List<DTColumn> columns { get; set; }
        public DTSearch search { get; set; }
        public List<DTOrder> order { get; set; }
    }

    public class DTColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public string searchable { get; set; }
        public string orderable { get; set; }
        public DTSearch search { get; set; }
    }

    public class DTSearch
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class DTOrder
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
    public class DTResponse
    {
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public string data { get; set; }
        public int TotalVehicle { get; set; }
        public int FilterVehcile { get; set; }
        public string FilterChasisNo { get; set; }

    }
}
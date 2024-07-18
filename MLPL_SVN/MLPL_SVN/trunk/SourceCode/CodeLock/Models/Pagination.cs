using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Models
{
   

    public class PaginationData
    {
        public int start { get; set; }
        public int length { get; set; }
        public Search search { get; set; }
        public List<Column> columns { get; set; }
        public List<Order> order { get; set; }
    }

    public class Search
    {
        public string value { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string level { get; set; }
        public string levelType { get; set; }
    }

    public class Column
    {
        public string name { get; set; }
    }

    //public class Order
    //{
    //    public int column { get; set; }
    //    public string dir { get; set; }
    //}



    public class Pagination
    {
        public DTPostData data { get; set; }
        public  DateTime toDate { get; set; }
        public short levelType { get; set; }
        public short level { get; set; }
        public DateTime    fromDate { get; set; }
        public int length { get; set; }
        public int start { get; set; }
        public string sorting { get; set; }
        public PaginationData Data { get; set; }

       public string documentNo { get; set; }
            public string manualDocumentNo { get; set; }
            public int customerId { get; set; }
    }
  
    public class DTPostData
    {
        public   DateTime toDate { get; set; }
        public  int levelType { get; set; }
        public int level { get; set; }
        public DateTime fromDate { get; set; }

        public short ToLocationId;
        public short FromLocationId;
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
        public string fromDate;
        public string toDate;
        public string level;
        public string levelType;
        public short ToLocationId;
        public short FromLocationId;
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class DTOrder
    {
        public int column { get; set; }
        public string dir { get; set; }
        public int Length { get; set; }
    }
    public class DTResponse
    {
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public object data { get; set; }
     
    }
}

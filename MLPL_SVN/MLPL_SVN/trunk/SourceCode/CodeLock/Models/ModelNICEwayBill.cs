using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class ModelNICEwayBill
    {
    }

    public class ModelNICEwayBillAuth
    {
        public string Data { get; set; }
    }
    public class ModelNICEwayBillAppKey
    {
        public string type { get; set; }
        public ModelNICEwayBillAppKeyData data { get; set; }
        public string portalType { get; set; }
    }
    public class ModelNICEwayBillAppKeyData
    {
        public string action { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string app_key { get; set; }
    }
    public class ModelNICEwayBillAppKeyResponse
    {
        public string action { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string app_key { get; set; }
        public string Data { get; set; }
        public int status { get; set; }
        public string error { get; set; }
        public string info { get; set; }
        public string authtoken { get; set; }
        public string sek { get; set; }
        public int error_code { get; set; }
        public string message { get; set; }
        public string Unauthorized { get; set; }
        public string description { get; set; }


    }

}
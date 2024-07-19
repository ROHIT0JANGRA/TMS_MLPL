using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class Ewaybill
    {

    }

    public class GetAllStateCredential
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public string API_USER { get; set; }
        public string API_PASSWORD { get; set; }
        public int? CityId { get; set; } // Nullable if CityId can be null
        public string GstTinNo { get; set; }
    }
    public class StateListViewModel
    {
        public IEnumerable<GetAllStateCredential> StateList { get; set; } // Using IEnumerable for flexibility
    }


    public class EWBMain
    {
        public long EwaybillId { get; set; }
        public object ErrorMessage { get; set; }
        public string GSTIN { get; set; }
        public object DocNo { get; set; }
        public string Date { get; set; }
        public int Old_EWayBill { get; set; }
        public int EWayBill { get; set; }
        public object ValidUpTo { get; set; }
        public string IsSuccess { get; set; }
        public object ErrorCode { get; set; }
        public string VehicleNo { get; set; }
        public object SupplierState { get; set; }
        public List<EWBDetail> EWBDetails { get; set; }
        public string Alert { get; set; }

    }
    public class EWBDetail
    {
        public long EwaybillId { get; set; }
        public string status { get; set; }
        public object errorCodes { get; set; }
        public object errorDesc { get; set; }
        public object ewbNo { get; set; }
        public string ewbDate { get; set; }
        public string genGstin { get; set; }
        public string docNo { get; set; }
        public string docDate { get; set; }
        public double delPinCode { get; set; }
        public double delStateCode { get; set; }
        public string delPlace { get; set; }
        public string validUpto { get; set; }
        public int extendedTimes { get; set; }
        public string rejectStatus { get; set; }
    }
}
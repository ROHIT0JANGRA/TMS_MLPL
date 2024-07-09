using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class TaxProEwayExtendValidityRequest
    {
        public string ewbNo { get; set; }
        public string vehicleNo { get; set; }
        public string fromPlace { get; set; }
        public int fromState { get; set; }
        public int remainingDistance { get; set; }
        public string transDocNo { get; set; }
        public string transDocDate { get; set; }
        public string transMode { get; set; }
        public int extnRsnCode { get; set; }
        public string extnRemarks { get; set; }
        public int fromPincode { get; set; }
        public string consignmentStatus { get; set; }
        public string transitType { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }

    }
    public class TaxProEwayConsolidated
    {
        public string fromPlace { get; set; }
        public string fromState { get; set; }
        public string vehicleNo { get; set; }
        public string transMode { get; set; }
        public string transDocNo { get; set; }
        public string transDocDate { get; set; }
        public List<TaxProEwayTripSheetEwbBills> tripSheetEwbBills { get; set; }
    }

    public class TaxProEwayTripSheetEwbBills
    {
        public string ewbNo { get; set; }
    }

}
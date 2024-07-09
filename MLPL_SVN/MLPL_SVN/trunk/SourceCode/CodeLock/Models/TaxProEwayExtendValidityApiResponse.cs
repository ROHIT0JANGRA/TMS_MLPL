using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class TaxProEwayExtendValidityApiResponse
    {
        public string ewayBillNo { get; set; }
        public string updatedDate { get; set; }
        public string validUpto { get; set; }
        public bool IsSuccess { get; set; }
        public string errorMsg { get; set; }

    }
    public class TaxProEwayConsolidateApiResponse
    {
        public string cEwbNo { get; set; }
        public string cEwbDate { get; set; }
        public bool IsSuccess { get; set; }
        public string errorMsg { get; set; }
    }
    public class TaxProEwayTripSheetApiResponse
    {
        public string tripSheetNo { get; set; }
        public string fromPlace { get; set; }
        public string fromState { get; set; }
        public string vehicleNo { get; set; }
        public string transMode { get; set; }
        public string transDocNo { get; set; }
        public string transDocDate { get; set; }
        public string userGstin { get; set; }
        public string enteredDate { get; set; }
        public string status { get; set; }
        public string EntryBy { get; set; }
        public string DocumentType { get; set; }

        //
    }
}
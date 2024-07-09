using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class TripsheetSettlementCancellation
    {

        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public long TripsheetId { get; set; }

        public byte searchBy { get; set; }

        public string Remarks { get; set; }

        [Display(Name = "Tripsheet No")]
        public string TripsheetNo { get; set; }

        [Display(Name = "Manual Tripsheet No")]
        public string ManualTripsheetNo { get; set; }

        [Display(Name = "Tripsheet Date")]
        public DateTime TripsheetDate { get; set; }

        [Display(Name = "Vehicle Type")]
        public string VehicleType { get; set; }

        [Display(Name = "Driver")]
        public string DriverName { get; set; }

        public short? DriverId { get; set; }

        public short? CancelBy { get; set; }
        public string FirstDriverName { get; set; }
        [Display(Name = "Tripsheet Action")]
        public byte TripsheetAction { get; set; }
        public string VehicleNo { get; set; }

        public List<DriverSettlementCancellationDetails> Details { get; set; }
    }

    public class DriverSettlementCancellationDetails : BaseModel
    {
        public long TripsheetId { get; set; }

        public bool IsChecked { get; set; }

        public string CancelReason { get; set; }

        public DateTime CancelDate { get; set; }

    }
}
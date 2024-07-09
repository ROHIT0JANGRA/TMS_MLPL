//  
// Type: CodeLock.Models.ThcSummary
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class ThcSummary : BaseModel
    {
        public ThcSummary()
        {
            this.ManifestList = new List<StockUpdateDocket>();
            this.DepsDetails = new List<DepsDocket>();
        }

        public short LocationId { get; set; }

        public long ThcId { get; set; }

        [Display(Name = "THC No")]
        public string ThcNo { get; set; }

        [Display(Name = "THC No")]
        public string ThcNos { get; set; }

        public short RouteId { get; set; }

        [Display(Name = "Departed Locations(s)")]
        public string ArrivalLocationCode { get; set; }

        [Display(Name = "Transition Time(In Hours)")]
        [Required(ErrorMessage = "Transition Time(In Hours)")]
        public byte TransitTimeHour { get; set; }

        [Display(Name = "Docket No")]
        public string DocketNo { get; set; }

        [Display(Name = "THC Date")]
        [DataType(DataType.DateTime)]
        public DateTime ThcDate { get; set; }

        [Display(Name = "Departed Location")]
        public string FromLocationCode { get; set; }

        public short FromLocationId { get; set; }

        [Display(Name = "Arrival Location")]
        public string ToLocationCode { get; set; }

        public short? ToLocationId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Actual Arrival Date")]
        [Required(ErrorMessage = "Please enter Arrival Date Time")]
        public DateTime? ActualArrivalDate { get; set; }

        [Display(Name = "Actual Departure Date")]
        [DataType(DataType.DateTime)]
        public DateTime? ActualDepartureDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Expected Arrival Date")]
        public DateTime? ExpectedArrivalDate { get; set; }

        public short TransitMin { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Expected Departed Date Time")]
        public DateTime? ExpectedDepartureDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Stock Update Date")]
        public DateTime? StockUpdateDate { get; set; }

        [Display(Name = "Outgoing Seal No 1")]
        [Required(ErrorMessage = "Please enter Outgoing Seal No 2")]
        public string OutgoingSealNo { get; set; }


        [Required(ErrorMessage = "Please enter Outgoing Seal No. 2")]
        [Display(Name = "Outgoing Seal No. 2")]
        public string OutgoingSealNo2 { get; set; }


        [Required(ErrorMessage = "Please enter Incoming Seal No")]
        [Display(Name = "Incoming Seal No ")]
        public string IncomingSealNo { get; set; }

        [Display(Name = "Incoming Seal No. Status")]
        public byte? IncomingSealStatus { get; set; }

        [Required(ErrorMessage = "Please enter Incoming Seal Reason")]
        [Display(Name = "Incoming Seal Reason")]
        public string IncomingSealReason { get; set; }

        [Required(ErrorMessage = "Please enter Outgoing Remark")]
        [Display(Name = "Outgoing Remark")]
        public string OutgoingRemark { get; set; }

        [Required(ErrorMessage = "Please enter Incoming Remark")]
        [Display(Name = "Incoming Remark")]
        public string IncomingRemark { get; set; }

        [AssertThat("StartKm > 0", ErrorMessage = "Start Kilometer must be greater than 0")]
        [Required(ErrorMessage = "Please enter Start Kilometer")]
        [Display(Name = "Start Kilometer")]
        public int StartKm { get; set; }

        [Display(Name = "End Kilometer")]
        [Required(ErrorMessage = "Please enter End Kilometer")]
        [AssertThat("StartKm < EndKm", ErrorMessage = "Please enter End Kilometer greater than Start Kilometer")]
        public int EndKm { get; set; }

        public short TotalTransitMin { get; set; }

        public short TotalManifest { get; set; }

        public short TotalDocket { get; set; }

        public int TotalPackages { get; set; }

        public Decimal TotalActualWeight { get; set; }

        [Display(Name = "Is Over Loaded")]
        public bool IsOverLoaded { get; set; }

        [RequiredIf("IsOverLoaded == true", ErrorMessage = "Please select Overloaded Reason")]
        [Display(Name = "Overloaded Reason")]
        public byte? OverLoadedReasonId { get; set; }

        public Decimal TotalWeight { get; set; }

        public bool? IsWeightAdded { get; set; }

        public Decimal AdjustmentWeight { get; set; }

        [Display(Name = "Total Weight Loaded")]
        public Decimal TotalWeightLoaded { get; set; }

        [Display(Name = "Capacity Utilization In Percentage")]
        public Decimal CapacityUtilization { get; set; }

        [Display(Name = "Late Arrival Reason")]
        public byte? LateArrivalReasonId { get; set; }

        public short LoadBy { get; set; }

        public DateTime LoadDate { get; set; }

        public short? UnloadBy { get; set; }

        public DateTime? UnloadDate { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        public bool IsUpdate { get; set; }

        public string ThcStatus { get; set; }

        public string StockUpdateRemarks { get; set; }

        public long DepsDocketId { get; set; }

        [Range(1.0, 999999999999.0, ErrorMessage = "Please enter EWAY Bill No")]
        [Display(Name = "EWAY Bill No")]
        [Required(ErrorMessage = "Please enter EWAY Bill No")]
        public string EwayBillNo { get; set; }

        [Display(Name = "EWAY Bill Issue Date")]
        public DateTime? EwayBillIssueDate { get; set; }

        [Display(Name = "EWAY Bill Expiry Date")]
        public DateTime? EwayBillExpiryDate { get; set; }

        public List<StockUpdateDocket> ManifestList { get; set; }

        public List<DepsDocket> DepsDetails { get; set; }
    }
}

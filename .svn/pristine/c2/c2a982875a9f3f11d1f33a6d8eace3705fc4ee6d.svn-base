using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Runtime.InteropServices;
using System.Web;

namespace CodeLock.Models
{
    public class MilkRunLogDetail : BaseModel
    {
        public MilkRunLogDetail()
        {
            this.VehicleLogDetail = new List<VehicleLogDetail>();
        }

        //DocumentName
        public string From { get; set; }

        public long TripsheetId { get; set; }

        [Display(Name = "Tripsheet No.")]
        [Required(ErrorMessage = "Enter Tripsheet No")]
        public string TripsheetNo { get; set; }

        public string To { get; set; }


        [Display(Name = "Start Date Time")]
        public DateTime? StartDateTime { get; set; }

        public DateTime StartDate { get; set; }

        public TimeSpan StartTime { get; set; }

        [Display(Name = "Start Km")]
        public int StartKm { get; set; }


        [Display(Name = "End Km")]
        public int EndKm { get; set; }

        public string Category { get; set; }


        [Display(Name = "Product")]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [Display(Name = "End Date Time")]
        public DateTime? EndDateTime { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan EndTime { get; set; }

        [Display(Name = "Run Km")]

        public int KmRun { get; set; }

        [Display(Name = "Transit Time")]
        public string TransitTime { get; set; }

        public List<CodeLock.Models.VehicleLogDetail> VehicleLogDetail { get; set; }

        public string TripsheetDate { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string CustomerName { get; set; }
        public string SubCategory { get; set; }

        [Display(Name = "Consignee Name")]
        public string ConsigneeName { get; set; }

        [Display(Name = "EWay bill No.")]
        public string EWaybillNo { get; set; }

        [Display(Name = "Invoice No.")]
        public string InvoiceNo { get; set; }

        [Display(Name = "Invoice Value")]
        public decimal InvoiceValue { get; set; }

        [Display(Name = "No. of Pkgs")]
        public decimal NoOfPackages { get; set; }

        [Display(Name = "Weight")]
        public decimal Weight { get; set; }

        [Display(Name = "Delivered Pkgs")]
        public decimal Deliveredpkgs { get; set; }
        public string Status { get; set; }
        public string StatusName { get; set; }
        public string Remarks { get; set; }

        [Display(Name = "Upload POD")]
        public string PODUpload { get; set; }

        public HttpPostedFileBase PODUploadAttachment { get; set; }

        [Display(Name = "Upload Toll Tax Document")]
        public string TollTaxUpload { get; set; }

        public HttpPostedFileBase TollTaxUploadAttachment { get; set; }

        [Display(Name = "Toll Tax Charges")]
        public decimal TollTaxCharges { get; set; }

        [Display(Name = "Upload Parking Charges")]
        public string ParkingChargesUpload { get; set; }

        [Display(Name = "Upload Parking Document")]
        public HttpPostedFileBase ParkingChargesUploadAttachment { get; set; }

        [Display(Name = "Parking Charges")]
        public decimal ParkingCharges { get; set; }

        [Display(Name = "Vehicle No.")]
        public string VehicleNo { get; set; }

        [Display(Name = "Vehicle Type")]
        public string VehicleTypeName { get; set; }

        [Display(Name = "Detention Night Charges")]
        public Decimal DetentionNightCharges { get; set; }

        [Display(Name = "Unloading Charges")]
        public Decimal UnloadingCharges { get; set; }

        [Display(Name = "Sunday / Holiday Charges")]
        public Decimal SundayHolidayCharges { get; set; }

    }

    public class MilkRunBillingDetail
    {
        public long TripsheetId { get; set; }

        public bool IsChecked { get; set; }
        public string TripSheetNo { get; set; }
        public string ManualTripsheetNo { get; set; }
        public string TripSheetDate { get; set; }
        public string VehicleNo { get; set; }


        [Display(Name = "Fixed Amount")]
        public Decimal FixedAmount { get; set; }

        [Display(Name = "Fixed Km")]
        public Decimal FixedKm { get; set; }

        [Display(Name = "Variable Rate")]
        public Decimal VariableRate { get; set; }

        [Display(Name = "Km Run")]
        public Decimal KmRun { get; set; }

        [Display(Name = "Base Amount")]
        public Decimal ActualAmount { get; set; }

        [Display(Name = "Extra Amount")]
        public Decimal ExtraAmount { get; set; }

        [Display(Name = "Net Amount")]
        public Decimal NetAmount { get; set; }

        public Decimal Igst { get; set; }

        public Decimal Cgst { get; set; }

        public Decimal Sgst { get; set; }

        public Decimal Ugst { get; set; }

        public Decimal GstTotal { get; set; }

        public Decimal GstRate { get; set; }
        public Decimal TotalAmount { get; set; }

        public Decimal TotalHolidayAmount { get; set; }
        public Decimal TotalWorkingHourAmount { get; set; }
        public Decimal TotalHolidays { get; set; }
        public Decimal TotalWorkingHours { get; set; }
        public string TotalWorkingHoursStr { get; set; }

        public Decimal FixedDays { get; set; }
        public Decimal ActualDays { get; set; }
        public Decimal WorkingHours { get; set; }

        public Decimal OtherFixedAmount { get; set; }
        public Decimal StateTax { get; set; }
        public Decimal ParkingCharge { get; set; }
        public Decimal LabourCharge { get; set; }
        public bool IsMilkrunHrsPerDayEnabled { get; set; }

        public long TSLaneDetailID { get; set; }
        public long LID { get; set; }
        public string LaneId { get; set; }
        public string MasterLaneId { get; set; }
        public string RouteName { get; set; }
        public string TourId { get; set; }
        public string ErId { get; set; }
        public string StartDate { get; set; }
        public long FSCRateId { get; set; }
        public long ContractID { get; set; }
        public Decimal VariableKMRate { get; set; }
        public Decimal VariableBaseAmtPerTrip { get; set; }
        public Decimal TotalTripFSCAmount { get; set; }
        public Decimal TollAmount { get; set; }
        public Decimal AdditionalKM { get; set; }
        public Decimal AdditionalAmountKM { get; set; }
        public Decimal OtherCharge { get; set; }
        public string Remark { get; set; }
        public bool IsLaneIdEnabled { get; set; }
        public Decimal DetentionNightCharges { get; set; }
        public Decimal SundayHolidayCharges { get; set; }
        public Decimal UnloadingCharges { get; set; }
        public Decimal MngmntFees { get; set; }
        public Decimal TollTaxCharges { get; set; }
        public Decimal ParkingCharges { get; set; }

        public Decimal ExtraHoursRate { get; set; }
        public Decimal ExtraKmAmount { get; set; }

        public string TotalExtraHours { get; set; }

        //


    }
}
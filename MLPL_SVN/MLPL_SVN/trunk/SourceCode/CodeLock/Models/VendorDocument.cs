//  
// Type: CodeLock.Models.VendorDocument
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VendorDocument
    {
        public long VendorId { get; set; }
        public long DocumentId { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNo { get; set; }

        [Display(Name = "Manual Document No")]
        public string ManualDocumentNo { get; set; }

        [Display(Name = "Type")]
        public string DocumentType { get; set; }

        public byte DocumentTypeId { get; set; }

        [Display(Name = "Date")]
        public DateTime DocumentDate { get; set; }

        [Display(Name = "Location")]
        public string DocumentLocation { get; set; }

        [Display(Name = "FTL Type")]
        public string FtlType { get; set; }

        [Display(Name = "Route Name")]
        public string RouteName { get; set; }

        [Display(Name = "Vehicle No")]
        public string VehicleNo { get; set; }

        [Display(Name = "Vendor Name")]
        public string VendorName { get; set; }

        [Display(Name = "Pan No")]
        [PanNoAnnotation]
        public string PanNo { get; set; }

        [Display(Name = "Service Tax No")]
        public string ServiceTaxNo { get; set; }

        [Display(Name = "Contract Amount")]
        public Decimal ContractAmount { get; set; }

        [Display(Name = "Total Advance Amount")]
        public Decimal TotalAdvanceAmount { get; set; }
        [Display(Name = "Advance Amount")]
        public Decimal AdvanceAmount { get; set; }

        [Display(Name = "Advance Amount Paid")]
        public Decimal AdvanceAmountPaidOthrLoc { get; set; }

        [Display(Name = "Balance Amount")]
        public Decimal BalanceAmount { get; set; }

        [Display(Name = "Other Amount")]
        public Decimal OtherAmount { get; set; }
        public short BAMappedLocationid { get; set; }
        [Display(Name = "FuelSlip No")]
        public string FuelSlipNo { get; set; }

        [Display(Name = "Fuel Qty")]
        public Decimal FuelQty { get; set; }

        [Display(Name = "Fuel Rate")]
        public Decimal FuelRate { get; set; }

        [Display(Name = "FuelSlip Date")]
        public string FuelSlipDate { get; set; }

        public bool IsChecked { get; set; }
        public byte TransportModeId { get; set; }
        public decimal TdsAmountOnAdvance { get; set; }
        public decimal TDSAmount { get; set; }
        public byte TDSRuleId { get; set; }
    }
}

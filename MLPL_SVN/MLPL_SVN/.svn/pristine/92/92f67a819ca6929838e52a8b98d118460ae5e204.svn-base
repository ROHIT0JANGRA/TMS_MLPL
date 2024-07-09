//  
// Type: CodeLock.Models.DocketInvoice
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DocketInvoiceCarton
    {
        public string TripsheetNo { get; set; }
        public string CartonNo { get; set; }
    }

    public class DocketInvoice
    {
        public DocketInvoice()
        {
            this.PartList = new List<InvoicePart>();
        }

        [Required(ErrorMessage = "Please enter Invoice No")]
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }

        public int InvoiceId { get; set; }

        [Display(Name = "Invoice Date")]
        [Required(ErrorMessage = "Please enter Invoice Date")]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Part No")]
        [Required(ErrorMessage = "Please select Part No")]
        public long PartId { get; set; }

        [Display(Name = "Part No")]
        [Required(ErrorMessage = "Please select Part No")]
        public string PartNo { get; set; }

        [Display(Name = "Packing Type")]
        [Required(ErrorMessage = "Please select Packing Type")]
        public short PackingTypeId { get; set; }
       

        [Required(ErrorMessage = "Please enter Type Of Package")]
        [Display(Name = "Type Of Package")]
        public short TypeOfPackage { get; set; }

        [Required(ErrorMessage = "Please enter Length")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Length")]
        [Display(Name = "Length")]
        public Decimal Length { get; set; }

        [Required(ErrorMessage = "Please enter Breadth")]
        [Display(Name = "Breadth")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Breadth")]
        public Decimal Breadth { get; set; }

        [Display(Name = "Height")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Height")]
        [Required(ErrorMessage = "Please enter Height")]
        public Decimal Height { get; set; }

        [Required(ErrorMessage = "Please enter Invoice Amount")]
        [Range(0.001, 999999999999.0, ErrorMessage = "Please enter Invoice Amount")]
        [Display(Name = "Invoice Amount")]
        public Decimal InvoiceAmount { get; set; }

        [Required(ErrorMessage = "Please enter Packages")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Packages")]
        [Display(Name = "Packages")]
        public short Packages { get; set; }

        [Display(Name = "Volumetric Weight")]
        //[Required(ErrorMessage = "Please enter Volumetric Weight")]
        //[Range(0.001, 99999.0, ErrorMessage = "Please enter Volumetric Weight")]
        public Decimal VolumetricWeight { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Actual Weight")]
        [Display(Name = "Actual Weight")]
        [Required(ErrorMessage = "Please enter Actual Weight")]
        public Decimal ActualWeight { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Charged Weight")]
        [Required(ErrorMessage = "Please enter Charged Weight")]
        [Display(Name = "Charged Weight")]
        public Decimal ChargedWeight { get; set; }

        [Display(Name = "EWAY Bill No")]
        public string EwayBillNo { get; set; }

        [Display(Name = "Part Quantity")]
        public int PartQuantity { get; set; }

        [Display(Name = "Part Weight")]
        public decimal PartWeight{get;set;}

        [Display(Name = "Reference No")]
        public string ReferenceNo { get; set; } 
        public DateTime? EwayBillIssueDate { get; set; }

        [Display(Name = "EWAY Bill Expiry Date")]
        public DateTime? EwayBillExpiryDate { get; set; }

        public List<InvoicePart> PartList { get; set; }

        [Display(Name = "PaymentMode")]
        public string PaymentMode { get; set; }

        [Required(ErrorMessage = "Please enter COD-Collectable Amount")]
        [Display(Name = "COD-Collectable Amount")]
        public Decimal CODCollectableAmount { get; set; }
       
        public string EwayBill{ get; set; }

        public DateTime? EwayBillDate { get; set; }
      
        public DateTime? EwayExpDate { get; set; }

        public decimal InvoiceValue { get; set; }

        //
    }
}

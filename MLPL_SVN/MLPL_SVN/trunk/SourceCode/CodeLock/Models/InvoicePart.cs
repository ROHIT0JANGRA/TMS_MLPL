//  
// Type: CodeLock.Models.InvoicePart
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class InvoicePart
    {
        public string InvoiceNo { get; set; }

        public int InvoiceId { get; set; }

        [Display(Name = "Part")]
        [Required(ErrorMessage = "Please select Part")]
        public int PartId { get; set; }

        public Decimal ChargeWeightPerQuantity { get; set; }

        [Display(Name = "Part Code")]
        public string PartCode { get; set; }

        [Display(Name = "Part Name")]
        //[Required(ErrorMessage = "Please enter Code")]
        public string PartName { get; set; }

        [Display(Name = "Part Description")]
        public string PartDescription { get; set; }

        [Display(Name = "Part Quantity")]
        public Decimal PartQuantity { get; set; }

        [Display(Name = "SlotDate")]
        public string SlotDate { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter Length")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Length")]
        [Display(Name = "Length")]
        public Decimal PartLength { get; set; }

        [Required(ErrorMessage = "Please enter Breadth")]
        [Display(Name = "Breadth")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Breadth")]
        public Decimal PartBreadth { get; set; }

        [Display(Name = "Height")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Height")]
        [Required(ErrorMessage = "Please enter Height")]
        public Decimal PartHeight { get; set; }

        [Display(Name = "Volumetric Weight")]
        [Required(ErrorMessage = "Please enter Volumetric Weight")]
        //[Range(0.001, 99999.0, ErrorMessage = "Please enter Volumetric Weight")]
        public Decimal PartVolumetricWeight { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Actual Weight")]
        [Display(Name = "Actual Weight")]
        [Required(ErrorMessage = "Please enter Actual Weight")]
        public Decimal PartActualWeight { get; set; }

        [Range(0.001, 99999.0, ErrorMessage = "Please enter Charged Weight")]
        [Required(ErrorMessage = "Please enter Charged Weight")]
        [Display(Name = "Charged Weight")]
        public Decimal PartChargedWeight { get; set; }

        [Display(Name = "TotalCubic")]
        public Decimal PartTotalCubic { get; set; }

        [Display(Name = "Part Amount")]
        public decimal PartAmount { get; set; }
        public bool IsCod { get; set; }

        [Display(Name = "Packing Type")]
        [Required(ErrorMessage = "Please select Packing Type")]
        public byte PackingTypeId { get; set; }

        [Display(Name = "Reference No")]
        public string ReferenceNo { get; set; }

        [Required(ErrorMessage = "Please enter Packages")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Packages")]
        [Display(Name = "Packages")]
        public short Packages { get; set; }

    }

    public class InvoiceVolumetric
    {
        public string InvoiceNo { get; set; }

        public int InvoiceId { get; set; }

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

        [Display(Name = "Volumetric Weight")]
        [Required(ErrorMessage = "Please enter Volumetric Weight")]
        [Range(0.001, 99999.0, ErrorMessage = "Please enter Volumetric Weight")]
        public Decimal VolumetricWeight { get; set; }

        [Display(Name = "Packages")]
        [Required(ErrorMessage = "Please enter Packages")]
        [Range(1, 999999, ErrorMessage = "Please enter Packages")]
        public int Packages { get; set; }

    }
}

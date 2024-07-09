//  
// Type: CodeLock.Models.TripsheetBill
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class TripsheetBill : BaseModel
  {
    public TripsheetBill()
    {
      this.Details = new List<TripsheetBillDetail>();
    }

    public short LocationId { get; set; }

    public long BillId { get; set; }

    [Display(Name = "Bill No")]
    public string BillNo { get; set; }

    [Display(Name = "Manual Bill No")]
    public string ManualBillNo { get; set; }

    [Display(Name = "Due Date")]
    public DateTime DueDate { get; set; }

    public short CustomerId { get; set; }

    [Required(ErrorMessage = "Please enter Customer")]
    [Display(Name = "Customer")]
    public string CustomerCode { get; set; }

    public string CustomerName { get; set; }

    [Display(Name = "Trip Type")]
    public byte TripTypeId { get; set; }

    [Display(Name = "Bill Date")]
    public DateTime BillDate { get; set; }

    [Display(Name = "FTL Type")]
    public byte FtlTypeId { get; set; }

    public short VehicleId { get; set; }

    [Display(Name = "Vehicle")]
    public string VehicleNo { get; set; }

    [Display(Name = "Bill Generation Location")]
    public short BillGenerationLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Bill Generation Location")]
    public string BillGenerationLocationCode { get; set; }

    [Display(Name = "Bill Submission Location")]
    public short BillSubmissionLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Bill Submission Location")]
    public string BillSubmissionLocationCode { get; set; }

    [Display(Name = "Bill Collection Location")]
    public short BillCollectionLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Bill Collection Location")]
    public string BillCollectionLocationCode { get; set; }

    [Display(Name = "Company GST State")]
    [Required(ErrorMessage = "Please select Company GST State")]
    public short CompanyGstStateId { get; set; }

    public long CompanyGstId { get; set; }

    [Display(Name = "Customer GST State")]
    [Required(ErrorMessage = "Please select Customer GST State")]
    public short CustomerGstStateId { get; set; }

    public long PartyGstId { get; set; }

    [Display(Name = "Customer GSTIN No")]
    public string CustomerGstStateGstTinNo { get; set; }

    [Display(Name = "Company GSTIN No")]
    public string CompanyGstStateGstTinNo { get; set; }

    [Display(Name = "SAC Code")]
    public byte SacId { get; set; }

    [Required(ErrorMessage = "Please enter SAC Code")]
    public string SacCode { get; set; }

    [Display(Name = "GST Rate")]
    public Decimal GstRate { get; set; }

    [Display(Name = "RCM Applicable")]
    public string IsRcm { get; set; }

    public string Notes { get; set; }

    public Decimal BillAmount { get; set; }

    public Decimal TaxTotal { get; set; }

    public Decimal SubTotal { get; set; }

    public List<TripsheetBillDetail> Details { get; set; }
  }
}

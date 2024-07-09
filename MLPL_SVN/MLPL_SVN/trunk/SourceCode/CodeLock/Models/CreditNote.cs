using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CreditNote : Base
  {
    public long BillId { get; set; }

    [Display(Name = "Bill No")]
    public string BillNo { get; set; }

    public Decimal BillAmount { get; set; }

    [Display(Name = "From Date")]
    public DateTime FromDate { get; set; }

    [Display(Name = "To Date")]
    public DateTime ToDate { get; set; }

    [Display(Name = "Billing Party")]
    public short CustomerId { get; set; }

    [Display(Name = "Billing Party")]
    public string CustomerCode { get; set; }

    public string CustomerName { get; set; }

    [Display(Name = "Billing Party")]
    [Required(ErrorMessage = "Please enter Billing Party")]
    public string CriteriaCustomerCode { get; set; }

    [Required(ErrorMessage = "Please enter Bill Credit Note Date")]
    [Display(Name = "Bill Credit Note Date")]
    public DateTime CreditNoteDate { get; set; }

    public string LocationCode { get; set; }

    public short LocationId { get; set; }

    [Display(Name = "Generation Location")]
    public short GenerationLocationId { get; set; }

    [Display(Name = "Generation Location")]
    public string GenerationLocationCode { get; set; }

    [Display(Name = "Paybas")]
    [Required(ErrorMessage = "Please Select Paybas")]
    public byte PaybasId { get; set; }

    public string Paybas { get; set; }

    public short AccountId { get; set; }

    [Display(Name = "Account Code")]
    [Required(ErrorMessage = "Please enter Account Code")]
    public string AccountCode { get; set; }

    [Display(Name = "Account Description")]
    public string AccountDescription { get; set; }

    public string FinYear { get; set; }

    [Display(Name = "Refrence Number")]
    public string RefrenceNumber { get; set; }

    [Required(ErrorMessage = "Please enter CreditNote Amount")]
    [Display(Name = "Total Credit Note Amount")]
    public Decimal TotalCreditNoteAmount { get; set; }

    public List<CreditNoteDetails> DetailList { get; set; }
  }
}

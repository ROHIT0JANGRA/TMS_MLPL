//  
// Type: CodeLock.Models.DcrTrack
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DcrTrack
  {
    [Display(Name = "Document Type")]
    [Required(ErrorMessage = "Please select Document Type")]
    public byte DocumentTypeId { get; set; }

    [Display(Name = "Document Number")]
    public string DocumentNumber { get; set; }

    [Display(Name = "Document Type")]
    public string DocumentTypeName { get; set; }

    [Display(Name = "Book Code")]
    public string BookCode { get; set; }

    [Display(Name = "Business Type")]
    public string BusinessType { get; set; }

    [Display(Name = "Series From")]
    public string SeriesFrom { get; set; }

    [Display(Name = "Series To")]
    public string SeriesTo { get; set; }

    [Display(Name = "Location")]
    public string LocationCode { get; set; }

    [Display(Name = "Allocated Category")]
    public string AllotedCategory { get; set; }

    [Display(Name = "Allocated To")]
    public short? AllotedTo { get; set; }

    public Decimal Total { get; set; }

    public Decimal Used { get; set; }

    public Decimal Cancelled { get; set; }

    public Decimal Void { get; set; }

    [Display(Name = "Is Active")]
    public bool IsActive { get; set; }
  }
}

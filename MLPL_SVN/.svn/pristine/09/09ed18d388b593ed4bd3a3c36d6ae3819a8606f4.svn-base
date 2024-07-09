//  
// Type: CodeLock.Models.MasterDcr
//  
//  
//  

using ExpressiveAnnotations.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class MasterDcr : BaseModel
  {
    public long Id { get; set; }

    [Display(Name = "Document Type")]
    [Required(ErrorMessage = "Please select Document Type")]
    public byte DocumentTypeId { get; set; }

    [Display(Name = "Document Type")]
    public string DocumentTypeName { get; set; }

    [Display(Name = "Book Code")]
    [Required(ErrorMessage = "Enter Book Code")]
    public string BookCode { get; set; }

    [Display(Name = "Business Type")]
    public byte BusinessTypeId { get; set; }

    [Required(ErrorMessage = "Enter Series From")]
    [Display(Name = "Series From")]
    public string SeriesFrom { get; set; }

    [Display(Name = "Series To")]
    public string SeriesTo { get; set; }

    [Display(Name = "Location")]
    [Required(ErrorMessage = "Please select Location")]
    public short LocationId { get; set; }

    [Display(Name = "Allocated Category")]
    public string AllotedCategory { get; set; }

    [Display(Name = "Allocated Category")]
    public string AllotedCategoryName { get; set; }

    [Display(Name = "Allocated To")]
    public short? AllotedTo { get; set; }

    [Display(Name = "Suffix Base")]
    public string SuffixBase { get; set; }

    [Display(Name = "Document Number")]
    [Required(ErrorMessage = "Please enter Document No")]
    public string DocumentNumber { get; set; }

    [Display(Name = "Page Size")]
    [Required(ErrorMessage = "Enter Page Size")]
    public int PageSize { get; set; }

    [Display(Name = "Total Leaf")]
    public Decimal Total { get; set; }

    public string SeriesFromBase { get; set; }

    public string SeriesToBase { get; set; }

    [RequiredIf("AllotedCategory != ''", ErrorMessage = "Please enter Alloted Name")]
    public string AllotedToName { get; set; }

    public DateTime AllotedDate { get; set; }

    public short? AllotedToOld { get; set; }

    public string AllotedToNameOld { get; set; }

    public string Suffix { get; set; }

    [Display(Name = "Location")]
    public string LocationCode { get; set; }

    public short LocationIdOld { get; set; }

    public string LocationCodeOld { get; set; }

    public string AllotedCategoryOld { get; set; }

    public string BusinessType { get; set; }

    public string ActionName { get; set; }

    public string ActionId { get; set; }

    public Decimal Used { get; set; }

    public Decimal Cancelled { get; set; }

    public Decimal Void { get; set; }

    public bool IsBusinessTypeWise { get; set; }
  }
}

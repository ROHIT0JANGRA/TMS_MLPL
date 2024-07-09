//  
// Type: CodeLock.Models.Deps
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class Deps
  {
    public byte DepsId { get; set; }

    public string DepsNo { get; set; }

    public long DocketId { get; set; }

    public string DocketNo { get; set; }

    public DateTime DocketDate { get; set; }

    public string DocketStatus { get; set; }

    public long ThcId { get; set; }

    public long ManifestId { get; set; }

    public string DocketSuffix { get; set; }

    public short LocationId { get; set; }

    public DateTime DepsDate { get; set; }

    public TimeSpan DepsTime { get; set; }

    public DateTime DepsDateTime { get; set; }

    public short EntryBy { get; set; }

    public byte DepsType { get; set; }

    [Display(Name = "From Location")]
    public string FromLocation { get; set; }

    [Display(Name = "To Location")]
    public string ToLocation { get; set; }

    [Display(Name = "Booked Packages")]
    public int Packages { get; set; }

    [Display(Name = "Actual Booked Weight")]
    public Decimal ActualWeight { get; set; }

    [Display(Name = "Arrival Packages")]
    public int ArrivalPackages { get; set; }

    [Display(Name = "Actual Arrival Weight")]
    public Decimal ArrivalWeight { get; set; }

    [Display(Name = "Short Packages")]
    public bool IsShort { get; set; }

    [Display(Name = "Reject Packages")]
    public bool IsReject { get; set; }

    [Display(Name = "Pilfer Packages")]
    public bool IsPilfer { get; set; }

    [Display(Name = "Damage Packages")]
    public bool IsDamage { get; set; }

    [Display(Name = "Short Packages")]
    public int ShortPackages { get; set; }

    [Display(Name = "Reject Packages")]
    public int RejectPackages { get; set; }

    [Display(Name = "Pilfer Packages")]
    public int PilferPackages { get; set; }

    [Display(Name = "Damage Packages")]
    public int DamagePackages { get; set; }

    [Required(ErrorMessage = "Please select Short Packages Reason")]
    [Display(Name = "Short Packages Reason")]
    public byte ShortPackagesReasonId { get; set; }

    [Required(ErrorMessage = "Please select Reject Packages Reason")]
    [Display(Name = "Reject Packages Reason")]
    public byte RejectPackagesReasonId { get; set; }

    [Display(Name = "Pilfer Packages Reason")]
    [Required(ErrorMessage = "Please select Pilfer Packages Reason")]
    public byte PilferPackagesReasonId { get; set; }

    [Display(Name = "Damage Packages Reason")]
    [Required(ErrorMessage = "Please select Damage Packages Reason")]
    public byte DamagePackagesReasonId { get; set; }

    [Display(Name = "Short Remark")]
    public string ShortRemark { get; set; }

    [Display(Name = "Reject Remark")]
    public string RejectRemark { get; set; }

    [Display(Name = "Pilfer Remark")]
    public string PilferRemark { get; set; }

    [Display(Name = "Damage Remark")]
    public string DamageRemark { get; set; }

    public HttpPostedFileBase ShortDocumentAttachment { get; set; }

    [Display(Name = "Short Document")]
    public string ShortDocumentName { get; set; }

    public HttpPostedFileBase RejectDocumentAttachment { get; set; }

    [Display(Name = "Reject Document")]
    public string RejectDocumentName { get; set; }

    public HttpPostedFileBase PilferDocumentAttachment { get; set; }

    [Display(Name = "Pilfer Document")]
    public string PilferDocumentName { get; set; }

    public HttpPostedFileBase DamageDocumentAttachment { get; set; }

    [Display(Name = "Damage Document")]
    public string DamageDocumentName { get; set; }
  }
}

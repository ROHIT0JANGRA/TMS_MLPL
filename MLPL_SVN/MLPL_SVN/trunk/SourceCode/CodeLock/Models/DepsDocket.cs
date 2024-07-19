//  
// Type: CodeLock.Models.DepsDocket
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CodeLock.Models
{
  public class DepsDocket
  {
    public DepsDocket()
    {
      this.History = new DepsHistory();
    }

    public string DocketSuffix { get; set; }

    public long DocketId { get; set; }

    [Display(Name = "Deps No")]
    public string DepsNo { get; set; }

    public short LocationId { get; set; }

    public string LocationCode { get; set; }

    public bool IsCheck { get; set; }

    public bool IsDEPS { get; set; }

    public bool IsCheckedShort { get; set; }

    public bool IsCheckedExtra { get; set; }

    public bool IsCheckedPilfer { get; set; }

    public bool IsCheckedDamage { get; set; }

    public int ShortPackages { get; set; }

    public int ExtraPackages { get; set; }

    public int PilferPackages { get; set; }

    public int DamagePackages { get; set; }

    public byte ShortPackagesReasonId { get; set; }

    public byte ExtraPackagesReasonId { get; set; }

    public byte PilferPackagesReasonId { get; set; }

    public byte DamagePackagesReasonId { get; set; }

    public HttpPostedFileBase ShortDocumentAttachment { get; set; }

    public string ShortDocumentName { get; set; }

    public HttpPostedFileBase ExtraDocumentAttachment { get; set; }

    public string ExtraDocumentName { get; set; }

    public HttpPostedFileBase PilferDocumentAttachment { get; set; }

    public string PilferDocumentName { get; set; }

    public HttpPostedFileBase DamageDocumentAttachment { get; set; }

    public string DamageDocumentName { get; set; }

    public string ShortRemark { get; set; }

    public string ExtraRemark { get; set; }

    public string PilferRemark { get; set; }

    public string DamageRemark { get; set; }

    public long DepsDocketId { get; set; }

    public long DepsId { get; set; }

    public byte ReasonId { get; set; }

    public string DocumentName { get; set; }

    public byte DepsType { get; set; }

    public string EntryByName { get; set; }

    public DateTime DepsDate { get; set; }

    public TimeSpan DepsTime { get; set; }

    [Display(Name = "Docket No")]
    public string DocketNo { get; set; }

    [Display(Name = "Found Packages")]
    public byte FoundPackages { get; set; }

    [Display(Name = "Packages")]
    public int Packages { get; set; }

    public byte DepsStatus { get; set; }

    [Display(Name = "Remark")]
    public string Remark { get; set; }

    public DepsHistory History { get; set; }
        public string UnloadingPersonName { get; set; }

    }
}

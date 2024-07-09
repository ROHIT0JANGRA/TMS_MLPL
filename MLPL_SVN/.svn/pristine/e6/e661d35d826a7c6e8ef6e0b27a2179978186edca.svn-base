//  
// Type: CodeLock.Models.DocumentTracking
//  
//  
//  

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DocumentTracking :BaseModel
    {
    public DocumentTracking()
    {
        this.DocumentTrackingDetails = new List<DocumentTracking>();
    }

        [Display(Name = "Handovered Date")]
        public string HandoveredDate { get; set; }

        [Display(Name = "Handovered By")]
        public string HandoveredBy { get; set; }
        public List<DocumentTracking> DocumentTrackingDetails { get; set; }

        [Display(Name = "IsChecked")]
        public bool IsChecked { get; set; }

        [Display(Name = "PodId")]
        public long PodId { get; set; }

        [Display(Name = "PodCount")]
        public long PodCount { get; set; }

        [Display(Name = "DocketId")]
        public string DocketId { get; set; }

        [Display(Name = "DocketNo")]
        public string DocketNo { get; set; }

        [Display(Name = "Docket Date")]
        public string DocketDate { get; set; }

        [Display(Name = "Edd")]
        public string Edd { get; set; }

        [Display(Name = "From Location")]
        public string FromLocation { get; set; }

        [Display(Name = "To Location")]
        public string ToLocation { get; set; }

        [Display(Name = "From City")]
        public string FromCity { get; set; }

        [Display(Name = "To City")]
        public string ToCity { get; set; }

        [Display(Name = "Transport Mode")]
        public string TransportMode { get; set; }

        [Display(Name = "Paybas")]
        public string Paybas { get; set; }

        [Display(Name = "DocketStatus")]
        public string DocketStatus { get; set; }

        [Display(Name = "ConsignorName")]
        public string ConsignorName { get; set; }

        [Display(Name = "ConsigneeName")]
        public string ConsigneeName { get; set; }

        [Display(Name = "DocumentName")]
        public string DocumentName { get; set; }

/// <summary>
/// /////////// OLD Field
/// </summary>

   [Display(Name = "Document Type")]
    public byte DocumentTypeId { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNo { get; set; }

    [Display(Name = "Manual Document No")]
    public string ManualDocumentNo { get; set; }

    [Display(Name = "Location")]
    public string LocationId { get; set; }
     public string localStoragePath { get; set; }
     public string FilesPath { get; set; }

    [Required(ErrorMessage = "Please select customer")]
    [Display(Name = "Customer")]
    public string CustomerId { get; set; }

    [Display(Name = "List Type")]
    public string ListType { get; set; }

    }
}

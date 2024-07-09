using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ConsignmentTracking
  {
    public long DocketId { get; set; }

    [Display(Name = "Document Type")]
    public string DocumentType { get; set; }

    [Display(Name = "Document No")]
    public string DocumentNos { get; set; }

    [Display(Name = "Docket No")]
    public string DocketNo { get; set; }

    public string DocketSuffix { get; set; }

    [Display(Name = "Referance No")]
    public string ReferanceNo { get; set; }

    [Display(Name = "Docket Status")]
    public string DocketStatus { get; set; }

    [Display(Name = "Undelivered Reason")]
    public string UndeliveredReason { get; set; }

    [Display(Name = "Docket Date & Time")]
    public DateTime DocketDateTime { get; set; }

    [Display(Name = "Current Location")]
    public string CurrentLocation { get; set; }

    [Display(Name = "Destination")]
    public string ToLocation { get; set; }

    [Display(Name = "Receiver Name")]
    public string ReceiverName { get; set; }

    [Display(Name = "POD")]
    public string PodDocumentName { get; set; }

    public string Origin { get; set; }

    public string Destination { get; set; }

    public string FromCityName { get; set; }

    public string ToCityName { get; set; }

    public DateTime CurrentStatusDateTime { get; set; }

    public DateTime DeliveryDateTime { get; set; }

    public int Packages { get; set; }

    public DocketTransitDetail DocketTransitDetailList { get; set; }
  }
}

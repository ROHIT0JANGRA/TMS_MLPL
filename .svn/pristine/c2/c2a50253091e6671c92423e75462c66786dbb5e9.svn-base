//  
// Type: CodeLock.Models.DeliveryMrHeader
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class DeliveryMrHeader : BaseModel
  {
    public DeliveryMrHeader()
    {
      this.ChargeList = new List<DeliveryMrCharge>();
    }

    [Display(Name = "Deliver By")]
    public bool IsDeliveredByConsignee { get; set; }

    public bool IsDeliveredFromMaster { get; set; }

    [Display(Name = "Docket Nos.")]
    [Required(ErrorMessage = "Please enter Docket Nos.")]
    public string DocketNos { get; set; }

    [Display(Name = "Docket Suffix")]
    [Required(ErrorMessage = "Please select Docket Suffix")]
    public string DocketSuffix { get; set; }

    public long MrId { get; set; }

    public string MrNo { get; set; }

    public DateTime MrDate { get; set; }

    public short LocationId { get; set; }

    public short PartyId { get; set; }

    public Decimal TotalBillAmount { get; set; }

    public string ManualMrNo { get; set; }

    public string LocationCode { get; set; }

    public string PartyCode { get; set; }

    public string PartyName { get; set; }

    public string Remarks { get; set; }

    public string VehicleNo { get; set; }

    [Display(Name = "GSTIN No")]
    public string GstTinNo { get; set; }

    public string DeliveryMrChargeList { get; set; }

    public string FinYear { get; set; }

    public Receipt ReceiptDetails { get; set; }

    public List<DeliveryMrCharge> ChargeList { get; set; }

    public List<CustomerBillDetail> Details { get; set; }

    public string ConsignorCode { get; set; }

    [Display(Name = "Consignor Name")]
    public string ConsignorName { get; set; }

    public string ConsigneeCode { get; set; }

    [Display(Name = "Consignee Name")]
    public string ConsigneeName { get; set; }

    public short DeliverPartyId { get; set; }

    [Required(ErrorMessage = "Deliver Party Code")]
    [Display(Name = "Deliver Party Code")]
    public string DeliverPartyCode { get; set; }

    [Display(Name = "Deliver Party Name")]
    public string DeliverPartyName { get; set; }


    [Display(Name = "Is Partial")]
    public bool IsPartial { get; set; }
    }
}

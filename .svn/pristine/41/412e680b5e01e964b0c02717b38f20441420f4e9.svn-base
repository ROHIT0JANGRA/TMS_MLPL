//  
// Type: CodeLock.Models.PutAwayDetail
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class PutAwayDetail : ProductDetail
  {
    public byte CompanyId { get; set; }

    public short WarehouseId { get; set; }

    public int SkuId { get; set; }

    public string SkuCode { get; set; }
    public string SkuName { get; set; }

    public long PutAwayId { get; set; }

    public string PutAwayNo { get; set; }

    public DateTime PutAwayDate { get; set; }

    public long GrnId { get; set; }

    public string GrnNo { get; set; }

    [Display(Name = "GRN Quantity")]
    public Decimal GrnQuantity { get; set; }

    public bool IsSerialNumber { get; set; }

    public bool? IsSingle { get; set; }

    public bool IsChecked { get; set; }

    public List<PutAwayBinDetail> BinDetails { get; set; }

    public string FirstSerialNo { get; set; }

    public string SecondSerialNo { get; set; }
  }
}

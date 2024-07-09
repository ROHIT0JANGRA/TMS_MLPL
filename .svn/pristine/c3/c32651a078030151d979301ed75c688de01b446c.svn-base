
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractDefineChargeMatrixHDR
  {
    public short ContractId { get; set; }

    [Display(Name = "Charge Type")]
    public bool IsBooking { get; set; }

    [Display(Name = "Delivery")]
    public bool IsDelivery { get; set; }

    public byte BaseOn { get; set; }

    public byte BaseCode { get; set; }
    public bool UsePartVolumetric { get; set; }

    public List<CustomerContractDefineChargeMatrix> Details { get; set; }
  }
}

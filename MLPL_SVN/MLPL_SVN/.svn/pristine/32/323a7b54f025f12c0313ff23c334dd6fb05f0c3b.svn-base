using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractChargeMatrixLTLHeader
  {
    public short ContractId { get; set; }

    public byte TransportModeId { get; set; }

    public bool IsBooking { get; set; }

    public byte BaseOn1 { get; set; }

    public byte BaseCode1 { get; set; }

    public byte BaseOn2 { get; set; }

    public short BaseCode2 { get; set; }

    public byte MatrixType { get; set; }

    public short FromLocationId { get; set; }

    public short ToLocationId { get; set; }

    public string FromLocation { get; set; }

    public string ToLocation { get; set; }

    [Required(ErrorMessage = "Please select Consignor")]
    [Display(Name = "Consignor")]
    public short ConsignorId { get; set; }

    public string ConsignorName { get; set; }

    [Required(ErrorMessage = "Please select Consignee")]
    [Display(Name = "Consignee")]
    public short ConsigneeId { get; set; }

    public string ConsigneeName { get; set; }

    public List<CustomerContractChargeMatrixLTL> Details { get; set; }
  }
}

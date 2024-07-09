using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractRateMatrix : BaseModel
  {
    public CustomerContractRateMatrix()
    {
      this.RateDetails = new List<CustomerContractRateMetrixSlabRate>();
      this.RangeDetails = new List<CustomerContractRateMatrixSlabRange>();
    }

    public short ContractId { get; set; }

    public short RateMatrixId { get; set; }

    public byte TransportModeId { get; set; }

    public bool IsBooking { get; set; }

    public byte BaseOn1 { get; set; }

    public byte BaseCode1 { get; set; }

    public byte BaseOn2 { get; set; }

    public short BaseCode2 { get; set; }

    public byte FtlTypeId { get; set; }

    public byte ChargeCode { get; set; }

    public byte MatrixType { get; set; }

    public short FromLocation { get; set; }

    public string FromLocationCode { get; set; }

    public short ToLocation { get; set; }

    public string ToLocationCode { get; set; }

    public short ConsignorId { get; set; }

    public short ConsigneeId { get; set; }

    [Display(Name = "Transit Days")]
    [Range(0, 256, ErrorMessage = "Please enter Transit Days greater than zero")]
    [Required(ErrorMessage = "Please enter Transit Days")]
    public byte TransitDays { get; set; }

    public short BillLocationId { get; set; }

    [Required(ErrorMessage = "Please enter Billing Location")]
    [Display(Name = "Billing Location")]
    public string BillLocationCode { get; set; }

    public List<CustomerContractRateMetrixSlabRate> RateDetails { get; set; }

    public List<CustomerContractRateMatrixSlabRange> RangeDetails { get; set; }

    public int rowIndex { get; set; }
    }
}

using System;

namespace CodeLock.Models
{
  public class CustomerContractChargeMatrixFTL : BaseModel
  {
    public short ContractId { get; set; }

    public byte TransportModeId { get; set; }

    public bool IsBooking { get; set; }

    public byte BaseOn1 { get; set; }

    public byte BaseCode1 { get; set; }

    public byte BaseOn2 { get; set; }

    public byte BaseCode2 { get; set; }

    public byte FtlTypeId { get; set; }

    public byte MatrixType { get; set; }

    public short FromLocation { get; set; }

    public short ToLocation { get; set; }

    public Decimal Rate { get; set; }

    public byte RateType { get; set; }

    public byte TransitDays { get; set; }

    public short? BillLocationId { get; set; }
  }
}


using System;

namespace CodeLock.Models
{
  public class CustomerContractODAMatrix : BaseModel
  {
    public short ContractId { get; set; }

    public byte DistanceId { get; set; }

    public byte SlabId { get; set; }

    public Decimal Rate { get; set; }
  }
}

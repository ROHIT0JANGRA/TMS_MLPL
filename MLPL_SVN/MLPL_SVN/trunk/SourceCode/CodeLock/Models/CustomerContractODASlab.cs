
namespace CodeLock.Models
{
  public class CustomerContractODASlab : BaseModel
  {
    public short ContractId { get; set; }

    public byte SlabId { get; set; }

    public short FromKg { get; set; }

    public short ToKg { get; set; }
  }
}

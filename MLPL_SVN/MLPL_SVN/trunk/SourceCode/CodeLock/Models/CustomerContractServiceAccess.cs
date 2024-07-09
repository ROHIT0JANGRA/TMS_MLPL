namespace CodeLock.Models
{
  public class CustomerContractServiceAccess : BaseModel
  {
    public short ContractId { get; set; }

    public short ServiceTypeId { get; set; }

    public byte ServiceId { get; set; }

    public byte TransportModeId { get; set; }
  }
}

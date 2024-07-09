
using System;
namespace CodeLock.Models
{
  public class BaBillDetail
  {
    public long DocketId { get; set; }

    public string DocketNo { get; set; }

    public DateTime DocketDate { get; set; }

    public string Paybas { get; set; }

    public string Origin { get; set; }

    public string Destination { get; set; }

    public int Packages { get; set; }

    public Decimal ChargeWeight { get; set; }

    public Decimal SubTotal { get; set; }

    public Decimal BasicFreight { get; set; }

    public Decimal Rate { get; set; }

    public Decimal ContractAmount { get; set; }

    public byte RateTypeId { get; set; }

    public string RateType { get; set; }
  }
}

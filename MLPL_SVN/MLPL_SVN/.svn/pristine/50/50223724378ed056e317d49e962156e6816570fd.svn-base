
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerContractRateMetrixSlabRate
  {
    public CustomerContractRateMetrixSlabRate()
    {
      this.ContractId = (short) 0;
      this.SlabId = (byte) 0;
      this.Rate = new Decimal(0);
      this.RateMatrixId = (short) 0;
      this.FromLocation = (short) 0;
      this.ToLocation = (short) 0;
    }
        public int rowIndex { get; set; }
        public short ContractId { get; set; }

    public short RateMatrixId { get; set; }

    public byte SlabId { get; set; }

    public short FromLocation { get; set; }

    public short ToLocation { get; set; }

    [Range(0, 999999999, ErrorMessage = "Please enter Rate greater than zero")]
    [Required(ErrorMessage = "Please enter Rate")]
    [Display(Name = "Rate")]
    public Decimal Rate { get; set; }

        public string ApplyRateType { get; set; }

        [Range(0, 999999999, ErrorMessage = "Please enter Incremental Weight greater than zero")]
        [Display(Name = "Incremental Weight")]
        public Decimal IncrementalWeight { get; set; }

        [Range(0, 999999999, ErrorMessage = "Please enter Incremental Rate greater than zero")]
        [Display(Name = "Incremental Rate")]
        public Decimal IncrementalRate { get; set; }

        public string hdApplyRateType { get; set; }

        
        
    }
}

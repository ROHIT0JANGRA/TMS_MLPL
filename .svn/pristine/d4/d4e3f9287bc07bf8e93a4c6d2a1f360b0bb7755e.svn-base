
using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class CustomerContract : BaseModel
    {
        public CustomerContract()
        {
            this.CustomerContractBasicInfo = new CustomerContractBasicInfo();
        }

        [Display(Name = "Contract Id")]
        public string ManualContractId { get; set; }

        [Display(Name = "Contract Id")]
        public short ContractId { get; set; }

        [Required(ErrorMessage = "Please select Paybas")]
        [Display(Name = "Paybas")]
        public byte PaybasId { get; set; }

        public string Paybas { get; set; }

        [Display(Name = "Customer Name")]
        [Required(ErrorMessage = "Please select Customer Name")]
        public short CustomerId { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please select Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please select End Date")]
        public DateTime EndDate { get; set; }

        public bool IsCustomerContract { get; set; }

        public string LocationCode { get; set; }

        public short BillGenerationLocationId { get; set; }

        public bool IsBillLocationEditable { get; set; }

        public string Category { get; set; }

        public string CategoryForContract { get; set; }

        public string StepSelection { get; set; }

        public CustomerContractBasicInfo CustomerContractBasicInfo { get; set; }
        public bool IsMilkrunHrsPerDayEnabled { get; set; }
        public bool IsLaneEnabled { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeLock.Models
{
    public class VendorContractDefineChargeMatrixHDR
    {
        [Key]
        public short ContractId { get; set; }

        [Display(Name = "Charge Type")]
        public bool IsBooking { get; set; }

        [Display(Name = "Delivery")]
        public bool IsDelivery { get; set; }

        public byte BaseOn { get; set; }

        public byte BaseCode { get; set; }

        public List<VendorContractDefineChargeMatrix> Details { get; set; }
    }
}
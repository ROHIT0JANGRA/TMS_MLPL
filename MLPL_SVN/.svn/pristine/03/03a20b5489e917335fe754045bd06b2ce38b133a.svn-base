using ExpressiveAnnotations.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VendorBillFinalizationProcess
    {
        [Display(Name = "Location")]
        public short LocationId { get; set; }

        public string LocationCode { get; set; }

        public short VendorId { get; set; }

        [RequiredIf("BillNo == null", ErrorMessage = "Please enter Vendor")]
        [Display(Name = "Vendor")]
        public string VendorCode { get; set; }

        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        public short EntryBy { get; set; }

        public byte CompanyId { get; set; }

        public string FinYear { get; set; }

        public List<FinalizationBillDetail> BillDetail { get; set; }
    }
}
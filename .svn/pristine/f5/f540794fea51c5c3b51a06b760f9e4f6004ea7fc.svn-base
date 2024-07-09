//  
// Type: CodeLock.Models.DispatchRegister
//  
//  
//  

using System;
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DispatchRegister
    {
        [Display(Name = "Dispatch No")]
        public string DispatchNo { get; set; }

        public DateTime? DispatchDateTime { get; set; }

        public string OrderNo { get; set; }
    }
    public class DispatchRegisterReport
    {
        //[Required(ErrorMessage = "Please select Vehicle")]
        public short VehicleId { get; set; }

        //[Required(ErrorMessage = "Please select Vehicle No")]
        public string VehicleNo { get; set; }

        public short ConsignorId { get; set; }

        public short ConsigneeId { get; set; }
        public short BillingPartyId { get; set; }

        public string InvoiceNo { get; set; }
        public string PartNo { get; set; }
        public string EwayBillNo { get; set; }
        public string DocketNo { get; set; }

        [Display(Name = "Location Type")]
        public short FromLocationTypeId { get; set; }
    }
}

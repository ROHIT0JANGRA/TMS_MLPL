using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Models
{
    public class GetEwayForTransporterWebtel
    {


    }
    public class GetEwayForTransporter
    {
        public string ErrorMessage { get; set; }
        public string GSTIN { get; set; }
        public string DocNo { get; set; }
        public string Date { get; set; }
        public int Old_EWayBill { get; set; }
        public int EWayBill { get; set; }
        public string ValidUpTo { get; set; }
        public string IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string VehicleNo { get; set; }
        public string SupplierState { get; set; }
        [NotMapped]
        public List<EwbDetail> ewbDetails { get; set; }
        public string Alert { get; set; }
    }

    public class GetEwayForDetails
    {
        public string ErrorMessage { get; set; }
        public string GSTIN { get; set; }
        public string DocNo { get; set; }
        public string Date { get; set; }
        public int Old_EWayBill { get; set; }
        public long EWayBill { get; set; }
        public string ValidUpTo { get; set; }
        public string IsSuccess { get; set; }
        public string ErrorCode { get; set; }
        public string VehicleNo { get; set; }
        public string SupplierState { get; set; }
        public EWBDetails ewbDetails { get; set; }
        public string Alert { get; set; }
    }
}
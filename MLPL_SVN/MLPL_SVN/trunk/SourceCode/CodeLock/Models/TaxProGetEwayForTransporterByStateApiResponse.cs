using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Models
{

    public class TaxProError
    {
        public string error_cd { get; set; }
        public string message { get; set; }
    }

    public class TaxProErrorList
    {
        public string status_cd { get; set; }
        public TaxProError error { get; set; }
    }

    public class TaxProGetEwayApiResponse
    {
        public long ewbNo { get; set; }
        public string ewbDate { get; set; }
        public string status { get; set; }
        public string validUpto { get; set; }
        public string errorMsg { get; set; }
        public int actualDist { get; set; }
        public string fromPlace { get; set; }
        public int fromStateCode { get; set; }
        public int fromPincode { get; set; }
        public int toPincode { get; set; }
        public string vehicleNo { get; set; }

    }

    public class TaxProGetEwayForTransporterByStateApiResponse
    {

        public long ewbNo { get; set; }
        public string ewbDate { get; set; }
        public string status { get; set; }
        public string genGstin { get; set; }
        public string docNo { get; set; }
        public string docDate { get; set; }
        public int delPinCode { get; set; }
        public int delStateCode { get; set; }
        public string delPlace { get; set; }
        public string validUpto { get; set; }
        public int extendedTimes { get; set; }
        public string rejectStatus { get; set; }
        
        [NotMapped]
        public List<TaxProGetEwayDetailsForTransporterByStateApiResponse> ewaydtl { get; set; }
    }
}
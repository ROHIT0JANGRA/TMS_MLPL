using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class VehicleLogRegister
    {
        [Display(Name = "Tripsheet Date")]
        public byte TripsheetDateType { get; set; }

        [Display(Name = "Vehicle No")]
        public short VehicleId { get; set; }

        public string VehicleNo { get; set; }

        [Display(Name = "Tripsheet No/Manual Tripsheet No")]
        public string TripsheetNo { get; set; }
    }
}
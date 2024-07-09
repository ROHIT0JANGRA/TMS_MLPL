using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace CodeLock.Models
{
    public class MasterUserVehicleMapping : Base
    {
        [Required(ErrorMessage = "User")]
        [Display(Name = "User")]
        public long UserId { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Vehicle")]
        public string Vehicle { get; set; }

        [Display(Name = "Assign Date")]
        public string AssignDate { get; set; }

        [Display(Name = "Assign By")]
        public string AssignBy { get; set; }

        [Display(Name = "No of Vehicle")]
        public string NoofVehicle { get; set; }

        [Display(Name = "Vehicle")]
        public string VehicleId { get; set; }

        public bool IsChecked { get; set; }

        [Display(Name = "Vehicle")]
        public List<MasterUserVehicleMapping> VehicleList { get; set; }



    }
}
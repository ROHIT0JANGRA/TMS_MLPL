using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace CodeLock.Models
{
    public class MasterTyreManufacturer : BaseModel
    {
        public  short ManufacturerId { get; set; }

        [Required(ErrorMessage = "Please enter Manufacturer Name")]
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }

        [Display(Name = "Manufacturer Address")]
        [Required(ErrorMessage = "Please enter Manufacturer Address")]
        public string ManufacturerAddress { get; set; }

        [Required(ErrorMessage = "Please enter TelePhone No")]
        [Display(Name = "TelePhone No")]
        [MobileAnnotation]
        public string ManufacturerTelNo { get; set; }

        public bool IsActive { get; set; }

    }
}
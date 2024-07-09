using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
    public class MasterTyrePosition : BaseModel
    {
        [Display(Name = "TyrePositionId")]
        public short TyrePositionid { get; set; }
        [Required(ErrorMessage = "Please enter VehicleType")]
        [Display(Name = "Vehicle Type")]
        public short VehicleTypeId { get; set; }
        [Display(Name = "Vehicle Type Name")]
        public string VehicleTypeName { get; set; }
        [Required(ErrorMessage = "Please enter Position Category")]
        [Display(Name = "Position Category")]
        public short PositionCategoryId { get; set; }
        [Display(Name = "Position Category Name")]
        public string PositionCategoryName { get; set; }
        //[Remote("IsPositionShortCodeAvailable", "TyrePosition", AdditionalFields = "TyrePositionid,_TyrePositionidToken", ErrorMessage = "PositionShortCode Name already exists.", HttpMethod = "POST")]
        //[StringLength(50, ErrorMessage = "Country Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
        [Display(Name = "Position Short Code")]
        [Required(ErrorMessage = "Please enter Position Short Code")]
        public string PositionShortCode { get; set; }
        [Required(ErrorMessage = "Please enter Tyre Position Description")]
        [Display(Name = "Tyre Position Description ")]
        public string TyrePositionDescription { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

    }
}
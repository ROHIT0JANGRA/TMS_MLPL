using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace CodeLock.Models
{
    public class MasterTyreSize : BaseModel
    {
        public short TyreSizeId { get; set; }

        [Remote("IsTyreSizeNameAvailable", "TyreSize", AdditionalFields = "TyreSizeId,_TyreSizeIdToken", ErrorMessage = "Tyre Size Name already exists.", HttpMethod = "POST")]
        [StringLength(100, ErrorMessage = "Tyre Size must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
        [Display(Name = "Tyre Size")]
        [Required(ErrorMessage = "Please Enter TyreSize Name")]
        public string TyreSizeName { get; set; }
        [Display(Name = "Tyre Type Category")]
        [Required(ErrorMessage = "Please Select Category")]
        public string TyreTypeCategory { get; set; }
       [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public string TyreTypeCategoryName { get; set; }

        public string TyreTypeCategoryList { get; set; }



    }
}
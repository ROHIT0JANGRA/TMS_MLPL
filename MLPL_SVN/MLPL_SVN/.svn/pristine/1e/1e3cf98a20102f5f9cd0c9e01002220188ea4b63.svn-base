using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CodeLock.Models
{
    public class MasterTyreModel : BaseModel
    {
        [Display(Name = "Tyre Model Id")]
        public short TyreModelId { get; set; }
        [Required(ErrorMessage = "Please enter TyreModelNo")]
        [Display(Name = "Tyre Model No")]
        public string TyreModelNo { get; set; }
        [Required(ErrorMessage = "Please enter TyreModelDescription")]
        [Display(Name = "Tyre Model Description")]
        public string TyreModelDescription { get; set; }
        [Required(ErrorMessage = "Please enter AverageTreadDepth")]
        [Display(Name = "Average Tread Depth")]
        public string AverageTreadDepth { get; set; }
        [Required(ErrorMessage = "Please enter Manufacturer")]
        [Display(Name = "Manufacturer")]
        public short ManufacturerId { get; set; }
        [Required(ErrorMessage = "Please enter TyreSize")]
        [Display(Name = "Tyre Size")]
        public short TyreSizeId { get; set; }
        [Required(ErrorMessage = "Please enter TyrePattern")]
        [Display(Name = "Tyre Pattern")]
        public short TyrePatternId { get; set; }
    }
}
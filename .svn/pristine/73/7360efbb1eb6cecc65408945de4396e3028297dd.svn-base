using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DocketReAssign : Base
    {
        public long DocketId { get; set; }

        [Display(Name = "Docket No")]
        [Required(ErrorMessage = "Please enter Docket No")]
        public string DocketNo { get; set; }

        [Display(Name = "Origin")]
        public string Origin { get; set; }

        [Display(Name = "Destination")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "Please select Re-Assign")]
        public long ToLocationId { get; set; }

        [Display(Name = "Re-Assign Location")]
        //[Required(ErrorMessage = "Please select Re-Assign")]
        public string ToLocation { get; set; }

        [Required(ErrorMessage = "Please enter Remarks")]
        [Display(Name = "Remarks")]
        public string Remarks { get; set; }

        [Display(Name = "Docket Status")]
        public string DocketStatus { get; set; }

        [Display(Name = "Submit")]
        public string Submit { get; set; }
        
        [Display(Name = "Docket Status")]
        [Required(ErrorMessage = "Please select docket status")]
        public string DocketStatusId { get; set; }

        [Display(Name = "Docket Status")]
        [Required(ErrorMessage = "Please select docket status")]
        public string DocketStatusCode { get; set; }

    }
}
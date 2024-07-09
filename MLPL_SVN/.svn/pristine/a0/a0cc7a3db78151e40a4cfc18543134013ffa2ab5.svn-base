using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class DownloadFinanceReport
    {
        [Required(ErrorMessage = "Please select Report Type")]
        public string ReportTypeId { get; set; }

        public string PickupID { get; set; }
        [Display(Name = "Is Individual")]
        public bool IsIndividual { get; set; }
        [Required(ErrorMessage = "Please select Location")]
        [Display(Name = "Location")]
        public short LocationId { get; set; }

        public long CustomerId { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { get; set; }

        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

    }
}
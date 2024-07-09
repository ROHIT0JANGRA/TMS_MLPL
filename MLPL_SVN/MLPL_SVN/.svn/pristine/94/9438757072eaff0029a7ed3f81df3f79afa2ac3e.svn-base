using System.ComponentModel.DataAnnotations;


namespace CodeLock.Models
{
    public class ExpenseRegisterDocumentWise
    {
        [Display(Name = "Report Type")] 
        public byte ReportType { get; set; }

        [Display(Name = "Document No")]
        public string DocumentNos { get; set; }

        [Display(Name = "Manual Document No")]
        public string ManualDocumentNos { get; set; }
        [Display(Name = "Vendor")]
        public string PartyCode { get; set; }

        public string PartyName { get; set; }

        public short PartyId { get; set; }

        [Display(Name = "Location")]
        public short LocationId { get; set; }

        [Display(Name = "Is Individual")]
        public bool IsIndividual { get; set; }


        [Display(Name = "Bill Type")]
        [Required(ErrorMessage = "Please select Bill Type")]
        public byte PaybasId { get; set; }

    }

}
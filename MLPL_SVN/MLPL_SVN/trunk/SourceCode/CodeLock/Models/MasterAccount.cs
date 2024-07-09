//  
// Type: CodeLock.Models.MasterAccount
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
    public class MasterAccount : BaseModel
    {
        public short AccountId { get; set; }

        [Display(Name = "Account Code")]
        public string AccountCode { get; set; }

        [Display(Name = "Account Category")]
        [Required(ErrorMessage = "Please select Account Category")]
        public byte AccountCategoryId { get; set; }

        [Display(Name = "Account Group")]
        [Required(ErrorMessage = "Please select Account Group")]
        public short AccountGroupId { get; set; }

        [Required(ErrorMessage = "Account Description cannot be blank")]
        [StringLength(100, ErrorMessage = "Account Description must be minimum 2 and maximum 100 character long", MinimumLength = 2)]
        [Display(Name = "Account Description")]
        public string AccountDescription { get; set; }

        [Required(ErrorMessage = "Please select Company")]
        [Display(Name = "Company")]
        public new byte CompanyId { get; set; }

        [Required(ErrorMessage = "Please select Party Type")]
        [Display(Name = "Party Type")]
        public byte PartyTypeId { get; set; }

        [Display(Name = "Mapped Account")]
        public short MappedAccountId { get; set; }

        [Display(Name = "Main Category")]
        [Required(ErrorMessage = "Please select Main Category")]
        public short MainCategoryId { get; set; }

        [Display(Name = "Main Category Name")]
        public string MainCategoryName { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        public string PartyAccount { get; set; }

        public string CategoryName { get; set; }

        public string GroupCode { get; set; }

        [Required(ErrorMessage = "Please enter Account Locations")]
        [Display(Name = "Account Locations")]
        public string AccountLocation { get; set; }

        public string SavedAccountLocation { get; set; }

        [Display(Name = "VENDOR")]
        public short PartyId { get; set; }

        public string PartyCode { get; set; }
        //[Required(ErrorMessage = "Please enter NEFT Code")]
        [Display(Name = "NEFT Code")]
        public string NEFTCode { get; set; }
    }
}

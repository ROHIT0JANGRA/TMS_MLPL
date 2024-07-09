//  
// Type: CodeLock.Models.RateInquiry
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class RateInquiry : BaseModel
  {
    [Display(Name = "Customer Name")]
    [Required(ErrorMessage = "Please select Customer Name")]
    public short CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string CustomerCode { get; set; }

    [Required(ErrorMessage = "Please select Matrix Type")]
    [Display(Name = "Matrix Type")]
    public byte MatrixType { get; set; }

    public short FromLocationId { get; set; }

    [Display(Name = "From ")]
    [Required(ErrorMessage = "Please select From Location")]
    public string FromLocation { get; set; }

    public short ToLocationId { get; set; }

    [Display(Name = "To ")]
    [Required(ErrorMessage = "Please select To Location")]
    public string ToLocation { get; set; }

    public string Rate { get; set; }

        [Display(Name = "Contract To")]
        public string Paybas { get; set; }
    }
}

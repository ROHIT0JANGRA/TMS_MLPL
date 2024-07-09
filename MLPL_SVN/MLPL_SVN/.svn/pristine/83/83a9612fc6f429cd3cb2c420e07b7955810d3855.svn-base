
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class CustomerGstRegistrationDetail
  {
    public short CustomerId { get; set; }

    public short StateId { get; set; }

    [Required(ErrorMessage = "Please enter State")]
    public string StateName { get; set; }

    [Required(ErrorMessage = "Please enter Address")]
    public string Address { get; set; }

    public int CityId { get; set; }

    [Required(ErrorMessage = "Please enter City")]
    public string CityName { get; set; }

    [StringLength(10, ErrorMessage = "Provisional ID/No must be 10 character long", MinimumLength = 10)]
    [Required(ErrorMessage = "Please enter Provisional ID/No")]
    public string ProvisionalId { get; set; }

    [Display(Name = "Gst Type")]
    public string GstType { get; set; }

    [GstInNoAnnotation]
    [Required(ErrorMessage = "Please enter GSTIN No")]
    [StringLength(15, ErrorMessage = "GSTIN No must be 15 character long", MinimumLength = 15)]
    public string GstTinNo { get; set; }
  }
}

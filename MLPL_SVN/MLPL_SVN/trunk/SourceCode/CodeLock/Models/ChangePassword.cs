
using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class ChangePassword : BaseModel
  {
    public short UserId { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please enter New Password")]
    [StringLength(25, ErrorMessage = "Password must be minimum 6 and maximum 25 character long", MinimumLength = 6)]
    [Display(Name = "New Password")]
    public string NewPassword { get; set; }

    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Please enter Confirm Password")]
    [StringLength(25, ErrorMessage = "Password must be minimum 6 and maximum 25 character long", MinimumLength = 6)]
    public string ConfirmPassword { get; set; }
  }
}

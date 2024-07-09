//  
// Type: CodeLock.Models.Login
//  
//  
//  

using System.ComponentModel.DataAnnotations;

namespace CodeLock.Models
{
  public class Login
  {
    [Required(ErrorMessage = "Please enter your User Name")]
    [Display(Name = "User Name")]
    [StringLength(50, ErrorMessage = "User Name must be minimum 2 and maximum 50 character long", MinimumLength = 2)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Please enter your Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}

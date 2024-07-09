//  
// Type: MobileAnnotation
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class MobileAnnotation : RegularExpressionAttribute
{
  static MobileAnnotation()
  {
    DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (MobileAnnotation), typeof (RegularExpressionAttributeAdapter));
  }

  public MobileAnnotation()
    : base("^(\\+91[\\-\\s]?)?[0]?(91)?[6789]\\d{9}$")
  {
  }

  public override string FormatErrorMessage(string name)
  {
    return "Mobile No is not valid";
  }
}

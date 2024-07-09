//  
// Type: OnlyAlphaAnnotation
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class OnlyAlphaAnnotation : RegularExpressionAttribute
{
  static OnlyAlphaAnnotation()
  {
    DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (OnlyAlphaAnnotation), typeof (RegularExpressionAttributeAdapter));
  }

  public OnlyAlphaAnnotation()
    : base("[a-zA-Z]*")
  {
  }

  public override string FormatErrorMessage(string name)
  {
    return "Only alphabets are allowed";
  }
}

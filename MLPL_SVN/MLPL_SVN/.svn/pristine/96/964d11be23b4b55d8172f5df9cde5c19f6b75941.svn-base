//  
// Type: PanNoAnnotation
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class PanNoAnnotation : RegularExpressionAttribute
{
  static PanNoAnnotation()
  {
    DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (PanNoAnnotation), typeof (RegularExpressionAttributeAdapter));
  }

  public PanNoAnnotation()
    : base("([A-Za-z]{5}\\d{4}[A-Za-z]{1})$")
  {
  }

  public override string FormatErrorMessage(string name)
  {
    return "PAN No. is not valid";
  }
}

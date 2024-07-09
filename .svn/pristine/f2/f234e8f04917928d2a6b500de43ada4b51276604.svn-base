//  
// Type: TimeAnnotation
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class TimeAnnotation : RegularExpressionAttribute
{
  static TimeAnnotation()
  {
    DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (TimeAnnotation), typeof (RegularExpressionAttributeAdapter));
  }

  public TimeAnnotation()
    : base("^(1?[0-9]|2[0-3]):[0-5][0-9]$")
  {
  }

  public override string FormatErrorMessage(string name)
  {
    return "Time Format is not valid";
  }
}

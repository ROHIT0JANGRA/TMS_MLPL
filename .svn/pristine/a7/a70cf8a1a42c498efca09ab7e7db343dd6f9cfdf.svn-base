//  
// Type: GstInNoAnnotation
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class GstInNoAnnotation : RegularExpressionAttribute
{
  static GstInNoAnnotation()
  {
    DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (GstInNoAnnotation), typeof (RegularExpressionAttributeAdapter));
  }

  public GstInNoAnnotation()
    : base("([0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]([A-Z]|[0-9]){3})$")
  {
  }

  public override string FormatErrorMessage(string name)
  {
    return "GSTIN No is not valid";
  }
}

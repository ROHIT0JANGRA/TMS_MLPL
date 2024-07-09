//  
// Type: NameAnnotation
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class NameAnnotation : RegularExpressionAttribute
{
  static NameAnnotation()
  {
    DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (NameAnnotation), typeof (RegularExpressionAttributeAdapter));
  }

  public NameAnnotation()
    : base("[a-zA-Z& .]*")
  {
  }

  public override string FormatErrorMessage(string name)
  {
    return "Only alphabets, space and ampersand(&) are allowed";
  }
}

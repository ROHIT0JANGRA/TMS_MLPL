//  
// Type: EmailAnnotation
//  
//  
//  

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class EmailAnnotation : RegularExpressionAttribute
{
  static EmailAnnotation()
  {
    DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof (EmailAnnotation), typeof (RegularExpressionAttributeAdapter));
  }

  public EmailAnnotation()
    : base("^[\\w!#$%&'*+\\-/=?\\^_`{|}~]+(\\.[\\w!#$%&'*+\\-/=?\\^_`{|}~]+)*@((([\\-\\w]+\\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\\.){3}[0-9]{1,3}))$")
  {
  }

  public override string FormatErrorMessage(string name)
  {
    return "Email Id is not valid";
  }
}

//  
// Type: GreaterThanZeroAnnotation
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class GreaterThanZeroAnnotation : ValidationAttribute, IClientValidatable
{
  public override bool IsValid(object value)
  {
    if (value == null)
      return false;
    if (value.GetType() != typeof (int) && value.GetType() != typeof (long) && (value.GetType() != typeof (double) && value.GetType() != typeof (float)) && value.GetType() != typeof (Decimal))
      throw new InvalidOperationException("can only be used on int, long, double, float, decimal properties.");
    return Convert.ToDouble(value) > 0.0;
  }

  public override string FormatErrorMessage(string name)
  {
    return "The " + name + " field must contain a minimum value of 1 in order to continue.";
  }

  public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
    ModelMetadata metadata,
    ControllerContext context)
  {
    yield return new ModelClientValidationRule()
    {
      ErrorMessage = string.IsNullOrEmpty(this.ErrorMessage) ? this.FormatErrorMessage(metadata.DisplayName) : this.ErrorMessage,
      ValidationType = "greaterthanzero"
    };
  }
}

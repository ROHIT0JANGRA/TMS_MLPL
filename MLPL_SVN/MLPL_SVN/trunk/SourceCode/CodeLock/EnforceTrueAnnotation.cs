//  
// Type: EnforceTrueAnnotation
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

public class EnforceTrueAnnotation : ValidationAttribute, IClientValidatable
{
  public override bool IsValid(object value)
  {
    if (value == null)
      return false;
    if (value.GetType() != typeof (bool))
      throw new InvalidOperationException("can only be used on boolean properties.");
    return (bool) value;
  }

  public override string FormatErrorMessage(string name)
  {
    return "The " + name + " field must be checked in order to continue.";
  }

  public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
    ModelMetadata metadata,
    ControllerContext context)
  {
    yield return new ModelClientValidationRule()
    {
      ErrorMessage = string.IsNullOrEmpty(this.ErrorMessage) ? this.FormatErrorMessage(metadata.DisplayName) : this.ErrorMessage,
      ValidationType = "enforcetrue"
    };
  }
}

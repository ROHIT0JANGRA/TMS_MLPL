//  
// Type: CodeLock.Models.ExtendedDataAnnotationsModelValidatorProvider
//  
//  
//  

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace CodeLock.Models
{
  public class ExtendedDataAnnotationsModelValidatorProvider : DataAnnotationsModelValidatorProvider
  {
    internal new static DataAnnotationsModelValidationFactory DefaultAttributeFactory = new DataAnnotationsModelValidationFactory(ExtendedDataAnnotationsModelValidatorProvider.Create);
    internal new static Dictionary<Type, DataAnnotationsModelValidationFactory> AttributeFactories = new Dictionary<Type, DataAnnotationsModelValidationFactory>()
    {
      {
        typeof (RegularExpressionAttribute),
        (DataAnnotationsModelValidationFactory) ((metadata, context, attribute) => (ModelValidator) new RegularExpressionAttributeAdapter(metadata, context, (RegularExpressionAttribute) attribute))
      },
      {
        typeof (RequiredAttribute),
        (DataAnnotationsModelValidationFactory) ((metadata, context, attribute) => (ModelValidator) new RequiredAttributeAdapter(metadata, context, (RequiredAttribute) attribute))
      }
    };

    internal static ModelValidator Create(
      ModelMetadata metadata,
      ControllerContext context,
      ValidationAttribute attribute)
    {
      return (ModelValidator) new DataAnnotationsModelValidator(metadata, context, attribute);
    }

    protected override IEnumerable<ModelValidator> GetValidators(
      ModelMetadata metadata,
      ControllerContext context,
      IEnumerable<Attribute> attributes)
    {
      List<ModelValidator> vals = base.GetValidators(metadata, context, attributes).ToList<ModelValidator>();
      if (metadata.ContainerType != (Type) null && ValidationManager.Validators.ContainsKey(metadata.ContainerType.Name))
      {
        Dictionary<string, ValidatorsValidatorProperty> validator = ValidationManager.Validators[metadata.ContainerType.Name];
        if (validator.ContainsKey(metadata.PropertyName))
        {
          ValidatorsValidatorProperty property = validator[metadata.PropertyName];
          if (property.Visible)
          {
            DataAnnotationsModelValidationFactory factory;
            if (property.Required)
            {
              ValidationAttribute required;
              if (metadata.ModelType == typeof (bool))
              {
                EnforceTrueAnnotation enforceTrueAnnotation = new EnforceTrueAnnotation();
                enforceTrueAnnotation.ErrorMessage = property.ErrorMessage;
                required = (ValidationAttribute) enforceTrueAnnotation;
              }
              else if (metadata.ModelType == typeof (int) || metadata.ModelType == typeof (long) || metadata.ModelType == typeof (double) || metadata.ModelType == typeof (float))
              {
                GreaterThanZeroAnnotation thanZeroAnnotation = new GreaterThanZeroAnnotation();
                thanZeroAnnotation.ErrorMessage = property.ErrorMessage;
                required = (ValidationAttribute) thanZeroAnnotation;
              }
              else
              {
                RequiredAttribute requiredAttribute = new RequiredAttribute();
                requiredAttribute.ErrorMessage = property.ErrorMessage;
                required = (ValidationAttribute) requiredAttribute;
              }
              if (!ExtendedDataAnnotationsModelValidatorProvider.AttributeFactories.TryGetValue(required.GetType(), out factory))
                factory = ExtendedDataAnnotationsModelValidatorProvider.DefaultAttributeFactory;
              yield return factory(metadata, context, required);
            }
            if (!string.IsNullOrEmpty(property.RegularExpression))
            {
              RegularExpressionAttribute expressionAttribute = new RegularExpressionAttribute(property.RegularExpression);
              expressionAttribute.ErrorMessage = property.ErrorMessage;
              RegularExpressionAttribute regEx = expressionAttribute;
              if (!ExtendedDataAnnotationsModelValidatorProvider.AttributeFactories.TryGetValue(regEx.GetType(), out factory))
                factory = ExtendedDataAnnotationsModelValidatorProvider.DefaultAttributeFactory;
              yield return factory(metadata, context, (ValidationAttribute) regEx);
            }
            if (!string.IsNullOrEmpty(property.Compare))
            {
              System.ComponentModel.DataAnnotations.CompareAttribute compareAttribute = new System.ComponentModel.DataAnnotations.CompareAttribute(property.Compare);
              compareAttribute.ErrorMessage = property.ErrorMessage;
              System.ComponentModel.DataAnnotations.CompareAttribute compare = compareAttribute;
              if (!ExtendedDataAnnotationsModelValidatorProvider.AttributeFactories.TryGetValue(compare.GetType(), out factory))
                factory = ExtendedDataAnnotationsModelValidatorProvider.DefaultAttributeFactory;
              yield return factory(metadata, context, (ValidationAttribute) compare);
            }
          }
        }
      }
    }
  }
}

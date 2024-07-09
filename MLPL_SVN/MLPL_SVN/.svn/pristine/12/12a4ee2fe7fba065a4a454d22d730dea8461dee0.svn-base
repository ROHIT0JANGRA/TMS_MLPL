//  
// Type: CodeLock.Models.ValidationManager
//  
//  
//  

using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace CodeLock.Models
{
  public static class ValidationManager
  {
    private static Dictionary<string, Dictionary<string, ValidatorsValidatorProperty>> _validators = (Dictionary<string, Dictionary<string, ValidatorsValidatorProperty>>) null;
    private static global::Validators _validatorLib;

    private static global::Validators validatorLib
    {
      get
      {
        if (ValidationManager._validatorLib == null)
        {
          using (XmlReader xmlReader = XmlReader.Create(HttpContext.Current.ApplicationInstance.Server.MapPath("~/Models/Validator.xml")))
            ValidationManager._validatorLib = (global::Validators) new XmlSerializer(typeof (global::Validators)).Deserialize(xmlReader);
        }
        return ValidationManager._validatorLib;
      }
    }

    public static Dictionary<string, Dictionary<string, ValidatorsValidatorProperty>> Validators
    {
      get
      {
        if (ValidationManager._validators == null)
        {
          ValidationManager._validators = new Dictionary<string, Dictionary<string, ValidatorsValidatorProperty>>();
          foreach (ValidatorsValidator validatorsValidator in ValidationManager.validatorLib.Items)
          {
            Dictionary<string, ValidatorsValidatorProperty> dictionary = new Dictionary<string, ValidatorsValidatorProperty>();
            foreach (ValidatorsValidatorProperty validatorProperty in validatorsValidator.Property)
              dictionary.Add(validatorProperty.Name, validatorProperty);
            ValidationManager._validators.Add(validatorsValidator.Type, dictionary);
          }
        }
        return ValidationManager._validators;
      }
    }

    public static void Refresh()
    {
      ValidationManager._validators.Clear();
      ValidationManager._validators = (Dictionary<string, Dictionary<string, ValidatorsValidatorProperty>>) null;
      ValidationManager._validatorLib = (global::Validators) null;
    }
  }
}

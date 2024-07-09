//  
// Type: CodeLock.Models.RegisterValidation
//  
//  
//  

using CodeLock.Areas.Master.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace CodeLock.Models
{
  public static class RegisterValidation
  {
    public static void Init()
    {
      List<MasterFields> list1 = FieldsUtility.GetAll(new byte?((byte) 0), "").ToList<MasterFields>();
      List<string> moduleList = list1.GroupBy<MasterFields, string>((Func<MasterFields, string>) (m => m.ModuleName)).Select<IGrouping<string, MasterFields>, string>((Func<IGrouping<string, MasterFields>, string>) (n => n.Key)).ToList<string>();
      Validators validators = new Validators();
      validators.Items = new ValidatorsValidator[moduleList.Count<string>()];
      for (int i = 0; i < moduleList.Count<string>(); ++i)
      {
        List<ValidatorsValidatorProperty> list2 = list1.Where<MasterFields>((Func<MasterFields, bool>) (m => m.ModuleName == moduleList[i])).Select<MasterFields, ValidatorsValidatorProperty>((Func<MasterFields, ValidatorsValidatorProperty>) (field => new ValidatorsValidatorProperty()
        {
          Name = field.FieldName,
          Required = field.IsMandatory,
          Visible = field.IsEnabled,
          ErrorMessage = "Please enter " + field.FieldCaption
        })).ToList<ValidatorsValidatorProperty>();
        validators.Items[i] = new ValidatorsValidator()
        {
          Property = list2.ToArray(),
          Type = moduleList[i]
        };
      }
      using (TextWriter textWriter = (TextWriter) new StreamWriter(HttpContext.Current.Server.MapPath("~/Models/Validator.xml")))
        new XmlSerializer(typeof (Validators)).Serialize(textWriter, (object) validators);
      HttpContext.Current.Application["FieldList"] = (object) list1;
    }
  }
}

//  
// Type: DisplayName
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

public class DisplayName : DisplayNameAttribute
{
  public DisplayName(string moduleName, string fieldName)
  {

 }

  public static string Name(string moduleName, string fieldName)
  {
    try
    {
      return ((IEnumerable<MasterFields>) HttpContext.Current.Application["FieldList"]).Where<MasterFields>((Func<MasterFields, bool>) (m => m.ModuleName == moduleName && m.FieldName == fieldName)).FirstOrDefault<MasterFields>().FieldCaption;
    }
    catch
    {
      return fieldName;
    }
  }

  public static string GetList(string moduleName)
  {
    new List<MasterFields>() { new MasterFields() };
    try
    {
      return new JavaScriptSerializer().Serialize((object) ((IEnumerable<MasterFields>) HttpContext.Current.Application["FieldList"]).Where<MasterFields>((Func<MasterFields, bool>) (m => m.ModuleName == moduleName)));
    }
    catch
    {
      return string.Empty;
    }
  }
}

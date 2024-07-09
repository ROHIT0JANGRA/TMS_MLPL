//  
// Type: ValidatorsValidatorProperty
//  
//  
//  

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "4.0.30319.1")]
[XmlType(AnonymousType = true)]
[DesignerCategory("code")]
[DebuggerStepThrough]
[Serializable]
public class ValidatorsValidatorProperty
{
  private string nameField;
  private bool requiredField;
  private bool visibleField;
  private string errorMessageField;
  private string regularExpressionField;
  private string compareField;

  public ValidatorsValidatorProperty()
  {
    this.requiredField = false;
    this.visibleField = true;
  }

  [XmlAttribute]
  public string Name
  {
    get
    {
      return this.nameField;
    }
    set
    {
      this.nameField = value;
    }
  }

  [XmlAttribute]
  [DefaultValue(false)]
  public bool Required
  {
    get
    {
      return this.requiredField;
    }
    set
    {
      this.requiredField = value;
    }
  }

  [DefaultValue(true)]
  [XmlAttribute]
  public bool Visible
  {
    get
    {
      return this.visibleField;
    }
    set
    {
      this.visibleField = value;
    }
  }

  [XmlAttribute]
  public string ErrorMessage
  {
    get
    {
      return this.errorMessageField;
    }
    set
    {
      this.errorMessageField = value;
    }
  }

  [XmlAttribute]
  public string RegularExpression
  {
    get
    {
      return this.regularExpressionField;
    }
    set
    {
      this.regularExpressionField = value;
    }
  }

  [XmlAttribute]
  public string Compare
  {
    get
    {
      return this.compareField;
    }
    set
    {
      this.compareField = value;
    }
  }
}

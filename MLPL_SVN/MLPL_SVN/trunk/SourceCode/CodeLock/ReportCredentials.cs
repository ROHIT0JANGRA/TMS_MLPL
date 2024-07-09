//  
// Type: ReportCredentials
//  
//  
//  

using Microsoft.Reporting.WebForms;
using System.Net;
using System.Security.Principal;

public class ReportCredentials : IReportServerCredentials
{
  private string _userName;
  private string _password;
  private string _domain;

  public ReportCredentials(string userName, string password, string domain)
  {
    this._userName = userName;
    this._password = password;
    this._domain = domain;
  }

  public WindowsIdentity ImpersonationUser
  {
    get
    {
      return (WindowsIdentity) null;
    }
  }

  public ICredentials NetworkCredentials
  {
    get
    {
      return (ICredentials) new NetworkCredential(this._userName, this._password, this._domain);
    }
  }

  public bool GetFormsCredentials(
    out Cookie authCoki,
    out string userName,
    out string password,
    out string authority)
  {
    userName = this._userName;
    password = this._password;
    authority = this._domain;
    authCoki = new Cookie(".ASPXAUTH", ".ASPXAUTH", "/", "Domain");
    return true;
  }
}

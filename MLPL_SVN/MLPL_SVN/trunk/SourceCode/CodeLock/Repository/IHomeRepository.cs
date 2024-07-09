//  
// Type: CodeLock.Repository.IHomeRepository
//  
//  
//  

using System;
using CodeLock.Helper;
using CodeLock.Models;

namespace CodeLock.Repository
{
  public interface IHomeRepository : IDisposable
  {
        bool IsDocketNoAvailable(string DocketNo, int DocketId);
        DocketStatus DocketStatusGetByCode(string DocketNo);
        string GetAppSettingById(short docketNomenclature);
        EmailConfig GetEmailConfig();
  }
}

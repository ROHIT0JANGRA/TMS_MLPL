//  
// Type: CodeLock.Models.DcrManagementHistory
//  
//  
//  

using System;

namespace CodeLock.Models
{
  public class DcrManagementHistory
  {
    public string BookCode { get; set; }

    public string Action { get; set; }

    public DateTime ActionDate { get; set; }

    public string SeriesFrom { get; set; }

    public string SeriesTo { get; set; }
  }
}

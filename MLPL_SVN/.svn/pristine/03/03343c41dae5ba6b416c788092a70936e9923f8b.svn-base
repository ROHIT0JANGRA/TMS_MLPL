//  
// Type: CodeLock.Areas.Master.Repository.BudgetRepository
//  
//  
//  

using CodeLock.Models;
using CodeLock.Repository;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public class BudgetRepository : BaseRepository, IBudgetRepository, IDisposable
  {
    public IEnumerable<AutoCompleteResult> GetBudgetFinancialYearList()
    {
      return (IEnumerable<AutoCompleteResult>) new List<AutoCompleteResult>()
      {
        new AutoCompleteResult() { Value = "1", Name = "2016-17" },
        new AutoCompleteResult() { Value = "1", Name = "2015-16" },
        new AutoCompleteResult() { Value = "2", Name = "2014-15" },
        new AutoCompleteResult() { Value = "3", Name = "2013-14" },
        new AutoCompleteResult() { Value = "4", Name = "2012-13" },
        new AutoCompleteResult() { Value = "5", Name = "2011-12" },
        new AutoCompleteResult() { Value = "6", Name = "2010-11" }
      };
    }
  }
}

using CodeLock.Models;
using System.Collections.Generic;

namespace CodeLock.Helper
{
  public class Dashboard
  {
    public List<AutoCompleteResult> WmsSummary { get; set; }

    public List<AutoCompleteResult> ProductList { get; set; }

    public List<MasterMenu> MenuList { get; set; }
  }
}

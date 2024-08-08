using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLock.Areas.Reports.Repository
{
    public interface IAnalysisRepository
    {
        IEnumerable<AdvanceFilterColumns> GetAdvanceSearchingColumnList(string FormName);
    }
}

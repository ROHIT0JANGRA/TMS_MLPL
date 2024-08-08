using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CodeLock.Areas.Reports.Repository
{
    public class AnalysisRepository : BaseRepository, IAnalysisRepository, IDisposable
    {
        public IEnumerable<AdvanceFilterColumns> GetAdvanceSearchingColumnList(string FormName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FormName", (object)FormName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());  
            return Helper.DataBaseFactory.QuerySP<AdvanceFilterColumns>("USP_GetSearchingColumnList", (object)dynamicParameters, "Report-GetAdvanceSearchingColumnList");
        }
    }
}
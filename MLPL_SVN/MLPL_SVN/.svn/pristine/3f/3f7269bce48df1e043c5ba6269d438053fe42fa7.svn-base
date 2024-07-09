//  
// Type: CodeLock.Areas.Master.Repository.FinancialYearRightRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
  public class FinancialYearRightRepository : BaseRepository, IFinancialYearRightRepository, IDisposable
  {
    public Response Insert(
      MasterFinancialYearRight objMasterFinancialYearRight)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlFinancialYearInsert", (object) XmlUtility.XmlSerializeToString((object) objMasterFinancialYearRight), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterFinancialYearRight_Insert", (object) dynamicParameters, "Master Financial Year Right - Insert").FirstOrDefault<Response>();
    }
  }
}

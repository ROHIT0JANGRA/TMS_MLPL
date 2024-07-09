//  
// Type: CodeLock.Areas.Master.Repository.AccountOpeningRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
  public class AccountOpeningRepository : BaseRepository, IAccountOpeningRepository, IDisposable
  {
    public IEnumerable<AccountOpeningDetail> GetAll(
      bool isLocationWise,
      short id,
      byte accountCategoryId,
      short accountId,
      short locationId)
    {
            
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@IsLocationWise", (object) isLocationWise, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Id", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountCategoryId", (object) accountCategoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountId", (object) accountId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinYear", (object)SessionUtility.FinYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AccountOpeningDetail>("Usp_MasterAccountOpening_GetAll", (object) dynamicParameters, "Account Opening Master - GetAll");
    }

    public Response InsetUpdate(MasterAccountOpening objAccountOpening)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAccountOpening", (object) XmlUtility.XmlSerializeToString((object) objAccountOpening), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterAccountOpening_InsertUpdate", (object) dynamicParameters, "Account Opening Master - Insert/Update").FirstOrDefault<Response>();
    }
  }
}

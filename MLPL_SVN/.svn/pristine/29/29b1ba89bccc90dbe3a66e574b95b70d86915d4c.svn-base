//  
// Type: CodeLock.Areas.Master.Repository.ChargeRepository
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
  public class ChargeRepository : BaseRepository, IChargeRepository, IDisposable
  {
    public MasterCharge GetChargeByTypeId(byte chargeType, byte chargeCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ChargeType", (object) chargeType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ChargeCode", (object) chargeCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCharge>("Usp_MasteCharge_GetChargeByTypeId", (object) dynamicParameters, "Charge Master - GetChargeByTypeId").FirstOrDefault<MasterCharge>();
    }
  }
}

//  
// Type: CodeLock.Areas.Master.Repository.SkuLocationMappingRepository
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
  public class SkuLocationMappingRepository : BaseRepository, ISkuLocationMappingRepository, IDisposable
  {
    public Response AddressMapping(
      MasterSkuLocationMapping objMasterSkuLocationMapping)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlSkuLocationMapping", (object) XmlUtility.XmlSerializeToString((object) objMasterSkuLocationMapping), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterSkuLocationMapping", (object) dynamicParameters, "SkuLocationMapping Master - Insert").FirstOrDefault<Response>();
    }

    public IEnumerable<MasterSkuLocationMapping> GetSkuLocationMappingList(
      byte skuId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@SkuId", (object) skuId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterSkuLocationMapping>("Usp_MasterSkuLocationMapping_GetSkuLocationMappingList", (object) dynamicParameters, "Master Sku Location Mapping - GetSkuLocationMappingList");
    }
  }
}

//  
// Type: CodeLock.Areas.Master.Repository.FuelSurchargeRevisioinRepository
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
  public class FuelSurchargeRevisioinRepository : BaseRepository, IFuelSurchargeRevisioinRepository, IDisposable
  {
    public IEnumerable<FuelSurchargeRevision> GetAll()
    {
      return DataBaseFactory.QuerySP<FuelSurchargeRevision>("Usp_FuelSurchargeRevision_GetAll", (object) null, "FuelSurchargeRevision Master - GetAll");
    }

    public FuelSurchargeRevision GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@RevisionId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      Tuple<IEnumerable<FuelSurchargeRevision>, IEnumerable<MasterFuelSurchargeRevisionRate>> tuple = DataBaseFactory.QueryMultipleSP<FuelSurchargeRevision, MasterFuelSurchargeRevisionRate>("Usp_FuelSurchargeRevision_GetById", (object) dynamicParameters, "FuelSurchargeRevision Master - GetById");
      FuelSurchargeRevision surchargeRevision = new FuelSurchargeRevision();
      if (tuple != null)
      {
        surchargeRevision = tuple.Item1.FirstOrDefault<FuelSurchargeRevision>();
        surchargeRevision.MasterFuelSurchargeRevisionRate = tuple.Item2.ToList<MasterFuelSurchargeRevisionRate>();
      }
      return surchargeRevision;
    }

    public string GetManualContractId(short contractId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ContractId", (object) contractId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ManualContractId", (object) null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(10));
      DataBaseFactory.QuerySP("Usp_FuelSurchargeRevision_GetManualContractId", (object) dynamicParameters, "FuelSurchargeRevision Master - GetManualContractId");
      return dynamicParameters.Get<string>("@ManualContractId");
    }

    public Response Insert(FuelSurchargeRevision objFuelSurchargeRevision)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlFuelSurchargeRevision", (object) XmlUtility.XmlSerializeToString((object) objFuelSurchargeRevision), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_FuelSurchargeRevision_Insert", (object) dynamicParameters, "FuelSurchargeRevision Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(FuelSurchargeRevision objFuelSurchargeRevision)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlFuelSurchargeRevision", (object) XmlUtility.XmlSerializeToString((object) objFuelSurchargeRevision), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_FuelSurchargeRevision_Update", (object) dynamicParameters, "FuelSurchargeRevision Master - Update").FirstOrDefault<Response>();
    }
  }
}

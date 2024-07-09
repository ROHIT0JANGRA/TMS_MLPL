//  
// Type: CodeLock.Areas.Master.Repository.ProductTemperatureRepository
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
  public class ProductTemperatureRepository : BaseRepository, IProductTemperatureRepository, IDisposable
  {
    public IEnumerable<MasterProductTemperature> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterProductTemperature>("Usp_MasterProductTemperature_GetAll", (object) null, "Master Product Temperature- GetAll");
    }

    public MasterProductTemperature GetById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ProductId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterProductTemperature>("Usp_MasterProductTemperature_GetById", (object) dynamicParameters, "Product Temperature Master - GetById").FirstOrDefault<MasterProductTemperature>();
    }

    public void InsertUpdate(MasterProductTemperature objProductTemperature)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlProduct", (object) XmlUtility.XmlSerializeToString((object) objProductTemperature), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ProductId", (object) objProductTemperature.ProductId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterProductTemperature_InsertUpdate", (object) dynamicParameters, "Product Temperature Master - Insert");
    }
  }
}

//  
// Type: CodeLock.Areas.Master.Repository.GeneralRepository
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
  public class GeneralRepository : BaseRepository, IGeneralRepository, IDisposable
  {
    public IEnumerable<MasterGeneral> GetCodeTypeList()
    {
      return DataBaseFactory.QuerySP<MasterGeneral>("Usp_MasterGeneral_GetCodeType", (object) null, "General Master - GetCodeTypeList");
    }

        public IEnumerable<AutoCompleteResult> GetAllPkgWarehouseList()
        {

            var data = DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_PKG_WarehouseMaster", (object)null, "General Warehouse Master - GetPKGWarehouseList");
            return data;
        }
        public string GetCodeTypeById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CodeTypeId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CodeType", (object) null, new DbType?(DbType.String), new ParameterDirection?(ParameterDirection.Output), new int?(100));
      DataBaseFactory.QuerySP("Usp_MasterGeneral_GetCodeTypeById", (object) dynamicParameters, "General Master - GetCodeTypeById");
      return dynamicParameters.Get<string>("@CodeType");
    }

    public MasterGeneral GetById(short id, short codeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CodeTypeId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CodeId", (object) codeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterGeneral>("Usp_MasterGeneral_GetById", (object) dynamicParameters, "General Master - GetById").FirstOrDefault<MasterGeneral>();
    }

    public IEnumerable<AutoCompleteResult> GetByIdList(short codeTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CodeTypeId", (object) codeTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGeneral_GetByIdList", (object) dynamicParameters, "General Master - GetByIdList");
    }

   public IEnumerable<AutoCompleteResult> GetPayBasList(short codeTypeId)
     {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeTypeId", (object)codeTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterGeneral_PayBasList", (object)dynamicParameters, "General Master - GetByIdList");
     }

   public IEnumerable<MasterGeneral> GetByGeneralList(short codeTypeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CodeTypeId", (object) codeTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterGeneral>("Usp_MasterGeneral_GetByGeneralList", (object) dynamicParameters, "General Master - GetByGeneralList");
    }

    public IEnumerable<MasterGeneral> GetAll(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CodeTypeId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterGeneral>("Usp_MasterGeneral_GetAll", (object) dynamicParameters, "General Master - GetAll");
    }

    public bool Insert(MasterGeneral objMasterGeneral)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlGeneral", (object) XmlUtility.XmlSerializeToString((object) objMasterGeneral), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Status", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterGeneral_Insert", (object) dynamicParameters, "General Master - Insert");
      return dynamicParameters.Get<bool>("@Status");
    }

    public bool Update(MasterGeneral objMasterGeneral)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlGeneral", (object) XmlUtility.XmlSerializeToString((object) objMasterGeneral), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@Status", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterGeneral_Update", (object) dynamicParameters, "General Master - Update");
      return dynamicParameters.Get<bool>("@Status");
    }

    public bool IsGeneralNameAvailable(string codeDescription, short codeTypeId, short codeId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CodeDescription", (object) codeDescription, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CodeTypeId", (object) codeTypeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CodeId", (object) codeId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterGeneral_CheckGeneral", (object) dynamicParameters, "General Master - IsGeneralNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

        public Response InsertFormDocumentImage(string DocumentId, string DocumentType, string FileName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocumentId", (object)DocumentId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocumentType", (object)DocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FileName", (object)FileName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_FormDocumentImage_Insert", (object)dynamicParameters, "FormDocumentImage - Insert").FirstOrDefault<Response>();
        }
        public CodeTypeByName GetByPayBaseName(string payBaseName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeType", (object)payBaseName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CodeTypeByName>("Usp_MasterGeneral_GetByName", (object)dynamicParameters, "MasterGeneral GetByPaybasName").FirstOrDefault<CodeTypeByName>();
        }
        public CodeTypeByName GetTransportMode(string transportName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeType", (object)transportName, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CodeTypeByName>("Usp_MasterGeneral_GetTransportMode", (object)dynamicParameters, "General Master - GetTransportMode").FirstOrDefault<CodeTypeByName>();
        }
        public CodeTypeByName GetServiceType(string serviceName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeType", (object)serviceName, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CodeTypeByName>("Usp_MasterGeneral_GetServiceType", (object)dynamicParameters, "General Master - GetServiceType").FirstOrDefault<CodeTypeByName>();
        }
        public CodeTypeByName GetFTLType(string ftlTypeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeType", (object)ftlTypeName, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CodeTypeByName>("Usp_MasterGeneral_GetFTLType", (object)dynamicParameters, "General Master - GetFTLType").FirstOrDefault<CodeTypeByName>();
        }
        public CodeTypeByName GetPickupDelivery(string pickupDelivery)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeType", (object)pickupDelivery, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CodeTypeByName>("Usp_MasterGeneral_GetPickupDelivery", (object)dynamicParameters, "General Master - GetPickupDelivery").FirstOrDefault<CodeTypeByName>();
        }
        public CodeTypeByName GetPackageType(string packageTypeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeType", (object)packageTypeName, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CodeTypeByName>("Usp_MasterGeneral_GetPackageType", (object)dynamicParameters, "General Master - GetPackageType").FirstOrDefault<CodeTypeByName>();
        }
        public CodeTypeByName GetProductType(string productTypeName)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CodeType", (object)productTypeName, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CodeTypeByName>("Usp_MasterGeneral_GetProductType", (object)dynamicParameters, "General Master - GetPickupDelivery").FirstOrDefault<CodeTypeByName>();
        }
    }
}

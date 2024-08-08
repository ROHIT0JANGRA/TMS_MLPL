//  
// Type: CodeLock.Areas.Master.Repository.IGeneralRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IGeneralRepository : IDisposable
  {
    IEnumerable<MasterGeneral> GetCodeTypeList();

    string GetCodeTypeById(short id);

    MasterGeneral GetById(short id, short codeId);

    IEnumerable<AutoCompleteResult> GetByIdList(short codeTypeId);

   IEnumerable<AutoCompleteResult> GetPayBasList(short codeTypeId);
   IEnumerable<MasterGeneral> GetByGeneralList(short codeTypeId);

    IEnumerable<MasterGeneral> GetAll(short id);

    bool Insert(MasterGeneral objMasterGeneral);

    bool Update(MasterGeneral objMasterGeneral);

    bool IsGeneralNameAvailable(string codeDescription, short codeTypeId, short codeId);
    Response InsertFormDocumentImage(string DocumentId, string DocumentType, string FileName);
        CodeTypeByName GetByPayBaseName(string payBaseName);
        CodeTypeByName GetTransportMode(string transportName);
        CodeTypeByName GetServiceType(string serviceName);
        CodeTypeByName GetFTLType(string ftlTypeName);
        CodeTypeByName GetPickupDelivery(string pickupDelivery);
        CodeTypeByName GetPackageType(string packageTypeName);
        CodeTypeByName GetProductType(string productTypeName);
        IEnumerable<AutoCompleteResult> GetAllPkgWarehouseList();
    }
}

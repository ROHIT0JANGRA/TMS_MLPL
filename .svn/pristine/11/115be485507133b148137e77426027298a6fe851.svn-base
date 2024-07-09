//  
// Type: CodeLock.Areas.Master.Repository.IVehicleDocumentTypeRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IVehicleDocumentTypeRepository : IDisposable
  {
    MasterVehicleDocumentType GetById(short id);

    IEnumerable<MasterVehicleDocumentType> GetAll();

    short Insert(
      MasterVehicleDocumentType objMasterVehicleDocumentType);

    short Update(
      MasterVehicleDocumentType objMasterVehicleDocumentType);

    bool IsDocumentAvailable(string VehicleDocument, short VehicleDocumentId);
  }
}

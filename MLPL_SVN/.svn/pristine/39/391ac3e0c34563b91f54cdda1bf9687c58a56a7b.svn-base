//  
// Type: CodeLock.Areas.Master.Repository.IUserCompanyRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IUserCompanyRepository : IDisposable
  {

        Response VehicleMapping(
        MasterUserVehicleMapping objMasterUserCompanyMapping);

        IEnumerable<MasterUserVehicleMapping> GetVahicleMappingByUserId(
                long userId);
   IEnumerable<MasterUserVehicleMapping> GetUserVehicleMapping();
    IEnumerable<MasterUserCompanyMapping> GetMapping();

    IEnumerable<MasterUserCompanyMapping> GetMappingByUserId(
      short userId);

    Response Mapping(
      MasterUserCompanyMapping objMasterUserCompanyMapping);
  }
}

//  
// Type: CodeLock.Areas.Master.Repository.ISacRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ISacRepository : IDisposable
  {
    MasterSac GetById(byte id);

    IEnumerable<MasterSac> GetAll();

    byte Insert(MasterSac objMasterSac);

    byte Update(MasterSac objMasterSac);

    bool IsSacNameAvailable(string sacName, byte sacId);

    bool IsSacCodeAvailable(string sacCode, byte sacId);

    IEnumerable<ServiceTypeToSacMapping> ServiceTypeToSacMapping(
      IEnumerable<ServiceTypeToSacMapping> objServiceTypeToSacMapping);

    IEnumerable<TransportModeToServiceMapping> TransportModeToServiceMapping(
      IEnumerable<TransportModeToServiceMapping> objTransportModeToServiceMapping);

    IEnumerable<AutoCompleteResult> GetSacList();

    IEnumerable<AutoCompleteResult> GetServiceList();

    IEnumerable<AutoCompleteResult> GetSacCategoryList();

    IEnumerable<ServiceTypeToSacMapping> GetServiceTypeToSacMapping();

    IEnumerable<TransportModeToServiceMapping> GetTransportModeToServiceMapping();

    IEnumerable<AutoCompleteResult> GetGstRateList();
  }
}

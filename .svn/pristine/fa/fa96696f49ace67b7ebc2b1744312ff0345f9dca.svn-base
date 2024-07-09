//  
// Type: CodeLock.Areas.Master.Repository.IAirportRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IAirportRepository : IDisposable
  {
    IEnumerable<MasterAirport> GetAll();

    MasterAirport GetDetailById(byte airportId, byte companyId);

    byte Insert(MasterAirport objMasterAirport);

    byte Update(MasterAirport objMasterAirport);

    IEnumerable<AutoCompleteResult> GetAirPortList();

    IEnumerable<AutoCompleteResult> GetAirLineList(byte airportId);

    IEnumerable<AutoCompleteResult> GetFlightList(
      byte airlineId,
      DateTime dateTime);

    bool IsAirportNameAvailable(string airportName, byte airportId);

    bool IsAirportNoAvailable(string airportNo, byte airportId);

    IEnumerable<AutoCompleteResult> GetAutoCompleteList(
      string airportNo);

    AutoCompleteResult CheckValidAirportNo(string airportNo);
  }
}

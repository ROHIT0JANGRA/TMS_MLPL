//  
// Type: CodeLock.Areas.Master.Repository.IFlightRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IFlightRepository : IDisposable
  {
    IEnumerable<MasterFlight> GetAll();

    MasterFlight GetDetailById(short id);

    short Insert(MasterFlight objMasterFlight);

    short Update(MasterFlight objMasterFlight);

    bool IsFlightNoAvailable(string flightNo, short flightId);

    IEnumerable<FlightDetail> GetFlightDetail(short id);
  }
}

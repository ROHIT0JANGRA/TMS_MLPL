//  
// Type: CodeLock.Areas.Master.Repository.IHolidayDateWiseRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface IHolidayDateWiseRepository : IDisposable
  {
    IEnumerable<MasterHolidayDateWise> GetAll();

    MasterHolidayDateWise GetById(byte id);

    short Insert(MasterHolidayDateWise objMasterHolidayDateWise);

    short Update(MasterHolidayDateWise objMasterHolidayDateWise);

    bool IsHolidayDateAvailable(DateTime holidayDate, short holidayId);

    bool IsDateHoliday(DateTime docketDate, short locationId);
  }
}

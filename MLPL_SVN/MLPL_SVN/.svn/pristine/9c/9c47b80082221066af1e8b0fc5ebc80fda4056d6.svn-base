//  
// Type: CodeLock.Areas.Master.Repository.HolidayDayWiseRepository
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
  public class HolidayDayWiseRepository : BaseRepository, IHolidayDayWiseRepository, IDisposable
  {
    public IEnumerable<MasterGeneral> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterGeneral>("Usp_MasterHolidayDayWise_GetAll", (object) null, "HolidayDayWise Master - GetAll");
    }

    public Response Insert(MasterHolidayDayWise objMasterHolidayDayWise)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlHoliday", (object) XmlUtility.XmlSerializeToString((object) objMasterHolidayDayWise), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterHolidayDayWise_Insert", (object) dynamicParameters, "HolidayDayWise Master - Insert").FirstOrDefault<Response>();
    }
  }
}

//  
// Type: CodeLock.Areas.Master.Repository.HolidayDateWiseRepository
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
  public class HolidayDateWiseRepository : BaseRepository, IHolidayDateWiseRepository, IDisposable
  {
    public IEnumerable<MasterHolidayDateWise> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterHolidayDateWise>("Usp_MasterHolidayDateWise_GetAll", (object) null, "HolidayDateWise Master - GetAll");
    }

    public MasterHolidayDateWise GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@HolidayId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterHolidayDateWise>("Usp_MasterHolidayDateWise_GetById", (object) dynamicParameters, "HolidayDateWise Master - GetById").FirstOrDefault<MasterHolidayDateWise>();
    }

    public short Insert(MasterHolidayDateWise objMasterHolidayDateWise)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlHoliday", (object) XmlUtility.XmlSerializeToString((object) objMasterHolidayDateWise), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@HolidayId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterHolidayDateWise_Insert", (object) dynamicParameters, "HolidayDateWise Master - Insert");
      return dynamicParameters.Get<short>("@HolidayId");
    }

    public short Update(MasterHolidayDateWise objMasterHolidayDateWise)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlHoliday", (object) XmlUtility.XmlSerializeToString((object) objMasterHolidayDateWise), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@HolidayId", (object) null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterHolidayDateWise_Update", (object) dynamicParameters, "HolidayDateWise Master - Update");
      return dynamicParameters.Get<short>("@HolidayId");
    }

    public bool IsHolidayDateAvailable(DateTime holidayDate, short holidayId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@HolidayId", (object) holidayId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@HolidayDate", (object) holidayDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterHolidayDateWise_IsNameAvailable", (object) dynamicParameters, "HolidayDateWise Master - IsHolidayDateAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public bool IsDateHoliday(DateTime docketDate, short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@DocketDate", (object) docketDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsDateHoliday", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterHolidayDateWise_IsDateHoliday", (object) dynamicParameters, "HolidayDateWise Master - IsDateHoliday");
      return dynamicParameters.Get<bool>("@IsDateHoliday");
    }
  }
}

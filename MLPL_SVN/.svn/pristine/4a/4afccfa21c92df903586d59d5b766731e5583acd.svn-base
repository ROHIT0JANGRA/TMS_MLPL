using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace CodeLock.Areas.Reports.Repository
{
  public class OperationRepository : BaseRepository, IOperationRepository, IDisposable
  {
    public IEnumerable<ReportFieldDetail> GetColumnListByReportId(
      byte reportId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ReportId", (object) reportId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<ReportFieldDetail>("Usp_Report_GetColumnListByReportId", (object) dynamicParameters, "Report - GetColumnListReportId");
    }

    public IEnumerable<DocketCharge> GetDocketCharges(
      byte baseOn,
      byte baseCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BaseOn", (object) baseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BaseCode", (object) baseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<DocketCharge>("Usp_Report_GetDocketCharges", (object) dynamicParameters, "Report - GetDocketCharges");
    }

    public IEnumerable<DocketCharge> GetDeliveryMrCharges(
      byte baseOn,
      byte baseCode)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@BaseOn", (object) baseOn, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BaseCode", (object) baseCode, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<DocketCharge>("Usp_Report_GetDeliveryMrCharges", (object) dynamicParameters, "Report - GetDeliveryMrCharges");
    }
  }
}

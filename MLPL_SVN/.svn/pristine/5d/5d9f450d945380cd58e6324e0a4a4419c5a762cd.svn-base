//  
// Type: CodeLock.Areas.FMS.Repository.JobOrderRepository
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

namespace CodeLock.Areas.FMS.Repository
{
  public class JobOrderRepository : BaseRepository, IJobOrderRepository, IDisposable
  {
    public AutoCompleteResult CheckValidVehicleNoForJobOrder(string vehicleNo)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleNo", (object) vehicleNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_JobOrder_CheckValidVehicleNoForJobOrder", (object) dynamicParameters, "Job Order - CheckValidVehicleNoForJobOrder").FirstOrDefault<AutoCompleteResult>();
    }

    public Response Insert(JobOrder objJobOrder)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlJobOrder", (object) XmlUtility.XmlSerializeToString((object) objJobOrder), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_JobOrder_Insert", (object) dynamicParameters, "Job Order - Insert").FirstOrDefault<Response>();
    }

    public Response Update(JobOrder objJobOrder)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlJobOrder", (object) XmlUtility.XmlSerializeToString((object) objJobOrder), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_JobOrder_Update", (object) dynamicParameters, "Job Order - Update").FirstOrDefault<Response>();
    }

    public IEnumerable<JobOrder> GetJobOrderListForApprove(
      DateTime fromDate,
      DateTime toDate,
      string jobOrderNo,
      byte jobCardType,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@JobCardType", (object) jobCardType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@JobOrderNo", (object) jobOrderNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<JobOrder>("Usp_JobOrder_GetJobOrderListForApprove", (object) dynamicParameters, "JobOrder - GetJobOrderListForApprove");
    }

    public Response Approve(JobOrderApprove objJobOrderApprove)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@JobOrderApprove", (object) XmlUtility.XmlSerializeToString((object) objJobOrderApprove), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_JobOrder_Approve", (object) dynamicParameters, "Job Order - Approve").FirstOrDefault<Response>();
    }

    public IEnumerable<JobOrder> GetJobOrderListForUpdate(
      DateTime fromDate,
      DateTime toDate,
      string jobOrderNo,
      byte jobCardType,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@JobCardType", (object) jobCardType, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@JobOrderNo", (object) jobOrderNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<JobOrder>("Usp_JobOrder_GetJobOrderListForUpdate", (object) dynamicParameters, "JobOrder - GetJobOrderListForUpdate");
    }

    public JobOrder GetById(long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@JobOrderId", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<JobOrder>("Usp_JobOrder_GetById", (object) dynamicParameters, "Job Order Master - GetById").FirstOrDefault<JobOrder>();
    }

    public IEnumerable<TaskDetail> GetTaskDetailById(long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@JobOrderId", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<TaskDetail>("Usp_JobOrder_GetTaskDetailById", (object) dynamicParameters, "JobOrder - GetTaskDetailById");
    }

    public IEnumerable<SparePartDetail> GetSparePartDetailById(long id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@JobOrderId", (object) id, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<SparePartDetail>("Usp_JobOrder_GetSparePartDetailById", (object) dynamicParameters, "JobOrder - GetSparePartDetailById");
    }

    public Response Close(JobOrder objJobOrder)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlJobOrder", (object) XmlUtility.XmlSerializeToString((object) objJobOrder), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_JobOrder_Close", (object) dynamicParameters, "Job Order - Close").FirstOrDefault<Response>();
    }
  }
}

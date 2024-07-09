//  
// Type: CodeLock.Areas.FMS.Repository.IJobOrderRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.FMS.Repository
{
  public interface IJobOrderRepository : IDisposable
  {
    AutoCompleteResult CheckValidVehicleNoForJobOrder(string vehicleNo);

    Response Insert(JobOrder objJobOrder);

    Response Update(JobOrder objJobOrder);

    IEnumerable<JobOrder> GetJobOrderListForApprove(
      DateTime fromDate,
      DateTime toDate,
      string jobOrderNo,
      byte jobCardType,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId);

    Response Approve(JobOrderApprove objJobOrderApprove);

    IEnumerable<JobOrder> GetJobOrderListForUpdate(
      DateTime fromDate,
      DateTime toDate,
      string jobOrderNo,
      byte jobCardType,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId);

    JobOrder GetById(long id);

    IEnumerable<TaskDetail> GetTaskDetailById(long id);

    IEnumerable<SparePartDetail> GetSparePartDetailById(long id);

    Response Close(JobOrder objJobOrder);
  }
}

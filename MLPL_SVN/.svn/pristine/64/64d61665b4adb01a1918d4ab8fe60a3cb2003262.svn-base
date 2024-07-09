using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Reports.Repository
{
  public interface IOperationRepository : IDisposable
  {
    IEnumerable<ReportFieldDetail> GetColumnListByReportId(byte reportId);

    IEnumerable<DocketCharge> GetDocketCharges(byte baseOn, byte baseCode);

    IEnumerable<DocketCharge> GetDeliveryMrCharges(
      byte baseOn,
      byte baseCode);
  }
}

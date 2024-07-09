//  
// Type: CodeLock.Areas.Master.Repository.ICustomerBillFormatRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ICustomerBillFormatRepository : IDisposable
  {
    IEnumerable<MasterCustomerBillFormat> GetAll(string groupCode);

    MasterCustomerBillFormat GetById(byte formatId);

    Response Mapping(MasterCustomerBillFormat objBillFormat);

    Response BillFormatMapping(
      MasterCustomerBillFormat objMasterCustomerBillFormatMapping);

    bool IsBillFormatMapped(short customerId);

    IEnumerable<AutoCompleteResult> GetBillFormatList();

    AutoCompleteResult GetBillFormatByCustomerId(
      short customerId,
      byte paybasId,
      byte transportModeId,
      byte serviceTypeId);

    IEnumerable<MasterCustomerBillFormat> GetBillFormat(
      string paybasId,
      string transportModeId,
      string serviceTypeId,
      byte formatId);
  }
}

//  
// Type: CodeLock.Areas.WMS.Repository.IGrnRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.WMS.Repository
{
  public interface IGrnRepository : IDisposable
  {
    Response Insert(Grn objGrn);

    bool IsFirstSerialNoExistForDispatch(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber);

    bool IsGrnExist(byte companyId, short warehouseId, int productId, long grnId);

    bool IsFirstSerialNoExistByGrnId(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      long grnId);

    bool IsFirstSerialNoExist(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber);

    bool IsSecondSerialNoExistForDispatch(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      string secondSerialNumber);

    bool IsSecondSerialNoExistByGrnId(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      string secondSerialNumber,
      long grnId);

    bool IsSecondSerialNoExist(
      byte companyId,
      short warehouseId,
      int productId,
      string firstSerialNumber,
      string secondSerialNumber);

    IEnumerable<Grn> GetGrnListForPutAway(
      byte companyId,
      short warehouseId,
      string grnNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate);

    IEnumerable<GrnDetail> GetGrnDetailsForPutAway(long[] grnIdList);

    Response InsertFromAsn(Grn objGrn);

    IEnumerable<GrnRegister> GetRegisterGrnDetail(
      string grnNo,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate);
  }
}

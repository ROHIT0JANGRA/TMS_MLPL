//  
// Type: CodeLock.Areas.Operation.Repository.IPfmRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Operation.Repository
{
  public interface IPfmRepository : IDisposable
  {
    IEnumerable<PfmDetails> GetDocketListForPfm(
      byte companyId,
      short locationId,
      string docketNoList,
      DateTime fromDate,
      DateTime toDate);

    Response InsertPfm(Pfm objPfm);

    IEnumerable<Pfm> GetPfmListForAcknowledge(
      byte companyId,
      short locationId,
      string pfmList,
      DateTime fromDate,
      DateTime toDate);

    IEnumerable<PfmDetails> GetPfmDocketListForAcknowledge(long pfmId);

    Response AcknowledgePfm(Pfm objPfm);

    Pod InsertPod(Pod objPfm);

    ScanDetail GetPodDetailByDocumentId(byte documentTypeId, long documentId);

    ScanDetail CheckPodScanStatus(
      string documentNo,
      byte documentTypeId,
      short locationId,
      string locationCode);

    Response InsertPODHandOver(DocumentTracking objPfm);
   IEnumerable<DocumentTracking> GetDocketPODHandOverList(
                  short locationId,
                  DateTime fromDate,
                  DateTime toDate,
                  string documentNo,
                  string manualDocumentNo,
                  int CustomerId,
                  int ListType);

    }
}

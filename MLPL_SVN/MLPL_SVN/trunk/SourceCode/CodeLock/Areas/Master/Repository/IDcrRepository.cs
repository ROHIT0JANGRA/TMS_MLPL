//  
// Type: CodeLock.Areas.Master.Repository.IDcrRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
    public interface IDcrRepository : IDisposable
    {
        MasterLocation IsDocumentNoDcrDumptcoExist(byte documentTypeId, string documentNo, short locationId, byte companyId);
        bool IsDocumentNoExist(byte documentTypeId, string documentNo, short locationId);

        bool IsBookCodeAvailable(byte documentTypeId, string bookCode);

        bool IsSeriesFromAvailable(byte documentTypeId, string seriesFrom, int totalLeaf);

        MasterDcr GetDetailByDocumentTypeIdAndDocumentNumber(
          byte documentTypeId,
          string seriesFrom);

        bool CheckValidSeriesFrom(string dcrSeriesFrom, string dcrSeriesTo, string seriesFrom);

        string GetMaxDocumentNumber(long documentId, string dcrSeriesFrom, string seriesFrom);

        int GetTotalLeaf(string seriesFrom, string dcrSeriesTo);

        IEnumerable<MasterDcr> GetAll();

        IEnumerable<MasterDcr> Insert(List<MasterDcr> objMasterDcr);

        IEnumerable<MasterDcr> DumtcoDcrInsert(List<MasterDcr> objMasterDcr);


        Response Split(MasterDcr objMasterDcr);

        Response Reallocate(MasterDcr objMasterDcr);

        IEnumerable<MasterDocumentControl> GetListByDocumentTypeId(
          byte documentTypeId,
          byte companyId);

        IEnumerable<DcrManagementHistory> GetManagementHistoryByDocumentTypeIdAndDocumentNumber(
          byte documentTypeId,
          string seriesFrom);

        Response IsDocumentAvailableForVoid(
          byte documentTypeId,
          string documentNo,
          short locationId);

        Response DocumentVoidInsert(
          long dcrId,
          string documentNo,
          short entryBy,
          byte companyId);

        IEnumerable<MasterDcr> InsertAFC(List<MasterDcr> objMasterDcr);
        bool IsSeriesFromAvailableAFC(byte documentTypeId, string seriesFrom, int totalLeaf);
        short GetDcrNoLength(byte documentTypeId);
    }
}

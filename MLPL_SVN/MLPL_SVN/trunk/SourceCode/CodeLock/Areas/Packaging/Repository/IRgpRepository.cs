using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace CodeLock.Areas.Packaging.Repository
{
    public interface IRgpRepository : IDisposable
    {
        IEnumerable<AutoCompleteResult> RGP_SeriesList();
        Task<string> GetRGPData();
        int InsertRGP(PackagingModel rgpChallan);
        Task<object> GetRGPDataListFromApi(int draw, int start, int length, string search);
        Task<Dictionary<string, object>> FetchBPMasterPagination(int start, int length, string search = null);
      //  Task<Dictionary<string, object>> GetRgpDetailsBySeriesNo(int? rgpSeriesNo);
        Task<Dictionary<string, object>> FetchRGPDataBySeriesNo(int? rgpSeriesNo);
        Task<List<Dictionary<string, object>>> GetTheRgpItemDetails(string cardCode, string FromWh);
        Task<int> FetchBPMasterCount(string countUrl);
        Task<Dictionary<string, object>> FetchBPMasterList(string Fetchurl, int start, int length, string search);
        //***************--Random methods for calling sap api ______________________ 
        HttpClient CreateHttpClient(string sessionId);
        Task<Stream> GetDecompressedStreamAsync(HttpResponseMessage response);
        Task<string> GetSessionIdAsync();
    }
}

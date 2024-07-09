using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.FMS.Repository;
using CodeLock.Models;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Web.Http;
using CodeLock.Areas.Operation.Repository;

namespace CodeLock.Areas.FMS.Api
{
    [RoutePrefix("api/Tripsheet")]
    public class TripsheetController : ApiController
    {
        private readonly ITripsheetRepository tripsheetRepository;
        private readonly IUserRepository userRepository;

        public TripsheetController(ITripsheetRepository _tripsheetRepository, IUserRepository _userRepository)
        {
            tripsheetRepository = _tripsheetRepository;
            userRepository = _userRepository;
        }

        [BasicAuthentication]
        [Route(nameof(DocketListByTripsheet))]
        [HttpGet]
        public HttpResponseMessage DocketListByTripsheet([FromUri] string tripsheetNo)
        {
            HttpResponseMessage response = null;
            DocketListByTripsheetApi docketListByTripsheetApiResponse = new DocketListByTripsheetApi();
            string json = string.Empty;
            docketListByTripsheetApiResponse = tripsheetRepository.GetDocketListByTripsheet(tripsheetNo);
            json = JsonConvert.SerializeObject(docketListByTripsheetApiResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [BasicAuthentication]
        [Route(nameof(DocketCartonListByTripsheet))]
        [HttpGet]
        public HttpResponseMessage DocketCartonListByTripsheet([FromUri] string tripsheetNo)
        {
            HttpResponseMessage response = null;
            DocketCartonListByTripsheetResponse docketCartonListByTripsheetResponse  = new DocketCartonListByTripsheetResponse();
            string json = string.Empty;
            docketCartonListByTripsheetResponse = tripsheetRepository.GetDocketCartonListByTripsheet(tripsheetNo);
            json = JsonConvert.SerializeObject(docketCartonListByTripsheetResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [BasicAuthentication]
        [Route(nameof(SubmitScanDocket))]
        [HttpPost]
        public HttpResponseMessage SubmitScanDocket([FromBody] ApiSubmitScanRequest apiSubmitScanRequest)
        {
            HttpResponseMessage response = null;
            ApiSubmitScanResponse apiSubmitScanResponse = new ApiSubmitScanResponse();
            string json = string.Empty;
            apiSubmitScanResponse = tripsheetRepository.SubmitScanDocket(apiSubmitScanRequest);
            json = JsonConvert.SerializeObject(apiSubmitScanResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }

        [BasicAuthentication]
        [Route(nameof(SubmitScanDocketCarton))]
        [HttpPost]
        public HttpResponseMessage SubmitScanDocketCarton([FromBody] ApiSubmitScanRequest apiSubmitScanRequest)
        {
            HttpResponseMessage response = null;
            ApiSubmitScanResponse apiSubmitScanResponse = new ApiSubmitScanResponse();
            string json = string.Empty;
            apiSubmitScanResponse = tripsheetRepository.SubmitScanDocketCarton(apiSubmitScanRequest);
            json = JsonConvert.SerializeObject(apiSubmitScanResponse);
            response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(json, Encoding.UTF8, "application/json");
            return response;
        }
    }
}

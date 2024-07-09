using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.IO.Compression;
using System.Linq;
using Newtonsoft.Json;

namespace CodeLock.Areas.Operation.Controllers
{
	public class TrackingController : Controller
	{
		private readonly ITrackingRepository trackingRepository;
		private readonly IGeneralRepository generalRepository;
		private readonly ILocationRepository locationRepository;
		private readonly ICustomerRepository customerRepository;

		public TrackingController()
		{


		}

		public TrackingController(
		  ITrackingRepository _trackingRepository,
		  IGeneralRepository _generalRepository,
		  ILocationRepository _locationRepository, ICustomerRepository _customerRepository)
		{
			this.trackingRepository = _trackingRepository;
			this.generalRepository = _generalRepository;
			this.locationRepository = _locationRepository;
			this.customerRepository = _customerRepository;
		}
		public ActionResult DownloadInZip(string files)
		{
			if (Session["docketDocumentName"] == null)
			{
				//return file
			}
			DataSet ds = (DataSet)Session["docketDocumentName"];

			List<fileInfo> listFiles = new List<fileInfo>();
			string fileSavePath = Server.MapPath("~/Storage/POD/");
			DirectoryInfo dirInfo = new DirectoryInfo(fileSavePath);
			string FileLoc = "", fileName = "";

			for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
			{
				fileName = ds.Tables[0].Rows[i]["DocumentName"].ToString();
				FileLoc = fileSavePath + fileName;

				if (System.IO.File.Exists(FileLoc))
				{
					listFiles.Add(new fileInfo()
					{
						FileId = i + 1,
						FilePath = FileLoc,
						FileName = fileName
					});
				}
			}

			var filesCol = listFiles;
			using (var memoryStream = new MemoryStream())
			{
				using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
				{
					for (int i = 0; i < filesCol.Count; i++)
					{
						ziparchive.CreateEntryFromFile(filesCol[i].FilePath, filesCol[i].FileName);
					}
				}
				return File(memoryStream.ToArray(), "application/zip", "PODAttachments.zip");
			}
		}
		public ActionResult IndexTriSpeed()
		{
			this.Init(0);
			return base.View();
		}

        public ActionResult IndexAlexis()
        {
            this.Init(0);
            return base.View();
        }

        public ActionResult Index()
		{
			this.Init(0);
			return base.View();
		}

        public ActionResult IndexV1()
        {
            this.Init(0);
            return base.View();
        }

        public ActionResult IndexLabourDC()
		{
			this.Init(0);
			return base.View();
		}

		public ActionResult IndexCustomer()
		{
			int rIndex;
			string CustomerId;
			DocumentTracking obj = new DocumentTracking();

			((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(23);


			IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);
			((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;

			rIndex = 0;
			CustomerId = "";

			foreach (var docket in iEnumerabledocket)
			{
				rIndex = rIndex + 1;
				if (rIndex == 1)
				{
					CustomerId = docket.Value;
				}
			}

			if (rIndex == 1)
			{
				obj.CustomerId = CustomerId;
			}

			return base.View(obj);
		}

		public ActionResult DownloadPOD(string filename)
		{
			string Content = "";
			string FileLoc = Server.MapPath("~/Storage/POD/");
			FileLoc = FileLoc + filename;

			if (System.IO.File.Exists(FileLoc))
			{
				if (Path.GetExtension(filename).ToLower() == ".gif")
				{
					Content = "image/gif";
				}

				else if (Path.GetExtension(filename).ToLower() == ".jpeg")
				{
					Content = "image/jpeg";
				}

				else if (Path.GetExtension(filename).ToLower() == ".jpg")
				{
					Content = "image/jpeg";
				}
				else if (Path.GetExtension(filename).ToLower() == ".png")
				{
					Content = "image/png";
				}
				else if (Path.GetExtension(filename).ToLower() == ".dwf")
				{
					Content = "Application/x-dwf";
				}
				else if (Path.GetExtension(filename).ToLower() == ".pdf")
				{
					Content = "Application/pdf";
				}
				else if (Path.GetExtension(filename).ToLower() == ".doc")
				{
					Content = "Application/vnd.ms-word";
				}
				else if (Path.GetExtension(filename).ToLower() == ".ppt" ||
					Path.GetExtension(filename).ToLower() == ".pps")
				{
					Content = "Application/vnd.ms-powerpoint";
				}
				else if (Path.GetExtension(filename).ToLower() == ".doc")
				{
					Content = "Application/vnd.ms-word";
				}
				else if (Path.GetExtension(filename).ToLower() == ".xls")
				{
					Content = "Application/vnd.ms-excel";
				}
				return File(FileLoc, Content);
			}
			else
			{
				return new HttpStatusCodeResult(System.Net.HttpStatusCode.Forbidden);
			}
		}

		public ActionResult InsertDone()
		{
			return base.View();
		}
		public ActionResult IndexDocketStatus()
		{
			((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(200);
			((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();

			return base.View();
		}

		[HttpPost]
		public ActionResult IndexDocketStatus(DocumentTracking objDocumentTracking)
		{
			ActionResult action;
			Response response = this.trackingRepository.InsertDocketChangeStatus(objDocumentTracking);
			if (response.IsSuccessfull)
			{
				action = base.RedirectToAction("InsertDone", new { id = response.DocumentId });
				return action;
			}

		   ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(200);
			((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
			action = base.View(objDocumentTracking);
			return action;
		}
		public ActionResult IndexPOD()
		{
			int rIndex;
			string CustomerId;

			DocumentTracking obj = new DocumentTracking();
			obj.localStoragePath = @Server.MapPath("~/Storage/POD/");
			IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);

			((dynamic)base.ViewBag).CustomerList = iEnumerabledocket;

			rIndex = 0;
			CustomerId = "";

			foreach (var docket in iEnumerabledocket)
			{
				rIndex = rIndex + 1;
				if (rIndex == 1)
				{
					CustomerId = docket.Value;
				}
			}

			if (rIndex == 1)
			{
				obj.CustomerId = CustomerId;
			}

			return base.View(obj);
		}
		public ActionResult Consignment()
		{
			return (ActionResult)this.View();
		}

		private void Init(byte locationHierarchyId)
		{
			((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(23);
			((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
		}

		public JsonResult GetDocketList(
	  short locationId,
	  DateTime fromDate,
	  DateTime toDate,
	  string documentNo,
	  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetDocketList(locationId, fromDate, toDate, documentNo, manualDocumentNo), JsonRequestBehavior.AllowGet);
		}
		public JsonResult GetDocketCustomerList(
		short locationId,
		DateTime fromDate,
		DateTime toDate,
		string documentNo,
		string manualDocumentNo,
		int CustomerId)
		{
			return this.Json((object)this.trackingRepository.GetDocketList(locationId, fromDate, toDate, documentNo, manualDocumentNo, CustomerId), JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetDocketListForChangeStatus(
		  string documentNo
		  )
		{
			IEnumerable<DocumentTracking> iEnumerabledocket = this.trackingRepository.GetDocketListForChangeStatus(documentNo);
			return this.Json((object)iEnumerabledocket, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetDocketPODList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo,
		  int CustomerId,
		  int ListType
		  )
		{

			IEnumerable<Docket> iEnumerabledocket = this.trackingRepository.GetDocketPODList(locationId, fromDate, toDate, documentNo, manualDocumentNo, CustomerId, ListType);

			DataSet ds = new DataSet();
			ds.Tables.Add("tblDocket");
			ds.Tables[0].Columns.Add("DocumentName");

			foreach (var docket in iEnumerabledocket)
			{
				DataRow dr = ds.Tables[0].NewRow();
				dr["DocumentName"] = docket.DocumentName.ToString();
				ds.Tables[0].Rows.Add(dr);
			}
			Session["docketDocumentName"] = ds;

			return this.Json((object)iEnumerabledocket, JsonRequestBehavior.AllowGet);
		}
		public JsonResult GetThcList(
	  short locationId,
	  DateTime fromDate,
	  DateTime toDate,
	  string documentNo,
	  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetThcList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetDrsList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetDrsList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetPrsList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetPrsList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetLoadingSheetList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetLoadingSheetList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetTripsheetList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetTripsheetList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetManifestList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetManifestList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetPfmList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetPfmList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetVrList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetVrList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public JsonResult GetConsignmentDetailsList(string documentNos, bool documentType)
		{
			return this.Json((object)this.trackingRepository.GetConsignmentDetailsList(documentNos, documentType));
		}

		public JsonResult GetConsignmentTransitDetails(long docketId, string docketSuffix)
		{
			return this.Json((object)this.trackingRepository.GetConsignmentTransitDetails(docketId, docketSuffix));
		}

		public JsonResult GetConsignmentTransitList(long docketId, string docketSuffix)
		{
			return this.Json((object)this.trackingRepository.GetConsignmentTransitList(docketId, docketSuffix));
		}

		public JsonResult GetDocketTalkList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetDocketTalkList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}
		public JsonResult GetUnLoadingSheetList(
		  short locationId,
		  DateTime fromDate,
		  DateTime toDate,
		  string documentNo,
		  string manualDocumentNo)
		{
			return this.Json((object)this.trackingRepository.GetUnLoadingSheetList(locationId, fromDate, toDate, documentNo, manualDocumentNo));
		}

		public ActionResult DocketTracking(long id)
		{
			return (ActionResult)this.View((object)new DocketTracking()
			{
				DocketId = id
			});
		}

		public JsonResult GetDocketTransitSummary(long docketId)
		{
			return this.Json((object)this.trackingRepository.GetDocketTransitSummary(docketId));
		}

		public JsonResult GetApiDocketStatus(string docketNo)
		{
			return this.Json((object)this.trackingRepository.GetApiDocketStatus(docketNo), JsonRequestBehavior.AllowGet);
		}

        [HttpPost]
        public JsonResult GetDocketListByPagination(Pagination pagination,short locationId, DateTime fromDate, DateTime toDate, string documentNo, string manualDocumentNo)
       {
            DTResponse DTResponse = new DTResponse();
            string sorting = pagination.data.columns[pagination.data.order[0].column].name == null ?
            "CD.DocketId asc" : pagination.data.columns[pagination.data.order[0].column].name + " " +
                pagination.data.order[0].dir;
            var DocketData = this.trackingRepository.GetDocketListByPagination(pagination.data.start, pagination.data.length, sorting, pagination.data.search.value, locationId, fromDate, toDate, documentNo, manualDocumentNo);
            DTResponse.recordsTotal = DocketData.FirstOrDefault() == null ? 0 : DocketData.FirstOrDefault().TotalDocket;
            DTResponse.recordsFiltered = DocketData.FirstOrDefault() == null ? 0 : DocketData.FirstOrDefault().FilterDockets; //pagination.data.search.value == null? customers.FirstOrDefault().TotalCustomers : customers.Count();
            DTResponse.data = JsonConvert.SerializeObject(DocketData);
            return Json(DTResponse, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVehicleGpsDetails(long fromDate,long toDate, string chassisNo)
        {
            return this.Json((object)this.trackingRepository.GetVehicleGpsDetails(fromDate, toDate, chassisNo), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
		{
			if (disposing)
				this.trackingRepository.Dispose();
			base.Dispose(disposing);
			if (disposing)
				this.generalRepository.Dispose();
			base.Dispose(disposing);
			if (disposing)
				this.locationRepository.Dispose();
			base.Dispose(disposing);
		}
	}
}

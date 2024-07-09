using CodeLock.Areas.Master.Repository;
using CodeLock.Areas.Operation.Repository;
using CodeLock.Areas.Reports.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Reports.Controllers
{
    public class OperationController : Controller
    {
        private readonly IOperationRepository operationRepository;
        private readonly IGeneralRepository generalRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IRouteRepository routeRepository;
        private readonly IPrsRepository prsRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IVehicleRepository vehicleRepository;

        public OperationController()
        {
        }

        public OperationController(IOperationRepository _operationRepository, IGeneralRepository _generalRepository, ILocationRepository _locationRepository, ICompanyRepository _companyRepository, IRouteRepository _routeRepository, IPrsRepository _prsRepository, ICustomerRepository _customerRepository, IVehicleRepository _vehicleRepository)
        {
            this.operationRepository = _operationRepository;
            this.generalRepository = _generalRepository;
            this.locationRepository = _locationRepository;
            this.companyRepository = _companyRepository;
            this.routeRepository = _routeRepository;
            this.prsRepository = _prsRepository;
            this.customerRepository = _customerRepository;
            this.vehicleRepository = _vehicleRepository;
        }
        public ActionResult CustomerDocketGPRORegister()
        {
            int rIndex;
            string CustomerName = "";

            DocketGPRORegister ObjReg = new DocketGPRORegister();
            IEnumerable<AutoCompleteResult> iEnumerabledocket = this.customerRepository.GetCustomerListUserwise(SessionUtility.LoginUserId);

            rIndex = 0;
            CustomerName = "";

            foreach (var docket in iEnumerabledocket)
            {
                rIndex = rIndex + 1;

                if (rIndex == 1)
                {
                    ObjReg.CustomerId = docket.Value.ConvertToShort();
                    ObjReg.CustomerName = docket.Name;
                    CustomerName = docket.Name;

                }
            }
            ((dynamic)base.ViewBag).CustomerName = CustomerName;
            return base.View(ObjReg);
        }

        public ActionResult DocketGPRORegister()
        {
            return base.View(new DocketGPRORegister());
        }
        public ActionResult CustomerCareReport()
        {
            return base.View(new SalesRegister());
        }

        public ActionResult DeliveryMrRegister()
        {
            DeliveryMrRegister deliveryMrRegister = new DeliveryMrRegister();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            return base.View(deliveryMrRegister);
        }

        public ActionResult DepsRegister()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(new DepsRegister());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.operationRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.generalRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.prsRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.routeRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.companyRepository.Dispose();
            }
            base.Dispose(disposing);
            if (disposing)
            {
                this.locationRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DocketGstRegister()
        {
            return base.View(new DocketGstRegister());
        }

        public ActionResult DocumentControlSeries()
        {
            DocumentControlSeries documentControlSeries = new DocumentControlSeries();
            ((dynamic)base.ViewBag).DocumentTypeList = this.generalRepository.GetByIdList(23);
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(documentControlSeries);
        }

        public JsonResult GetColumnListByReportId(byte reportId)
        {
            JsonResult jsonResult = base.Json(this.operationRepository.GetColumnListByReportId(reportId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetDeliveryMrCharges(byte baseOn, byte baseCode)
        {
            JsonResult jsonResult = base.Json(this.operationRepository.GetDeliveryMrCharges(baseOn, baseCode), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetDocketCharges(byte baseOn, byte baseCode)
        {
            JsonResult jsonResult = base.Json(this.operationRepository.GetDocketCharges(baseOn, baseCode), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
        public ActionResult SalesSummaryRegister()
        {
            SalesProfitability salesProfitability = new SalesProfitability()
            {
                FormatType = true
            };
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            return base.View(salesProfitability);
        }
        public ActionResult SalesProfitability()
        {
            SalesProfitability salesProfitability = new SalesProfitability()
            {
                FormatType = true
            };
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            return base.View(salesProfitability);
        }

        public ActionResult SalesRegister()
        {
            SalesRegister salesRegister = new SalesRegister()
            {
                BaseOn = 0
            };
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).LoadTypeList = this.generalRepository.GetByIdList(26);
            ((dynamic)base.ViewBag).PickupDeliveryTypeList = this.generalRepository.GetByIdList(19);
            ((dynamic)base.ViewBag).BookedByList = this.prsRepository.GetBookedByList();
            ViewBag.CustomerList = customerRepository.GetCustomerList();
            return base.View(salesRegister);
        }

        public ActionResult Stock(byte? id)
        {
            int num;
            StockReport stockReport = new StockReport()
            {
                ReportType = true,
                FormatType = true
            };
            ((dynamic)base.ViewBag).PaybasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).ServiceTypeList = this.generalRepository.GetByIdList(16);
            ((dynamic)base.ViewBag).BusinessTypeList = this.generalRepository.GetByIdList(22);
            ((dynamic)base.ViewBag).StockTypeList = this.generalRepository.GetByIdList(63);
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            dynamic viewBag = base.ViewBag;
            num = (id.ConvertToByte() == 0 ? 1 : (int)id.ConvertToByte());
            viewBag.ReportId = num;
            return base.View(stockReport);
        }

        public ActionResult TransitStatus()
        {
            return base.View(new TransitStatus());
        }

        public ActionResult VendorPerformanceMis()
        {
            ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetRouteNameList();
            return base.View(new VendorPerformance());
        }

        public ActionResult VrRegister()
        {
            return base.View();
        }

        public ActionResult WorkDone()
        {
            return base.View(new WorkDone()
            {
                DateType = true
            });
        }

        public ActionResult ServiceLevel()
        {
            return base.View(new SalesRegister());
        }

        public ActionResult DeliveryMRDetailRegister()
        {

            return base.View(new SalesRegister());
        }

        public ActionResult MovementAnalysisReport()
        {

            return base.View(new SalesRegister());
        }

        public ActionResult DispatchDLYBAReport()
        {

            return base.View(new SalesRegister());
        }

        public ActionResult DocketeWayBillRegister()
        {
            return base.View(new DocketGPRORegister());
        }

        public ActionResult LabourDCReport()
        {
            return base.View(new SalesRegister());
        }

        public ActionResult DispatchRegister()
        {
            ViewBag.VehicleList = vehicleRepository.GetVehicleList();
            ViewBag.CustomerList = customerRepository.GetCustomerList();
            return base.View(new DispatchRegisterReport());
        }

        public ActionResult VehicleProfitability()
        {
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetRouteNameList();
            return base.View();
        }
    }
}

using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using CodeLock.Repository;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IMenuRepository menuRepository;
        private readonly IDashboardRepository dashboardRepository;

        public DashboardController()
        {
        }

        public DashboardController(IMenuRepository _menuRepository, IDashboardRepository _dashboardRepository)
        {
            this.menuRepository = _menuRepository;
            this.dashboardRepository = _dashboardRepository;
        }

        public JsonResult GetAll()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetAll(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId));
            return jsonResult;
        }

        public ActionResult Index_Old()
        {
            ChartDetail chartDetail = new ChartDetail();
            chartDetail = this.dashboardRepository.GetAll(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            ChartDetail FleetTripsheet = new ChartDetail();
            FleetTripsheet = this.dashboardRepository.GetFleetTripsheetDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.FleetTripTotalGeneratedTripsList = FleetTripsheet.FleetTripTotalGeneratedTripsList;
            chartDetail.FleetTripPendingforOperationClosureList = FleetTripsheet.FleetTripPendingforOperationClosureList;
            chartDetail.FleetTripTripPendingForFinanceClosureList = FleetTripsheet.FleetTripTripPendingForFinanceClosureList;

            ChartDetail FinRece = new ChartDetail();
            FinRece = this.dashboardRepository.GetFinReceDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.FinReceTripsBillList = FinRece.FinReceTripsBillList;
            chartDetail.FinReceTBBList = FinRece.FinReceTBBList;
            chartDetail.FinRecePaidList = FinRece.FinRecePaidList;
            chartDetail.FinReceToPayList = FinRece.FinReceToPayList;

            ChartDetail FinColl = new ChartDetail();
            FinColl = this.dashboardRepository.GetFinCollDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.FinCollTripsBillList = FinColl.FinCollTripsBillList;
            chartDetail.FinCollTBBList = FinColl.FinCollTBBList;
            chartDetail.FinCollPaidList = FinColl.FinCollPaidList;
            chartDetail.FinCollToPayList = FinColl.FinCollToPayList;

            ChartDetail OpeBooking = new ChartDetail();
            OpeBooking = this.dashboardRepository.GetOperationalBookingDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.BookedShipmentList = OpeBooking.BookedShipmentList;
            chartDetail.LSPendingForMFList = OpeBooking.LSPendingForMFList;
            chartDetail.MFPendingForTHCList = OpeBooking.MFPendingForTHCList;
            chartDetail.VehiclePendingforUnloadList = OpeBooking.VehiclePendingforUnloadList;
            chartDetail.ShipmentPendingforDeliveryList = OpeBooking.ShipmentPendingforDeliveryList;
            chartDetail.DRSPendingForClosureList = OpeBooking.DRSPendingForClosureList;

            ((dynamic)base.ViewBag).MenuList = this.menuRepository.GetMenuListByUserId(SessionUtility.LoginUserId, SessionUtility.CompanyId);
            return base.View(chartDetail);
        }

        public ActionResult Index()
        {
            ChartDetail chartDetail = new ChartDetail();
            chartDetail = this.dashboardRepository.GetAll(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            ChartDetail FleetTripsheet = new ChartDetail();
            FleetTripsheet = this.dashboardRepository.GetFleetTripsheetDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.FleetTripTotalGeneratedTripsList = FleetTripsheet.FleetTripTotalGeneratedTripsList;
            chartDetail.FleetTripPendingforOperationClosureList = FleetTripsheet.FleetTripPendingforOperationClosureList;
            chartDetail.FleetTripTripPendingForFinanceClosureList = FleetTripsheet.FleetTripTripPendingForFinanceClosureList;

            ChartDetail FinRece = new ChartDetail();
            FinRece = this.dashboardRepository.GetFinReceDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.FinReceTripsBillList = FinRece.FinReceTripsBillList;
            chartDetail.FinReceTBBList = FinRece.FinReceTBBList;
            chartDetail.FinRecePaidList = FinRece.FinRecePaidList;
            chartDetail.FinReceToPayList = FinRece.FinReceToPayList;

            ChartDetail FinColl = new ChartDetail();
            FinColl = this.dashboardRepository.GetFinCollDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.FinCollTripsBillList = FinColl.FinCollTripsBillList;
            chartDetail.FinCollTBBList = FinColl.FinCollTBBList;
            chartDetail.FinCollPaidList = FinColl.FinCollPaidList;
            chartDetail.FinCollToPayList = FinColl.FinCollToPayList;

            ChartDetail OpeBooking = new ChartDetail();
            OpeBooking = this.dashboardRepository.GetOperationalBookingDetail(SessionUtility.CompanyId, SessionUtility.LoginLocationId, SessionUtility.LoginUserId);
            chartDetail.BookedShipmentList = OpeBooking.BookedShipmentList;
            chartDetail.LSPendingForMFList = OpeBooking.LSPendingForMFList;
            chartDetail.MFPendingForTHCList = OpeBooking.MFPendingForTHCList;
            chartDetail.VehiclePendingforUnloadList = OpeBooking.VehiclePendingforUnloadList;
            chartDetail.ShipmentPendingforDeliveryList = OpeBooking.ShipmentPendingforDeliveryList;
            chartDetail.DRSPendingForClosureList = OpeBooking.DRSPendingForClosureList;

            ((dynamic)base.ViewBag).MenuList = this.menuRepository.GetMenuListByUserId(SessionUtility.LoginUserId, SessionUtility.CompanyId);
            return base.View(chartDetail);
        }

        [HttpPost]
        public JsonResult GetPaybasWiseDocketCount()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetPaybasWiseDocketCount(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetCustomerBillWiseAmount()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetCustomerBillWiseAmount(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVendorBillWiseAmount()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetVendorBillWiseAmount(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetMonthWiseDocketCount()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetMonthWiseDocketCount(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetCustomerSales()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetCustomerSales(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetLocationSales()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetLocationSales(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDocketDeliveryDetails()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetDocketDeliveryDetails(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetLocationWiseDocketDeliveryDetails()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetLocationWiseDocketDeliveryDetails(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDocketDetails()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetDocketDetails(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDocketBillUnBilledDetails()
        {
            JsonResult jsonResult = base.Json(this.dashboardRepository.GetDocketBillUnBilledDetails(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }
    }
}

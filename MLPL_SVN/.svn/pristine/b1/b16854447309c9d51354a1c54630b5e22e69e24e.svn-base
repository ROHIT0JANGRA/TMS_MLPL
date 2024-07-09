using CodeLock.Areas.FMS.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Net;
using System.IO;

namespace CodeLock.Areas.FMS.Controllers
{
    public class TripsheetController : Controller
    {
        private readonly ITripsheetRepository tripsheetRepository;
        private readonly IGeneralRepository generalRepository;

        public TripsheetController()
        {
        }

        public TripsheetController(
          ITripsheetRepository _tripsheetRepository,
          IGeneralRepository _generalRepository)
        {
            this.tripsheetRepository = _tripsheetRepository;
            this.generalRepository = _generalRepository;
        }



        [HttpGet]
        public virtual ActionResult DownloadTripsheetLog(string filename)
        {
            //fileName should be like "photo.jpg"
            string fullPath = Path.Combine(Server.MapPath("~/Storage/TripsheetLog/"), filename);
            return File(fullPath, "application/octet-stream", filename);
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            HttpFileCollectionBase files = Request.Files;
            string FileLoc = "";
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFileBase file = files[i];
                string fileName = files.AllKeys[i].ToString();

                FileLoc = Server.MapPath("~/Storage/TripsheetLog/");

                if (System.IO.Directory.Exists(FileLoc)) { }
                else
                {
                    System.IO.Directory.CreateDirectory(FileLoc);
                }

                FileLoc = FileLoc + fileName;
                file.SaveAs(FileLoc);
            }

            return Json("Your files uploaded successfully", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMilkRunTripsheetDetails(string TripsheetNo)
        {
            JsonResult jsonResult = base.Json(this.tripsheetRepository.GetMilkRunTripsheetDetails(TripsheetNo));
            return jsonResult;
        }
        public ActionResult TripBillMilkRun()
        {
            MilkRunLogDetail ObjBill = new MilkRunLogDetail();
            ((dynamic)base.ViewBag).ProductTypeList = this.generalRepository.GetByIdList(24);
            return base.View(ObjBill);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TripBillMilkRun(MilkRunLogDetail ObjBill)
        {
            ActionResult action;
            ObjBill.CompanyId = SessionUtility.CompanyId;
            ObjBill.EntryBy = SessionUtility.LoginUserId;

            foreach(var item in ObjBill.VehicleLogDetail)
            {
                item.EntryBy = SessionUtility.LoginUserId.ToString();
            }

            ObjBill.TollTaxUploadAttachment = null;
            ObjBill.ParkingChargesUploadAttachment = null;
            ObjBill.PODUploadAttachment = null;
            Response response = this.tripsheetRepository.InsertMilkRunTripsheet(ObjBill);

            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).ProductTypeList = this.generalRepository.GetByIdList(24);
                action = base.View(ObjBill);
            }
            else
            {
                action = base.RedirectToAction("Done", new { documentNo = response.DocumentNo, DocumentId = response.DocumentId, status  = "MilkRunLog" });
            }

            return action;
        }

        public JsonResult GetTrispeedListByVehicleNo(string vehicleId)
        {
            return this.Json((object)this.tripsheetRepository.GetTrispeedListByVehicleNo(vehicleId));
        }

        [HttpPost]
        [ActionName("GetTracking")]
        public ActionResult GetSkuPost(long TripsheetId)
        {
            VehicleTracking objList = new VehicleTracking();

            List<Tracking_Details> obj = (List<Tracking_Details>)this.tripsheetRepository.GetVehicleTrackingId(TripsheetId.ToString());

            objList.TrackingList = obj;

            Session["AddTracking"] = objList.TrackingList;

            return PartialView("_VehicleTrackingList", objList.TrackingList);
        }


        [HttpPost]
        [ActionName("ValidateTracking")]
        public string ValidateTrackingPost(int SkuId)
        {
            VehicleTracking objList = new VehicleTracking();
            string flag = "NO";

            if (Session["AddTracking"] != null)
            {
                objList.TrackingList = (List<Tracking_Details>)Session["AddTracking"];
                foreach (var item in objList.TrackingList)
                {
                    //if (SkuId == item.SkuId)
                    //{
                    //    flag = "YES";
                    //}
                }

            }

            return flag;
        }
        [HttpPost]
        [ActionName("DeleteTracking")]
        public ActionResult DeleteSkuPost(int OrderDetailId)
        {
            VehicleTracking objList = new VehicleTracking();

            if (Session["AddTracking"] != null)
            {
                objList.TrackingList = (List<Tracking_Details>)Session["AddTracking"];
                objList.TrackingList.RemoveAt(OrderDetailId);

                List<Tracking_Details> obj = objList.TrackingList;
                int index = 0;

                foreach (var item in obj)
                {
                    item.SNo = index;
                    index = index + 1;
                }
            }

            Session["AddTracking"] = objList.TrackingList;

            return PartialView("_VehicleTrackingList", objList.TrackingList);
        }

        [HttpPost]
        [ActionName("AddTracking")]
        public ActionResult AddSkuPost(string FromCity, string ToCity, string DatedDes,
            int StartKM, int EndKM, int TotalRunKM, string LoadType, string CustomerName,
            string LRDetails, string Remark)
        {
            Tracking_Details objDetail = new Tracking_Details();
            VehicleTracking objList = new VehicleTracking();

            if (Session["AddTracking"] != null)
            {
                objList.TrackingList = (List<Tracking_Details>)Session["AddTracking"];
            }

            objDetail.SNo = objList.TrackingList.Count;
            objDetail.FromCity = FromCity;
            objDetail.ToCity = ToCity;
            objDetail.DatedDes = DatedDes;
            objDetail.StartKM = StartKM;
            objDetail.EndKM = EndKM;
            objDetail.TotalRunKM = TotalRunKM;
            objDetail.LoadType = LoadType;
            objDetail.CustomerName = CustomerName;
            objDetail.LRDetails = LRDetails;
            objDetail.Remark = Remark;

            objList.TrackingList.Add(objDetail);

            Session["AddTracking"] = objList.TrackingList;

            return PartialView("_VehicleTrackingList", objList.TrackingList);
        }
        public ActionResult VehicleTrackingDone()
        {
            return (ActionResult)this.View();
        }
        public ActionResult VehicleTracking()
        {
            VehicleTracking obj = new Models.VehicleTracking();

            obj.VehicleTrackingId = (long)0;
            Tracking_Details objDetail = new Tracking_Details();
            objDetail.SNo = 0;
            objDetail.FromCity = "";
            objDetail.ToCity = "";
            objDetail.DatedDes = "";
            objDetail.StartKM = 0;
            objDetail.EndKM = 0;
            objDetail.TotalRunKM = 0;
            objDetail.LoadType = "";
            objDetail.CustomerName = "";
            objDetail.LRDetails = "";
            objDetail.Remark = "";
            obj.TrackingList.Add(objDetail);
            Session["AddTracking"] = obj.TrackingList;

            Session["ClickResponse"] = null;

            return (ActionResult)this.View((object)obj);
        }

        [HttpPost]
        public ActionResult VehicleTracking(VehicleTracking obj)
        {

            obj.TrackingList = (List<Tracking_Details>)Session["AddTracking"];
            obj.EntryBy = SessionUtility.LoginUserId;
            Response response;

            if (Session["ClickResponse"] == null)
            {
                response = this.tripsheetRepository.VehicleTrackingInsert(obj);
                Session["ClickResponse"] = response;
                Session["AddTracking"] = null;
            }
            else
            {
                response = (Response)Session["ClickResponse"];
            }

            if (response.IsSuccessfull)
                return (ActionResult)this.RedirectToAction("VehicleTrackingDone", (object)new
                {
                    documentId = response.DocumentId,
                    documentNo = response.DocumentNo,
                    status = "VehicleTracking"
                });

            return (ActionResult)this.View((object)obj);
        }

        public JsonResult GetMetnatancList(string VehicleNo)
        {
            return base.Json(this.tripsheetRepository.GetMetnatancList(VehicleNo));
        }
        //VehicleMaintenanceDone
        public ActionResult VehicleMaintenanceDone()
        {
            return (ActionResult)this.View();
        }
        public ActionResult VehicleMaintenance()
        {
            return (ActionResult)this.View((object)new VehicleMaintenanceStatus());
        }

        [HttpPost]
        public ActionResult VehicleMaintenance(VehicleMaintenanceStatus objVehicleMaintenanceStatus)
        {
            VehicleMaintenanceStatus objResponse = new VehicleMaintenanceStatus();
            if (this.ModelState.IsValid)
            {
                objVehicleMaintenanceStatus.EntryBy = SessionUtility.LoginUserId;

                if (objVehicleMaintenanceStatus.BillDocument != null)
                {
                    DateTime now = DateTime.Now;
                    string FileLoc = "";
                    string fileName = "";

                    fileName = DateTime.Now.ToString().Trim();
                    fileName = fileName.Replace(" ", "");
                    fileName = fileName.Replace("/", "_");
                    fileName = fileName.Replace(@"\", "_");
                    fileName = fileName.Replace(":", "");
                    fileName = objVehicleMaintenanceStatus.VehicleNo + fileName + objVehicleMaintenanceStatus.BillDocument.FileName;

                    //  FileLoc =  string.Concat(ConfigHelper.LocalStoragePath + "VehicleMaintenance");

                    FileLoc = Server.MapPath("~/Storage/VehicleMaintenance/");

                    if (System.IO.Directory.Exists(FileLoc)) { }
                    else
                    {
                        System.IO.Directory.CreateDirectory(FileLoc);
                    }
                    FileLoc = FileLoc + fileName;
                    string str1 = FileLoc;// string.Concat(ConfigHelper.LocalStoragePath, "VehicleMaintenance/", fileName);

                    objVehicleMaintenanceStatus.BillDocument.SaveAs(str1);
                    objVehicleMaintenanceStatus.DocumentName = fileName;
                    objVehicleMaintenanceStatus.BillDocument = null;
                }
                if (this.tripsheetRepository.VehicleMaintenanceInsert(objVehicleMaintenanceStatus).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("VehicleMaintenanceDone", (object)new
                    {
                        documentId = objVehicleMaintenanceStatus.VehicleNo,
                        documentNo = objVehicleMaintenanceStatus.VehicleNo,
                        status = "VehicleStatusUpdateDone"
                    });

            }
            // return base.View(objResponse);
            return (ActionResult)this.View((object)objVehicleMaintenanceStatus);

        }

        public JsonResult GetVehicleStatus(string VehicleNo)
        {
            return base.Json(this.tripsheetRepository.GetVehicleStatus(VehicleNo));
        }

        public ActionResult VehicleStatusDone()
        {
            return (ActionResult)this.View();
        }

        public ActionResult VehicleStatus()
        {
            VehicleStatusDetail vehicleStatusDetail = new Models.VehicleStatusDetail();

            var vehicleStatusList = this.tripsheetRepository.GetVehicleStatusListDtl(SessionUtility.LoginUserId);
            vehicleStatusDetail.VehicleStatusList = (List<GetVehicleStatusList>)vehicleStatusList;

            var vehicleDetailList = this.tripsheetRepository.GetVehicleStatusDtl(SessionUtility.LoginUserId);
            vehicleStatusDetail.VehicleDetailList = (List<GetVehicleStatusList>)vehicleDetailList;

            ((dynamic)base.ViewBag).StatusReasonList = new SelectList(Enumerable.Empty<SelectListItem>());

            return (ActionResult)this.View((object)vehicleStatusDetail);
        }

        [HttpPost]
        public ActionResult VehicleStatus(VehicleStatusDetail objVehicleStatusDetail)
        {
            if (this.ModelState.IsValid)
            {
                if (this.tripsheetRepository.VehicleStatusInsert(objVehicleStatusDetail, SessionUtility.LoginUserId).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("VehicleStatusDone", (object)new
                    {
                        documentId = objVehicleStatusDetail.VehicleId,
                        documentNo = objVehicleStatusDetail.VehicleNo,
                        status = "VehicleStatusUpdateDone"
                    });
            }
            return (ActionResult)this.View((object)objVehicleStatusDetail);
        }


        [HttpPost]
        public JsonResult GetStatusReason(byte VehicleStatus)
        {
            return base.Json(this.tripsheetRepository.GetStatusReason(VehicleStatus));
        }
        public ActionResult VehicleStatusList()
        {

            return base.View(this.tripsheetRepository.GetVehicleStatusListDtl());
        }


        public ActionResult VehicleStatusListUpdate(short id)
        {
            VehicleMaintananceUpdateData vehlist = new VehicleMaintananceUpdateData();
            vehlist.VehicleMaintenanceUpdateList = (List<GetVehicleListForMaintanance>)this.tripsheetRepository.VehicleMaintananceUpdateDataList(id);
            return base.View(vehlist);
        }

        [HttpPost]
        public ActionResult VehicleStatusListUpdate(VehicleMaintananceUpdateData objVehicleMaintananceUpdateData)
        {
            ActionResult action;
            objVehicleMaintananceUpdateData.VehicleMaintenanceUpdateList.RemoveAll((GetVehicleListForMaintanance m) => m.VehicleStatus == null);



            foreach (GetVehicleListForMaintanance GetVehicleListForMaintanance in
                   from m in objVehicleMaintananceUpdateData.VehicleMaintenanceUpdateList
                   where m.BillDocument != null && m.VehicleStatus != null
                   select m)
            {

                DateTime now = DateTime.Now;
                string FileLoc = "";
                string fileName = "";

                fileName = DateTime.Now.ToString().Trim();
                fileName = fileName.Replace(" ", "");
                fileName = fileName.Replace("/", "_");
                fileName = fileName.Replace(@"\", "_");
                fileName = fileName.Replace(":", "");
                fileName = GetVehicleListForMaintanance.VehicleNo + fileName + GetVehicleListForMaintanance.BillDocument.FileName;

                //  FileLoc =  string.Concat(ConfigHelper.LocalStoragePath + "VehicleMaintenance");

                FileLoc = Server.MapPath("~/Storage/VehicleMaintenance/");

                if (System.IO.Directory.Exists(FileLoc)) { }
                else
                {
                    System.IO.Directory.CreateDirectory(FileLoc);
                }
                FileLoc = FileLoc + fileName;
                string str1 = FileLoc;// string.Concat(ConfigHelper.LocalStoragePath, "VehicleMaintenance/", fileName);

                GetVehicleListForMaintanance.BillDocument.SaveAs(str1);
                GetVehicleListForMaintanance.DocumentName = fileName;
                GetVehicleListForMaintanance.BillDocument = null;
            }
            objVehicleMaintananceUpdateData.VehicleMaintenanceUpdateList.ForEach((GetVehicleListForMaintanance m) => m.EntryBy = SessionUtility.LoginUserId);


            if (!this.tripsheetRepository.VehicleStatusListUpdateInsert(objVehicleMaintananceUpdateData).IsSuccessfull)
            {
                action = base.View(VehicleStatusListUpdate(objVehicleMaintananceUpdateData));
            }
            else
            {
                action = base.RedirectToAction("VehicleStatusListUpdateDone");
            }
            return action;

        }


        public ActionResult VehicleStatusListUpdateDone()
        {
            return base.View();
        }

        public ActionResult InsertRCM()
        {
            Tripsheet tripsheet = new Tripsheet()
            {
                FuelSlipDetails = new List<FuelSlipDetail>()
            };
            tripsheet.FuelSlipDetails.Add(new FuelSlipDetail()
            {
                TripsheetId = 0L,
                FuelSlipType = "",
                SlipNo = "",
                FuelVendorId = (short)0,
                FuelVendorCode = "",
                FuelVendorName = "",
                Quantity = new Decimal(0),
                Rate = new Decimal(0),
                Amount = new Decimal(0)
            });
            tripsheet.CompanyId = SessionUtility.CompanyId;
            tripsheet.StartLocationId = SessionUtility.LoginLocationId;
            tripsheet.StartLocation = SessionUtility.LoginLocationCode;
            tripsheet.EndLocationId = SessionUtility.LoginLocationId;
            tripsheet.EndLocation = SessionUtility.LoginLocationCode;
            tripsheet.AdvanceLocationId = SessionUtility.LoginLocationId;
            tripsheet.AdvanceLocationCode = SessionUtility.LoginLocationCode;
            tripsheet.ChecklistDetails = this.tripsheetRepository.GetCheckList().ToList<ChecklistDetail>();
            ((dynamic)base.ViewBag).TripsheetCompanyList = this.generalRepository.GetByIdList(304);
            return (ActionResult)this.View((object)tripsheet);
        }
        public ActionResult Insert()
        {
            Tripsheet tripsheet = new Tripsheet()
            {
                FuelSlipDetails = new List<FuelSlipDetail>()
            };
            tripsheet.FuelSlipDetails.Add(new FuelSlipDetail()
            {
                TripsheetId = 0L,
                FuelSlipType = "",
                SlipNo = "",
                FuelVendorId = (short)0,
                FuelVendorCode = "",
                FuelVendorName = "",
                Quantity = new Decimal(0),
                Rate = new Decimal(0),
                Amount = new Decimal(0)
            });
            tripsheet.CompanyId = SessionUtility.CompanyId;
            tripsheet.StartLocationId = SessionUtility.LoginLocationId;
            tripsheet.StartLocation = SessionUtility.LoginLocationCode;
            tripsheet.EndLocationId = SessionUtility.LoginLocationId;
            tripsheet.EndLocation = SessionUtility.LoginLocationCode;
            tripsheet.AdvanceLocationId = SessionUtility.LoginLocationId;
            tripsheet.AdvanceLocationCode = SessionUtility.LoginLocationCode;
            tripsheet.ChecklistDetails = this.tripsheetRepository.GetCheckList().ToList<ChecklistDetail>();
            return (ActionResult)this.View((object)tripsheet);
        }

        [ValidateAntiModelInjection("TripsheetId")]
        [HttpPost]
        public ActionResult Insert(Tripsheet objTripsheet)
        {
            objTripsheet.EntryBy = SessionUtility.LoginUserId;
            objTripsheet.FinYear = SessionUtility.FinYear;
            if (string.IsNullOrEmpty(objTripsheet.ManualTripsheetNo))
                objTripsheet.ManualTripsheetNo = "NA";
            short? firstDriverId = objTripsheet.FirstDriverId;
            if (!(firstDriverId.HasValue ? new int?((int)firstDriverId.GetValueOrDefault()) : new int?()).HasValue)
                objTripsheet.FirstDriverId = new short?((short)1);
            objTripsheet.SubCategory = objTripsheet.Category == (byte)2 ? objTripsheet.InternalUsageSubCategory : objTripsheet.ExternalUsageSubCategory;
            if (objTripsheet.AdvanceAmount == new Decimal(0))
            {
                this.ModelState.Remove("AdvanceDate");
                this.ModelState.Remove("AdvanceLocationId");
                this.ModelState.Remove("AdvanceLocationCode");
                this.ModelState.Remove("AdvancePaidBy");
                this.ModelState.Remove("AdvancePlace");
                this.ModelState.Remove("AdvanceAmount");
                this.ModelState.Remove("PaymentDetails.ChequeType");
                this.ModelState.Remove("PaymentDetails.ChequeNo");
                this.ModelState.Remove("PaymentDetails.ChequeDate");
                
                
            }
            this.ModelState.Remove("InternalCustomer");
            this.ModelState.Remove("PaymentDetails.TdsAccountId");
            if (!this.ModelState.IsValid)
                return (ActionResult)this.View((object)objTripsheet);

            objTripsheet.ChecklistDetails.RemoveAll((Predicate<ChecklistDetail>)(m => !m.IsChecked));
            objTripsheet.DocketDetails.RemoveAll((Predicate<DocketDetail>)(m => !m.IsChecked));
            objTripsheet.FuelSlipDetails.RemoveAll((Predicate<FuelSlipDetail>)(m => string.IsNullOrEmpty(m.SlipNo)));
            Response response = this.tripsheetRepository.Insert(objTripsheet);
            return (ActionResult)this.RedirectToAction("Done", (object)new
            {
                documentId = response.DocumentId,
                documentNo = response.DocumentNo,
                voucherId = response.DocumentId2,
                voucherNo = response.DocumentNo2,
                status = "GenerationDone"
            });
        }

        public ActionResult Done()
        {
            return (ActionResult)this.View();
        }

        public JsonResult GetDocketListByVehicleNo(string vehicleNo)
        {
            return this.Json((object)this.tripsheetRepository.GetDocketListByVehicleNo(vehicleNo));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                this.tripsheetRepository.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult ClosureRCM()
        {
            TripsheetClosure tripsheetClosure = new TripsheetClosure()
            {
                OilExpenses = new List<OilExpenses>(),
                EnRouteExpenses = new List<EnRouteExpenses>(),
                TripsheetAdvanceDetail = new List<TripsheetAdvance>(),
                VehicleLogDetail = new List<VehicleLogDetail>(),
                ThcDetail = new List<ThcDetail>(),
                ThcFieldDetail = new List<ThcFieldDetail>()
            };
            TripsheetClosure tripsheetClosure1 = tripsheetClosure;
            List<OilExpenses> oilExpenses = tripsheetClosure1.OilExpenses;
            OilExpenses oilExpense = new OilExpenses()
            {
                PetrolPumpId = 0,
                PetrolPumpName = "",
                Km = 0,
                BillNo = "",
                BillDate = DateTime.Now,
                FuelQuantity = new decimal(0),
                FuelRate = new decimal(0),
                Amount = new decimal?(new decimal(0)),
                ApprovedAmount = new decimal(0),
                PaidBy = 0,
                Remarks = ""
            };
            oilExpenses.Add(oilExpense);
            List<EnRouteExpenses> enRouteExpenses = tripsheetClosure1.EnRouteExpenses;
            EnRouteExpenses enRouteExpense = new EnRouteExpenses()
            {
                ChargeCode = 0,
                ChargeName = "",
                SpentAmount = new decimal(0),
                BillNo = "",
                BillDate = DateTime.Now,
                StanderdAmount = new decimal(0),
                Remarks = ""
            };
            enRouteExpenses.Add(enRouteExpense);
            List<TripsheetAdvance> tripsheetAdvanceDetail = tripsheetClosure1.TripsheetAdvanceDetail;
            TripsheetAdvance tripsheetAdvance = new TripsheetAdvance()
            {
                Place = "",
                AdvanceDate = DateTime.Now,
                Amount = new decimal(0),
                BranchName = "",
                PaidBy = ""
            };
            tripsheetAdvanceDetail.Add(tripsheetAdvance);
            List<VehicleLogDetail> vehicleLogDetail = tripsheetClosure1.VehicleLogDetail;
            VehicleLogDetail vehicleLogDetail1 = new VehicleLogDetail()
            {
                From = "",
                To = "",
                StartDateTime = new DateTime?(DateTime.Now),
                StartKm = 0,
                EndKm = 0,
                Category = 0,
                ProductId = 0,
                EndDateTime = new DateTime?(DateTime.Now),
                KmRun = 0,
                TransitTime = "00:00",
                IdleTime = "00:00"
            };
            vehicleLogDetail.Add(vehicleLogDetail1);
            List<ThcDetail> thcDetail = tripsheetClosure1.ThcDetail;
            ThcDetail thcDetail1 = new ThcDetail()
            {
                FromCityId = 0,
                FromCity = "",
                ToCity = "",
                ToCityId = 0,
                ThcNo = "",
                ThcDate = DateTime.Now,
                FreightAmount = new decimal(0),
                LabourCharge = new decimal(0),
                OtherCharge = new decimal(0),
                TotalAmount = new decimal(0)
            };
            thcDetail.Add(thcDetail1);
            List<ThcFieldDetail> thcFieldDetail = tripsheetClosure1.ThcFieldDetail;
            ThcFieldDetail thcFieldDetail1 = new ThcFieldDetail()
            {
                ThcNo = "",
                ThcDate = DateTime.Now,
                FromLocationId = 0,
                ToLocationId = 0,
                FromLocation = "",
                ToLocation = "",
                StartKm = new int?(0),
                EndKm = new int?(0),
                TotalRumKm = new int?(0),
                LoadType = ""
            };
            thcFieldDetail.Add(thcFieldDetail1);
            ((dynamic)base.ViewBag).ProductTypeList = this.generalRepository.GetByIdList(24);
            return base.View(tripsheetClosure1);
        }

        [HttpPost]
        public ActionResult ClosureRCM(TripsheetClosure objTripsheetClosure)
        {
            objTripsheetClosure.EnRouteExpenses.ForEach((Action<EnRouteExpenses>)(m => m.Remarks = m.Remarks.ConvertToString()));
            objTripsheetClosure.OilExpenses.ForEach((Action<OilExpenses>)(m => m.Remarks = m.Remarks.ConvertToString()));
            if (objTripsheetClosure.TripsheetAction == (byte)1)
            {
                objTripsheetClosure.OpCloseStatus = true;
            }
            else if (objTripsheetClosure.TripsheetAction == (byte)2)
            {
                objTripsheetClosure.FinCloseStatus = true;
                objTripsheetClosure.OpCloseStatus = true;
            }
            objTripsheetClosure.VehicleLogDetail.RemoveAll((Predicate<VehicleLogDetail>)(m => string.IsNullOrEmpty(m.From)));
            objTripsheetClosure.VehicleLogDetail.ForEach((Action<VehicleLogDetail>)(m =>
            {
                m.IdleTime = Convert.ToString(m.IdleTime);
                m.StartDate = m.StartDateTime.ConvertToDateTime().Date;
                m.StartTime = m.StartDateTime.ConvertToDateTime().TimeOfDay;
                m.EndDate = m.EndDateTime.ConvertToDateTime().Date;
                m.EndTime = m.EndDateTime.ConvertToDateTime().TimeOfDay;
            }));
            objTripsheetClosure.VehicleLogDetail.ToList<VehicleLogDetail>().ForEach((Action<VehicleLogDetail>)(m => m.IdleTime = Convert.ToString(m.IdleTime.ConvertToString())));
            objTripsheetClosure.OilExpenses.RemoveAll((Predicate<OilExpenses>)(m => string.IsNullOrEmpty(m.BillNo)));

            if (objTripsheetClosure.ThcDetail != null)
            {
                objTripsheetClosure.ThcDetail.RemoveAll((Predicate<ThcDetail>)(m => string.IsNullOrEmpty(m.ThcNo)));
            }

            //objTripsheetClosure.ThcDetail.RemoveAll((Predicate<ThcDetail>) (m => string.IsNullOrEmpty(m.ThcNo)));



            objTripsheetClosure.EnRouteExpenses.RemoveAll((Predicate<EnRouteExpenses>)(m => string.IsNullOrEmpty(m.BillNo)));
            Response response = this.tripsheetRepository.Close(objTripsheetClosure);
            return (ActionResult)this.RedirectToAction("Done", (object)new
            {
                documentId = response.DocumentId,
                documentNo = response.DocumentNo,
                status = "ClosureDone"
            });
        }
        public ActionResult Closure()
        {
            TripsheetClosure tripsheetClosure = new TripsheetClosure()
            {
                OilExpenses = new List<OilExpenses>(),
                EnRouteExpenses = new List<EnRouteExpenses>(),
                TripsheetAdvanceDetail = new List<TripsheetAdvance>(),
                VehicleLogDetail = new List<VehicleLogDetail>(),
                ThcDetail = new List<ThcDetail>(),
                ThcFieldDetail = new List<ThcFieldDetail>(),
                TripsheetLaneDetails = new List<TripsheetLaneDetail>()
            };
            TripsheetClosure tripsheetClosure1 = tripsheetClosure;
            List<OilExpenses> oilExpenses = tripsheetClosure1.OilExpenses;
            OilExpenses oilExpense = new OilExpenses()
            {
                PetrolPumpId = 0,
                PetrolPumpName = "",
                Km = 0,
                BillNo = "",
                BillDate = DateTime.Now,
                FuelQuantity = new decimal(0),
                FuelRate = new decimal(0),
                Amount = new decimal?(new decimal(0)),
                ApprovedAmount = new decimal(0),
                PaidBy = 0,
                Remarks = ""
            };
            oilExpenses.Add(oilExpense);
            List<EnRouteExpenses> enRouteExpenses = tripsheetClosure1.EnRouteExpenses;
            EnRouteExpenses enRouteExpense = new EnRouteExpenses()
            {
                ChargeCode = 0,
                ChargeName = "",
                SpentAmount = new decimal(0),
                BillNo = "",
                BillDate = DateTime.Now,
                StanderdAmount = new decimal(0),
                Remarks = ""
            };
            enRouteExpenses.Add(enRouteExpense);
            List<TripsheetAdvance> tripsheetAdvanceDetail = tripsheetClosure1.TripsheetAdvanceDetail;
            TripsheetAdvance tripsheetAdvance = new TripsheetAdvance()
            {
                Place = "",
                AdvanceDate = DateTime.Now,
                Amount = new decimal(0),
                BranchName = "",
                PaidBy = ""
            };
            tripsheetAdvanceDetail.Add(tripsheetAdvance);
            List<VehicleLogDetail> vehicleLogDetail = tripsheetClosure1.VehicleLogDetail;
            VehicleLogDetail vehicleLogDetail1 = new VehicleLogDetail()
            {
                From = "",
                To = "",
                StartDateTime = new DateTime?(DateTime.Now),
                StartKm = 0,
                EndKm = 0,
                Category = 0,
                ProductId = 0,
                EndDateTime = new DateTime?(DateTime.Now),
                KmRun = 0,
                TransitTime = "00:00",
                IdleTime = "00:00"
            };
            vehicleLogDetail.Add(vehicleLogDetail1);
            List<ThcDetail> thcDetail = tripsheetClosure1.ThcDetail;
            ThcDetail thcDetail1 = new ThcDetail()
            {
                FromCityId = 0,
                FromCity = "",
                ToCity = "",
                ToCityId = 0,
                ThcNo = "",
                ThcDate = DateTime.Now,
                FreightAmount = new decimal(0),
                LabourCharge = new decimal(0),
                OtherCharge = new decimal(0),
                TotalAmount = new decimal(0)
            };
            thcDetail.Add(thcDetail1);
            List<ThcFieldDetail> thcFieldDetail = tripsheetClosure1.ThcFieldDetail;
            ThcFieldDetail thcFieldDetail1 = new ThcFieldDetail()
            {
                ThcNo = "",
                ThcDate = DateTime.Now,
                FromLocationId = 0,
                ToLocationId = 0,
                FromLocation = "",
                ToLocation = "",
                StartKm = new int?(0),
                EndKm = new int?(0),
                TotalRumKm = new int?(0),
                LoadType = ""
            };
            thcFieldDetail.Add(thcFieldDetail1);
            tripsheetClosure1.TripsheetLaneDetails = new List<TripsheetLaneDetail>()
            {
                new TripsheetLaneDetail() {
                    ID = 0,
                    LaneId = string.Empty
                }
            };
            List<AutoCompleteResult> viewBag_LaneList = this.tripsheetRepository.GetLaneList((short)SessionUtility.CompanyId, 0, 0).Select(row => new AutoCompleteResult() { Name = row.LaneId, Value = row.ID.ToString() }).ToList();
            viewBag_LaneList.Insert(0, new AutoCompleteResult() { Name = "Select Lane", Value = string.Empty });
            ((dynamic)base.ViewBag).LaneList = viewBag_LaneList;
            ((dynamic)base.ViewBag).ProductTypeList = this.generalRepository.GetByIdList(24);
            return base.View(tripsheetClosure1);
        }

        [HttpPost]
        public ActionResult Closure(TripsheetClosure objTripsheetClosure)
        {
            objTripsheetClosure.EnRouteExpenses.ForEach((Action<EnRouteExpenses>)(m => m.Remarks = m.Remarks.ConvertToString()));
            objTripsheetClosure.OilExpenses.ForEach((Action<OilExpenses>)(m => m.Remarks = m.Remarks.ConvertToString()));
            if (objTripsheetClosure.TripsheetAction == (byte)1)
            {
                objTripsheetClosure.OpCloseStatus = true;
            }
            else if (objTripsheetClosure.TripsheetAction == (byte)2)
            {
                objTripsheetClosure.FinCloseStatus = true;
                objTripsheetClosure.OpCloseStatus = true;
            }
            objTripsheetClosure.VehicleLogDetail.RemoveAll((Predicate<VehicleLogDetail>)(m => string.IsNullOrEmpty(m.From)));
            objTripsheetClosure.VehicleLogDetail.ForEach((Action<VehicleLogDetail>)(m =>
            {
                m.IdleTime = Convert.ToString(m.IdleTime);
                m.StartDate = m.StartDateTime.ConvertToDateTime().Date;
                m.StartTime = m.StartDateTime.ConvertToDateTime().TimeOfDay;
                m.EndDate = m.EndDateTime.ConvertToDateTime().Date;
                m.EndTime = m.EndDateTime.ConvertToDateTime().TimeOfDay;
            }));
            objTripsheetClosure.VehicleLogDetail.ToList<VehicleLogDetail>().ForEach((Action<VehicleLogDetail>)(m => m.IdleTime = Convert.ToString(m.IdleTime.ConvertToString())));
            objTripsheetClosure.OilExpenses.RemoveAll((Predicate<OilExpenses>)(m => string.IsNullOrEmpty(m.BillNo)));

            if (objTripsheetClosure.ThcDetail != null)
            {
                objTripsheetClosure.ThcDetail.RemoveAll((Predicate<ThcDetail>)(m => string.IsNullOrEmpty(m.ThcNo)));
            }

            if (objTripsheetClosure.TripsheetLaneDetails != null)
            {
                objTripsheetClosure.TripsheetLaneDetails.RemoveAll((Predicate<TripsheetLaneDetail>)(m => string.IsNullOrEmpty(m.LaneId)));
            }
            //objTripsheetClosure.ThcDetail.RemoveAll((Predicate<ThcDetail>) (m => string.IsNullOrEmpty(m.ThcNo)));



            objTripsheetClosure.EnRouteExpenses.RemoveAll((Predicate<EnRouteExpenses>)(m => string.IsNullOrEmpty(m.BillNo)));
            Response response = this.tripsheetRepository.Close(objTripsheetClosure);
            return (ActionResult)this.RedirectToAction("Done", (object)new
            {
                documentId = response.DocumentId,
                documentNo = response.DocumentNo,
                status = "ClosureDone"
            });
        }

        public JsonResult GetTripsheetListForClose(
          byte tripsheetAction,
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForClose(tripsheetAction, searchBy, tripsheetNo, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
        }

        public JsonResult GetById(long TripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetById(TripsheetId));
        }

        [HttpPost]
        public JsonResult GetAutoCompleteChargeList(string chargeName)
        {
            return this.Json((object)this.tripsheetRepository.GetAutoCompleteChargeList(chargeName));
        }

        public JsonResult IsChargeNameExist(string chargeName)
        {
            return this.Json((object)this.tripsheetRepository.IsChargeNameExist(chargeName));
        }
        public JsonResult IsChargeNameExistTripSheet(string chargeName, string TripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.IsChargeNameExistTripSheet(chargeName, TripsheetId));
        }
        public JsonResult GetAdvanceDetail(long TripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetAdvanceDetail(TripsheetId));
        }

        public ActionResult DriverSettlement()
        {
            return (ActionResult)this.View((object)new DriverSettlement());
        }

        [HttpPost]
        public ActionResult DriverSettlement(DriverSettlement objDriverSettlement)
        {
            objDriverSettlement.EntryBy = SessionUtility.LoginUserId;
            objDriverSettlement.EntryDate = DateTime.Now;
            objDriverSettlement.LocationId = SessionUtility.LoginLocationId;
            objDriverSettlement.LocationCode = SessionUtility.LoginLocationCode;
            objDriverSettlement.CompanyId = SessionUtility.CompanyId;
            objDriverSettlement.Remarks = objDriverSettlement.Remarks.ConvertToString();
            objDriverSettlement.FinYear = SessionUtility.FinYear;
            this.ModelState.Remove("PaymentDetails.TdsAccountId");
            this.tripsheetRepository.DriverSettlement(objDriverSettlement);
            return (ActionResult)this.RedirectToAction("Done", (object)new
            {
                documentId = objDriverSettlement.TripsheetId,
                documentNo = objDriverSettlement.TripsheetNo,
                status = "DriverSettlementDone"
            });
        }

        public JsonResult GetTripsheetListForDriverSettlement(
          byte searchBy,
          string TripsheetNo,
          DateTime fromDate,
          DateTime toDate)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForDriverSettlement(searchBy, TripsheetNo, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
        }

        public JsonResult GetOilExpenseDetailAgaintsCash(long TripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetOilExpenseDetailAgaintsCash(TripsheetId));
        }

        public JsonResult GetEnRouteExpenseDetail(long TripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetEnRouteExpenseDetail(TripsheetId));
        }

        public JsonResult GetDetailListForClosure(long TripsheetId)
        {
            return this.Json((object)new TripsheetClosure()
            {
                VehicleLogDetail = this.tripsheetRepository.GetTripsheetVehicleLogList(TripsheetId).ToList<VehicleLogDetail>(),
                EnRouteExpenses = this.tripsheetRepository.GetTripsheetEnrouteExpenseList(TripsheetId).ToList<EnRouteExpenses>(),
                OilExpenses = this.tripsheetRepository.GetTripsheetOilExpenseList(TripsheetId).ToList<OilExpenses>(),
                ThcDetail = this.tripsheetRepository.GetTripsheetThcDetailList(TripsheetId).ToList<ThcDetail>(),
                ThcFieldDetail = this.tripsheetRepository.GetTripsheetThcFieldDetailList(TripsheetId).ToList<ThcFieldDetail>(),
                TripsheetLaneDetails = this.tripsheetRepository.GetTripsheetLaneFieldDetailList(TripsheetId).ToList <TripsheetLaneDetail>()
            });
        }
        public JsonResult GetDetailListForClosureRCM(long TripsheetId)
        {
            Tracking_Details obj = new Tracking_Details();
            List<Tracking_Details> objList = this.tripsheetRepository.GetVehicleTrackingId(TripsheetId.ToString()).ToList<Tracking_Details>();
            int total = 0;
            foreach (var item in objList)
            {
                total = total + item.TotalRunKM;
            }
            obj.FromCity = "Total";
            obj.TotalRunKM = total;

            objList.Add(obj);

            return this.Json((object)new TripsheetClosure()
            {
                VehicleLogDetail = this.tripsheetRepository.GetTripsheetVehicleLogList(TripsheetId).ToList<VehicleLogDetail>(),
                EnRouteExpenses = this.tripsheetRepository.GetTripsheetEnrouteExpenseList(TripsheetId).ToList<EnRouteExpenses>(),
                OilExpenses = this.tripsheetRepository.GetTripsheetOilExpenseList(TripsheetId).ToList<OilExpenses>(),
                ThcDetail = this.tripsheetRepository.GetTripsheetThcDetailList(TripsheetId).ToList<ThcDetail>(),
                ThcFieldDetail = this.tripsheetRepository.GetTripsheetThcFieldDetailList(TripsheetId).ToList<ThcFieldDetail>(),
                ThcTrackingDetail = objList
            });
        }
        public ActionResult DriverAdvance()
        {
            return (ActionResult)this.View((object)new DriverAdvance()
            {
                AdvanceLocationId = SessionUtility.LoginLocationId,
                AdvanceLocationCode = SessionUtility.LoginLocationCode
            });
        }

        [HttpPost]
        public ActionResult DriverAdvance(DriverAdvance objDriverAdvance)
        {
            if (this.ModelState.IsValid)
            {
                objDriverAdvance.LocationId = SessionUtility.LoginLocationId;
                objDriverAdvance.EntryBy = SessionUtility.LoginUserId;
                objDriverAdvance.LocationCode = SessionUtility.LoginLocationCode;
                objDriverAdvance.FinYear = SessionUtility.FinYear;
                if (objDriverAdvance.PaymentDetails.PaymentMode == 8)
                {
                    objDriverAdvance.PaymentDetails.CashAccountId = objDriverAdvance.PaymentDetails.BaAccountID;

                }
                if (this.tripsheetRepository.DriverAdvanceInsert(objDriverAdvance).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("Done", (object)new
                    {
                        documentId = objDriverAdvance.TripsheetId,
                        documentNo = objDriverAdvance.TripsheetNo,
                        status = "DriverAdvanceDone"
                    });
            }
            return (ActionResult)this.View((object)objDriverAdvance);
        }

        public JsonResult GetTripsheetListForDriverAdvance(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForDriverAdvance(searchBy, tripsheetNo, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
        }

        public JsonResult GetLaneList(short companyId, short customerId, long? laneId)
        {
            List<AutoCompleteResult> viewBag_LaneList = this.tripsheetRepository.GetLaneList(companyId, customerId, laneId).Select(row => new AutoCompleteResult() { Name = row.LaneId, Value = row.ID.ToString() }).ToList();
            viewBag_LaneList.Insert(0, new AutoCompleteResult() { Name = "Select Lane", Value = string.Empty });
            return this.Json((object)viewBag_LaneList);
        }
        public JsonResult GetLaneDetail(short companyId, short customerId, long laneId, DateTime? TrisheeetDate)
        {
            return this.Json((object)this.tripsheetRepository.GetLaneDetail(companyId, customerId, laneId, TrisheeetDate).ToList());
        }
        public JsonResult GetFSCRateContractDetail(short companyId, short customerId, long? laneId, long VehicleId, DateTime? StartDate, short? ContractID)
        {
            return this.Json((object)this.tripsheetRepository.GetFSCRateContractDetail(companyId, customerId, laneId, VehicleId, StartDate, ContractID).ToList());
        }
        public JsonResult GetCardListByTripsheetId(long tripsheetId, bool isFuelCard)
        {
            return this.Json((object)this.tripsheetRepository.GetCardListByTripsheetId(tripsheetId, isFuelCard));
        }

        public JsonResult IsTripsheetNoExist(string tripsheetNo)
        {
            return this.Json((object)this.tripsheetRepository.IsTripsheetNoExist(tripsheetNo));
        }

        public ActionResult FuelSlipEntry()
        {
            return (ActionResult)this.View((object)new FuelSlip()
            {
                Details = {
          new FuelSlipDetail()
        }
            });
        }

        [HttpPost]
        public ActionResult FuelSlipEntry(FuelSlip objFuelSlip)
        {
            if (this.ModelState.IsValid)
            {
                objFuelSlip.LocationId = SessionUtility.LoginLocationId;
                objFuelSlip.LocationCode = SessionUtility.LoginLocationCode;
                objFuelSlip.CompanyId = SessionUtility.CompanyId;
                objFuelSlip.FinYear = SessionUtility.FinYear;
                objFuelSlip.EntryBy = SessionUtility.LoginUserId;
                objFuelSlip.AdvancePaidBy = SessionUtility.LoginUserName;
                if (this.tripsheetRepository.FuelSlipInsert(objFuelSlip).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("Done", (object)new
                    {
                        documentId = objFuelSlip.TripsheetId,
                        documentNo = objFuelSlip.TripsheetNo,
                        status = "FuelSlipEntryDone"
                    });
            }
            return (ActionResult)this.View(nameof(FuelSlipEntry), (object)objFuelSlip);
        }

        public JsonResult GetTripsheetListForFuelSlip(
          string manualTripsheetNo,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate,
          string vehicleNo)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForFuelSlip(manualTripsheetNo, tripsheetNo, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId, vehicleNo));
        }

        public JsonResult GetFuelSlipDetailByTripsheetId(long tripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetFuelSlipDetailByTripsheetId(tripsheetId));
        }

        public ActionResult Cancellation()
        {
            return (ActionResult)this.View((object)new TripsheetCancellation());
        }

        public JsonResult GetCancelledTripsheetList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string tripsheetNos,
          string manualTripsheetNos)
        {
            return this.Json((object)this.tripsheetRepository.GetCancelledTripsheetList(locationId, fromDate, toDate, tripsheetNos, manualTripsheetNos));
        }

        [HttpPost]
        public ActionResult Cancellation(TripsheetCancellation objTripsheetCancellation)
        {
            objTripsheetCancellation.Details.RemoveAll((Predicate<Tripsheet>)(m => !m.IsChecked));
            objTripsheetCancellation.Details.ForEach((Action<Tripsheet>)(m => m.CancelDate = objTripsheetCancellation.CancelDate));
            objTripsheetCancellation.Details.ForEach((Action<Tripsheet>)(m => m.CancelReason = objTripsheetCancellation.CancelReason));
            objTripsheetCancellation.Details.ForEach((Action<Tripsheet>)(m => m.EntryBy = SessionUtility.LoginUserId));
            if (this.tripsheetRepository.Cancellation(objTripsheetCancellation).IsSuccessfull)
                return (ActionResult)this.RedirectToAction("Done", (object)new
                {
                    status = "CancellationDone"
                });
            return (ActionResult)this.View((object)objTripsheetCancellation);
        }

        public ActionResult ExpectedExpense()
        {
            return (ActionResult)this.View((object)new TripsheetExpectedExpense());
        }

        [HttpPost]
        public ActionResult ExpectedExpense(
          TripsheetExpectedExpense objTripsheetExpectedExpense)
        {
            if (this.tripsheetRepository.ExpectedExpense(objTripsheetExpectedExpense).IsSuccessfull)
                return (ActionResult)this.RedirectToAction("Done", (object)new
                {
                    status = "ExpectedExpenseDone"
                });
            return (ActionResult)this.View((object)objTripsheetExpectedExpense);
        }

        public JsonResult GetTripsheetListForExpectedExpense(
          DateTime fromDate,
          DateTime toDate)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForExpectedExpense(fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate));
        }

        public ActionResult ExpectedDriverAdvance()
        {
            return (ActionResult)this.View((object)new ExpectedDriverAdvance()
            {
                Details = {
          new ExpectedDriverAdvanceDetails()
        }
            });
        }

        [HttpPost]
        public ActionResult ExpectedDriverAdvance(
          ExpectedDriverAdvance objExpectedDriverAdvance)
        {
            objExpectedDriverAdvance.Details.RemoveAll((Predicate<ExpectedDriverAdvanceDetails>)(m => m.PaidAmount > new Decimal(0)));
            objExpectedDriverAdvance.Details.ForEach((Action<ExpectedDriverAdvanceDetails>)(m => m.EntryBy = SessionUtility.LoginUserId));
            if (this.tripsheetRepository.ExpectedDriverAdvanceInsert(objExpectedDriverAdvance).IsSuccessfull)
                return (ActionResult)this.RedirectToAction("Done", (object)new
                {
                    documentId = objExpectedDriverAdvance.TripsheetId,
                    documentNo = objExpectedDriverAdvance.TripsheetNo,
                    status = "ExpectedDriverAdvanceDone"
                });
            return (ActionResult)this.View((object)objExpectedDriverAdvance);
        }

        public JsonResult GetTripsheetListForExpectedDriverAdvance(
          byte searchBy,
          string tripsheetNo,
          DateTime fromDate,
          DateTime toDate)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForDriverAdvance(searchBy, tripsheetNo, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
        }

        public JsonResult GetExpectedDriverAdvanceDetailById(long tripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetExpectedDriverAdvanceDetailById(tripsheetId));
        }

        public JsonResult GetFuelSlipDetail(long TripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetFuelSlipDetail(TripsheetId));
        }

        public ActionResult AdvanceCancellation()
        {
            return (ActionResult)this.View((object)new TripsheetAdvanceCancellation());
        }

        public JsonResult GetAdvanceCancelTripsheetList(
          short locationId,
          DateTime fromDate,
          DateTime toDate,
          string tripsheetNos,
          string manualTripsheetNos,
          string voucherNo)
        {
            return this.Json((object)this.tripsheetRepository.GetAdvanceCancelTripsheetList(locationId, fromDate, toDate, tripsheetNos, manualTripsheetNos, voucherNo));
        }

        public JsonResult GetAdvanceCancelDriverAdvanceList(long tripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetAdvanceCancelDriverAdvanceList(tripsheetId));
        }

        [HttpPost]
        public ActionResult AdvanceCancellation(TripsheetAdvanceCancellation tripsheetAdvanceCancellation)
        {
            tripsheetAdvanceCancellation.CancelBy = SessionUtility.LoginUserId;
            if (this.tripsheetRepository.AdvanceCancellation(tripsheetAdvanceCancellation).IsSuccessfull)
                return (ActionResult)this.RedirectToAction("Done", (object)new
                {
                    status = "AdvanceCancellationDone"
                });
            return (ActionResult)this.View((object)tripsheetAdvanceCancellation);
        }

        [HttpPost]
        public JsonResult GetTripsheetListForTripsheetSettlementCancellation(
         byte searchBy,
         string TripsheetNo,
         DateTime fromDate,
         DateTime toDate,
        byte tripsheetAction)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForTripsheetSettlementCancellation(searchBy, TripsheetNo, fromDate, toDate, tripsheetAction, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
        }
        public ActionResult TripsheetSettlementCancellation()
        {
            return base.View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TripsheetSettlementCancellation(TripsheetSettlementCancellation objTripsheetSettlementCancellation)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objTripsheetSettlementCancellation);
            }
            else
            {
                objTripsheetSettlementCancellation.LocationId = SessionUtility.LoginLocationId;
                objTripsheetSettlementCancellation.LocationCode = SessionUtility.LoginLocationCode;
                objTripsheetSettlementCancellation.CancelBy = new short?(SessionUtility.LoginUserId);
                objTripsheetSettlementCancellation.Details.RemoveAll((DriverSettlementCancellationDetails m) => !m.IsChecked);
                if (this.tripsheetRepository.TripsheetSettlementCancellation(objTripsheetSettlementCancellation).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("Done", (object)new
                    {
                        status = "TripsheetSettlementCancellationDone"
                    });
                return (ActionResult)this.View((object)objTripsheetSettlementCancellation);
            }
            return action;
        }

        public ActionResult TripsheetFuelSlipCancellation()
        {
            return base.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TripsheetFuelSlipCancellation(FuelSlip objFuelSlip)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objFuelSlip);
            }
            else
            {
                objFuelSlip.EntryBy = SessionUtility.LoginUserId;
                objFuelSlip.Details.RemoveAll((FuelSlipDetail m) => !m.IsChecked);
                if (this.tripsheetRepository.TripsheetFuelSlipCancellation(objFuelSlip).IsSuccessfull)
                    return (ActionResult)this.RedirectToAction("Done", (object)new
                    {
                        status = "TripsheetFuelSlipCancellationDone"
                    });
                return (ActionResult)this.View((object)objFuelSlip);
            }
            return action;
        }

        [HttpPost]
        public JsonResult GetTripsheetListForTripsheetFuelSlipCancellation(
         byte searchBy,
         string TripsheetNo,
         DateTime fromDate,
         DateTime toDate)
        {
            return this.Json((object)this.tripsheetRepository.GetTripsheetListForTripsheetFuelSlipCancellation(searchBy, TripsheetNo, fromDate, toDate, SessionUtility.FinStartDate, SessionUtility.FinEndDate, SessionUtility.LoginLocationId));
        }

        [HttpPost]
        public JsonResult GetFuelSlipListForTripsheetFuelSlipCancellation(long tripsheetId)
        {
            return this.Json((object)this.tripsheetRepository.GetFuelSlipListForTripsheetFuelSlipCancellation(tripsheetId));
        }
    }
}

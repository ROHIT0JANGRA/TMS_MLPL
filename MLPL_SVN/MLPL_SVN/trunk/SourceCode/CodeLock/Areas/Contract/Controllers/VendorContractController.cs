using CodeLock.Areas.Contract.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Contract.Controllers
{
    public class VendorContractController : Controller
    {
        private readonly ICustomerContractRepository customerContractRepository;
        private readonly IVendorContractRepository vendorContractRepository;

        private readonly IGeneralRepository generalRepository;

        private readonly IVendorRepository vendorRepository;

        private readonly ILocationRepository locationRepository;

        private readonly IVehicleTypeRepository vehicleTypeRepository;

        private readonly IRouteRepository routeRepository;

        private readonly IVehicleRepository vehicleRepository;

        private readonly ICityRepository cityRepository;

        private readonly IRulesRepository rulesRepository;

        private readonly IAddressRepository addressRepository;

        private readonly IStateRepository stateRepository;

        private readonly ICountryRepository countryRepository;


        public VendorContractController()
        {

        }

        public VendorContractController(IVendorContractRepository _vendorContractRepository, IGeneralRepository _generalRepository, 
            IVendorRepository _vendorRepository, ILocationRepository _locationRepository, IVehicleTypeRepository _vehicleTypeRepository, 
            IRouteRepository _routeRepository, IVehicleRepository _vehicleRepository, ICityRepository _cityRepository, 
            IAddressRepository _addressRepository, ICountryRepository _countryRepository, IStateRepository _stateRepository, 
            IRulesRepository _rulesRepository, ICustomerContractRepository _customerContractRepository)
        {
            this.vendorContractRepository = _vendorContractRepository;
            this.generalRepository = _generalRepository;
            this.vendorRepository = _vendorRepository;
            this.locationRepository = _locationRepository;
            this.vehicleTypeRepository = _vehicleTypeRepository;
            this.routeRepository = _routeRepository;
            this.vehicleRepository = _vehicleRepository;
            this.cityRepository = _cityRepository;
            this.addressRepository = _addressRepository;
            this.stateRepository = _stateRepository;
            this.countryRepository = _countryRepository;
            this.rulesRepository = _rulesRepository;
            this.customerContractRepository = _customerContractRepository;
        }

        [HttpPost]
        public JsonResult GetDetail(short contractId, byte baseOn, byte baseCode, bool isBooking, byte chargeCode)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.GetDetail(contractId, baseOn, baseCode, isBooking, chargeCode));
            return jsonResult;
        }

        public ActionResult FleetCharge(short id, byte baseOn1, byte baseOn2, byte baseCode1, short baseCode2, byte chargeCode, byte matrixType, short fromLocation, short toLocation, byte transportModeId, bool isBooking, byte ftlTypeId, short consignorId, short consigneeId, short vendorTypeId, long vendorId)
        {
            ActionResult actionResult;
           // var oCustomerContractData = this.customerContractRepository.GetById(id, true);
            var IsMilkrunHrsPerDayEnabled = true;
            var IsLaneEnabled = false;
            short CustomerId = 0;
            CustomerContractFleetCharge customerContractFleetCharge = new CustomerContractFleetCharge()
            {
                Details = this.vendorContractRepository.GetFleetChargeBySearchingCriteria(id, chargeCode, matrixType, toLocation, ftlTypeId).ToList<CustomerContractFleetCharge>(),
                ContractId = id,
                BaseOn1 = baseOn1,
                BaseOn2 = baseOn2,
                BaseCode1 = baseCode1,
                BaseCode2 = baseCode2,
                ChargeCode = chargeCode,
                MatrixType = matrixType,
                ToLocation = toLocation,
                TransportModeId = transportModeId,
                IsBooking = isBooking,
                FtlTypeId = ftlTypeId,
                ConsignorId = consignorId,
                ConsigneeId = consigneeId,
                IsMilkrunHrsPerDayEnabled = IsMilkrunHrsPerDayEnabled,
                IsLaneEnabled = IsLaneEnabled,
                CustomerId = CustomerId
            };

            CustomerContractFleetCharge customerContractFleetCharge1 = customerContractFleetCharge;
            ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleList();
            ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            ((dynamic)base.ViewBag).MovementTypeList = this.customerContractRepository.GetMovementTypeList();


            List<AutoCompleteResult> items = new List<AutoCompleteResult>();
            items.Add(new AutoCompleteResult { Value ="1", Name="Fixed" });
            items.Add(new AutoCompleteResult { Value ="2", Name="Per Days" });
            ((dynamic)base.ViewBag).ContractTypeList = items;


            this.GetHeaderInfo(new short?(id));
            ((dynamic)base.ViewBag).ChargeName = "FLEET CHARGE";
            if (customerContractFleetCharge1.Details.Count <= 0)
            {
                List<CustomerContractFleetCharge> details = customerContractFleetCharge1.Details;
                CustomerContractFleetCharge customerContractFleetCharge2 = new CustomerContractFleetCharge()
                {
                    ContractId = id,
                    BaseOn1 = baseOn1,
                    BaseOn2 = baseOn2,
                    BaseCode1 = baseCode1,
                    BaseCode2 = baseCode2,
                    ChargeCode = chargeCode,
                    MatrixType = matrixType,
                    ToLocation = toLocation,
                    TransportModeId = transportModeId,
                    IsBooking = isBooking,
                    FtlTypeId = ftlTypeId,
                    ConsignorId = consignorId,
                    IsMilkrunHrsPerDayEnabled = IsMilkrunHrsPerDayEnabled,
                    IsLaneEnabled = IsLaneEnabled
                };
                details.Add(customerContractFleetCharge2);
                customerContractFleetCharge1.vendorTypeId = vendorTypeId;
                customerContractFleetCharge1.vendorId = vendorId;

                actionResult = base.View(customerContractFleetCharge1);
            }
            else
            {
                customerContractFleetCharge1.vendorTypeId = vendorTypeId;
                customerContractFleetCharge1.vendorId = vendorId;
                actionResult = base.View(customerContractFleetCharge1);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult FleetCharge(CustomerContractFleetCharge objCustomerContractFleetCharge)
        {
            ActionResult action;
            objCustomerContractFleetCharge.EntryBy = SessionUtility.LoginUserId;
            Response response = this.vendorContractRepository.InsertFleetCharge(objCustomerContractFleetCharge);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleList();
                ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
                ((dynamic)base.ViewBag).ProductTypeList = this.generalRepository.GetByIdList(24);
                var oLaneList = this.customerContractRepository.GetLaneList((short)SessionUtility.CompanyId, objCustomerContractFleetCharge.CustomerId, null);
                List<AutoCompleteResult> viewBag_LaneList = oLaneList.Select(row => new AutoCompleteResult() { Name = row.LaneId, Value = row.ID.ToString() }).ToList();
                viewBag_LaneList.Insert(0, new AutoCompleteResult() { Name = "Select Lane", Value = string.Empty });
                ((dynamic)base.ViewBag).LaneList = viewBag_LaneList;
                action = base.View(objCustomerContractFleetCharge);
            }
            else
            {
               // action = base.RedirectToAction("Result", new { documentId = response.DocumentId });
                action = base.RedirectToAction("Result", new { ContractId = response.DocumentId, VendorTypeId = objCustomerContractFleetCharge.vendorTypeId, VendorId = objCustomerContractFleetCharge.vendorId });

            }
            return action;
        }


        [HttpPost]
        public JsonResult CheckDate(short contractId, short vendorId, DateTime startDate, DateTime endDate)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.CheckDate(contractId, vendorId, startDate, endDate), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CheckDateIsValid(short contractId, short vendorId, DateTime contractDate)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.CheckDateIsValid(contractId, vendorId, contractDate), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult CityBased(short id, int fromCityId, string fromCityName, int toCityId, string toCityName, byte transportModeId, byte ftlTypeId, short vehicleId)
        {
            ActionResult actionResult;
            List<VendorContractCityBased> vendorContractCityBaseds = new List<VendorContractCityBased>();
            vendorContractCityBaseds = this.vendorContractRepository.GetCityBasedDetailById(id, fromCityId, toCityId, transportModeId, ftlTypeId, vehicleId).ToList<VendorContractCityBased>();
            ((dynamic)base.ViewBag).FromCityId = fromCityId;
            ((dynamic)base.ViewBag).FromCityName = fromCityName;
            ((dynamic)base.ViewBag).ToCityId = toCityId;
            ((dynamic)base.ViewBag).ToCityName = toCityName;
            ((dynamic)base.ViewBag).TransportModeId = transportModeId;
            ((dynamic)base.ViewBag).FtlTypeId = ftlTypeId;
            ((dynamic)base.ViewBag).VehicleId = vehicleId;
            this.Init();
            this.GetHeaderInfo(new short?(id));

            IEnumerable<AutoCompleteResult> vehicleList = this.vehicleRepository.GetVehicleByVendorIdFtlTypeId(ftlTypeId, id);
            List<AutoCompleteResult> autoCompleteVehicleList = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteVehicle = new AutoCompleteResult()
            {
                Name = "ALL",
                Value = "0"
            };
            autoCompleteVehicleList.Add(autoCompleteVehicle);
            autoCompleteVehicleList.AddRange(vehicleList);
            ((dynamic)base.ViewBag).VehicleList = autoCompleteVehicleList;


            if (vendorContractCityBaseds.Count <= 0)
            {
                VendorContractCityBased vendorContractCityBased = new VendorContractCityBased()
                {
                    ContractId = id,
                    FromCityId = fromCityId,
                    FromCityName = fromCityName,
                    ToCityId = toCityId,
                    ToCityName = toCityName,
                    TransportModeId = transportModeId,
                    FtlTypeId = ftlTypeId,
                    VehicleId = vehicleId
                };
                vendorContractCityBaseds.Add(vendorContractCityBased);
                actionResult = base.View(vendorContractCityBaseds);
            }
            else
            {
                actionResult = base.View(vendorContractCityBaseds);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult CityBased(List<VendorContractCityBased> objCityBased, short id, int fromCityId, string fromCityName, int toCityId, string toCityName, byte transportModeId, byte ftlTypeId, short vehicleId)
        {
            ActionResult action;
            objCityBased.ForEach((VendorContractCityBased m) =>
            {
                m.EntryBy = SessionUtility.LoginUserId;
                m.EntryDate = DateTime.Now;
                m.UpdateBy = new short?(SessionUtility.LoginUserId);
                m.UpdateDate = new DateTime?(DateTime.Now);
            });
            objCityBased.AddRange(this.vendorContractRepository.GetCityBasedDetailById(id, fromCityId, toCityId, transportModeId, ftlTypeId, vehicleId));
            Response response = this.vendorContractRepository.InsertCityBased(objCityBased);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).FromCityId = objCityBased[0].FromCityId;
                ((dynamic)base.ViewBag).FromCityName = objCityBased[0].FromCityName;
                ((dynamic)base.ViewBag).ToCityId = objCityBased[0].ToCityId;
                ((dynamic)base.ViewBag).ToCityName = objCityBased[0].ToCityName;
                ((dynamic)base.ViewBag).TransportModeId = objCityBased[0].TransportModeId;
                ((dynamic)base.ViewBag).FtlTypeId = objCityBased[0].FtlTypeId;
                ((dynamic)base.ViewBag).VehicleId = objCityBased[0].VehicleId;
                this.Init();
                this.GetHeaderInfo(new short?(objCityBased[0].ContractId));
                action = base.View(objCityBased);
            }
            else
            {
                MasterVendor vendorTypeIdByContractId = (new VendorContractRepository()).GetVendorTypeIdByContractId((short)response.DocumentId);
                action = base.RedirectToAction("Result", new { ContractId = response.DocumentId, VendorTypeId = vendorTypeIdByContractId.VendorTypeId, VendorId = vendorTypeIdByContractId.VendorId });
            }
            return action;
        }

        [HttpGet]
        public ActionResult CityBasedCriteria(short id, byte vendorTypeId)
        {
            VendorContractCityBased vendorContractCityBased = new VendorContractCityBased()
            {
                ContractId = id,
                VendorTypeId = vendorTypeId
            };
            VendorContractCityBased vendorContractCityBased1 = vendorContractCityBased;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            return base.View(vendorContractCityBased1);
        }

        [HttpPost]
        public ActionResult CityBasedCriteria(VendorContractCityBased objVendorContractCityBased)
        {
            ActionResult action = base.RedirectToAction("CityBased", new { id = objVendorContractCityBased.ContractId, transportModeId = objVendorContractCityBased.TransportModeId, ftlTypeId = objVendorContractCityBased.FtlTypeId, fromCityId = objVendorContractCityBased.FromCityId, vehicleId = objVendorContractCityBased.VehicleId, fromCityName = objVendorContractCityBased.FromCityName, toCityId = objVendorContractCityBased.ToCityId, toCityName = objVendorContractCityBased.ToCityName });
            return action;
        }

        [HttpGet]
        public ActionResult CrossingBased(short id, short fromLocationId, string fromLocationCode, int toCityId, string toCityName)
        {
            ActionResult actionResult;
            List<VendorContractCrossingBased> vendorContractCrossingBaseds = new List<VendorContractCrossingBased>();
            vendorContractCrossingBaseds = this.vendorContractRepository.GetCrossingBasedDetailById(id, fromLocationId, toCityId).ToList<VendorContractCrossingBased>();
            ((dynamic)base.ViewBag).FromLocationId = fromLocationId;
            ((dynamic)base.ViewBag).FromLocationCode = fromLocationCode;
            ((dynamic)base.ViewBag).ToCityId = toCityId;
            ((dynamic)base.ViewBag).ToCityName = toCityName;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            if (vendorContractCrossingBaseds.Count <= 0)
            {
                VendorContractCrossingBased vendorContractCrossingBased = new VendorContractCrossingBased()
                {
                    ContractId = id,
                    FromLocationId = fromLocationId,
                    FromLocationCode = fromLocationCode,
                    ToCityId = toCityId,
                    ToCityName = toCityName
                };
                vendorContractCrossingBaseds.Add(vendorContractCrossingBased);
                actionResult = base.View(vendorContractCrossingBaseds);
            }
            else
            {
                actionResult = base.View(vendorContractCrossingBaseds);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult CrossingBased(List<VendorContractCrossingBased> objCrossingBased, short id, short fromLocationId, string fromLocationCode, int toCityId, string toCityName)
        {
            ActionResult action;
            objCrossingBased.ForEach((VendorContractCrossingBased m) =>
            {
                m.EntryBy = SessionUtility.LoginUserId;
                m.EntryDate = DateTime.Now;
                m.UpdateBy = new short?(SessionUtility.LoginUserId);
                m.UpdateDate = new DateTime?(DateTime.Now);
            });
            objCrossingBased.AddRange(this.vendorContractRepository.GetCrossingBasedDetailById(id, fromLocationId, toCityId));
            Response response = this.vendorContractRepository.InsertCrossingBased(objCrossingBased);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).FromLocationId = objCrossingBased[0].FromLocationId;
                ((dynamic)base.ViewBag).FromLocationCode = objCrossingBased[0].FromLocationCode;
                ((dynamic)base.ViewBag).ToCityId = objCrossingBased[0].ToCityId;
                ((dynamic)base.ViewBag).ToCityName = objCrossingBased[0].ToCityName;
                this.Init();
                this.GetHeaderInfo(new short?(objCrossingBased[0].ContractId));
                action = base.View(objCrossingBased);
            }
            else
            {
                MasterVendor vendorTypeIdByContractId = (new VendorContractRepository()).GetVendorTypeIdByContractId((short)response.DocumentId);
                action = base.RedirectToAction("Result", new { ContractId = response.DocumentId, VendorTypeId = vendorTypeIdByContractId.VendorTypeId, VendorId = vendorTypeIdByContractId.VendorId });
            }
            return action;
        }

        [HttpGet]
        public ActionResult CrossingBasedCriteria(short id, byte vendorTypeId)
        {
            VendorContractCrossingBased vendorContractCrossingBased = new VendorContractCrossingBased()
            {
                ContractId = id,
                VendorTypeId = vendorTypeId
            };
            VendorContractCrossingBased vendorContractCrossingBased1 = vendorContractCrossingBased;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            return base.View(vendorContractCrossingBased1);
        }

        public ActionResult Details(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            short? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?(nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                VendorContract detailById = this.vendorContractRepository.GetDetailById(id.Value);
                if (detailById != null)
                {
                    httpStatusCodeResult = base.View(detailById);
                }
                else
                {
                    httpStatusCodeResult = base.HttpNotFound();
                }
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.vendorContractRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult DistanceBased(short id, byte transportModeId, byte ftlTypeId, short vehicleId)
        {
            ActionResult actionResult;
            List<VendorContractDistanceBased> vendorContractDistanceBaseds = new List<VendorContractDistanceBased>();
            vendorContractDistanceBaseds = this.vendorContractRepository.GetDistanceBasedDetailById(id, transportModeId, ftlTypeId, vehicleId).ToList<VendorContractDistanceBased>();
            ((dynamic)base.ViewBag).TransportModeId = transportModeId;
            ((dynamic)base.ViewBag).FtlTypeId = ftlTypeId;
            ((dynamic)base.ViewBag).VehicleId = vehicleId;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleByFtlTypeId(ftlTypeId);
            if (vendorContractDistanceBaseds.Count <= 0)
            {
                VendorContractDistanceBased vendorContractDistanceBased = new VendorContractDistanceBased()
                {
                    ContractId = id,
                    TransportModeId = transportModeId,
                    FtlTypeId = ftlTypeId,
                    VehicleId = vehicleId
                };
                vendorContractDistanceBaseds.Add(vendorContractDistanceBased);
                actionResult = base.View(vendorContractDistanceBaseds);
            }
            else
            {
                actionResult = base.View(vendorContractDistanceBaseds);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult DistanceBased(List<VendorContractDistanceBased> objDistanceBased, short id, byte transportModeId, byte ftlTypeId, short vehicleId)
        {
            ActionResult action;
            objDistanceBased.ForEach((VendorContractDistanceBased m) =>
            {
                m.EntryBy = SessionUtility.LoginUserId;
                m.EntryDate = DateTime.Now;
                m.UpdateBy = new short?(SessionUtility.LoginUserId);
                m.UpdateDate = new DateTime?(DateTime.Now);
            });
            objDistanceBased.AddRange(this.vendorContractRepository.GetDistanceBasedDetailById(id, transportModeId, ftlTypeId, vehicleId));
            Response response = this.vendorContractRepository.InsertDistanceBased(objDistanceBased);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).FtlTypeId = objDistanceBased[0].FtlTypeId;
                ((dynamic)base.ViewBag).VehicleTypeId = objDistanceBased[0].VehicleTypeId;
                ((dynamic)base.ViewBag).VehicleId = objDistanceBased[0].VehicleId;
                this.Init();
                this.GetHeaderInfo(new short?(objDistanceBased[0].ContractId));
                action = base.View(objDistanceBased);
            }
            else
            {
                MasterVendor vendorTypeIdByContractId = (new VendorContractRepository()).GetVendorTypeIdByContractId((short)response.DocumentId);
                action = base.RedirectToAction("Result", new { ContractId = response.DocumentId, VendorTypeId = vendorTypeIdByContractId.VendorTypeId, VendorId = vendorTypeIdByContractId.VendorId });
            }
            return action;
        }

        public ActionResult DistanceBasedCriteria(short id, byte vendorTypeId)
        {
            VendorContractDistanceBased vendorContractDistanceBased = new VendorContractDistanceBased()
            {
                ContractId = id,
                VendorTypeId = vendorTypeId
            };
            VendorContractDistanceBased vendorContractDistanceBased1 = vendorContractDistanceBased;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            return base.View(vendorContractDistanceBased1);
        }

        [HttpPost]
        public ActionResult DistanceBasedCriteria(VendorContractDistanceBased objVendorContractDistanceBased)
        {
            ActionResult action = base.RedirectToAction("DistanceBased", new { id = objVendorContractDistanceBased.ContractId, transportModeId = objVendorContractDistanceBased.TransportModeId, ftlTypeId = objVendorContractDistanceBased.FtlTypeId, vehicleId = objVendorContractDistanceBased.VehicleId });
            return action;
        }

        [HttpGet]
        public ActionResult DocketBased(short id, short fromLocationId, string fromLocationCode, short toLocationId, string toLocationCode, bool isBooking, short baContractTypeId)
        {
            ActionResult actionResult;
            List<VendorContractDocketBased> vendorContractDocketBaseds = new List<VendorContractDocketBased>();
            vendorContractDocketBaseds = this.vendorContractRepository.GetDocketBasedDetailById(id, fromLocationId, toLocationId, isBooking, baContractTypeId).ToList<VendorContractDocketBased>();
            ((dynamic)base.ViewBag).FromLocationId = fromLocationId;
            ((dynamic)base.ViewBag).FromLocationCode = fromLocationCode;
            ((dynamic)base.ViewBag).ToLocationId = toLocationId;
            ((dynamic)base.ViewBag).ToLocationCode = toLocationCode;
            ((dynamic)base.ViewBag).IsBooking = isBooking;
            ((dynamic)base.ViewBag).BaContractTypeId = baContractTypeId;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            if (vendorContractDocketBaseds.Count <= 0)
            {
                VendorContractDocketBased vendorContractDocketBased = new VendorContractDocketBased()
                {
                    ContractId = id,
                    FromLocationId = fromLocationId,
                    FromLocationCode = fromLocationCode,
                    ToLocationId = toLocationId,
                    ToLocationCode = toLocationCode,
                    IsBooking = isBooking,
                    BaContractTypeId = baContractTypeId
                };
                vendorContractDocketBaseds.Add(vendorContractDocketBased);
                actionResult = base.View(vendorContractDocketBaseds);
            }
            else
            {
                actionResult = base.View(vendorContractDocketBaseds);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult DocketBased(List<VendorContractDocketBased> objDocketBased, short id, short fromLocationId, short toLocationId, bool isBooking, short baContractTypeId)
        {
            ActionResult action;
            Response response = this.vendorContractRepository.InsertDocketBased(objDocketBased, id, fromLocationId, toLocationId, isBooking, baContractTypeId);
            if (!response.IsSuccessfull)
            {
                ((dynamic)base.ViewBag).FromLocationId = objDocketBased[0].FromLocationId;
                ((dynamic)base.ViewBag).FromLocationCode = objDocketBased[0].FromLocationCode;
                ((dynamic)base.ViewBag).ToLocationId = objDocketBased[0].ToLocationId;
                ((dynamic)base.ViewBag).ToLocationCode = objDocketBased[0].ToLocationCode;
                ((dynamic)base.ViewBag).IsBooking = objDocketBased[0].IsBooking;
                ((dynamic)base.ViewBag).BaContractTypeId = objDocketBased[0].BaContractTypeId;
                this.Init();
                this.GetHeaderInfo(new short?(objDocketBased[0].ContractId));
                action = base.View(objDocketBased);
            }
            else
            {
                MasterVendor vendorTypeIdByContractId = (new VendorContractRepository()).GetVendorTypeIdByContractId((short)response.DocumentId);
                action = base.RedirectToAction("Result", new { ContractId = response.DocumentId, VendorTypeId = vendorTypeIdByContractId.VendorTypeId, VendorId = vendorTypeIdByContractId.VendorId });
            }
            return action;
        }

        [HttpGet]
        public ActionResult DocketBasedCriteria(short id, byte vendorTypeId)
        {
            VendorContractDocketBased vendorContractDocketBased = new VendorContractDocketBased()
            {
                ContractId = id,
                VendorTypeId = vendorTypeId
            };
            VendorContractDocketBased vendorContractDocketBased1 = vendorContractDocketBased;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            return base.View(vendorContractDocketBased1);
        }

        [HttpPost]
        public JsonResult GetActiveVendorContract(short vendorId, DateTime documentDate)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.GetActiveVendorContract(vendorId, documentDate), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetAll(short vendorId)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.GetAll(vendorId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetCreditDaysByVendorId(short vendorId)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.GetCreditDaysByVendorId(vendorId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        private void GetHeaderInfo(short? id)
        {
            short num = id.ConvertToShort();
            if (num > 0)
            {
                VendorContract detailById = this.vendorContractRepository.GetDetailById(num);
                ((dynamic)base.ViewBag).VendorName = detailById.VendorName;
                ((dynamic)base.ViewBag).VendorCode = detailById.VendorCode;
                ((dynamic)base.ViewBag).VendorId = detailById.VendorId;
                ((dynamic)base.ViewBag).VendorType = detailById.VendorType;
                ((dynamic)base.ViewBag).VendorTypeId = detailById.VendorTypeId;
                ((dynamic)base.ViewBag).ContractId = detailById.ContractId;
                ((dynamic)base.ViewBag).ManualContractId = detailById.VendorContractBasicInfo.ManualContractId;
                ((dynamic)base.ViewBag).IsCustomerContract = false;
            }
        }

        [HttpPost]
        public JsonResult GetVendorContractAmount(short contractId, byte matrixTypeId, byte transportModeId, short routeId, int fromCityId, int toCityId, byte ftlTypeId, short vehicleId, decimal totalWeight)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.GetVendorContractAmount(contractId, matrixTypeId, transportModeId, routeId, fromCityId, toCityId, ftlTypeId, vehicleId, totalWeight), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult Index(short? vendorId, byte? vendorTypeId)
        {
            bool flag;
            VendorContract vendorContract = new VendorContract()
            {
                ContractId = 0
            };

            byte? nullable1 = vendorTypeId;
            int num;
            if ((nullable1.GetValueOrDefault() <= (byte)0 ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
            {
                short? nullable2 = vendorId;
                num = (nullable2.GetValueOrDefault() <= (short)0 ? 0 : (nullable2.HasValue ? 1 : 0)) == 0 ? 1 : 0;
            }
            else
                num = 1;


            if (num == 0)
            {
                vendorContract.VendorTypeId = vendorTypeId.ConvertToByte();
                ((dynamic)base.ViewBag).vendorId = vendorId.ConvertToShort();
            }
            dynamic viewBag = base.ViewBag;
            IEnumerable<AutoCompleteResult> byIdList = this.generalRepository.GetByIdList(29);
            viewBag.VendorTypeList =
                from m in byIdList
                where m.Value != "1"
                select m;
            ((dynamic)base.ViewBag).VendorNameList = this.vendorRepository.GetVendorNameList();
            return base.View(vendorContract);
        }

        private void Init()
        {
            ((dynamic)base.ViewBag).VendorTypeList = this.generalRepository.GetByIdList(29);
            ((dynamic)base.ViewBag).VendorNameList = this.vendorRepository.GetVendorNameList();
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).VendorCategoryList = this.generalRepository.GetByIdList(2);
            ((dynamic)base.ViewBag).ContractCategoryList = this.generalRepository.GetByIdList(53);
            ((dynamic)base.ViewBag).PaymentBasisList = this.vendorContractRepository.GetPaymentBasisList();
            ((dynamic)base.ViewBag).PaymentIntervalList = this.vendorContractRepository.GetPaymentIntervalList();

            IEnumerable<AutoCompleteResult> ftlTypeList = this.generalRepository.GetByIdList(9);
            List<AutoCompleteResult> autoCompleteFtlTypeList = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteFtlType = new AutoCompleteResult()
            {
                Name = "ALL",
                Value = "0"
            };
            autoCompleteFtlTypeList.Add(autoCompleteFtlType);
            autoCompleteFtlTypeList.AddRange(ftlTypeList);
            ((dynamic)base.ViewBag).FtlTypeList = autoCompleteFtlTypeList;

            ((dynamic)base.ViewBag).VehicleTypeList = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).VehicleType = this.vehicleTypeRepository.GetVehicleTypeList();
            ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleList();
            ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetRouteNameList();
            ((dynamic)base.ViewBag).BaContractList = this.generalRepository.GetByIdList(101);
            IEnumerable<AutoCompleteResult> byIdList = this.generalRepository.GetByIdList(14);
            List<AutoCompleteResult> autoCompleteResults = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteResult = new AutoCompleteResult()
            {
                Name = "ALL",
                Value = "0"
            };
            autoCompleteResults.Add(autoCompleteResult);
            autoCompleteResults.AddRange(byIdList);
            ((dynamic)base.ViewBag).PayBasList = autoCompleteResults;
            IEnumerable<AutoCompleteResult> byIdList1 = this.generalRepository.GetByIdList(15);
            List<AutoCompleteResult> autoCompleteResults1 = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteResult1 = new AutoCompleteResult()
            {
                Name = "ALL",
                Value = "0"
            };
            autoCompleteResults1.Add(autoCompleteResult1);
            autoCompleteResults1.AddRange(byIdList1);
            ((dynamic)base.ViewBag).TransportModeList = autoCompleteResults1;
            ((dynamic)base.ViewBag).DocketRateTypeList = this.generalRepository.GetByIdList(36);
            ((dynamic)base.ViewBag).BookingList = this.vendorContractRepository.GetBookingList();
            ((dynamic)base.ViewBag).CityNameList = this.cityRepository.GetCityList();
            IEnumerable<AutoCompleteResult> byIdList2 = this.generalRepository.GetByIdList(24);
            List<AutoCompleteResult> autoCompleteResults2 = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteResult2 = new AutoCompleteResult()
            {
                Name = "ALL",
                Value = "0"
            };
            autoCompleteResults2.Add(autoCompleteResult2);
            autoCompleteResults2.AddRange(byIdList2);
            ((dynamic)base.ViewBag).ProductTypeList = autoCompleteResults2;
            IEnumerable<AutoCompleteResult> byIdList3 = this.generalRepository.GetByIdList(25);
            List<AutoCompleteResult> autoCompleteResults3 = new List<AutoCompleteResult>();
            AutoCompleteResult autoCompleteResult3 = new AutoCompleteResult()
            {
                Name = "ALL",
                Value = "0"
            };
            autoCompleteResults3.Add(autoCompleteResult3);
            autoCompleteResults3.AddRange(byIdList3);
            ((dynamic)base.ViewBag).PackagingTypeList = autoCompleteResults3;
        }

        public ActionResult Insert()
        {
            VendorContract vendorContract = new VendorContract()
            {
                ContractId = 0
            };
            this.Init();
            return base.View(vendorContract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("ContractId")]
        public ActionResult Insert(VendorContract objVendorContract)
        {
            ActionResult action;
            objVendorContract.VendorContractBasicInfo.EntryBy = SessionUtility.LoginUserId;
            objVendorContract.VendorContractBasicInfo.EntryDate = DateTime.Now;

            Response response = this.vendorContractRepository.Insert(objVendorContract);

            if (!response.IsSuccessfull)
            {
                this.Init();
                action = base.View(objVendorContract);
            }
            else
            {
                if (objVendorContract.VendorTypeId == 5)
                {

                    Session["IsCustomerContract"] = false;
                    action = base.RedirectToAction("Done", new { id = response.DocumentId });
                    //action = base.RedirectToAction("Done", "CustomerContract", new { id = respon//se.DocumentId, IsCustContract = false });
                }
                else
                    action = base.RedirectToAction("Details", new { id = response.DocumentId });
            }
            return action;
        }

        public ActionResult Result(short? ContractId, byte VendorTypeId, short VendorId)
        {
            VendorContract detailById = this.vendorContractRepository.GetDetailById(ContractId.Value);
            return base.View(detailById);
        }

        [HttpGet]
        public ActionResult RouteBased(short id, byte transportModeId, short routeId, short vehicleId, byte ftlTypeId)
        {
            ActionResult actionResult;
            List<VendorContractRouteBased> vendorContractRouteBaseds = new List<VendorContractRouteBased>();
            vendorContractRouteBaseds = this.vendorContractRepository.GetRouteBasedDetailById(id, routeId, vehicleId, ftlTypeId).ToList<VendorContractRouteBased>();
            ((dynamic)base.ViewBag).TransportModeId = transportModeId;
            ((dynamic)base.ViewBag).RouteId = routeId;
            ((dynamic)base.ViewBag).VehicleId = vehicleId;
            ((dynamic)base.ViewBag).FtlTypeId = ftlTypeId;
            this.Init();
            this.GetHeaderInfo(new short?(id));
            ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetRouteListByTransportModeId(transportModeId, 0);
            ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleByFtlTypeId(ftlTypeId);
            if (vendorContractRouteBaseds.Count <= 0)
            {
                VendorContractRouteBased vendorContractRouteBased = new VendorContractRouteBased()
                {
                    ContractId = id,
                    RouteId = routeId,
                    VehicleId = vehicleId,
                    FtlTypeId = ftlTypeId
                };
                vendorContractRouteBaseds.Add(vendorContractRouteBased);
                actionResult = base.View(vendorContractRouteBaseds);
            }
            else
            {
                actionResult = base.View(vendorContractRouteBaseds);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult RouteBased(List<VendorContractRouteBased> objRouteBased, short id, byte transportModeId, short routeId, short vehicleId, byte ftlTypeId)
        {
            ActionResult action;
            objRouteBased.ForEach((VendorContractRouteBased m) =>
            {
                m.EntryBy = SessionUtility.LoginUserId;
                m.EntryDate = DateTime.Now;
                m.UpdateBy = new short?(SessionUtility.LoginUserId);
                m.UpdateDate = new DateTime?(DateTime.Now);
            });
            objRouteBased.AddRange(this.vendorContractRepository.GetRouteBasedDetailById(id, routeId, vehicleId, ftlTypeId));
            Response response = this.vendorContractRepository.InsertRouteBased(objRouteBased);
            if (!response.IsSuccessfull)
            {
                this.Init();
                this.GetHeaderInfo(new short?(objRouteBased[0].ContractId));
                ((dynamic)base.ViewBag).TransportModeId = objRouteBased[0].TransportModeId;
                ((dynamic)base.ViewBag).RouteId = objRouteBased[0].RouteId;
                ((dynamic)base.ViewBag).VehicleId = objRouteBased[0].VehicleId;
                ((dynamic)base.ViewBag).FtlTypeId = objRouteBased[0].FtlTypeId;
                ((dynamic)base.ViewBag).RouteList = this.routeRepository.GetRouteListByTransportModeId(objRouteBased[0].TransportModeId, 0);
                ((dynamic)base.ViewBag).VehicleList = this.vehicleRepository.GetVehicleByFtlTypeId(objRouteBased[0].FtlTypeId);
                action = base.View(objRouteBased);
            }
            else
            {
                MasterVendor vendorTypeIdByContractId = (new VendorContractRepository()).GetVendorTypeIdByContractId(response.DocumentId.ConvertToShort());
                action = base.RedirectToAction("Result", new { ContractId = response.DocumentId, VendorTypeId = vendorTypeIdByContractId.VendorTypeId, VendorId = vendorTypeIdByContractId.VendorId });
            }
            return action;
        }

        public ActionResult RouteBasedCriteria(short id, byte vendorTypeId)
        {
            VendorContractRouteBased vendorContractRouteBased = new VendorContractRouteBased()
            {
                ContractId = id,
                VendorTypeId = vendorTypeId
            };
            VendorContractRouteBased vendorContractRouteBased1 = vendorContractRouteBased;
            this.GetHeaderInfo(new short?(id));
            this.Init();
            return base.View(vendorContractRouteBased1);
        }

        [HttpPost]
        public ActionResult RouteBasedCriteria(VendorContractRouteBased objVendorContractRouteBased)
        {
            ActionResult action = base.RedirectToAction("RouteBased", new { id = objVendorContractRouteBased.ContractId, transportModeId = objVendorContractRouteBased.TransportModeId, routeId = objVendorContractRouteBased.RouteId, vehicleId = objVendorContractRouteBased.VehicleId, ftlTypeId = objVendorContractRouteBased.FtlTypeId });
            return action;
        }

        public ActionResult StepSelection(short? contractId, byte? vendorTypeId, short? vendorId)
        {
            VendorContract vendorContract = new VendorContract();
            this.GetHeaderInfo(contractId);
            return base.View(vendorContract);
        }

        public ActionResult Update(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            short? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?(nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                VendorContract detailById = this.vendorContractRepository.GetDetailById(id.Value);
                if (detailById != null)
                {
                    this.Init();
                    httpStatusCodeResult = base.View(detailById);
                }
                else
                {
                    httpStatusCodeResult = base.HttpNotFound();
                }
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("ContractId")]
        public ActionResult Update(VendorContract objVendorContract)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objVendorContract.VendorContractBasicInfo.UpdateBy = new short?(SessionUtility.LoginUserId);
                objVendorContract.VendorContractBasicInfo.UpdateDate = new DateTime?(DateTime.Now);
                Response response = this.vendorContractRepository.Update(objVendorContract);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("Details", new { id = response.DocumentId });
                    return action;
                }
            }
            this.Init();
            action = base.RedirectToAction("Details", new { id = objVendorContract.ContractId });
            return action;
        }



        public ActionResult ModewiseServices(short? id)
        {
            VendorContractModewiseServices vendorContractModewiseService = new VendorContractModewiseServices()
            {
                ContractId = id.Value,
                ServiceTaxPayer = this.generalRepository.GetByGeneralList(20).ToArray<MasterGeneral>()
            };
            ((dynamic)base.ViewBag).ServiceTaxPayerList = this.generalRepository.GetByIdList(20);
            ((dynamic)base.ViewBag).TransportModeList = new SelectList(this.vendorContractRepository.GetTransportModeList(vendorContractModewiseService.ContractId), "Value", "Name");
            this.ModewiseServicesInit();
            this.GetHeaderInfo(id);
            return base.View(vendorContractModewiseService);
        }

        [HttpPost]
        public ActionResult ModewiseServices(VendorContractModewiseServices objVendorContractModewiseServices)
        {
            ActionResult action;
            if (!objVendorContractModewiseServices.UseMinimumFreightTypeBaseWise)
            {
                objVendorContractModewiseServices.MinimumFreightRate = new decimal(0);
                objVendorContractModewiseServices.MinimumFreightRateType = "F";
                objVendorContractModewiseServices.MinimumFreightAmount = new decimal(0);
                base.ModelState.Remove("MinimumFreighRate");
                base.ModelState.Remove("MinimumFreighRateType");
                base.ModelState.Remove("MinimumFreightAmount");
            }
            if (objVendorContractModewiseServices.UseMinimumFreightTypeBaseWise)
            {
                base.ModelState.Remove("MinimumFreightLowerLimit");
                base.ModelState.Remove("MinimumFreightUpperLimit");
                base.ModelState.Remove("MinimumSubTotalAmount");
                base.ModelState.Remove("SubTotalLowerLimit");
                base.ModelState.Remove("SubTotalUpperLimit");
                base.ModelState.Remove("MinimumFreightAmount");
            }
            if (base.ModelState.IsValid)
            {
                if (this.vendorContractRepository.InsertModewiseServices(objVendorContractModewiseServices).IsSuccessfull)
                {
                    action = base.RedirectToAction("Result", new { documentId = objVendorContractModewiseServices.ContractId });
                    return action;
                }
            }
            this.ModewiseServicesInit();
            action = base.View(objVendorContractModewiseServices);
            return action;
        }
        private void ModewiseServicesInit()
        {
            ((dynamic)base.ViewBag).FuelSurchargeRateTypeList = this.vendorContractRepository.GetFuelSurchargeRateTypeList();
        }
        public ActionResult DefineChargeMatrix(short? id)
        {
            string moduleRuleByIdAndRuleId = this.rulesRepository.GetModuleRuleByIdAndRuleId(ModuleHelper.Docket, RuleHelper.ChargeRule);
            this.InitDefineChargeMatrix(moduleRuleByIdAndRuleId.ConvertToByte(), true);
            if (base.Request.QueryString["IsBooking"] == null)
            {
                ((dynamic)base.ViewBag).IsBooking = true;
                ((dynamic)base.ViewBag).IsDelivery = false;
            }
            else
            {
                ((dynamic)base.ViewBag).IsBooking = base.Request.QueryString["IsBooking"].ConvertToBool();
                if (!((dynamic)base.ViewBag).IsBooking)
                {
                    ((dynamic)base.ViewBag).IsDelivery = true;
                }
                else
                {
                    ((dynamic)base.ViewBag).IsDelivery = false;
                }
            }
            VendorContractDefineChargeMatrixHDR vendorContractDefineChargeMatrixHDR = new VendorContractDefineChargeMatrixHDR()
            {
                ContractId = id.ConvertToShort(),
                IsBooking = (bool)((dynamic)base.ViewBag).IsBooking,
                IsDelivery = (bool)((dynamic)base.ViewBag).IsDelivery,
                BaseOn = moduleRuleByIdAndRuleId.ConvertToByte(),
                BaseCode = Convert.ToByte(((dynamic)base.ViewBag).BaseCode)
            };
            VendorContractDefineChargeMatrixHDR list = vendorContractDefineChargeMatrixHDR;
            list.Details = this.vendorContractRepository.GetDefineChargeMatrixList(list).ToList<VendorContractDefineChargeMatrix>();
            this.GetHeaderInfo(id);
            return base.View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DefineChargeMatrix(VendorContractDefineChargeMatrixHDR objFilterVendor)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                foreach (VendorContractDefineChargeMatrix detail in objFilterVendor.Details)
                {
                    detail.ContractId = objFilterVendor.ContractId;
                    detail.IsBooking = objFilterVendor.IsBooking;
                    detail.BaseOn = objFilterVendor.BaseOn;
                    detail.BaseCode = objFilterVendor.BaseCode;
                    detail.UpdateBy = new short?(SessionUtility.LoginUserId);
                    detail.UpdateDate = new DateTime?(DateTime.Now);
                }
                if (this.vendorContractRepository.UpdateDefineChargeMatrix(objFilterVendor).IsSuccessfull)
                {
                    action = base.RedirectToAction("Result", new { documentId = objFilterVendor.ContractId });
                    return action;
                }
            }
            this.InitDefineChargeMatrix(objFilterVendor.BaseOn, false);
            action = base.View(objFilterVendor);
            return action;
        }
        private void InitDefineChargeMatrix(byte baseOn, bool isPageLoad)
        {
            ((dynamic)base.ViewBag).SlabTypeList = this.vendorContractRepository.GetSlabTypeList();
            ((dynamic)base.ViewBag).ChargeBaseList = this.vendorContractRepository.GetChargeBaseList();
            if (baseOn == 1)
            {
                ((dynamic)base.ViewBag).BaseCodeList = this.generalRepository.GetByIdList(22).ToList<AutoCompleteResult>();
                ((dynamic)base.ViewBag).BaseOnName = "Business Type";
            }
            else if (baseOn != 2)
            {
                ((dynamic)base.ViewBag).BaseCodeList = this.vendorContractRepository.GetBaseCodeList();
            }
            else
            {
                ((dynamic)base.ViewBag).BaseCodeList = this.generalRepository.GetByIdList(16).ToList<AutoCompleteResult>();
                ((dynamic)base.ViewBag).BaseOnName = "Service Type";
            }
            if (isPageLoad)
            {
                if (base.Request.QueryString["BaseCode"] == null)
                {
                    base.ViewBag.BaseCode = (((dynamic)base.ViewBag).BaseCodeList as List<AutoCompleteResult>).FirstOrDefault<AutoCompleteResult>().Value;
                }
                else
                {
                    ((dynamic)base.ViewBag).BaseCode = base.Request.QueryString["BaseCode"].ConvertToByte();
                }
            }
        }
        public ActionResult StandardChargeCriteria(short id)
        {
            VendorContractChargeMatrixSTD vendorContractChargeMatrixSTD = new VendorContractChargeMatrixSTD();

            byte num = this.rulesRepository.GetModuleRuleByIdAndRuleId(ModuleHelper.Docket, RuleHelper.ChargeRule).ConvertToByte();
            this.InitDefineChargeMatrix(num, true);
            vendorContractChargeMatrixSTD.ContractId = id.ConvertToShort();
            vendorContractChargeMatrixSTD.BaseOn1 = num;
            vendorContractChargeMatrixSTD.IsBooking = true;
            ((dynamic)base.ViewBag).MatrixTypeList = this.vendorContractRepository.GetMatrixTypeListByContractId(id);
            this.Init(new bool?(true), id);
            ((dynamic)base.ViewBag).TransportModeList = this.vendorContractRepository.GetTransportModeList(id);
            this.GetHeaderInfo(new short?(id));
            return base.View(vendorContractChargeMatrixSTD);
        }

        private void Init(bool? isCustomerContract, short contractId)
        {
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).PartyCategoryList = this.generalRepository.GetByIdList(52);
            ((dynamic)base.ViewBag).ContractCategoryList = this.generalRepository.GetByIdList(53);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).RateTypeList = this.vendorContractRepository.GetRateTypeListByContractId(contractId);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).ProRataTypeList = this.generalRepository.GetByIdList(50);
            ((dynamic)base.ViewBag).RiskMatrixRateTypeList = this.vendorContractRepository.GetRiskMatrixRateTypeList();
            if (!isCustomerContract.ConvertToBool())
            {
                ((dynamic)base.ViewBag).CustomerList = this.vendorRepository.GetVendorNameList();
            }
            else
            {
                ((dynamic)base.ViewBag).CustomerList = this.vendorRepository.GetCustomerList();
            }
        }

        private void ServiceSelectionInit()
        {
            ((dynamic)base.ViewBag).CodDaccRateTypeList = this.generalRepository.GetByIdList(17);
        }

        public ActionResult ServiceSelection(short id)
        {

            MasterGeneral masterGeneral;
            MasterGeneral masterGeneral1;
            MasterGeneral masterGeneral2;
            MasterGeneral masterGeneral3;
            MasterGeneral masterGeneral4;
            int i;


            VendorContractServices vendorContractService = new VendorContractServices()
            {
                ContractId = id
            };

            List<VendorContractServiceAccess> list = this.vendorContractRepository.GetServiceAccessById(id).ToList<VendorContractServiceAccess>();
            vendorContractService.TransportMode = this.generalRepository.GetByGeneralList(15).ToArray<MasterGeneral>();
            vendorContractService.ServiceType = this.generalRepository.GetByGeneralList(16).ToArray<MasterGeneral>();
            vendorContractService.RateTypes = this.generalRepository.GetByGeneralList(17).ToArray<MasterGeneral>();
            vendorContractService.Matrices = this.generalRepository.GetByGeneralList(18).ToArray<MasterGeneral>();
            vendorContractService.PickupDelivery = this.generalRepository.GetByGeneralList(19).ToArray<MasterGeneral>();
            MasterGeneral[] transportMode = vendorContractService.TransportMode;

            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral = transportMode[i];
                masterGeneral.CodeTypeId = 15;
                masterGeneral.IsActive = false;
            }

            transportMode = vendorContractService.ServiceType;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral1 = transportMode[i];
                masterGeneral1.CodeTypeId = 16;
                masterGeneral1.IsActive = false;
            }
            transportMode = vendorContractService.RateTypes;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral2 = transportMode[i];
                masterGeneral2.CodeTypeId = 17;
                masterGeneral2.IsActive = false;
            }
            transportMode = vendorContractService.Matrices;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral3 = transportMode[i];
                masterGeneral3.CodeTypeId = 18;
                masterGeneral3.IsActive = false;
            }
            transportMode = vendorContractService.PickupDelivery;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral4 = transportMode[i];
                masterGeneral4.CodeTypeId = 19;
                masterGeneral4.IsActive = false;
            }

            foreach (VendorContractServiceAccess vendorContractServiceAccess in list)
            {
                if (vendorContractServiceAccess.ServiceTypeId == 15)
                {
                    transportMode = vendorContractService.TransportMode;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral = transportMode[i];
                        if (vendorContractServiceAccess.ServiceId == masterGeneral.CodeId)
                        {
                            masterGeneral.IsActive = true;
                        }
                    }
                }
                if (vendorContractServiceAccess.ServiceTypeId == 16)
                {
                    transportMode = vendorContractService.ServiceType;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral1 = transportMode[i];
                        if (vendorContractServiceAccess.ServiceId == masterGeneral1.CodeId)
                        {
                            masterGeneral1.IsActive = true;
                        }
                    }
                }
                if (vendorContractServiceAccess.ServiceTypeId == 17)
                {
                    transportMode = vendorContractService.RateTypes;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral2 = transportMode[i];
                        if (vendorContractServiceAccess.ServiceId == masterGeneral2.CodeId)
                        {
                            masterGeneral2.IsActive = true;
                        }
                    }
                }
                if (vendorContractServiceAccess.ServiceTypeId == 18)
                {
                    transportMode = vendorContractService.Matrices;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral3 = transportMode[i];
                        if (vendorContractServiceAccess.ServiceId == masterGeneral3.CodeId)
                        {
                            masterGeneral3.IsActive = true;
                        }
                    }
                }
                if (vendorContractServiceAccess.ServiceTypeId == 19)
                {
                    transportMode = vendorContractService.PickupDelivery;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral4 = transportMode[i];
                        if (vendorContractServiceAccess.ServiceId == masterGeneral4.CodeId)
                        {
                            masterGeneral4.IsActive = true;
                        }
                    }
                }
            }
            this.Init(new bool?(true));
            vendorContractService.CarrierDetails = this.vendorContractRepository.GetCarrierRiskList(id).ToList<VendorContractRiskMatrix>();
            vendorContractService.OwnerDetails = this.vendorContractRepository.GetOwnerRiskList(id).ToList<VendorContractRiskMatrix>();
            if (vendorContractService.CarrierDetails.Count < 1)
            {
                List<VendorContractRiskMatrix> carrierDetails = vendorContractService.CarrierDetails;
                VendorContractRiskMatrix customerContractRiskMatrix = new VendorContractRiskMatrix()
                {
                    ContractId = id,
                    FromFreight = new decimal(0),
                    ToFreight = new decimal(0),
                    Rate = new decimal(0),
                    RateType = 0,
                    IsCarrierRisk = true,
                    MaximumChargeAmount = new decimal(0),
                    MinimumChargeAmount = new decimal(0)
                };
                carrierDetails.Add(customerContractRiskMatrix);
            }
            if (vendorContractService.OwnerDetails.Count < 1)
            {
                List<VendorContractRiskMatrix> ownerDetails = vendorContractService.OwnerDetails;
                VendorContractRiskMatrix customerContractRiskMatrix1 = new VendorContractRiskMatrix()
                {
                    ContractId = id,
                    FromFreight = new decimal(0),
                    ToFreight = new decimal(0),
                    Rate = new decimal(0),
                    RateType = 0,
                    MaximumChargeAmount = new decimal(0),
                    MinimumChargeAmount = new decimal(0)
                };
                ownerDetails.Add(customerContractRiskMatrix1);
            }
            this.ServiceSelectionInit();
            this.GetHeaderInfo(new short?(id));
            return base.View(vendorContractService);
        }


        private void Init(bool? isVendorContract)
        {
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).PartyCategoryList = this.generalRepository.GetByIdList(52);
            ((dynamic)base.ViewBag).ContractCategoryList = this.generalRepository.GetByIdList(53);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).ProRataTypeList = this.generalRepository.GetByIdList(50);
            ((dynamic)base.ViewBag).RiskMatrixRateTypeList = this.vendorContractRepository.GetRiskMatrixRateTypeList();
        }


        [HttpPost]
        public JsonResult GetExpenseRate(byte transportModeId, byte matrixTypeId, short fromLocationId, short toLocationId, byte rateTypeId)
        {
            JsonResult jsonResult = base.Json(this.vendorContractRepository.GetExpenseRate(transportModeId, matrixTypeId, fromLocationId, toLocationId, rateTypeId));
            return jsonResult;
        }


        [HttpPost]
        public ActionResult ServiceSelection(VendorContractServices objVendorContractServices)
        {
            ActionResult action;
            if (!objVendorContractServices.UseVolumetric)
            {
                base.ModelState.Remove("VolumetricWeightType");
                objVendorContractServices.VolumetricWeightType = "";
            }
            if (!objVendorContractServices.UseCod)
            {
                base.ModelState.Remove("CodRateType");
                objVendorContractServices.CodRateType = 0;
            }
            if (!objVendorContractServices.UseDacc)
            {
                base.ModelState.Remove("DaccRateType");
                objVendorContractServices.DaccRateType = 0;
            }
            if (!objVendorContractServices.UseOctroi)
            {
                base.ModelState.Remove("OctroiRateType");
                objVendorContractServices.OctroiRateType = 0;
            }
            if (!objVendorContractServices.UseDeliveryWithoutDemurrage)
            {
                base.ModelState.Remove("DemurrageRateType");
                objVendorContractServices.DemurrageRateType = 0;
            }
            objVendorContractServices.CarrierDetails.ForEach((VendorContractRiskMatrix m) => m.ContractId = objVendorContractServices.ContractId);
            objVendorContractServices.OwnerDetails.ForEach((VendorContractRiskMatrix m) => m.ContractId = objVendorContractServices.ContractId);
            if (!objVendorContractServices.IsFovApplicable)
            {
                base.ModelState.Remove("CarrierDetails[0].RateType");
                base.ModelState.Remove("OwnerDetails[0].RateType");
            }
            objVendorContractServices.EntryBy = SessionUtility.LoginUserId;
            if (!this.vendorContractRepository.InsertServices(objVendorContractServices).IsSuccessfull)
            {
                this.ServiceSelectionInit();
                action = base.View(objVendorContractServices);
            }
            else
            {
                action = base.RedirectToAction("Result", new { documentId = objVendorContractServices.ContractId });
            }
            return action;
        }

        public ActionResult Done(short? id)
        {
            ((dynamic)base.ViewBag).IsCustomerContract = false;
            this.GetHeaderInfo(id);
            return base.View();
        }

    }
}

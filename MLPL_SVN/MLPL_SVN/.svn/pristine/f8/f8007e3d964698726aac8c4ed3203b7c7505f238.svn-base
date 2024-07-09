
using CodeLock.Areas.Contract.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Contract.Controllers
{
    public class CustomerContractController : Controller
    {
        private readonly ICustomerContractRepository customerContractRepository;

        private readonly ILocationRepository locationRepository;

        private readonly IGeneralRepository generalRepository;

        private readonly ICountryRepository countryRepository;

        private readonly ICustomerRepository customerRepository;

        private readonly IAddressRepository addressRepository;

        private readonly IVendorRepository vendorRepository;

        private readonly IStateRepository stateRepository;

        private readonly ICityRepository cityRepository;

        private readonly IRulesRepository rulesRepository;

        private readonly IChargeRepository chargeRepository;

        private readonly IVehicleRepository vehicleRepository;
        private readonly IPartRepository partRepository;
        public CustomerContractController()
        {
        }
        public CustomerContractController(ICustomerContractRepository _customerContractRepository, ILocationRepository _locationRepository, IGeneralRepository _generalRepository, ICountryRepository _countryRepository, ICustomerRepository _customerRepository, IVendorRepository _vendorRepository, IStateRepository _stateRepository, ICityRepository _cityRepository, IRulesRepository _rulesRepository, IAddressRepository _addressRepository, IChargeRepository _chargeRepository, IVehicleRepository _vehicleRepository, IPartRepository _partRepository)
        {
            this.customerContractRepository = _customerContractRepository;
            this.locationRepository = _locationRepository;
            this.generalRepository = _generalRepository;
            this.countryRepository = _countryRepository;
            this.customerRepository = _customerRepository;
            this.addressRepository = _addressRepository;
            this.vendorRepository = _vendorRepository;
            this.stateRepository = _stateRepository;
            this.cityRepository = _cityRepository;
            this.rulesRepository = _rulesRepository;
            this.chargeRepository = _chargeRepository;
            this.vehicleRepository = _vehicleRepository;
            this.partRepository = _partRepository;
        }
        public ActionResult BillingInfo(short id)
        {
            CustomerContractBillingInfo customerContractBillingInfo = new CustomerContractBillingInfo()
            {
                ContractId = id
            };
            CustomerContractBillingInfo billingDetails = this.customerContractRepository.GetBillingDetails(id);
            if (billingDetails != null)
            {
                customerContractBillingInfo = billingDetails;
            }
            this.Init(new bool?(true));
            this.Init2(customerContractBillingInfo.CountryId, customerContractBillingInfo.StateId, customerContractBillingInfo.ContractId);
            this.GetHeaderInfo(new short?(id));
            return base.View(customerContractBillingInfo);
        }

        [HttpPost]
        public ActionResult BillingInfo(CustomerContractBillingInfo objCustomerContractBillingInfo)
        {
            ActionResult action;
            if (objCustomerContractBillingInfo.BillLocationRule == 0)
            {
                base.ModelState.Remove("BillGenerationLocationId");
            }
            if (objCustomerContractBillingInfo.BillLocationRule == 2)
            {
                base.ModelState.Remove("BillGenerationLocationId");
            }
            if (!base.ModelState.IsValid)
            {
                this.Init(new bool?(true));
                this.Init2(objCustomerContractBillingInfo.CountryId, objCustomerContractBillingInfo.StateId, objCustomerContractBillingInfo.ContractId);
                action = base.View(objCustomerContractBillingInfo);
            }
            else
            {
                objCustomerContractBillingInfo.EntryBy = SessionUtility.LoginUserId;
                this.customerContractRepository.InsertBillingInfo(objCustomerContractBillingInfo);
                action = base.RedirectToAction("Result", new { documentId = objCustomerContractBillingInfo.ContractId });
            }
            return action;
        }

        [HttpPost]
        public JsonResult CheckDate(short contractId, short customerId, byte paybasId, bool isCustomerContract, DateTime startDate, DateTime endDate)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.CheckDate(contractId, customerId, paybasId, isCustomerContract, startDate, endDate), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CheckDateIsValid(short contractId, short customerId, byte paybasId, bool isCustomerContract, DateTime contractDate)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.CheckDateIsValid(contractId, customerId, paybasId, isCustomerContract, contractDate), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult CheckOdaApplicable(short contractId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.CheckOdaApplicable(contractId));
            return jsonResult;
        }
        public ActionResult CopyContract(short? customerId, bool? isCustomerContract)
        {
            CopyCustomerContract copyCustomerContract = new CopyCustomerContract()
            {
                IsCustomerContract = (isCustomerContract.HasValue ? isCustomerContract.ConvertToBool() : true),
                CustomerId = customerId.ConvertToShort()
            };
            this.Init(new bool?(copyCustomerContract.IsCustomerContract));
            return base.View(copyCustomerContract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("ContractId")]
        public ActionResult CopyContract(CopyCustomerContract objCopyCustomerContract)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objCopyCustomerContract.EntryBy = SessionUtility.LoginUserId;
                Response response = this.customerContractRepository.CopyContract(objCopyCustomerContract);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("Done", new { id = response.DocumentId });
                    return action;
                }
            }
            this.Init(new bool?(objCopyCustomerContract.IsCustomerContract));
            action = base.View(objCopyCustomerContract);
            return action;
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
            bool usePartVolumetric = this.customerContractRepository.GetServicesById((short)id).UsePartVolumetric;
            CustomerContractDefineChargeMatrixHDR customerContractDefineChargeMatrixHDR = new CustomerContractDefineChargeMatrixHDR()
            {
                ContractId = id.ConvertToShort(),
                IsBooking = (bool)((dynamic)base.ViewBag).IsBooking,
                IsDelivery = (bool)((dynamic)base.ViewBag).IsDelivery,
                BaseOn = moduleRuleByIdAndRuleId.ConvertToByte(),
                BaseCode = Convert.ToByte(((dynamic)base.ViewBag).BaseCode),
                UsePartVolumetric = usePartVolumetric
            };
            CustomerContractDefineChargeMatrixHDR list = customerContractDefineChargeMatrixHDR;
            list.Details = this.customerContractRepository.GetDefineChargeMatrixList(list).ToList<CustomerContractDefineChargeMatrix>();
            this.GetHeaderInfo(id);
            return base.View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DefineChargeMatrix(CustomerContractDefineChargeMatrixHDR objFilter)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                foreach (CustomerContractDefineChargeMatrix detail in objFilter.Details)
                {
                    detail.ContractId = objFilter.ContractId;
                    detail.IsBooking = objFilter.IsBooking;
                    detail.BaseOn = objFilter.BaseOn;
                    detail.BaseCode = objFilter.BaseCode;
                    detail.UpdateBy = new short?(SessionUtility.LoginUserId);
                    detail.UpdateDate = new DateTime?(DateTime.Now);
                }
                if (this.customerContractRepository.UpdateDefineChargeMatrix(objFilter).IsSuccessfull)
                {
                    action = base.RedirectToAction("Result", new { documentId = objFilter.ContractId });
                    return action;
                }
            }
            this.InitDefineChargeMatrix(objFilter.BaseOn, false);
            action = base.View(objFilter);
            return action;
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
                this.GetHeaderInfo(id);
                CustomerContract value = (CustomerContract)this.customerContractRepository.GetById(id.Value, ((dynamic)base.ViewBag).IsCustomerContract);
                if (value != null)
                {
                    httpStatusCodeResult = base.View(value);
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

        public ActionResult Done(short? id)
        {
            this.GetHeaderInfo(id);
            return base.View();
        }

        public ActionResult FleetCharge(short id, byte baseOn1, byte baseOn2, byte baseCode1, short baseCode2, byte chargeCode, byte matrixType, short fromLocation, short toLocation, byte transportModeId, bool isBooking, byte ftlTypeId, short consignorId, short consigneeId)
        {
            ActionResult actionResult;
            var oCustomerContractData = this.customerContractRepository.GetById(id, true);
            var IsMilkrunHrsPerDayEnabled = oCustomerContractData.IsMilkrunHrsPerDayEnabled;
            var IsLaneEnabled = oCustomerContractData.IsLaneEnabled;
            var CustomerId = oCustomerContractData.CustomerId;
            CustomerContractFleetCharge customerContractFleetCharge = new CustomerContractFleetCharge()
            {
                Details = this.customerContractRepository.GetFleetChargeBySearchingCriteria(id, chargeCode, matrixType, toLocation, ftlTypeId).ToList<CustomerContractFleetCharge>(),
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
            items.Add(new AutoCompleteResult { Value = "1", Name = "Fixed" });
            items.Add(new AutoCompleteResult { Value = "2", Name = "Per Days" });
            ((dynamic)base.ViewBag).ContractTypeList = items;


            if (IsLaneEnabled)
            {
                var oLaneList = this.customerContractRepository.GetLaneList((short)SessionUtility.CompanyId, oCustomerContractData.CustomerId, null);
                List<AutoCompleteResult> viewBag_LaneList = oLaneList.Select(row => new AutoCompleteResult() { Name = row.LaneId, Value = row.ID.ToString() }).ToList();
                viewBag_LaneList.Insert(0, new AutoCompleteResult() { Name = "Select Lane", Value = string.Empty });
                ((dynamic)base.ViewBag).LaneList = viewBag_LaneList;
            }
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
                actionResult = base.View(customerContractFleetCharge1);
            }
            else
            {
                actionResult = base.View(customerContractFleetCharge1);
            }
            return actionResult;
        }

        [HttpPost]
        public JsonResult GetLaneDetails(short companyId, short customerId, short laneId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetLaneList(companyId, customerId, laneId));
            return jsonResult;
        }

        [HttpPost]
        public ActionResult FleetCharge(CustomerContractFleetCharge objCustomerContractFleetCharge)
        {
            ActionResult action;
            objCustomerContractFleetCharge.EntryBy = SessionUtility.LoginUserId;
            Response response = this.customerContractRepository.InsertFleetCharge(objCustomerContractFleetCharge);
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
                action = base.RedirectToAction("Result", new { documentId = response.DocumentId });
            }
            return action;
        }

        [HttpPost]
        public JsonResult GetAll(short customerId, bool? isCustomerContract)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetAll(customerId, isCustomerContract.ConvertToBool()), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetBaseCode2List(short contractId, byte baseOn, byte baseCode, bool isBooking, byte chargeCode)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetBaseCode2List(contractId, baseOn, baseCode, isBooking, chargeCode));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetBillingDetails(short contractId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetBillingDetails(contractId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public JsonResult GetBillingInfoByCustomerId(short customerId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetBillingInfoByCustomerId(customerId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetChargeBase(short contractId, byte baseOn, byte baseCode, bool isBooking, byte chargeCode)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetChargeBase(contractId, baseOn, baseCode, isBooking, chargeCode));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetChargeList(short contractId, byte baseOn, byte baseCode, bool isBooking)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetChargeList(contractId, baseOn, baseCode, isBooking));
            return jsonResult;
        }

        public JsonResult GetCreditDaysByCustomerIdAndPaybasId(short customerId, byte paybasId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetCreditDaysByCustomerIdAndPaybasId(customerId, paybasId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetDetail(short contractId, byte baseOn, byte baseCode, bool isBooking, byte chargeCode)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetDetail(contractId, baseOn, baseCode, isBooking, chargeCode));
            return jsonResult;
        }

        public JsonResult GetDetails()
        {
            return base.Json(this.customerContractRepository.GetDetails(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetailsByManualContractId(string manualContractId, string customerCode, string customerName)
        {
            IEnumerable<CustomerContract> detailsByManualContractId = this.customerContractRepository.GetDetailsByManualContractId(manualContractId, customerCode, customerName);
            return base.Json(detailsByManualContractId, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDetailsForFreightContract(short contractId)
        {
            IEnumerable<CustomerContract> detailsForFreightContract = this.customerContractRepository.GetDetailsForFreightContract(contractId);
            return base.Json(detailsForFreightContract, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetExpenseRate(byte transportModeId, byte matrixTypeId, short fromLocationId, short toLocationId, byte rateTypeId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetExpenseRate(transportModeId, matrixTypeId, fromLocationId, toLocationId, rateTypeId));
            return jsonResult;
        }

        public JsonResult GetFreightContractDetailsByManualContractId(short contractId, string manualContractId, string customerCode, string customerName)
        {
            IEnumerable<CustomerContract> freightContractDetailsByManualContractId = this.customerContractRepository.GetFreightContractDetailsByManualContractId(contractId, manualContractId, customerCode, customerName);
            return base.Json(freightContractDetailsByManualContractId, JsonRequestBehavior.AllowGet);
        }

        private void GetHeaderInfo(short? id)
        {
            short num = id.ConvertToShort();
            if (num <= 0)
            {
                ((dynamic)base.ViewBag).IsCustomerContract = true;
            }
            else
            {
                CustomerContract contractHeaderInformation = this.customerContractRepository.GetContractHeaderInformation(num);
                ((dynamic)base.ViewBag).CustomerName = contractHeaderInformation.CustomerName;
                ((dynamic)base.ViewBag).CustomerCode = contractHeaderInformation.CustomerCode;
                ((dynamic)base.ViewBag).CustomerId = contractHeaderInformation.CustomerId;
                ((dynamic)base.ViewBag).ContractId = contractHeaderInformation.ContractId;
                ((dynamic)base.ViewBag).ManualContractId = contractHeaderInformation.ManualContractId;
                ((dynamic)base.ViewBag).IsCustomerContract = contractHeaderInformation.IsCustomerContract;
                ((dynamic)base.ViewBag).BillLocationId = contractHeaderInformation.BillGenerationLocationId;
                ((dynamic)base.ViewBag).IsBillLocationEditable = contractHeaderInformation.IsBillLocationEditable;
            }
        }

        public List<AutoCompleteResult> GetMatrixTypeListByContractId(short id)
        {
            return this.customerContractRepository.GetMatrixTypeListByContractId(id).ToList<AutoCompleteResult>();
        }

        public CustomerContractModewiseServices GetModewiseServicesDetail(short contractId, short transportmodeId)
        {
            return this.customerContractRepository.GetModewiseServicesDetails(contractId, transportmodeId);
        }

        [HttpPost]
        public JsonResult GetModewiseServicesDetails(short contractId, short transportmodeId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetModewiseServicesDetails(contractId, transportmodeId), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetRateInquiry(short customerId, byte matrixTypeId, short fromLocationId, short toLocationId)
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.GetRateInquiry(customerId, matrixTypeId, fromLocationId, toLocationId));
            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetServicesById(short id)
        {
            JsonResult jsonResult;
            CustomerContractServices servicesById = this.customerContractRepository.GetServicesById(id);
            if (servicesById == null)
            {
                servicesById = new CustomerContractServices()
                {
                    ContractId = id
                };
                jsonResult = base.Json(servicesById, JsonRequestBehavior.AllowGet);
            }
            else
            {
                jsonResult = base.Json(servicesById, JsonRequestBehavior.AllowGet);
            }
            return jsonResult;
        }
        public ActionResult IndexVendor(short? customerId, bool? isCustomerContract)
        {
            short? nullable1 = customerId;
            isCustomerContract = false;
            int num;
            if ((nullable1.GetValueOrDefault() <= (short)0 ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
            {
                bool? nullable2 = isCustomerContract;
                num = (nullable2.GetValueOrDefault() ? 0 : (nullable2.HasValue ? 1 : 0)) == 0 ? 1 : 0;
            }
            else
                num = 1;
            //if (num == 0)
            //    return (ActionResult)this.View((object)this.customerContractRepository.GetVendorContract(customerId));

            return (ActionResult)this.View((object)this.customerContractRepository.GetVendorContract(customerId));

            //            return (ActionResult)this.View((object)this.customerContractRepository.GetAll());
        }



        public ActionResult Index(short? customerId, bool? isCustomerContract)
        {
            short? nullable1 = customerId;
            int num;
            if ((nullable1.GetValueOrDefault() <= (short)0 ? 0 : (nullable1.HasValue ? 1 : 0)) != 0)
            {
                bool? nullable2 = isCustomerContract;
                num = (nullable2.GetValueOrDefault() ? 0 : (nullable2.HasValue ? 1 : 0)) == 0 ? 1 : 0;
            }
            else
                num = 1;
            if (num == 0)
                return (ActionResult)this.View((object)this.customerContractRepository.GetVendorContract(customerId));
            return (ActionResult)this.View((object)this.customerContractRepository.GetAll());
        }


        private void Init(bool? isCustomerContract)
        {
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).PartyCategoryList = this.generalRepository.GetByIdList(52);
            ((dynamic)base.ViewBag).ContractCategoryList = this.generalRepository.GetByIdList(53);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).ProRataTypeList = this.generalRepository.GetByIdList(50);
            ((dynamic)base.ViewBag).RiskMatrixRateTypeList = this.customerContractRepository.GetRiskMatrixRateTypeList();
            if (!isCustomerContract.ConvertToBool())
            {
                ((dynamic)base.ViewBag).CustomerList = this.vendorRepository.GetVendorNameList();
            }
            else
            {
                ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetCustomerList();
            }
        }

        private void Init(bool? isCustomerContract, short contractId)
        {
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).LocationList = this.locationRepository.GetLocationList();
            ((dynamic)base.ViewBag).PartyCategoryList = this.generalRepository.GetByIdList(52);
            ((dynamic)base.ViewBag).ContractCategoryList = this.generalRepository.GetByIdList(53);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).RateTypeList = this.customerContractRepository.GetRateTypeListByContractId(contractId);
            ((dynamic)base.ViewBag).FtlTypeList = this.generalRepository.GetByIdList(9);
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            ((dynamic)base.ViewBag).ProRataTypeList = this.generalRepository.GetByIdList(50);
            ((dynamic)base.ViewBag).RiskMatrixRateTypeList = this.customerContractRepository.GetRiskMatrixRateTypeList();
            ((dynamic)base.ViewBag).PackingType = this.generalRepository.GetByIdList(102);
            if (!isCustomerContract.ConvertToBool())
            {
                ((dynamic)base.ViewBag).CustomerList = this.vendorRepository.GetVendorNameList();
            }
            else
            {
                ((dynamic)base.ViewBag).CustomerList = this.customerRepository.GetCustomerList();
            }
        }

        private void Init2(byte countryId, short stateId, short contractId)
        {
            ((dynamic)base.ViewBag).AddressList = JsonConvert.SerializeObject(this.addressRepository.GetAddressByContractId(contractId));
            if ((countryId != 0 ? true : stateId != 0))
            {
                ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateListByCountryId(countryId);
                ((dynamic)base.ViewBag).CityList = this.cityRepository.GetCityListByStateId(stateId);
            }
            else
            {
                ((dynamic)base.ViewBag).StateList = new SelectList(Enumerable.Empty<SelectListItem>());
                ((dynamic)base.ViewBag).CityList = new SelectList(Enumerable.Empty<SelectListItem>());
            }
        }

        private void InitDefineChargeMatrix(byte baseOn, bool isPageLoad)
        {
            ((dynamic)base.ViewBag).SlabTypeList = this.customerContractRepository.GetSlabTypeList();
            ((dynamic)base.ViewBag).ChargeBaseList = this.customerContractRepository.GetChargeBaseList();
            if (baseOn == 1)
            {
                ((dynamic)base.ViewBag).BaseCodeList = this.generalRepository.GetByIdList(22).ToList<AutoCompleteResult>();
                ((dynamic)base.ViewBag).BaseOnName = "Business Type";
            }
            else if (baseOn != 2)
            {
                ((dynamic)base.ViewBag).BaseCodeList = this.customerContractRepository.GetBaseCodeList();
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

        public ActionResult Insert(short? customerId, bool? isCustomerContract)
        {
            CustomerContract customerContract = new CustomerContract()
            {
                ContractId = 0,
                IsCustomerContract = (isCustomerContract.HasValue ? isCustomerContract.ConvertToBool() : true),
                CustomerId = customerId.ConvertToShort()
            };
            this.Init(new bool?(customerContract.IsCustomerContract));
            return base.View(customerContract);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("ContractId")]
        public ActionResult Insert(CustomerContract objCustomerContract)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objCustomerContract.CustomerContractBasicInfo.EntryBy = SessionUtility.LoginUserId;
                objCustomerContract.CustomerContractBasicInfo.Attachment = null;
                Response response = this.customerContractRepository.Insert(objCustomerContract);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("Done", new { id = response.DocumentId });
                    return action;
                }
            }
            this.Init(new bool?(objCustomerContract.IsCustomerContract));
            action = base.View(objCustomerContract);
            return action;
        }

        public JsonResult IsFovApplicable()
        {
            JsonResult jsonResult = base.Json(this.customerContractRepository.IsFovApplicable(), JsonRequestBehavior.AllowGet);
            return jsonResult;
        }

        public ActionResult ModewiseServices(short? id)
        {
            CustomerContractModewiseServices customerContractModewiseService = new CustomerContractModewiseServices()
            {
                ContractId = id.Value,
                ServiceTaxPayer = this.generalRepository.GetByGeneralList(20).ToArray<MasterGeneral>()
            };
            ((dynamic)base.ViewBag).ServiceTaxPayerList = this.generalRepository.GetByIdList(20);
            ((dynamic)base.ViewBag).TransportModeList = new SelectList(this.customerContractRepository.GetTransportModeList(customerContractModewiseService.ContractId), "Value", "Name");
            this.ModewiseServicesInit();
            this.GetHeaderInfo(id);
            return base.View(customerContractModewiseService);
        }

        [HttpPost]
        public ActionResult ModewiseServices(CustomerContractModewiseServices objCustomerContractModewiseServices)
        {
            ActionResult action;
            if (!objCustomerContractModewiseServices.UseMinimumFreightTypeBaseWise)
            {
                objCustomerContractModewiseServices.MinimumFreightRate = new decimal(0);
                objCustomerContractModewiseServices.MinimumFreightRateType = "F";
                objCustomerContractModewiseServices.MinimumFreightAmount = new decimal(0);
                base.ModelState.Remove("MinimumFreighRate");
                base.ModelState.Remove("MinimumFreighRateType");
                base.ModelState.Remove("MinimumFreightAmount");
            }
            if (objCustomerContractModewiseServices.UseMinimumFreightTypeBaseWise)
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
                if (this.customerContractRepository.InsertModewiseServices(objCustomerContractModewiseServices).IsSuccessfull)
                {
                    action = base.RedirectToAction("Result", new { documentId = objCustomerContractModewiseServices.ContractId });
                    return action;
                }
            }
            this.ModewiseServicesInit();
            action = base.View(objCustomerContractModewiseServices);
            return action;
        }

        private void ModewiseServicesInit()
        {
            ((dynamic)base.ViewBag).FuelSurchargeRateTypeList = this.customerContractRepository.GetFuelSurchargeRateTypeList();
        }

        public ActionResult ODA(short id)
        {
            MasterODA masterODA = new MasterODA();
            masterODA = this.customerContractRepository.GetOdaDetail(id);
            if (masterODA == null)
            {
                masterODA = new MasterODA()
                {
                    ContractId = id
                };
            }
            return base.View(masterODA);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ODA(MasterODA objODA)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                action = base.View(objODA);
            }
            else
            {
                this.customerContractRepository.InsertODA(objODA);
                action = base.RedirectToAction("Result", new { documentId = objODA.ContractId });
            }
            return action;
        }

        public ActionResult PopUp()
        {
            return base.View(new CustomerContract());
        }

        public ActionResult PopUpContract()
        {
            return base.View(new CustomerContract());
        }

        public ActionResult RateInquiry()
        {
            RateInquiry rateInquiry = new RateInquiry();
            ((dynamic)base.ViewBag).MatrixTypeList = this.generalRepository.GetByIdList(18);
            return base.View(rateInquiry);
        }

        public ActionResult RateMatrix()
        {
            CustomerContractChargeMatrixLTLHeader customerContractChargeMatrixLTLHeader = new CustomerContractChargeMatrixLTLHeader()
            {
                Details = new List<CustomerContractChargeMatrixLTL>()
            };
            customerContractChargeMatrixLTLHeader.Details.Add(new CustomerContractChargeMatrixLTL());
            ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            customerContractChargeMatrixLTLHeader.ContractId = base.Request.QueryString["ContractId"].ConvertToShort();
            customerContractChargeMatrixLTLHeader.TransportModeId = base.Request.QueryString["TransportModeId"].ConvertToByte();
            customerContractChargeMatrixLTLHeader.IsBooking = base.Request.QueryString["IsBooking"].ConvertToBool();
            customerContractChargeMatrixLTLHeader.BaseOn1 = base.Request.QueryString["BaseOn1"].ConvertToByte();
            customerContractChargeMatrixLTLHeader.BaseCode1 = base.Request.QueryString["BaseCode1"].ConvertToByte();
            customerContractChargeMatrixLTLHeader.BaseOn2 = base.Request.QueryString["BaseOn2"].ConvertToByte();
            customerContractChargeMatrixLTLHeader.BaseCode2 = base.Request.QueryString["BaseCode2"].ConvertToByte();
            customerContractChargeMatrixLTLHeader.BaseOn1 = base.Request.QueryString["BaseOn1"].ConvertToByte();
            customerContractChargeMatrixLTLHeader.MatrixType = base.Request.QueryString["MatrixType"].ConvertToByte();
            customerContractChargeMatrixLTLHeader.Details = this.customerContractRepository.GetRateMatrixList(customerContractChargeMatrixLTLHeader).ToList<CustomerContractChargeMatrixLTL>();
            return base.View(customerContractChargeMatrixLTLHeader);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RateMatrix(CustomerContractChargeMatrixLTLHeader objRateMatrix)
        {
            if (base.ModelState.IsValid)
            {
                this.customerContractRepository.UpdateRateMatrix(objRateMatrix);
            }
    ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            return base.View(objRateMatrix);
        }

        public ActionResult RateMatrixCriteria(short? id)
        {
            ((dynamic)base.ViewBag).TransportModeList = new SelectList(this.customerContractRepository.GetTransportModeList(id.Value), "Value", "Name");
            ((dynamic)base.ViewBag).MatrixTypeList = new SelectList(this.customerContractRepository.GetMatrixTypeList(id.Value), "Value", "Name");
            return base.View();
        }

        public ActionResult RateMatrixSelection(short? id)
        {
            RateMatrixStepSelection rateMatrixStepSelection = new RateMatrixStepSelection()
            {
                ContractId = id.ConvertToShort()
            };
            return base.View(rateMatrixStepSelection);
        }

        [HttpGet]
        public ActionResult RateMatrixSlabRange(short id, byte baseOn1, byte baseOn2, byte baseCode1, short baseCode2, byte chargeCode, byte matrixType, short fromLocation, short toLocation, byte transportModeId, bool isBooking, byte ftlTypeId, short consignorId, short consigneeId)
        {
            ActionResult actionResult;
            CustomerContractRateMatrix customerContractRateMatrix = new CustomerContractRateMatrix()
            {
                RangeDetails = this.customerContractRepository.GetRateMatrixSlabRangeDetailBySearchingCriteria(id, chargeCode).ToList<CustomerContractRateMatrixSlabRange>(),
                ContractId = id,
                BaseOn1 = baseOn1,
                BaseOn2 = baseOn2,
                BaseCode1 = baseCode1,
                BaseCode2 = baseCode2,
                ChargeCode = chargeCode,
                MatrixType = matrixType,
                FromLocation = fromLocation,
                ToLocation = toLocation,
                TransportModeId = transportModeId,
                IsBooking = isBooking,
                FtlTypeId = ftlTypeId,
                ConsignorId = consignorId,
                ConsigneeId = consigneeId
            };
            CustomerContractRateMatrix customerContractRateMatrix1 = customerContractRateMatrix;
            ((dynamic)base.ViewBag).RateTypeList = this.customerContractRepository.GetRateTypeListByContractId(id);
            if (customerContractRateMatrix1.RangeDetails.Count <= 0)
            {
                List<CustomerContractRateMatrixSlabRange> rangeDetails = customerContractRateMatrix1.RangeDetails;
                CustomerContractRateMatrixSlabRange customerContractRateMatrixSlabRange = new CustomerContractRateMatrixSlabRange()
                {
                    ContractId = id,
                    SlabId = 0,
                    From = new decimal(0),
                    To = new decimal(0),
                    RateType = 0
                };
                rangeDetails.Add(customerContractRateMatrixSlabRange);
                actionResult = base.View(customerContractRateMatrix1);
            }
            else
            {
                actionResult = base.View(customerContractRateMatrix1);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult RateMatrixSlabRange(CustomerContractRateMatrix objCustomerContractRateMatrix)
        {
            for (int i = 0; i < objCustomerContractRateMatrix.RangeDetails.Count; i++)
            {
                objCustomerContractRateMatrix.RangeDetails[i].ContractId = objCustomerContractRateMatrix.ContractId;
                objCustomerContractRateMatrix.RangeDetails[i].ChargeCode = objCustomerContractRateMatrix.ChargeCode;
                objCustomerContractRateMatrix.RangeDetails[i].SlabId = (i + 1).ConvertToByte();
            }
            this.customerContractRepository.InsertRateMatrixSlabRange(objCustomerContractRateMatrix);
            ActionResult action = base.RedirectToAction("RateMatrixSelection", "CustomerContract", new { id = objCustomerContractRateMatrix.ContractId, baseOn1 = objCustomerContractRateMatrix.BaseOn1, baseOn2 = objCustomerContractRateMatrix.BaseOn2, baseCode1 = objCustomerContractRateMatrix.BaseCode1, baseCode2 = objCustomerContractRateMatrix.BaseCode2, chargeCode = objCustomerContractRateMatrix.ChargeCode, matrixType = objCustomerContractRateMatrix.MatrixType, fromLocation = objCustomerContractRateMatrix.FromLocation, toLocation = objCustomerContractRateMatrix.ToLocation, transportModeId = objCustomerContractRateMatrix.TransportModeId, isBooking = objCustomerContractRateMatrix.IsBooking, ftlTypeId = objCustomerContractRateMatrix.FtlTypeId, consignorId = objCustomerContractRateMatrix.ConsignorId, consigneeId = objCustomerContractRateMatrix.ConsigneeId });
            return action;
        }

        [HttpGet]
        public ActionResult RateMatrixSlabRate(short id, byte baseOn1, byte baseOn2, byte baseCode1, short baseCode2, byte chargeCode, byte matrixType, short fromLocation, short toLocation, byte transportModeId, bool isBooking, byte ftlTypeId, short consignorId, short consigneeId)
        {
            ActionResult actionResult;
            List<CustomerContractRateMatrix> customerContractRateMatrices = new List<CustomerContractRateMatrix>();
            List<CustomerContractRateMetrixSlabRate> customerContractRateMetrixSlabRates = new List<CustomerContractRateMetrixSlabRate>();
            List<CustomerContractRateMatrixSlabRange> customerContractRateMatricesSlabRange = new List<CustomerContractRateMatrixSlabRange>();
            customerContractRateMetrixSlabRates = this.customerContractRepository.GetRateMatrixSlabDetailBySearchingCriteria(id, chargeCode).ToList<CustomerContractRateMetrixSlabRate>();
            customerContractRateMatrices = this.customerContractRepository.GetRateMatrixSlabRateDetailBySearchingCriteria(id, baseOn1, baseOn2, baseCode1, baseCode2, chargeCode, matrixType, fromLocation, toLocation, transportModeId, isBooking, ftlTypeId, consignorId, consigneeId).ToList<CustomerContractRateMatrix>();
            ((dynamic)base.ViewBag).ContractId = id;
            ((dynamic)base.ViewBag).BaseOn1 = baseOn1;
            ((dynamic)base.ViewBag).BaseOn2 = baseOn2;
            ((dynamic)base.ViewBag).BaseCode1 = baseCode1;
            ((dynamic)base.ViewBag).BaseCode2 = baseCode2;
            ((dynamic)base.ViewBag).ChargeCode = chargeCode;
            ((dynamic)base.ViewBag).MatrixType = matrixType;
            ((dynamic)base.ViewBag).FromLocation = fromLocation;
            ((dynamic)base.ViewBag).ToLocation = toLocation;
            ((dynamic)base.ViewBag).TransportModeId = transportModeId;
            ((dynamic)base.ViewBag).IsBooking = isBooking;
            ((dynamic)base.ViewBag).FtlTypeId = ftlTypeId;
            ((dynamic)base.ViewBag).ConsigneeId = consigneeId;
            ((dynamic)base.ViewBag).ConsigneeId = consigneeId;
            base.TempData["FromLocation"] = fromLocation;
            base.TempData["ToLocation"] = toLocation;
            this.Init(new bool?(true));
            if (customerContractRateMatrices.Count <= 0)
            {
                CustomerContractRateMatrix customerContractRateMatrix = new CustomerContractRateMatrix()
                {
                    ContractId = id,
                    BaseOn1 = baseOn1,
                    BaseOn2 = baseOn2,
                    BaseCode1 = baseCode1,
                    BaseCode2 = baseCode2,
                    ChargeCode = chargeCode,
                    MatrixType = matrixType,
                    FromLocation = fromLocation,
                    ToLocation = toLocation,
                    TransportModeId = transportModeId,
                    IsBooking = isBooking,
                    FtlTypeId = ftlTypeId,
                    ConsignorId = consignorId,
                    ConsigneeId = consigneeId,
                    RateDetails = new List<CustomerContractRateMetrixSlabRate>()
                };
                customerContractRateMatrices.Add(customerContractRateMatrix);
                if (customerContractRateMetrixSlabRates.Count != 0)
                {
                    foreach (CustomerContractRateMatrix customerContractRateMatrix1 in customerContractRateMatrices)
                    {
                        customerContractRateMatrix1.RateDetails.AddRange(customerContractRateMetrixSlabRates);
                    }
                }
                else
                {
                    List<CustomerContractRateMetrixSlabRate> rateDetails = customerContractRateMatrices[0].RateDetails;
                    CustomerContractRateMetrixSlabRate customerContractRateMetrixSlabRate = new CustomerContractRateMetrixSlabRate()
                    {
                        SlabId = 0,
                        RateMatrixId = 0,
                        Rate = new decimal(0)
                    };
                    rateDetails.Add(customerContractRateMetrixSlabRate);
                }
                actionResult = base.View(customerContractRateMatrices);
            }
            else
            {
                actionResult = base.View(customerContractRateMatrices);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult RateMatrixSlabRate(List<CustomerContractRateMatrix> objCustomerContractRateMatrixList)
        {
            foreach (CustomerContractRateMatrix customerContractRateMatrix in objCustomerContractRateMatrixList)
            {
                foreach (CustomerContractRateMetrixSlabRate rateDetail in customerContractRateMatrix.RateDetails)
                {
                    rateDetail.FromLocation = customerContractRateMatrix.FromLocation;
                    rateDetail.ToLocation = customerContractRateMatrix.ToLocation;
                }
            }
            this.customerContractRepository.InsertRateMatrixSlabRate(objCustomerContractRateMatrixList);
            ActionResult action = base.RedirectToAction("RateMatrixSelection", "CustomerContract", new { id = objCustomerContractRateMatrixList[0].ContractId, baseOn1 = objCustomerContractRateMatrixList[0].BaseOn1, baseOn2 = objCustomerContractRateMatrixList[0].BaseOn2, baseCode1 = objCustomerContractRateMatrixList[0].BaseCode1, baseCode2 = objCustomerContractRateMatrixList[0].BaseCode2, chargeCode = objCustomerContractRateMatrixList[0].ChargeCode, matrixType = objCustomerContractRateMatrixList[0].MatrixType, fromLocation = base.TempData["FromLocation"].ConvertToShort(), toLocation = base.TempData["ToLocation"].ConvertToShort(), transportModeId = objCustomerContractRateMatrixList[0].TransportModeId, isBooking = objCustomerContractRateMatrixList[0].IsBooking, ftlTypeId = objCustomerContractRateMatrixList[0].FtlTypeId, consignorId = objCustomerContractRateMatrixList[0].ConsignorId, consigneeId = objCustomerContractRateMatrixList[0].ConsigneeId });
            return action;
        }

        public ActionResult Result(short documentId)
        {
            this.GetHeaderInfo(new short?(documentId));
            return base.View();
        }

        public ActionResult ServiceSelection(short id)
        {
            MasterGeneral masterGeneral;
            MasterGeneral masterGeneral1;
            MasterGeneral masterGeneral2;
            MasterGeneral masterGeneral3;
            MasterGeneral masterGeneral4;
            int i;
            CustomerContractServices customerContractService = new CustomerContractServices()
            {
                ContractId = id
            };

            List<CustomerContractServiceAccess> list = this.customerContractRepository.GetServiceAccessById(id).ToList<CustomerContractServiceAccess>();
            customerContractService.TransportMode = this.generalRepository.GetByGeneralList(15).ToArray<MasterGeneral>();
            customerContractService.ServiceType = this.generalRepository.GetByGeneralList(16).ToArray<MasterGeneral>();
            customerContractService.RateTypes = this.generalRepository.GetByGeneralList(17).ToArray<MasterGeneral>();
            customerContractService.Matrices = this.generalRepository.GetByGeneralList(18).ToArray<MasterGeneral>();
            customerContractService.PickupDelivery = this.generalRepository.GetByGeneralList(19).ToArray<MasterGeneral>();
            MasterGeneral[] transportMode = customerContractService.TransportMode;

            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral = transportMode[i];
                masterGeneral.CodeTypeId = 15;
                masterGeneral.IsActive = false;
            }

            transportMode = customerContractService.ServiceType;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral1 = transportMode[i];
                masterGeneral1.CodeTypeId = 16;
                masterGeneral1.IsActive = false;
            }
            transportMode = customerContractService.RateTypes;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral2 = transportMode[i];
                masterGeneral2.CodeTypeId = 17;
                masterGeneral2.IsActive = false;
            }
            transportMode = customerContractService.Matrices;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral3 = transportMode[i];
                masterGeneral3.CodeTypeId = 18;
                masterGeneral3.IsActive = false;
            }
            transportMode = customerContractService.PickupDelivery;
            for (i = 0; i < (int)transportMode.Length; i++)
            {
                masterGeneral4 = transportMode[i];
                masterGeneral4.CodeTypeId = 19;
                masterGeneral4.IsActive = false;
            }
            foreach (CustomerContractServiceAccess customerContractServiceAccess in list)
            {
                if (customerContractServiceAccess.ServiceTypeId == 15)
                {
                    transportMode = customerContractService.TransportMode;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral = transportMode[i];
                        if (customerContractServiceAccess.ServiceId == masterGeneral.CodeId)
                        {
                            masterGeneral.IsActive = true;
                        }
                    }
                }
                if (customerContractServiceAccess.ServiceTypeId == 16)
                {
                    transportMode = customerContractService.ServiceType;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral1 = transportMode[i];
                        if (customerContractServiceAccess.ServiceId == masterGeneral1.CodeId)
                        {
                            masterGeneral1.IsActive = true;
                        }
                    }
                }
                if (customerContractServiceAccess.ServiceTypeId == 17)
                {
                    transportMode = customerContractService.RateTypes;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral2 = transportMode[i];
                        if (customerContractServiceAccess.ServiceId == masterGeneral2.CodeId)
                        {
                            masterGeneral2.IsActive = true;
                        }
                    }
                }
                if (customerContractServiceAccess.ServiceTypeId == 18)
                {
                    transportMode = customerContractService.Matrices;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral3 = transportMode[i];
                        if (customerContractServiceAccess.ServiceId == masterGeneral3.CodeId)
                        {
                            masterGeneral3.IsActive = true;
                        }
                    }
                }
                if (customerContractServiceAccess.ServiceTypeId == 19)
                {
                    transportMode = customerContractService.PickupDelivery;
                    for (i = 0; i < (int)transportMode.Length; i++)
                    {
                        masterGeneral4 = transportMode[i];
                        if (customerContractServiceAccess.ServiceId == masterGeneral4.CodeId)
                        {
                            masterGeneral4.IsActive = true;
                        }
                    }
                }
            }
            this.Init(new bool?(true));
            customerContractService.CarrierDetails = this.customerContractRepository.GetCarrierRiskList(id).ToList<CustomerContractRiskMatrix>();
            customerContractService.OwnerDetails = this.customerContractRepository.GetOwnerRiskList(id).ToList<CustomerContractRiskMatrix>();
            if (customerContractService.CarrierDetails.Count < 1)
            {
                List<CustomerContractRiskMatrix> carrierDetails = customerContractService.CarrierDetails;
                CustomerContractRiskMatrix customerContractRiskMatrix = new CustomerContractRiskMatrix()
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
            if (customerContractService.OwnerDetails.Count < 1)
            {
                List<CustomerContractRiskMatrix> ownerDetails = customerContractService.OwnerDetails;
                CustomerContractRiskMatrix customerContractRiskMatrix1 = new CustomerContractRiskMatrix()
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
            return base.View(customerContractService);
        }

        [HttpPost]
        public ActionResult ServiceSelection(CustomerContractServices objCustomerContractServices)
        {
            ActionResult action;
            if (!objCustomerContractServices.UseVolumetric)
            {
                base.ModelState.Remove("VolumetricWeightType");
                objCustomerContractServices.VolumetricWeightType = "";
            }
            if (!objCustomerContractServices.UseCod)
            {
                base.ModelState.Remove("CodRateType");
                objCustomerContractServices.CodRateType = 0;
            }
            if (!objCustomerContractServices.UseDacc)
            {
                base.ModelState.Remove("DaccRateType");
                objCustomerContractServices.DaccRateType = 0;
            }
            if (!objCustomerContractServices.UseOctroi)
            {
                base.ModelState.Remove("OctroiRateType");
                objCustomerContractServices.OctroiRateType = 0;
            }
            if (!objCustomerContractServices.UseDeliveryWithoutDemurrage)
            {
                base.ModelState.Remove("DemurrageRateType");
                objCustomerContractServices.DemurrageRateType = 0;
            }
            objCustomerContractServices.CarrierDetails.ForEach((CustomerContractRiskMatrix m) => m.ContractId = objCustomerContractServices.ContractId);
            objCustomerContractServices.OwnerDetails.ForEach((CustomerContractRiskMatrix m) => m.ContractId = objCustomerContractServices.ContractId);
            if (!objCustomerContractServices.IsFovApplicable)
            {
                base.ModelState.Remove("CarrierDetails[0].RateType");
                base.ModelState.Remove("OwnerDetails[0].RateType");
            }
            objCustomerContractServices.EntryBy = SessionUtility.LoginUserId;
            if (!this.customerContractRepository.InsertServices(objCustomerContractServices).IsSuccessfull)
            {
                this.ServiceSelectionInit();
                action = base.View(objCustomerContractServices);
            }
            else
            {
                action = base.RedirectToAction("Result", new { documentId = objCustomerContractServices.ContractId });
            }
            return action;
        }

        private void ServiceSelectionInit()
        {
            ((dynamic)base.ViewBag).CodDaccRateTypeList = this.generalRepository.GetByIdList(17);
        }

        public ActionResult StandardCharge(short id, byte baseOn1, byte baseOn2, byte baseCode1, short baseCode2, byte chargeCode, byte matrixType, short fromLocation, short toLocation, byte transportModeId, bool isBooking, byte ftlTypeId, short consignorId, short consigneeId,bool isCustomerContract)
        {
            ActionResult actionResult;
            short customerId = this.customerContractRepository.GetById((short)id,isCustomerContract).CustomerId;
            CustomerContractChargeMatrixSTD customerContractChargeMatrixSTD = new CustomerContractChargeMatrixSTD()
            {
                Details = this.customerContractRepository.GetChargeMatrixSTDDetailBySearchingCriteria(id, baseOn1, baseOn2, baseCode1, baseCode2, chargeCode, matrixType, fromLocation, toLocation, transportModeId, isBooking, ftlTypeId, consignorId, consigneeId).ToList<CustomerContractChargeMatrixSTD>(),
                ContractId = id,
                BaseOn1 = baseOn1,
                BaseOn2 = baseOn2,
                BaseCode1 = baseCode1,
                BaseCode2 = baseCode2,
                ChargeCode = chargeCode,
                MatrixType = matrixType,
                FromLocation = fromLocation,
                ToLocation = toLocation,
                TransportModeId = transportModeId,
                IsBooking = isBooking,
                FtlTypeId = ftlTypeId,
                ConsignorId = consignorId,
                ConsigneeId = consigneeId
            };
            CustomerContractChargeMatrixSTD customerContractChargeMatrixSTD1 = customerContractChargeMatrixSTD;
            if (consignorId == 0 && consigneeId == 0)
                ((dynamic)base.ViewBag).PartList = this.partRepository.GetPartListByCustomerId(customerId);
            else
                ((dynamic)base.ViewBag).PartList = this.partRepository.GetPartListByConsignorIdAndConsigneeId(consignorId, consigneeId);
            this.Init(new bool?(true), id);
            this.GetHeaderInfo(new short?(id));
            ((dynamic)base.ViewBag).ChargeName = this.chargeRepository.GetChargeByTypeId(ModuleHelper.Docket, chargeCode).ChargeName;
            if (customerContractChargeMatrixSTD1.Details.Count <= 0)
            {
                List<CustomerContractChargeMatrixSTD> details = customerContractChargeMatrixSTD1.Details;
                CustomerContractChargeMatrixSTD customerContractChargeMatrixSTD2 = new CustomerContractChargeMatrixSTD()
                {
                    ContractId = id,
                    BaseOn1 = baseOn1,
                    BaseOn2 = baseOn2,
                    BaseCode1 = baseCode1,
                    BaseCode2 = baseCode2,
                    ChargeCode = chargeCode,
                    MatrixType = matrixType,
                    FromLocation = fromLocation,
                    ToLocation = toLocation,
                    TransportModeId = transportModeId,
                    IsBooking = isBooking,
                    FtlTypeId = ftlTypeId,
                    BillLocationId = (short?)((dynamic)base.ViewBag).BillLocationId,
                    ConsignorId = consignorId,
                    ConsigneeId = consigneeId
                };
                details.Add(customerContractChargeMatrixSTD2);
                actionResult = base.View(customerContractChargeMatrixSTD1);
            }
            else
            {
                actionResult = base.View(customerContractChargeMatrixSTD1);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult StandardCharge(CustomerContractChargeMatrixSTD objChargeMatrixSTD)
        {
            ActionResult action;
            objChargeMatrixSTD.EntryBy = SessionUtility.LoginUserId;
            Response response = this.customerContractRepository.InsertChargeMatrixSTD(objChargeMatrixSTD);
            if (!response.IsSuccessfull)
            {
                action = base.View(objChargeMatrixSTD);
            }
            else
            {
                action = base.RedirectToAction("Result", new { documentId = response.DocumentId });
            }
            return action;
        }

        public ActionResult StandardChargeCriteria(short id)
        {
            CustomerContractChargeMatrixSTD customerContractChargeMatrixSTD = new CustomerContractChargeMatrixSTD();
            byte num = this.rulesRepository.GetModuleRuleByIdAndRuleId(ModuleHelper.Docket, RuleHelper.ChargeRule).ConvertToByte();
            this.InitDefineChargeMatrix(num, true);
            customerContractChargeMatrixSTD.ContractId = id.ConvertToShort();
            customerContractChargeMatrixSTD.BaseOn1 = num;
            customerContractChargeMatrixSTD.IsBooking = true;
            ((dynamic)base.ViewBag).MatrixTypeList = this.customerContractRepository.GetMatrixTypeListByContractId(id);
            this.Init(new bool?(true), id);
            ((dynamic)base.ViewBag).TransportModeList = this.customerContractRepository.GetTransportModeList(id);
            this.GetHeaderInfo(new short?(id));
            return base.View(customerContractChargeMatrixSTD);
        }

        public ActionResult StandardChargeMatrixUpload()
        {
            return base.View(new StandardChargeMatrixUpload());
        }

        [HttpPost]
        public ActionResult StandardChargeMatrixUpload(StandardChargeMatrixUpload objStandardChargeMatrixUpload)
        {
            StandardChargeMatrixUpload standardChargeMatrixUpload = new StandardChargeMatrixUpload()
            {
                IsSuccessfull = false,
                ErrorMessage = "Invalid File"
            };
            StandardChargeMatrixUpload standardChargeMatrixUpload1 = standardChargeMatrixUpload;
            if (objStandardChargeMatrixUpload.File != null)
            {
                objStandardChargeMatrixUpload.EntryBy = SessionUtility.LoginUserId;
                standardChargeMatrixUpload1 = this.customerContractRepository.StandardChargeMatrixUpload(objStandardChargeMatrixUpload);
            }
            return base.View(standardChargeMatrixUpload1);
        }

        public ActionResult StepSelection(short? id, bool? isCustomerContract)
        {
            CustomerContract customerContract = new CustomerContract()
            {
                ContractId = id.ConvertToShort(),
                IsCustomerContract = isCustomerContract.ConvertToBool()
            };
            CustomerContract customerContract1 = customerContract;
            this.GetHeaderInfo(id);
            return base.View(customerContract1);
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
                this.GetHeaderInfo(id);
                CustomerContract value = (CustomerContract)this.customerContractRepository.GetById(id.Value, ((dynamic)base.ViewBag).IsCustomerContract);
                value.IsCustomerContract = (bool)((dynamic)base.ViewBag).IsCustomerContract;
                if (value != null)
                {
                    this.Init(((dynamic)base.ViewBag).IsCustomerContract);
                    httpStatusCodeResult = base.View(value);
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
        public ActionResult Update(CustomerContract objCustomerContract)
        {
            ActionResult action;
            if (base.ModelState.IsValid)
            {
                objCustomerContract.UpdateBy = new short?(SessionUtility.LoginUserId);
                objCustomerContract.CustomerContractBasicInfo.Attachment = null;
                Response response = this.customerContractRepository.Update(objCustomerContract);
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("Done", new { id = response.DocumentId });
                    return action;
                }
            }
            this.Init(new bool?(objCustomerContract.IsCustomerContract));
            action = base.View(objCustomerContract);
            return action;
        }

        [HttpGet]
        public ActionResult RateMatrixSlabRangeSimply(short id, byte baseOn1, byte baseOn2, byte baseCode1, short baseCode2, byte chargeCode, byte matrixType, short fromLocation, short toLocation, byte transportModeId, bool isBooking, byte ftlTypeId, short consignorId, short consigneeId)
        {
            ActionResult actionResult;
            CustomerContractRateMatrix customerContractRateMatrix = new CustomerContractRateMatrix()
            {
                RangeDetails = this.customerContractRepository.GetRateMatrixSlabRangeDetailBySearchingCriteria(id, chargeCode).ToList<CustomerContractRateMatrixSlabRange>(),
                ContractId = id,
                BaseOn1 = baseOn1,
                BaseOn2 = baseOn2,
                BaseCode1 = baseCode1,
                BaseCode2 = baseCode2,
                ChargeCode = chargeCode,
                MatrixType = matrixType,
                FromLocation = fromLocation,
                ToLocation = toLocation,
                TransportModeId = transportModeId,
                IsBooking = isBooking,
                FtlTypeId = ftlTypeId,
                ConsignorId = consignorId,
                ConsigneeId = consigneeId
            };
            CustomerContractRateMatrix customerContractRateMatrix1 = customerContractRateMatrix;
            ((dynamic)base.ViewBag).RateTypeList = this.customerContractRepository.GetRateTypeListByContractId(id);
            if (customerContractRateMatrix1.RangeDetails.Count <= 0)
            {
                List<CustomerContractRateMatrixSlabRange> rangeDetails = customerContractRateMatrix1.RangeDetails;
                CustomerContractRateMatrixSlabRange customerContractRateMatrixSlabRange = new CustomerContractRateMatrixSlabRange()
                {
                    ContractId = id,
                    SlabId = 0,
                    From = new decimal(0),
                    To = new decimal(0),
                    RateType = 0
                };
                rangeDetails.Add(customerContractRateMatrixSlabRange);
                actionResult = base.View(customerContractRateMatrix1);
            }
            else
            {
                actionResult = base.View(customerContractRateMatrix1);
            }
            return actionResult;
        }

        [HttpGet]
        public ActionResult RateMatrixSlabRateSimply(short id, byte baseOn1, byte baseOn2, byte baseCode1, short baseCode2, byte chargeCode, byte matrixType, short fromLocation, short toLocation, byte transportModeId, bool isBooking, byte ftlTypeId, short consignorId, short consigneeId)
        {
            ActionResult actionResult;
            List<CustomerContractRateMatrix> customerContractRateMatrices = new List<CustomerContractRateMatrix>();
            List<CustomerContractRateMetrixSlabRate> customerContractRateMetrixSlabRates = new List<CustomerContractRateMetrixSlabRate>();
            List<CustomerContractRateMatrixSlabRange> customerContractRateMatricesSlabRange = new List<CustomerContractRateMatrixSlabRange>();
            customerContractRateMetrixSlabRates = this.customerContractRepository.GetRateMatrixSlabDetailBySearchingCriteria(id, chargeCode).ToList<CustomerContractRateMetrixSlabRate>();
            customerContractRateMatrices = this.customerContractRepository.GetRateMatrixSlabRateDetailBySearchingCriteriaSimply(id, baseOn1, baseOn2, baseCode1, baseCode2, chargeCode, matrixType, fromLocation, toLocation, transportModeId, isBooking, ftlTypeId, consignorId, consigneeId).ToList<CustomerContractRateMatrix>();
            ((dynamic)base.ViewBag).ContractId = id;
            ((dynamic)base.ViewBag).BaseOn1 = baseOn1;
            ((dynamic)base.ViewBag).BaseOn2 = baseOn2;
            ((dynamic)base.ViewBag).BaseCode1 = baseCode1;
            ((dynamic)base.ViewBag).BaseCode2 = baseCode2;
            ((dynamic)base.ViewBag).ChargeCode = chargeCode;
            ((dynamic)base.ViewBag).MatrixType = matrixType;
            ((dynamic)base.ViewBag).FromLocation = fromLocation;
            ((dynamic)base.ViewBag).ToLocation = toLocation;
            ((dynamic)base.ViewBag).TransportModeId = transportModeId;
            ((dynamic)base.ViewBag).IsBooking = isBooking;
            ((dynamic)base.ViewBag).FtlTypeId = ftlTypeId;
            ((dynamic)base.ViewBag).ConsigneeId = consigneeId;
            ((dynamic)base.ViewBag).ConsigneeId = consigneeId;
            base.TempData["FromLocation"] = fromLocation;
            base.TempData["ToLocation"] = toLocation;
            this.Init(new bool?(true));
            if (customerContractRateMatrices.Count <= 0)
            {
                CustomerContractRateMatrix customerContractRateMatrix = new CustomerContractRateMatrix()
                {
                    ContractId = id,
                    BaseOn1 = baseOn1,
                    BaseOn2 = baseOn2,
                    BaseCode1 = baseCode1,
                    BaseCode2 = baseCode2,
                    ChargeCode = chargeCode,
                    MatrixType = matrixType,
                    FromLocation = fromLocation,
                    ToLocation = toLocation,
                    TransportModeId = transportModeId,
                    IsBooking = isBooking,
                    FtlTypeId = ftlTypeId,
                    ConsignorId = consignorId,
                    ConsigneeId = consigneeId,
                    RateDetails = new List<CustomerContractRateMetrixSlabRate>()
                };
                customerContractRateMatrices.Add(customerContractRateMatrix);
                if (customerContractRateMetrixSlabRates.Count != 0)
                {
                    foreach (CustomerContractRateMatrix customerContractRateMatrix1 in customerContractRateMatrices)
                    {
                        customerContractRateMatrix1.RateDetails.AddRange(customerContractRateMetrixSlabRates);
                    }
                }
                else
                {
                    List<CustomerContractRateMetrixSlabRate> rateDetails = customerContractRateMatrices[0].RateDetails;
                    CustomerContractRateMetrixSlabRate customerContractRateMetrixSlabRate = new CustomerContractRateMetrixSlabRate()
                    {
                        SlabId = 0,
                        RateMatrixId = 0,
                        Rate = new decimal(0),
                        IncrementalRate = new decimal(0),
                        IncrementalWeight = new decimal(0)
                    };
                    rateDetails.Add(customerContractRateMetrixSlabRate);
                }
                actionResult = base.View(customerContractRateMatrices);
            }
            else
            {
                actionResult = base.View(customerContractRateMatrices);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult RateMatrixSlabRateSimply(List<CustomerContractRateMatrix> objCustomerContractRateMatrixList)
        {
            int i;
            i = 1;
            foreach (CustomerContractRateMatrix customerContractRateMatrix in objCustomerContractRateMatrixList)
            {
                customerContractRateMatrix.rowIndex = i;
                foreach (CustomerContractRateMetrixSlabRate rateDetail in customerContractRateMatrix.RateDetails)
                {
                    rateDetail.FromLocation = customerContractRateMatrix.FromLocation;
                    rateDetail.ToLocation = customerContractRateMatrix.ToLocation;
                    rateDetail.rowIndex = i;
                }
                i = i + 1;
            }
            this.customerContractRepository.InsertRateMatrixSlabRate(objCustomerContractRateMatrixList);
            ActionResult action = base.RedirectToAction("RateMatrixSelection", "CustomerContract", new { id = objCustomerContractRateMatrixList[0].ContractId, baseOn1 = objCustomerContractRateMatrixList[0].BaseOn1, baseOn2 = objCustomerContractRateMatrixList[0].BaseOn2, baseCode1 = objCustomerContractRateMatrixList[0].BaseCode1, baseCode2 = objCustomerContractRateMatrixList[0].BaseCode2, chargeCode = objCustomerContractRateMatrixList[0].ChargeCode, matrixType = objCustomerContractRateMatrixList[0].MatrixType, fromLocation = base.TempData["FromLocation"].ConvertToShort(), toLocation = base.TempData["ToLocation"].ConvertToShort(), transportModeId = objCustomerContractRateMatrixList[0].TransportModeId, isBooking = objCustomerContractRateMatrixList[0].IsBooking, ftlTypeId = objCustomerContractRateMatrixList[0].FtlTypeId, consignorId = objCustomerContractRateMatrixList[0].ConsignorId, consigneeId = objCustomerContractRateMatrixList[0].ConsigneeId });
            return action;
        }


    }
}

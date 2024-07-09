using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web;

namespace CodeLock.Areas.Master.Controllers
{
  public class GstController : Controller
  {
    private readonly IGstRepository gstRepository;
    private readonly IStateRepository stateRepository;
    private readonly ICompanyRepository companyRepository;
    private readonly ICustomerRepository customerRepository;
    private readonly IVendorRepository vendorRepository;
    private readonly IGeneralRepository generalRepository;
    public GstController()
    {
    }

    public GstController(
          IGstRepository _gstRepository,
          IStateRepository _stateRepository,
          ICompanyRepository _companyRepository,
          ICustomerRepository _customerRepository,
          IVendorRepository _vendorRepository,
          IGeneralRepository generalRepository)
        {
            this.gstRepository = _gstRepository;
            this.stateRepository = _stateRepository;
            this.companyRepository = _companyRepository;
            this.customerRepository = _customerRepository;
            this.vendorRepository = _vendorRepository;
            this.generalRepository=generalRepository;
        }
        public JsonResult ValidateGSTState(long GstId, long OwnerId, long StateId,byte OwnerType)
    {
        return base.Json(this.gstRepository.ValidateGSTState(GstId, OwnerId, StateId, OwnerType));
    }
   public ActionResult Index(byte ownerType)
    {
      return (ActionResult) this.View((object) new GstRegistration()
      {
        OwnerType = ownerType
      });
    }

    [HttpPost]
    public ActionResult Index(GstRegistration objGstRegistration)
    {
      return (ActionResult) this.RedirectToAction("Insert", (object) new
      {
        ownerType = objGstRegistration.OwnerType,
        ownerCode = objGstRegistration.OwnerCode
      });
    }

    public JsonResult GetById(long gstId)
    {
      return this.Json((object) this.gstRepository.GetById(gstId), JsonRequestBehavior.AllowGet);
    }

    public ActionResult Insert(byte ownerType, string ownerCode)
    {
      AutoCompleteResult autoCompleteResult = new AutoCompleteResult();
      switch (ownerType)
      {
        case 1:
          autoCompleteResult = this.companyRepository.IsCompanyCodeExist(ownerCode);
          break;
        case 3:
          autoCompleteResult = this.customerRepository.IsCustomerCodeExist(ownerCode, SessionUtility.CompanyId);
          break;
        case 5:
          autoCompleteResult = this.vendorRepository.IsVendorCodeExist(ownerCode, (byte) 0);
          break;
      }
        ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
            ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);

      return (ActionResult) this.View((object) new GstRegistration()
      {
        OwnerType = ownerType,
        OwnerCode = autoCompleteResult.Name,
        OwnerId = autoCompleteResult.Value.ConvertToLong(),
        OwnerName = autoCompleteResult.Description
      });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("GstId")]
    public ActionResult Insert(GstRegistration objGstRegistration)
    {
      if (this.ModelState.IsValid)
      {
        objGstRegistration.EntryBy = SessionUtility.LoginUserId;
        if (this.gstRepository.Insert(objGstRegistration).IsSuccessfull)
          return (ActionResult) this.RedirectToAction("Done", (object) new
          {
            status = (objGstRegistration.OwnerType == (byte) 1 ? "CompanyGstRegistrationDone" : (objGstRegistration.OwnerType == (byte) 3 ? "CustomerGstRegistrationDone" : (objGstRegistration.OwnerType == (byte) 5 ? "VendorGstRegistrationDone" : ""))),
            ownerType = objGstRegistration.OwnerType,
            ownerCode = objGstRegistration.OwnerCode
          });
      }
      return (ActionResult) this.View((object) objGstRegistration);
    }

    public ActionResult Update(long? id)
    {
      long? nullable = id;

          ((dynamic)base.ViewBag).StateList = this.stateRepository.GetStateList();
          ((dynamic)base.ViewBag).RegistrationTypeList = this.generalRepository.GetByIdList(201);
    
        if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        return (ActionResult) this.View((object) this.gstRepository.GetById((long) id.Value));
    }

    [ValidateAntiModelInjection("GstId")]
    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Update(GstRegistration objGstRegistration)
    {
      if (this.ModelState.IsValid)
      {
        objGstRegistration.UpdateBy = new short?(SessionUtility.LoginUserId);
        if (this.gstRepository.Update(objGstRegistration).IsSuccessfull)
          return (ActionResult) this.RedirectToAction("Done", (object) new
          {
            status = (objGstRegistration.OwnerType == (byte) 1 ? "CompanyGstRegistrationDone" : (objGstRegistration.OwnerType == (byte) 3 ? "CustomerGstRegistrationDone" : (objGstRegistration.OwnerType == (byte) 5 ? "VendorGstRegistrationDone" : ""))),
            ownerType = objGstRegistration.OwnerType,
            ownerCode = objGstRegistration.OwnerCode
          });
      }
      return (ActionResult) this.View((object) objGstRegistration);
    }

    [HttpPost]
    public ActionResult GstRegistrationPartialView(
      short customerId,
      string customerCode,
      string customerName)
    {
      return (ActionResult) this.PartialView("_GstRegistration", (object) new GstRegistration()
      {
        CustomerCode = customerCode,
        CustomerName = customerName,
        CustomerId = customerId
      });
    }

        [HttpPost]
        public ActionResult GstRegister(GstRegistration objGstRegistration)
        {
            ActionResult actionResult;
            object[] customerId;
            DateTime now;
            char[] chrArray;
            try
            {
                if (objGstRegistration.IsGstRegistered)
                {
                    Response response = new Response();
                    if (this.gstRepository.Insert(objGstRegistration).IsSuccessfull)
                    {
                        actionResult = base.Json("GST Registered Successfully");
                        return actionResult;
                    }
                }
                else if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any<string>())
                {
           
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        customerId = new object[] { objGstRegistration.CustomerId, "_", null, null };
                        now = DateTime.Now;
                        customerId[2] = now.ToString("ddMMyyHHmmss");
                        customerId[3] = (new Random()).Next(10, 90);
                        string str = string.Concat(customerId);
                        string fileName = objGstRegistration.GstDeclarationAttachment.FileName;
                        chrArray = new char[] { '.' };
                        objGstRegistration.DeclarationDocumentName = GoogleStorageHelper.GetFileName("GST", "DECL", "", str, string.Concat("GST.", fileName.Split(chrArray).Last<string>()));
                    }
                    else
                    {
                        customerId = new object[] { objGstRegistration.CustomerId, "_", null, null, null, null };
                        now = DateTime.Now;
                        customerId[2] = now.ToString("ddMMyyHHmmss");
                        customerId[3] = (new Random()).Next(10, 90);
                        customerId[4] = ".";
                        string fileName1 = objGstRegistration.GstDeclarationAttachment.FileName;
                        chrArray = new char[] { '.' };
                        customerId[5] = fileName1.Split(chrArray).Last<string>();
                        objGstRegistration.DeclarationDocumentName = string.Concat(customerId);
                        string str1 = Path.Combine(string.Concat(ConfigHelper.LocalStoragePath, "GstDeclaration/"), objGstRegistration.DeclarationDocumentName);
                        objGstRegistration.GstDeclarationAttachment.SaveAs(str1);
                    }
                    actionResult = base.Json("Declaration Document Upload Successfully.");
                    return actionResult;
                }
                actionResult = base.Json("Error Occur While Gst Registration, Please Try Again.");
            }
            catch (Exception exception)
            {
                ExceptionUtility.LogException(exception, "Gst Registration", SessionUtility.LoginUserId);
                actionResult = base.Json("Error Occur While Gst Registration, Please Try Again.");
            }
            return actionResult;
        }
        public ActionResult Done()
    {
      return (ActionResult) this.View();
    }

    [HttpPost]
    public JsonResult GetStateListByOwnerTypeIdAndOwnerId(byte ownerType, long ownerId)
    {
      return this.Json((object) this.gstRepository.GetStateListByOwnerTypeIdAndOwnerId(ownerType, ownerId));
    }

    [HttpPost]
    public JsonResult IsStateNameAvailable(
      string stateName,
      byte ownerType,
      long ownerId,
      long gstId)
    {
      return this.Json((object) this.gstRepository.IsStateNameAvailable(stateName, ownerType, ownerId, gstId));
    }

    [HttpPost]
    public JsonResult GetGstServiceTypeIdBySacId(byte sacId)
    {
      return this.Json((object) this.gstRepository.GetGstServiceTypeIdBySacId(sacId));
    }

    [HttpPost]
    public JsonResult GetGstRegistrationByOwnerId(byte ownerType, int ownerId)
    {
      return this.Json((object) this.gstRepository.GetGstRegistrationByOwnerId(ownerType, ownerId));
    }

    [HttpPost]
    public JsonResult GetGstStateList(byte ownerType, long ownerId, short locationId)
    {
      return this.Json((object) this.gstRepository.GetGstStateList(ownerType, ownerId, locationId), JsonRequestBehavior.AllowGet);
    }

  [HttpPost]
    public JsonResult GetStateByLocation(short locationId)
    {
      return this.Json((object) this.stateRepository.GetStateByLocation(locationId), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult GetGstServiceAndSacCategoryByTransportModeId(byte transportModeId)
    {
      return this.Json((object) this.gstRepository.GetGstServiceAndSacCategoryByTransportModeId(transportModeId), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult GetGstDetailByGstServiceTypeId(byte gstServiceTypeId)
    {
      return this.Json((object) this.gstRepository.GetGstDetailByGstServiceTypeId(gstServiceTypeId), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult GetGstDetailByOwnerAndState(
      byte ownerType,
      long ownerId,
      short stateId)
    {
      return this.Json((object) this.gstRepository.GetGstDetailByOwnerAndState(ownerType, ownerId, stateId), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult GetGstDetailByOwnerAndCity(
      byte ownerType,
      long ownerId,
      int cityId)
    {
      return this.Json((object) this.gstRepository.GetGstDetailByOwnerAndCity(ownerType, ownerId, cityId), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult GetCustomerGstDetailByCustomerIdAndCityId(
      short customerId,
      int cityId)
    {
      return this.Json((object) this.gstRepository.GetCustomerGstDetailByCustomerIdAndCityId(customerId, cityId), JsonRequestBehavior.AllowGet);
    }

    public SelectList GetSacList()
    {
      return new SelectList((IEnumerable) new GstRepository().GetSacList(), "Value", "Name");
    }

    public JsonResult GetGstDetailByLocationIdAndOwnerType(
      short locationId,
      byte ownerType)
    {
      return this.Json((object) this.gstRepository.GetGstDetailByLocationIdAndOwnerType(locationId, ownerType), JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetList()
    {
      return this.Json((object) this.gstRepository.GetSacList(), JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetDetailById(byte id)
    {
      return this.Json((object) this.gstRepository.GetDetailById(id));
    }

    public JsonResult GetCityListByOwnerAndState(
      byte ownerType,
      long ownerId,
      short stateId)
    {
      return this.Json((object) this.gstRepository.GetCityListByOwnerAndState(ownerType, ownerId, stateId), JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity(
      byte ownerType,
      long ownerId,
      short stateId,
      int cityId)
    {
      return this.Json((object) this.gstRepository.GetGstDetailsByOwnerTypeAndOwnerAndStateAndCity(ownerType, ownerId, stateId, cityId), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult GetAutoCompleteSacList(string sacCode)
    {
      return this.Json((object) this.gstRepository.GetAutoCompleteSacList(sacCode), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult IsSacCodeExist(string sacCode)
    {
      return this.Json((object) this.gstRepository.IsSacCodeExist(sacCode), JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation(
      byte ownerType,
      long ownerId,
      short stateId,
      short locationId)
    {
      return this.Json((object) this.gstRepository.GetGstDetailsByOwnerTypeAndOwnerAndStateAndLocation(ownerType, ownerId, stateId, locationId), JsonRequestBehavior.AllowGet);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.gstRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}

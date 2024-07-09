using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class StateController : Controller
  {
    private readonly IStateRepository stateRepository;
    private readonly ICountryRepository countryRepository;

    public StateController()
    {
    }

    public StateController(IStateRepository _stateRepository, ICountryRepository _countryRepository)
    {
      this.stateRepository = _stateRepository;
      this.countryRepository = _countryRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.stateRepository.GetAll());
    }

        public ActionResult Insert()
        {
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            MasterState masterState = new MasterState();
            masterState.MasterStateDocumentList.Add(new MasterStateDocument());
            return base.View(masterState);
        }


        [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("StateId")]
    public ActionResult Insert(MasterState objMasterState)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterState);
      objMasterState.EntryBy = SessionUtility.LoginUserId;
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.stateRepository.Insert(objMasterState)
      });
    }

    [HttpPost]
    [ValidateAntiModelInjection("StateId")]
    public JsonResult IsStateNameAvailable(MasterState objMasterState)
    {
      return this.Json((object) this.stateRepository.IsStateNameAvailable(objMasterState.StateName, objMasterState.StateId));
    }

    [ValidateAntiModelInjection("StateId")]
    [HttpPost]
    public JsonResult IsStateCodeAvailable(MasterState objMasterState)
    {
      return this.Json((object) this.stateRepository.IsStateCodeAvailable(objMasterState.StateCode, objMasterState.StateId));
    }


        public ActionResult Update(byte? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            MasterState masterState = new MasterState();
            ((dynamic)base.ViewBag).CountryList = this.countryRepository.GetCountryList();
            byte? nullable2 = id;
            if (nullable2.HasValue)
            {
                nullable1 = new int?((int)nullable2.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (nullable.HasValue)
            {
                masterState = this.stateRepository.GetById(id.Value);
                if (masterState.MasterStateDocumentList.Count == 0)
                {
                    masterState.MasterStateDocumentList.Add(new MasterStateDocument());
                }
                httpStatusCodeResult = base.View(masterState);
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


        [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateAntiModelInjection("StateId")]
    public ActionResult Update(MasterState objMasterState)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterState);
      objMasterState.UpdateBy = new short?(SessionUtility.LoginUserId);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = this.stateRepository.Update(objMasterState)
      });
    }

    [HttpPost]
    public JsonResult GetStateListByCountryId(byte countryId)
    {
      return this.Json((object) this.stateRepository.GetStateListByCountryId(countryId));
    }

    public JsonResult GetStateList()
    {
      return this.Json((object) this.stateRepository.GetStateList());
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return (ActionResult) this.View((object) this.stateRepository.GetById(id.Value));
    }

    [HttpPost]
    public JsonResult CheckIsStateOrUnionTerritory(MasterState objMasterState)
    {
      return this.Json((object) this.stateRepository.CheckIsStateOrUnionTerritory(objMasterState.StateId));
    }

    [HttpPost]
    public JsonResult CheckStateOrUnionTerritory(short stateId)
    {
      return this.Json((object) this.stateRepository.CheckIsStateOrUnionTerritory(stateId));
    }

    public JsonResult GetAutoCompleteStateList(string stateName)
    {
      return this.Json((object) this.stateRepository.GetAutoCompleteStateList(stateName));
    }

    [HttpPost]
    public JsonResult IsStateNameExist(string stateName)
    {
      return this.Json((object) this.stateRepository.IsStateNameExist(stateName));
    }
  }
}

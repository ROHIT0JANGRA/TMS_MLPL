using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class UserWarehouseController : Controller
  {
    private readonly IUserWarehouseRepository userWarehouseRepository;
    private readonly IUserRepository userRepository;

    public UserWarehouseController()
    {
    }

    public UserWarehouseController(
      IUserWarehouseRepository _userWarehouseRepository,
      IUserRepository _userRepository)
    {
      this.userWarehouseRepository = _userWarehouseRepository;
      this.userRepository = _userRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.userWarehouseRepository.GetMapping());
    }

        public ActionResult Mapping(short? id)
        {
            MasterUserWarehouseMapping masterUserWarehouseMapping = new MasterUserWarehouseMapping();
            ((dynamic)base.ViewBag).UserList = this.userRepository.GetUserList();
            return base.View(masterUserWarehouseMapping);
        }

        [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult Mapping(
      MasterUserWarehouseMapping objMasterUserWarehouseMapping)
    {
      if (this.ModelState.IsValid)
      {
        objMasterUserWarehouseMapping.UpdateBy = new short?(SessionUtility.LoginUserId);
        objMasterUserWarehouseMapping.WarehouseId = SessionUtility.WarehouseId;
        objMasterUserWarehouseMapping.WarehouseList.ForEach((Action<MasterUserWarehouseMapping>) (m =>
        {
          m.UserId = objMasterUserWarehouseMapping.UserId;
          m.UpdateBy = new short?(SessionUtility.LoginUserId);
        }));
        objMasterUserWarehouseMapping.WarehouseList.RemoveAll((Predicate<MasterUserWarehouseMapping>) (m => !m.IsActive));
        if (this.userWarehouseRepository.Mapping(objMasterUserWarehouseMapping).IsSuccessfull)
          return (ActionResult) this.RedirectToAction("Index");
      }
      return (ActionResult) this.View((object) objMasterUserWarehouseMapping);
    }

    [HttpPost]
    public JsonResult GetMappingByUserId(short userId)
    {
      return this.Json((object) this.userWarehouseRepository.GetMappingByUserId(userId), JsonRequestBehavior.AllowGet);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.userWarehouseRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}

using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class FuelBrandController : Controller
  {
    private readonly IFuelBrandRepository fuelBrandRepository;
    private readonly IGeneralRepository generalRepository;

    public FuelBrandController()
    {
    }

    public FuelBrandController(
      IFuelBrandRepository _fuelBrandRepository,
      IGeneralRepository _generalRepository)
    {
      this.fuelBrandRepository = _fuelBrandRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      List<MasterFuelBrand> list = this.fuelBrandRepository.GetAll().ToList<MasterFuelBrand>();
      foreach (MasterFuelBrand masterFuelBrand in list)
      {
        foreach (MultiCheckBox multiCheckBox in this.generalRepository.GetAll((short) 7).Select<MasterGeneral, MultiCheckBox>((Func<MasterGeneral, MultiCheckBox>) (x => new MultiCheckBox()
        {
          Name = x.CodeDescription,
          Value = x.CodeId.ToString()
        })).ToArray<MultiCheckBox>())
        {
          if (multiCheckBox.Value == "1" && masterFuelBrand.IsDiesel)
            masterFuelBrand.FuelTypes = masterFuelBrand.FuelTypes + ", " + multiCheckBox.Name;
          if (multiCheckBox.Value == "2" && masterFuelBrand.IsPetrol)
            masterFuelBrand.FuelTypes = masterFuelBrand.FuelTypes + ", " + multiCheckBox.Name;
          if (multiCheckBox.Value == "3" && masterFuelBrand.IsCng)
            masterFuelBrand.FuelTypes = masterFuelBrand.FuelTypes + ", " + multiCheckBox.Name;
        }
        masterFuelBrand.FuelTypes = masterFuelBrand.FuelTypes != null ? masterFuelBrand.FuelTypes.Substring(1) : " ";
      }
      return (ActionResult) this.View((object) list);
    }

    public ActionResult Insert(byte? id)
    {
      MasterFuelBrand masterFuelBrand = new MasterFuelBrand();
      byte? nullable1 = id;
      int? nullable2 = nullable1.HasValue ? new int?((int) nullable1.GetValueOrDefault()) : new int?();
      if (nullable2.HasValue)
        masterFuelBrand = this.fuelBrandRepository.GetDetailById(id.Value);
      MultiCheckBox[] array = this.generalRepository.GetAll((short) 7).Select<MasterGeneral, MultiCheckBox>((Func<MasterGeneral, MultiCheckBox>) (x => new MultiCheckBox()
      {
        Name = x.CodeDescription,
        IsChecked = x.IsActive,
        Value = x.CodeId.ToString()
      })).ToArray<MultiCheckBox>();
      ((IEnumerable<MultiCheckBox>) array).Select<MultiCheckBox, bool>((Func<MultiCheckBox, bool>) (m => m.IsChecked = false)).ToArray<bool>();
      nullable1 = id;
      int? nullable3;
      if (!nullable1.HasValue)
      {
        nullable2 = new int?();
        nullable3 = nullable2;
      }
      else
        nullable3 = new int?((int) nullable1.GetValueOrDefault());
      nullable2 = nullable3;
      if (nullable2.HasValue)
      {
        foreach (MultiCheckBox multiCheckBox in array)
        {
          if (multiCheckBox.Value == "1" && masterFuelBrand.IsDiesel)
            multiCheckBox.IsChecked = true;
          if (multiCheckBox.Value == "2" && masterFuelBrand.IsPetrol)
            multiCheckBox.IsChecked = true;
          if (multiCheckBox.Value == "3" && masterFuelBrand.IsCng)
            multiCheckBox.IsChecked = true;
        }
      }
      masterFuelBrand.FuelType = array;
      return (ActionResult) this.View((object) masterFuelBrand);
    }

    [ValidateAntiForgeryToken]
    [HttpPost]
    [ValidateAntiModelInjection("FuelBrandId")]
    public ActionResult Insert(MasterFuelBrand objMasterFuelBrand)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterFuelBrand);
      foreach (MultiCheckBox multiCheckBox in objMasterFuelBrand.FuelType)
      {
        if (multiCheckBox.Value == "1" && multiCheckBox.IsChecked)
          objMasterFuelBrand.IsDiesel = true;
        if (multiCheckBox.Value == "2" && multiCheckBox.IsChecked)
          objMasterFuelBrand.IsPetrol = true;
        if (multiCheckBox.Value == "3" && multiCheckBox.IsChecked)
          objMasterFuelBrand.IsCng = true;
      }
      byte num;
      if (objMasterFuelBrand.FuelBrandId > (byte) 0)
      {
        objMasterFuelBrand.UpdateBy = new short?(SessionUtility.LoginUserId);
        num = this.fuelBrandRepository.Update(objMasterFuelBrand);
      }
      else
      {
        objMasterFuelBrand.EntryBy = SessionUtility.LoginUserId;
        num = this.fuelBrandRepository.Insert(objMasterFuelBrand);
      }
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        id = num
      });
    }

    public ActionResult View(byte? id)
    {
      byte? nullable = id;
      if (!(nullable.HasValue ? new int?((int) nullable.GetValueOrDefault()) : new int?()).HasValue)
        return (ActionResult) new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      MasterFuelBrand detailById = this.fuelBrandRepository.GetDetailById(id.Value);
      foreach (MultiCheckBox multiCheckBox in this.generalRepository.GetAll((short) 7).Select<MasterGeneral, MultiCheckBox>((Func<MasterGeneral, MultiCheckBox>) (x => new MultiCheckBox()
      {
        Name = x.CodeDescription,
        Value = x.CodeId.ToString()
      })).ToArray<MultiCheckBox>())
      {
        if (multiCheckBox.Value == "1" && detailById.IsDiesel)
          detailById.FuelTypes = detailById.FuelTypes + ", " + multiCheckBox.Name;
        if (multiCheckBox.Value == "2" && detailById.IsPetrol)
          detailById.FuelTypes = detailById.FuelTypes + ", " + multiCheckBox.Name;
        if (multiCheckBox.Value == "3" && detailById.IsCng)
          detailById.FuelTypes = detailById.FuelTypes + ", " + multiCheckBox.Name;
      }
      detailById.FuelTypes = detailById.FuelTypes.Substring(1);
      if (detailById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) detailById);
    }

    public JsonResult GetListByFuelTypeId(byte fuelTypeId)
    {
      return this.Json((object) this.fuelBrandRepository.GetListByFuelTypeId(fuelTypeId));
    }

    [ValidateAntiModelInjection("FuelBrandId")]
    [HttpPost]
    public JsonResult IsFuelBrandNameAvailable(MasterFuelBrand objMasterFuelBrand)
    {
      return this.Json((object) this.fuelBrandRepository.IsFuelBrandNameAvailable(objMasterFuelBrand.FuelBrandName, objMasterFuelBrand.FuelBrandId));
    }

    public JsonResult CheckValidFuelBrandName(string fuelBrandName)
    {
      return this.Json((object) this.fuelBrandRepository.CheckValidFuelBrandName(fuelBrandName));
    }

    public JsonResult GetAutoCompleteList(string fuelBrandName)
    {
      return this.Json((object) this.fuelBrandRepository.GetAutoCompleteList(fuelBrandName));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.fuelBrandRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}

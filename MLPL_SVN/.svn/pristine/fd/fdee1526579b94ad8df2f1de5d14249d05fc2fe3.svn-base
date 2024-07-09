using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class SkuLocationMappingController : Controller
  {
    private readonly ISkuLocationMappingRepository skuLocationMappingRepository;
    private readonly ISkuRepository skuRepository;
    private readonly ILocationRepository locationRepository;

    public SkuLocationMappingController()
    {
    }

    public SkuLocationMappingController(
      ISkuLocationMappingRepository _skuLocationMappingRepository,
      ISkuRepository _skuRepository,
      ILocationRepository _locationRepository)
    {
      this.skuLocationMappingRepository = _skuLocationMappingRepository;
      this.skuRepository = _skuRepository;
      this.locationRepository = _locationRepository;
    }

        public ActionResult Insert(short? id)
        {
            int? nullable;
            int? nullable1;
            MasterSkuLocationMapping masterSkuLocationMapping = new MasterSkuLocationMapping();
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
                masterSkuLocationMapping.SkuId = (byte)id.Value;
            }
            ((dynamic)base.ViewBag).SkuList = this.skuRepository.GetSkuList();
            ((dynamic)base.ViewBag).Message = false;
            return base.View(masterSkuLocationMapping);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(MasterSkuLocationMapping objMasterSkuLocationMapping)
        {
            if ((!base.ModelState.IsValid ? false : objMasterSkuLocationMapping.SkuId > 0))
            {
                objMasterSkuLocationMapping.LocationList.ForEach((MasterSkuLocationMapping m) => {
                    m.SkuId = objMasterSkuLocationMapping.SkuId;
                    m.EntryBy = SessionUtility.LoginUserId;
                });
                ((dynamic)base.ViewBag).Message = this.skuLocationMappingRepository.AddressMapping(objMasterSkuLocationMapping).IsSuccessfull;
            }
           ((dynamic)base.ViewBag).SkuList = this.skuRepository.GetSkuList();
            return base.View(objMasterSkuLocationMapping);
        }

        public JsonResult GetSkuLocationMappingList(byte skuId)
    {
      return this.Json((object) this.skuLocationMappingRepository.GetSkuLocationMappingList(skuId));
    }
  }
}

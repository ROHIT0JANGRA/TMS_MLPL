using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Reports.Controllers
{
  public class WMSController : Controller
  {
    private readonly ICompanyRepository companyRepository;
    private readonly IUserWarehouseRepository userWarehouseRepository;

    public WMSController()
    {
    }

    public WMSController(
      ICompanyRepository _companyRepository,
      IUserWarehouseRepository _userWarehouseRepository)
    {
      this.companyRepository = _companyRepository;
      this.userWarehouseRepository = _userWarehouseRepository;
    }

        public ActionResult StockReport()
        {
            WarehouseStock warehouseStock = new WarehouseStock();
            ((dynamic)base.ViewBag).CompanyList = this.companyRepository.GetCompanyList();
            ((dynamic)base.ViewBag).WarehouseList = this.userWarehouseRepository.GetMappingByUserId(SessionUtility.LoginUserId);
            return base.View(warehouseStock);
        }


        protected override void Dispose(bool disposing)
    {
      if (disposing)
        this.userWarehouseRepository.Dispose();
      base.Dispose(disposing);
      if (disposing)
        this.companyRepository.Dispose();
      base.Dispose(disposing);
    }
  }
}

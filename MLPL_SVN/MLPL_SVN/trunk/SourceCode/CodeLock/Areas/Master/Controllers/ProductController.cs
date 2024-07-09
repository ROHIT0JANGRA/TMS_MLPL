using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductRepository productRepository;
    private readonly IGeneralRepository generalRepository;

    public ProductController()
    {
    }

    public ProductController(
      IProductRepository _productRepository,
      IGeneralRepository _generalRepository)
    {
      this.productRepository = _productRepository;
      this.generalRepository = _generalRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) this.productRepository.GetAll());
    }

        public ActionResult Insert()
        {
            MasterProduct masterProduct = new MasterProduct();
            ((dynamic)base.ViewBag).UnitsOfMeasurementList = this.generalRepository.GetByIdList(10);
            return base.View(masterProduct);
        }

    [ValidateAntiModelInjection("ProductId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Insert(MasterProduct objMasterProject)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterProject);
      objMasterProject.EntryBy = SessionUtility.LoginUserId;
      objMasterProject.CompanyId = SessionUtility.CompanyId;
      int num = this.productRepository.Insert(objMasterProject);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        CompanyId = objMasterProject.CompanyId,
        productId = num
      });
    }

    public ActionResult Update(byte companyId, int productId)
    {
        ((dynamic)base.ViewBag).UnitsOfMeasurementList = this.generalRepository.GetByIdList(10);
        ActionResult actionResult = base.View(this.productRepository.GetById(companyId, productId));
        return actionResult;
    }

    [ValidateAntiModelInjection("ProductId")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Update(MasterProduct objMasterProject)
    {
      if (!this.ModelState.IsValid)
        return (ActionResult) this.View((object) objMasterProject);
      objMasterProject.UpdateBy = new short?(SessionUtility.LoginUserId);
      objMasterProject.CompanyId = SessionUtility.CompanyId;
      int num = this.productRepository.Update(objMasterProject);
      return (ActionResult) this.RedirectToAction("View", (object) new
      {
        CompanyId = objMasterProject.CompanyId,
        productId = num
      });
    }

    public ActionResult View(byte companyId, int productId)
    {
      return (ActionResult) this.View((object) this.productRepository.GetById(companyId, productId));
    }

    [HttpPost]
    public JsonResult GetPartAutoCompleteList(
      string productName,
      short consignorId,
      short consigneeId,
      byte companyId)
    {
      return this.Json((object) this.productRepository.GetPartAutoCompleteList(productName, consignorId, consigneeId, companyId));
    }

    public JsonResult IsPartCodeExist(
      string productName,
      short consignorId,
      short consigneeId,
      byte companyId)
    {
      return this.Json((object) this.productRepository.IsPartCodeExist(productName, consignorId, consigneeId, companyId));
    }

    [HttpPost]
    [ValidateAntiModelInjection("ProductId")]
    public JsonResult IsProductNameAvailable(MasterProduct objMasterProject)
    {
      return this.Json((object) this.productRepository.IsProductNameAvailable(objMasterProject.ProductName, objMasterProject.ProductId));
    }

    public JsonResult GetAutoCompleteProductList(string productCode)
    {
      return this.Json((object) this.productRepository.GetAutoCompleteProductList(SessionUtility.CompanyId, productCode));
    }

    public JsonResult IsProductCodeExist(string productCode)
    {
      return this.Json((object) this.productRepository.IsProductCodeExist(SessionUtility.CompanyId, productCode));
    }

    public JsonResult GetCustomerMappingList(int productId)
    {
      return this.Json((object) this.productRepository.GetCustomerMappingList(productId));
    }

    public ActionResult ProductCustomerMapping()
    {
      return (ActionResult) this.View((object) new ProductCustomerMapping());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult ProductCustomerMapping(
      ProductCustomerMapping objProductCustomerMapping)
    {
      if (this.ModelState.IsValid)
      {
        objProductCustomerMapping.ProductCustomerMappingList.ForEach((Action<ProductCustomerMappingDetail>) (m => m.CompanyId = SessionUtility.CompanyId));
        objProductCustomerMapping.ProductCustomerMappingList.ForEach((Action<ProductCustomerMappingDetail>) (m => m.EntryBy = SessionUtility.LoginUserId));
        objProductCustomerMapping.ProductCustomerMappingList.ForEach((Action<ProductCustomerMappingDetail>) (m => m.ProductId = objProductCustomerMapping.ProductId));
        if (this.productRepository.Mapping(objProductCustomerMapping).IsSuccessfull)
          return (ActionResult) this.RedirectToAction("ProductCustomerMappingDone", (object) new
          {
            productId = objProductCustomerMapping.ProductId
          });
      }
      return (ActionResult) this.View((object) objProductCustomerMapping);
    }

    public ActionResult ProductCustomerMappingDone(int productId)
    {
      ProductCustomerMapping productCustomerMapping = new ProductCustomerMapping();
      ProductCustomerMapping productCodeAndNameById = this.productRepository.GetProductCodeAndNameById(productId);
      productCodeAndNameById.ProductCustomerMappingList = this.productRepository.GetCustomerMappingList(productId).ToList<ProductCustomerMappingDetail>();
      if (productCodeAndNameById == null)
        return (ActionResult) this.HttpNotFound();
      return (ActionResult) this.View((object) productCodeAndNameById);
    }
  }
}

using CodeLock.Areas.Master.Repository;
using CodeLock.Helper;
using CodeLock.Models;
using Dapper;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class VehicleDocumentTypeController : Controller
  {
    private readonly IVehicleDocumentTypeRepository vehicleDocumentTypeRepository;
    private readonly IGeneralRepository generalRepository;

        public VehicleDocumentTypeController()
        {
        }

        public VehicleDocumentTypeController(IVehicleDocumentTypeRepository _vehicleDocumentTypeRepository, IGeneralRepository _generalRepository)
        {
            this.vehicleDocumentTypeRepository = _vehicleDocumentTypeRepository;
            this.generalRepository = _generalRepository;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.vehicleDocumentTypeRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index()
        {
            return base.View(this.vehicleDocumentTypeRepository.GetAll());
        }

        public ActionResult Insert()
        {
            ((dynamic)base.ViewBag).RenewalAuthorityList = this.generalRepository.GetByIdList(8);
            ((dynamic)base.ViewBag).VehicleDocumentList = this.generalRepository.GetByIdList(85);
            return base.View(new MasterVehicleDocumentType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("VehicleDocumentId")]
        public ActionResult Insert(MasterVehicleDocumentType objMasterVehicleDocumentType)
        {
            ActionResult action;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).RenewalAuthorityList = this.generalRepository.GetByIdList(8);
                ((dynamic)base.ViewBag).VehicleDocumentList = this.generalRepository.GetByIdList(85);
                action = base.View(objMasterVehicleDocumentType);
            }
            else
            {
                objMasterVehicleDocumentType.EntryBy = SessionUtility.LoginUserId;
                if (objMasterVehicleDocumentType.DocumentAttachment != null)
                {
                    DynamicParameters dynamicParameter = new DynamicParameters();
                    int? nullable = null;
                    byte? nullable1 = null;
                    byte? nullable2 = nullable1;
                    nullable1 = null;
                    dynamicParameter.Add("@VehicleDocumentId", null, new DbType?(DbType.Int16), new ParameterDirection?(ParameterDirection.Output), nullable, nullable2, nullable1);
                    DataBaseFactory.QuerySP("Usp_MasterVehicleDocument_GetMaxVehicleDocumentId", dynamicParameter, "Vehicle Document Master - GetMaxVehicleDocumentId");
                    short num = dynamicParameter.Get<short>("@VehicleDocumentId");
                    string fileName = "";
                    if (!ConfigHelper.IsLocalStorage) 
                    {
                        
                        fileName = AzureStorageHelper.GetFileName("VehicleDocument", "DOC_TYPE", objMasterVehicleDocumentType.DocumentNo.ToString(), num.ToString(), objMasterVehicleDocumentType.DocumentAttachment.FileName);
                        fileName = fileName.Replace(" ", String.Empty);
                        //fileName = AzureStorageHelper.GetFileName("VehicleDocument", "DOC_TYPE", objMasterVehicleDocumentType.DocumentNo.ToString(), num.ToString(), objMasterVehicleDocumentType.VehicleNo);
                        if (AzureStorageHelper.IsBlobExists(AzureStorageHelper.AzureContainerName, fileName))
                        {
                            AzureStorageHelper.DeleteBlob(AzureStorageHelper.AzureContainerName, fileName);
                        }
                        
                        AzureStorageHelper.UploadBlob("VehicleDocument", objMasterVehicleDocumentType.DocumentAttachment, fileName, fileName);
                    }
                    else
                    {
                        fileName = string.Concat(num.ToString(), "_", objMasterVehicleDocumentType.DocumentAttachment.FileName);
                        //fileName = string.Concat(num.ToString(), "_", objMasterVehicleDocumentType.VehicleNo);
                        fileName = fileName.Replace(" ", String.Empty);

                        string FileLoc = Server.MapPath("~/Storage/VehicleDocument/");

                        if (System.IO.Directory.Exists(FileLoc)) { }
                        else
                        {
                            System.IO.Directory.CreateDirectory(FileLoc);
                        }
                        string str = Path.Combine(Server.MapPath("~/Storage/VehicleDocument/"), fileName);
                        if (System.IO.File.Exists(str) == true)
                        {
                            System.IO.File.Delete(str);
                        }
                        objMasterVehicleDocumentType.DocumentAttachment.SaveAs(str);
                    }
                    objMasterVehicleDocumentType.UploadedDocumentName = fileName;
                    objMasterVehicleDocumentType.DocumentAttachment = null;
                }
                short num1 = this.vehicleDocumentTypeRepository.Insert(objMasterVehicleDocumentType);
                action = base.RedirectToAction("View", new { id = num1 });
            }
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("VehicleDocumentId")]
        public JsonResult IsDocumentAvailable(MasterVehicleDocumentType objMasterVehicleDocumentType)
        {
            JsonResult jsonResult = base.Json(this.vehicleDocumentTypeRepository.IsDocumentAvailable(objMasterVehicleDocumentType.Document, objMasterVehicleDocumentType.VehicleDocumentId));
            return jsonResult;
        }

        public ActionResult Update(short? id)
        {
            ActionResult httpStatusCodeResult;
            int? nullable;
            int? nullable1;
            ((dynamic)base.ViewBag).RenewalAuthorityList = this.generalRepository.GetByIdList(8);
            ((dynamic)base.ViewBag).VehicleDocumentList = this.generalRepository.GetByIdList(85);
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
                httpStatusCodeResult = base.View(this.vehicleDocumentTypeRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjection("VehicleDocumentId")]
        public ActionResult Update(MasterVehicleDocumentType objMasterVehicleDocumentType)
        {
            ActionResult action;
            short vehicleDocumentId;
            if (!base.ModelState.IsValid)
            {
                ((dynamic)base.ViewBag).RenewalAuthorityList = this.generalRepository.GetByIdList(8);
                ((dynamic)base.ViewBag).VehicleDocumentList = this.generalRepository.GetByIdList(85);
                action = base.View(objMasterVehicleDocumentType);
            }
            else
            {
                objMasterVehicleDocumentType.UpdateBy = new short?(SessionUtility.LoginUserId);
                if (objMasterVehicleDocumentType.DocumentAttachment != null)
                {
                    string fileName = ""; 
                    if (!ConfigHelper.IsLocalStorage)
                    {
                        if (objMasterVehicleDocumentType.UploadedDocumentName != null)
                        {
                            if (AzureStorageHelper.IsBlobExists(AzureStorageHelper.AzureContainerName, objMasterVehicleDocumentType.UploadedDocumentName))
                            {
                                AzureStorageHelper.DeleteBlob("", objMasterVehicleDocumentType.UploadedDocumentName);
                            }
                            
                        }
                        string str = objMasterVehicleDocumentType.DocumentNo.ToString();
                        vehicleDocumentId = objMasterVehicleDocumentType.VehicleDocumentId;
                        fileName = AzureStorageHelper.GetFileName("VehicleDocument", "DOC_TYPE", str, vehicleDocumentId.ToString(), objMasterVehicleDocumentType.DocumentAttachment.FileName);
                        fileName = fileName.Replace(" ", String.Empty);
                        //fileName = AzureStorageHelper.GetFileName("VehicleDocument", "DOC_TYPE", str, vehicleDocumentId.ToString(), objMasterVehicleDocumentType.VehicleNo);
                        AzureStorageHelper.UploadBlob("VehicleDocument", objMasterVehicleDocumentType.DocumentAttachment, fileName, fileName);
                    }
                    else
                    {
                        
                        if (objMasterVehicleDocumentType.UploadedDocumentName != null)
                        {
                           
                            string str1 = Path.Combine(Server.MapPath("~/Storage/VehicleDocument/"), objMasterVehicleDocumentType.UploadedDocumentName);
                            if (System.IO.File.Exists(str1) == true)
                            {
                                System.IO.File.Delete(str1);
                            }
                            
                        }

                        vehicleDocumentId = objMasterVehicleDocumentType.VehicleDocumentId;
                        //fileName = string.Concat(vehicleDocumentId.ToString(), "_", objMasterVehicleDocumentType.VehicleNo);
                                              
                        fileName = string.Concat(vehicleDocumentId.ToString(), "_", objMasterVehicleDocumentType.DocumentAttachment.FileName);
                        fileName = fileName.Replace(" ", String.Empty);
                        string str2 = Path.Combine(Server.MapPath("~/Storage/VehicleDocument/"), fileName);
                        
                        if (System.IO.File.Exists(str2) == true)
                        {
                            System.IO.File.Delete(str2);
                        }
                        objMasterVehicleDocumentType.DocumentAttachment.SaveAs(str2);
                      
                    }
                    objMasterVehicleDocumentType.UploadedDocumentName = fileName;
                    objMasterVehicleDocumentType.DocumentAttachment = null;
                }
           
                short num = this.vehicleDocumentTypeRepository.Update(objMasterVehicleDocumentType);
                action = base.RedirectToAction("View", new { id = num });
            }
            return action;
        }

        public ActionResult View(short? id)
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
                httpStatusCodeResult = base.View(this.vehicleDocumentTypeRepository.GetById(id.Value));
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


    }
}

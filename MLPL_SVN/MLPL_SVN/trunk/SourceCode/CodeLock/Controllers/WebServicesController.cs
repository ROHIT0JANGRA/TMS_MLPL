using CodeLock.Areas.Operation.Repository;
using CodeLock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace CodeLock.Controllers
{
    public class WebServicesController : Controller
    {
        private readonly IDocketRepository docketRepository;
        public WebServicesController()
        {
        }

        public WebServicesController(IDocketRepository _docketRepository)
        {
            this.docketRepository = _docketRepository;
        }


        [HttpGet]
        public string CheckValidDocketNo(string docketNo)
        {
            DocketDetailForSolex obj = new Models.DocketDetailForSolex();
            obj = this.docketRepository.CheckValidDocketNoForSolex(docketNo);
            string output = JsonConvert.SerializeObject(obj);

            return output;
        }

        // GET: WebServices
        public ActionResult Index()
        {
            return View();
        }

        // GET: WebServices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WebServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebServices/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebServices/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WebServices/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: WebServices/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WebServices/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

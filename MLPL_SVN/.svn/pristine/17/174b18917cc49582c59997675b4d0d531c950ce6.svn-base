using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class FinancialYearRightController : Controller
  {
    private readonly IFinancialYearRightRepository rightFinanicalYearRepository;
    private readonly ICompanyRepository companyRepository;

    public FinancialYearRightController()
    {
    }

    public FinancialYearRightController(
      IFinancialYearRightRepository _rightFinanicalYearRepository,
      ICompanyRepository _companyRepository)
    {
      this.rightFinanicalYearRepository = _rightFinanicalYearRepository;
      this.companyRepository = _companyRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View();
    }

        public ActionResult Insert()
        {
            MasterFinancialYearRight masterFinancialYearRight = new MasterFinancialYearRight()
            {
                FinanceYearList = (
                    from a in this.companyRepository.GetVirtualLoginFinanceYearList()
                    select new FinanceYear()
                    {
                        Value = a.Value,
                        Name = a.Name
                    }).ToList<FinanceYear>()
            };
            ((dynamic)base.ViewBag).Message = false;
            return base.View(masterFinancialYearRight);
        }

        [HttpPost]
        public ActionResult Insert(MasterFinancialYearRight objMasterFinancialYearRight)
        {
            if (base.ModelState.IsValid)
            {
                objMasterFinancialYearRight.EntryBy = SessionUtility.LoginUserId;
                objMasterFinancialYearRight.FinanceYearList.ForEach((FinanceYear x) => x.MasterFinancialYearRight.UserId = objMasterFinancialYearRight.UserId);
                ((dynamic)base.ViewBag).Message = this.rightFinanicalYearRepository.Insert(objMasterFinancialYearRight).IsSuccessfull;
            }
            return base.View(objMasterFinancialYearRight);
        }
    }
}

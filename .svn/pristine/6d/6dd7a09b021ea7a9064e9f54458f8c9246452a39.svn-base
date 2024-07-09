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
  public class HolidayDayWiseController : Controller
  {
    private readonly IHolidayDayWiseRepository holidayDayWiseRepository;

    public HolidayDayWiseController()
    {
    }

    public HolidayDayWiseController(
      IHolidayDayWiseRepository _holidayDayWiseRepository)
    {
      this.holidayDayWiseRepository = _holidayDayWiseRepository;
    }

    public ActionResult Index()
    {
      return (ActionResult) this.View((object) new MasterHolidayDayWise()
      {
        DayOfHoliday = this.holidayDayWiseRepository.GetAll().ToArray<MasterGeneral>()
      });
    }

        [HttpPost]
        public ActionResult Index(MasterHolidayDayWise objMasterHolidayDayWise)
        {
            if (base.ModelState.IsValid)
            {
                objMasterHolidayDayWise.DayOfHoliday.ToList<MasterGeneral>().ForEach((MasterGeneral m) => m.UpdateBy = new short?(SessionUtility.LoginUserId));
                if (this.holidayDayWiseRepository.Insert(objMasterHolidayDayWise).IsSuccessfull)
                {
                    ((dynamic)base.ViewBag).Message = "Data saved successfully";
                }
            }
            return base.View(objMasterHolidayDayWise);
        }
    }
}

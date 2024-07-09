//  
// Type: CodeLock.Areas.Contract.Controllers.ExpenseContractController
//  
//  
//  

using CodeLock.Areas.Contract.Repository;
using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Contract.Controllers
{
  public class ExpenseContractController : Controller
  {
    private readonly IExpenseContractRepository expenseContractRepository;
    private readonly IGeneralRepository generalRepository;

    public ExpenseContractController()
    {
    }

    public ExpenseContractController(
      IExpenseContractRepository _expenseContractRepository,
      IGeneralRepository _generalRepository)
    {
      this.expenseContractRepository = _expenseContractRepository;
      this.generalRepository = _generalRepository;
    }

        public ActionResult ExpenseContract()
        {
            ((dynamic)base.ViewBag).PayBasList = this.generalRepository.GetByIdList(14);
            ((dynamic)base.ViewBag).TransportModeList = this.generalRepository.GetByIdList(15);
            ((dynamic)base.ViewBag).MatrixTypeList = this.generalRepository.GetByIdList(18);
            return base.View();
        }

        public ActionResult ExpenseCharge(short id, string expenseName, byte payBasId, string payBas, byte transportModeId, byte matrixType, short fromLocation, short toLocation)
        {
            ActionResult actionResult;
            ExpenseContract expenseContract = new ExpenseContract()
            {
                Details = new List<ExpenseContract>()
            };
            expenseContract.Details = this.expenseContractRepository.GetExpenseContractDetailBySearchingCriteria(id, expenseName, payBasId, payBas, transportModeId, matrixType, fromLocation, toLocation).ToList<ExpenseContract>();
            expenseContract.ExpenseId = id;
            expenseContract.ExpenseName = expenseName;
            expenseContract.PayBasId = payBasId;
            expenseContract.PayBas = payBas;
            expenseContract.TransportModeId = transportModeId;
            expenseContract.MatrixType = matrixType;
            expenseContract.FromLocationId = fromLocation;
            expenseContract.ToLocationId = toLocation;
            ((dynamic)base.ViewBag).RateTypeList = this.generalRepository.GetByIdList(17);
            if (expenseContract.Details.Count <= 0)
            {
                List<ExpenseContract> details = expenseContract.Details;
                ExpenseContract expenseContract1 = new ExpenseContract()
                {
                    ExpenseId = id,
                    ExpenseName = expenseName,
                    PayBasId = payBasId,
                    PayBas = payBas,
                    TransportModeId = transportModeId,
                    MatrixType = matrixType,
                    FromLocationId = fromLocation,
                    ToLocationId = toLocation
                };
                details.Add(expenseContract1);
                actionResult = base.View(expenseContract);
            }
            else
            {
                actionResult = base.View(expenseContract);
            }
            return actionResult;
        }

        [HttpPost]
        public ActionResult ExpenseCharge(ExpenseContract objExpenseContract)
        {
            ActionResult action;
            objExpenseContract.Details.ForEach((ExpenseContract m) => m.EntryBy = SessionUtility.LoginUserId);
            objExpenseContract.Details.ForEach((ExpenseContract m) => m.CompanyId = SessionUtility.CompanyId);
            objExpenseContract.Details.ForEach((ExpenseContract m) => m.ExpenseId = objExpenseContract.ExpenseId);
            objExpenseContract.Details.ForEach((ExpenseContract m) => m.PayBasId = objExpenseContract.PayBasId);
            objExpenseContract.Details.ForEach((ExpenseContract m) => m.TransportModeId = objExpenseContract.TransportModeId);
            objExpenseContract.Details.ForEach((ExpenseContract m) => m.MatrixType = objExpenseContract.MatrixType);
            Response response = this.expenseContractRepository.InsertExpenseContract(objExpenseContract);
            if (!response.IsSuccessfull)
            {
                action = base.View(objExpenseContract);
            }
            else
            {
                action = base.RedirectToAction("Result", new { documentId = response.DocumentId });
            }
            return action;
        }


    }
}

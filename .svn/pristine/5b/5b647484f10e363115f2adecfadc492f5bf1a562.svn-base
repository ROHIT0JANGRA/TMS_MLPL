using CodeLock.Areas.Master.Repository;
using CodeLock.Models;
using Microsoft.CSharp.RuntimeBinder;
using Secure_Coding.MvcSecurityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Mvc;

namespace CodeLock.Areas.Master.Controllers
{
  public class CardController : Controller
  {
    private readonly ICardRepository cardRepository;
    private readonly IVehicleRepository vehicleRepository;
    private readonly IAccountRepository accountRepository;

        public CardController()
        {
        }

        public CardController(ICardRepository _cardRepository, IVehicleRepository _vehicleRepository, IAccountRepository _accountRepository)
        {
            this.cardRepository = _cardRepository;
            this.vehicleRepository = _vehicleRepository;
            this.accountRepository = _accountRepository;
        }

        public JsonResult CheckCardSufficientBalance(short cardId)
        {
            JsonResult jsonResult = base.Json(this.cardRepository.CheckCardSufficientBalance(cardId));
            return jsonResult;
        }

        public ActionResult Deposit()
        {
            CardDeposit cardDeposit = new CardDeposit()
            {
                IsFuelCard = true
            };
            ((dynamic)base.ViewBag).BankList = this.accountRepository.GetAccountListByAccountCategoryId(6);
            ((dynamic)base.ViewBag).AccountList = this.accountRepository.GetAccountListByAccountCategoryId(6);

            return base.View(cardDeposit);
        }

        [HttpPost]
        public ActionResult Deposit(CardDeposit objCardDeposit)
        {
            ActionResult action;
            objCardDeposit.CardDetailList.ForEach((MasterCard m) => m.EntryBy = SessionUtility.LoginUserId);
            objCardDeposit.CardDetailList.ForEach((MasterCard m) => m.LocationId = SessionUtility.LoginLocationId);
            objCardDeposit.CardDetailList.ForEach((MasterCard m) => m.CompanyId = SessionUtility.CompanyId);
            objCardDeposit.CardDetailList.ForEach((MasterCard m) => m.FinYear = SessionUtility.FinYear);
            if (!this.cardRepository.Deposit(objCardDeposit).IsSuccessfull)
            {
                objCardDeposit.IsFuelCard = true;
                ((dynamic)base.ViewBag).BankList = this.accountRepository.GetAccountListByAccountCategoryId(6);
                ((dynamic)base.ViewBag).AccountList = this.accountRepository.GetAccountListByAccountCategoryId(6);

                action = base.View(objCardDeposit);
            }
            else
            {
                action = base.RedirectToAction("Done");
            }
            return action;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.cardRepository.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Done()
        {
            return base.View();
        }

        public JsonResult GetCardListByAccountId(int isFuelCard, short accountId)
        {
            JsonResult jsonResult = base.Json(this.cardRepository.GetCardListByAccountId(isFuelCard, accountId));
            return jsonResult;
        }

        public JsonResult GetCardListByCardType(int isFuelCard, string AccountId)
        {
            return base.Json(this.cardRepository.GetCardListByCardType(isFuelCard, AccountId));
        }
        public JsonResult GetCardListByVehicleId(short vehicleId, DateTime tripsheetDate, int isFuelCard)
        {
            JsonResult jsonResult = base.Json(this.cardRepository.GetCardListByVehicleId(vehicleId, tripsheetDate, isFuelCard));
            return jsonResult;
        }

        public JsonResult GetCashCardAccount(short cardId)
        {
            return base.Json(this.cardRepository.GetCashCardAccount(cardId));
        }

        public JsonResult GetDetailById(short cardId)
        {
            return base.Json(this.cardRepository.GetDetailById(cardId));
        }

        public ActionResult Index()
        {
            return base.View(this.cardRepository.GetAll());
        }

        public ActionResult Insert(short? id)
        {
            int? nullable;
            int? nullable1;
            short num;
            int? nullable2;
            MasterCard masterCard = new MasterCard();
            MasterCard masterCard1 = masterCard;
            short? nullable3 = id;
            if (nullable3.HasValue)
            {
                nullable1 = new int?(nullable3.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable1 = nullable;
            }
            nullable = nullable1;
            if (!nullable.HasValue)
            {
                num = 0;
            }
            else
            {
                num = id.ConvertToShort();
            }
            masterCard1.CardId = num;
            masterCard.IsFuelCard = 1;
            nullable3 = id;
            if (nullable3.HasValue)
            {
                nullable2 = new int?(nullable3.GetValueOrDefault());
            }
            else
            {
                nullable = null;
                nullable2 = nullable;
            }
            nullable = nullable2;
            if (nullable.HasValue)
            {
                masterCard = this.cardRepository.GetDetailById(id.Value);
                masterCard.SavedVehicle = string.Join<short>(",",
                    from m in this.cardRepository.GetCashCardDetail(id.Value)
                    select m.VehicleDriverId);
            }
            dynamic viewBag = base.ViewBag;
            IEnumerable<AutoCompleteResult> vehicleListByCardId = this.cardRepository.GetVehicleListByCardId(masterCard.CardId);
            viewBag.VehicleList = (
                from m in vehicleListByCardId
                where m.Value != "1"
                select m).ToList<AutoCompleteResult>();
            ((dynamic)base.ViewBag).AccountList = this.accountRepository.GetAccountListByAccountCategoryId(6);
            return base.View(masterCard);
        }

        [HttpPost]
        public ActionResult Insert(MasterCard ObjCard)
        {
            Response response;
            ActionResult action;
            base.ModelState.Remove("DepositAmount");
            //if (base.ModelState.IsValid)
            //{
                ObjCard.EntryBy = SessionUtility.LoginUserId;
                ObjCard.UpdateBy = new short?(SessionUtility.LoginUserId);
                ObjCard.IsVehicle = true;
                response = (ObjCard.CardId <= 0 ? this.cardRepository.Insert(ObjCard) : this.cardRepository.Update(ObjCard));
                if (response.IsSuccessfull)
                {
                    action = base.RedirectToAction("View", new { id = response.DocumentId });
                    return action;
                }
                base.TempData["result"] = response;
            //}
            ((dynamic)base.ViewBag).AccountList = this.accountRepository.GetAccountListByAccountCategoryId(6);
            dynamic viewBag = base.ViewBag;
            IEnumerable<AutoCompleteResult> vehicleListByCardId = this.cardRepository.GetVehicleListByCardId(ObjCard.CardId);
            viewBag.VehicleList = (
                from m in vehicleListByCardId
                where m.Value != "1"
                select m).ToList<AutoCompleteResult>();
            action = base.View(ObjCard);
            return action;
        }

        [HttpPost]
        [ValidateAntiModelInjection("CardId")]
        public JsonResult IsCardNoAvailable(MasterCard ObjCard)
        {
            JsonResult jsonResult = base.Json(this.cardRepository.IsCardNoAvailable(ObjCard.CardNo, ObjCard.CardId));
            return jsonResult;
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
                MasterCard detailById = this.cardRepository.GetDetailById(id.Value);
                if (detailById != null)
                {
                    detailById.Vehicle = string.Join(", ",
                        from m in this.cardRepository.GetCashCardDetail(id.Value)
                        select m.VehicleDriver);
                    httpStatusCodeResult = base.View(detailById);
                }
                else
                {
                    httpStatusCodeResult = base.HttpNotFound();
                }
            }
            else
            {
                httpStatusCodeResult = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return httpStatusCodeResult;
        }


    }
}

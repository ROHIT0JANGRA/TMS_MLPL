//  
// Type: CodeLock.Areas.Master.Repository.ICardRepository
//  
//  
//  

using CodeLock.Models;
using System;
using System.Collections.Generic;

namespace CodeLock.Areas.Master.Repository
{
  public interface ICardRepository : IDisposable
  {
    IEnumerable<MasterCard> GetAll();

    MasterCard GetDetailById(short id);

    Response Insert(MasterCard ObjCard);

    Response Update(MasterCard ObjCard);

    IEnumerable<CardDetail> GetCashCardDetail(short id);

    IEnumerable<AutoCompleteResult> GetCardListByVehicleId(
      short vehicleId,
      DateTime tripsheetDate,
      int isFuelCard);

    AutoCompleteResult GetCashCardAccount(short cardId);

    bool IsCardNoAvailable(string cardNo, short cardId);

    Decimal CheckCardSufficientBalance(short cardId);

    IEnumerable<MasterCard> GetCardListByCardType(int isFuelCard, string AccountId);

    IEnumerable<MasterCard> GetCardListByAccountId(
      int isFuelCard,
      short accountId);

    Response Deposit(CardDeposit objCardDeposit);

    IEnumerable<AutoCompleteResult> GetVehicleListByCardId(short cardId);
  }
}

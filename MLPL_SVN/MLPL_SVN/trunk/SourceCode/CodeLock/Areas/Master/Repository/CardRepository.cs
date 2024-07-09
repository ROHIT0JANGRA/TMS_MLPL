//  
// Type: CodeLock.Areas.Master.Repository.CardRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CodeLock.Areas.Master.Repository
{
  public class CardRepository : BaseRepository, ICardRepository, IDisposable
  {
    public IEnumerable<MasterCard> GetAll()
    {
      IEnumerable<MasterCard> masterCards = DataBaseFactory.QuerySP<MasterCard>("Usp_MasterCard_GetAll", (object) null, "Cash Card Master - GetAll");
      foreach (MasterCard masterCard in masterCards)
        masterCard.Vehicle = string.Join(", ", this.GetCashCardDetail(masterCard.CardId).Select<CardDetail, string>((Func<CardDetail, string>) (m => m.VehicleDriver)));
      return masterCards;
    }

    public MasterCard GetDetailById(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CardId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCard>("Usp_MasterCard_GetDetailById", (object) dynamicParameters, "Cash Card Master - GetDetailById").FirstOrDefault<MasterCard>();
    }

    public Response Insert(MasterCard ObjCard)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCard", (object) XmlUtility.XmlSerializeToString((object) ObjCard), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterCard_Insert", (object) dynamicParameters, "Cash Card Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterCard ObjCard)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@@XmlCard", (object) XmlUtility.XmlSerializeToString((object) ObjCard), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterCard_Update", (object) dynamicParameters, "Cash Card Master - Update").FirstOrDefault<Response>();
    }

    public Response Deposit(CardDeposit objCardDeposit)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlCardDeposit", (object) XmlUtility.XmlSerializeToString((object) objCardDeposit), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterCard_Deposit", (object) dynamicParameters, "Cash Card Master - Deposit").FirstOrDefault<Response>();
    }

    public IEnumerable<CardDetail> GetCashCardDetail(short id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CardId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<CardDetail>("Usp_MasterCashCard_GetCashCardDetail", (object) dynamicParameters, "Cash Card Master - GetCashCardDetail");
    }

    public IEnumerable<AutoCompleteResult> GetCardListByVehicleId(
      short vehicleId,
      DateTime tripsheetDate,
      int isFuelCard)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@VehicleId", (object) vehicleId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@TripsheetDate", (object) tripsheetDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsFuelCard", (object) isFuelCard, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCard_GetCardListByVehicleId", (object) dynamicParameters, "Cash Card Master - GetCashCardByVehicleId");
    }

    public AutoCompleteResult GetCashCardAccount(short cardId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CardId", (object) cardId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCashCard_GetCashCardAccount", (object) dynamicParameters, "Cash Card Master - GetCashCardAccount").FirstOrDefault<AutoCompleteResult>();
    }

    public bool IsCardNoAvailable(string cardNo, short cardId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CardId", (object) cardId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CardNo", (object) cardNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCard_IsCardNoAvailable", (object) dynamicParameters, "Card Master - IsCardNoAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }

    public Decimal CheckCardSufficientBalance(short cardId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CardId", (object) cardId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@BalanceAmount", (object) null, new DbType?(DbType.Decimal), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterCard_CheckCardSufficientBalance", (object) dynamicParameters, "Card Master - CheckCardSufficientBalance");
      return dynamicParameters.Get<Decimal>("@BalanceAmount");
    }

    public IEnumerable<MasterCard> GetCardListByCardType(int isFuelCard, string AccountId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@IsFuelCard", (object) isFuelCard, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountId", (object)AccountId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCard>("Usp_MasterCard_GetCardListByCardType", (object) dynamicParameters, "Cash Card Master - GetCardListByCardType");
    }

    public IEnumerable<MasterCard> GetCardListByAccountId(
      int isFuelCard,
      short accountId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@IsFuelCard", (object) isFuelCard, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@AccountId", (object) accountId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterCard>("Usp_MasterCard_GetCardListByAccountId", (object) dynamicParameters, "Cash Card Master - GetCardListByAccountId");
    }

    public IEnumerable<AutoCompleteResult> GetVehicleListByCardId(
      short cardId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CardId", (object) cardId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterCard_GetVehicleListByCardId", (object) dynamicParameters, "Card Master - GetVehicleListByCardType");
    }
  }
}

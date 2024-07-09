//  
// Type: CodeLock.Areas.Master.Repository.ReceiverRepository
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
  public class ReceiverRepository : BaseRepository, IReceiverRepository, IDisposable
  {
    public MasterReceiver GetById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ReceiverId", (object) id, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterReceiver>("Usp_MasterReceiver_GetById", (object) dynamicParameters, "Receiver Master - GetById").FirstOrDefault<MasterReceiver>();
    }

    public IEnumerable<MasterReceiver> GetAll()
    {
      return DataBaseFactory.QuerySP<MasterReceiver>("Usp_MasterReceiver_GetAll", (object) null, "Receiver Master - GetAll");
    }

    public byte Insert(MasterReceiver objMasterReceiver)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlReceiver", (object) XmlUtility.XmlSerializeToString((object) objMasterReceiver), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ReceiverId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterReceiver_Insert", (object) dynamicParameters, "Receiver Master - Insert");
      return dynamicParameters.Get<byte>("@ReceiverId");
    }

    public byte Update(MasterReceiver objMasterReceiver)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlReceiver", (object) XmlUtility.XmlSerializeToString((object) objMasterReceiver), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ReceiverId", (object) null, new DbType?(DbType.Byte), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP<MasterVendor>("Usp_MasterReceiver_Update", (object) dynamicParameters, "Receiver Master - Update");
      return dynamicParameters.Get<byte>("@ReceiverId");
    }

    public IEnumerable<AutoCompleteResult> GetAutoCompleteReceiverListByLocation(
      string receiverCode,
      short locationId,
      byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ReceiverCode", (object) receiverCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterReceiver_GetAutoCompleteListByLocation", (object) dynamicParameters, "Receiver Master - GetAutoCompletereceiverListByLocation");
    }

    public AutoCompleteResult IsReceiverCodeExistByLocation(
      string receiverCode,
      short locationId,
      byte companyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ReceiverCode", (object) receiverCode, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@CompanyId", (object) companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterReceiver_IsReceiverCodeExistByLocation", (object) dynamicParameters, "Receiver Master - IsReceiverCodeExistByLocation").FirstOrDefault<AutoCompleteResult>();
    }

    public bool IsReceiverNameAvailable(string receiverName, short receiverId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@ReceiverId", (object) receiverId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ReceiverName", (object) receiverName, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@IsAvailable", (object) null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
      DataBaseFactory.QuerySP("Usp_MasterReceiver_IsNameAvailable", (object) dynamicParameters, "Receiver Master - IsReceiverNameAvailable");
      return dynamicParameters.Get<bool>("@IsAvailable");
    }
  }
}

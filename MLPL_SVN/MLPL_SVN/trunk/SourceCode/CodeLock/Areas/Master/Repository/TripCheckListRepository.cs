//  
// Type: CodeLock.Areas.Master.Repository.TripCheckListRepository
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
  public class TripCheckListRepository : BaseRepository, ITripCheckListRepository, IDisposable
  {
    public IEnumerable<MasterTripCheckList> GetAll()
    {
      IEnumerable<MasterTripCheckList> masterTripCheckLists = DataBaseFactory.QuerySP<MasterTripCheckList>("Usp_MasterTripCheckList_GetAll", (object) null, "TripCheckList Master - GetAll");
      foreach (MasterTripCheckList masterTripCheckList in masterTripCheckLists)
        masterTripCheckList.Documents = string.Join(", ", this.GetCashTripCheckListDetail(masterTripCheckList.CheckListId).Select<MasterTripCheckListDocument, string>((Func<MasterTripCheckListDocument, string>) (m => m.DocumentName)));
      return masterTripCheckLists;
    }

    public MasterTripCheckList GetDetailById(byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CheckListId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterTripCheckList>("Usp_MasterTripCheckList_GetDetailById", (object) dynamicParameters, "TripCheckList Master - GetDetailById").FirstOrDefault<MasterTripCheckList>();
    }

    public Response Insert(MasterTripCheckList ObjTripCheckList)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlTripCheckList", (object) XmlUtility.XmlSerializeToString((object) ObjTripCheckList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterTripCheckList_Insert", (object) dynamicParameters, "TripCheckList Master - Insert").FirstOrDefault<Response>();
    }

    public Response Update(MasterTripCheckList ObjTripCheckList)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@@XmlTripCheckList", (object) XmlUtility.XmlSerializeToString((object) ObjTripCheckList), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_MasterTripCheckList_Update", (object) dynamicParameters, "TripCheckList Master - Update").FirstOrDefault<Response>();
    }

    public IEnumerable<MasterTripCheckListDocument> GetCashTripCheckListDetail(
      byte id)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@CheckListId", (object) id, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<MasterTripCheckListDocument>("Usp_MasterCashTripCheckList_GetDocumentDetail", (object) dynamicParameters, "TripCheckList Master - GetCashTripCheckListDetail");
    }
  }
}

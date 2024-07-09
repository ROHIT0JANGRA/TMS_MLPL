//  
// Type: CodeLock.Areas.Operation.Repository.VendorDocumentApprovalRepository
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

namespace CodeLock.Areas.Operation.Repository
{
  public class VendorDocumentApprovalRepository : BaseRepository, IVendorDocumentApprovalRepository, IDisposable
  {
    public IEnumerable<VendorDocumentDetail> GetDocumentListForApproval(
      short locationId,
      string SelectedDocumentType)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@DocumentTypes", (object) SelectedDocumentType, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<VendorDocumentDetail>("Usp_VendorDocumentApproval_GetDocumentListForApproval", (object) dynamicParameters, "Vendor Document Approval - GetDocumentListForApproval");
    }

    public Response Insert(VendorDocumentApproval objVendorDocumentApproval)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlVendorDocumentApproval", (object) XmlUtility.XmlSerializeToString((object) objVendorDocumentApproval), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_VendorDocumentApproval_Insert", (object) dynamicParameters, "Vendor Document Approval - Insert").FirstOrDefault<Response>();
    }

    public IEnumerable<VendorDocumentDetail> GetVendorDocumentDetailListByDocumentId(
      long historyId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@HistoryId", (object) historyId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<VendorDocumentDetail>("Usp_VendorDocumentApproval_GetVendorDocumentDetailListByDocumentId", (object) dynamicParameters, "Vendor Document Detail - GetVendorDocumentDetailListByDocumentId");
    }
  }
}

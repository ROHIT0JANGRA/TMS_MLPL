//  
// Type: CodeLock.Areas.Finance.Repository.PurchaseOrderRepository
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

namespace CodeLock.Areas.Finance.Repository
{
  public class PurchaseOrderRepository : BaseRepository, IPurchaseOrderRepository, IDisposable
  {
    public Response Insert(PurchaseOrder objPurchaseOrder)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPurchaseOrder", (object) XmlUtility.XmlSerializeToString((object) objPurchaseOrder), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_PurchaseOrder_Insert", (object) dynamicParameters, "Purchase Order insert").FirstOrDefault<Response>();
    }

    public IEnumerable<PurchaseOrder> GetPurchaseOrderListForApproval(
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      short vendorId,
      string poNo,
      string manualPoNo,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PoNo", (object) poNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ManualPoNo", (object) manualPoNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<PurchaseOrder>("Usp_PurchaseOrder_GetPurchaseOrderListForApproval", (object) dynamicParameters, "Purchase Order - GetJobOrderListForApprove");
    }

    public Response Approve(PurchaseOrderApprove objPurchaseOrderApprove)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPurchaseOrderApprove", (object) XmlUtility.XmlSerializeToString((object) objPurchaseOrderApprove), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_PurchaseOrder_Approve", (object) dynamicParameters, "PurchaseOrder- Approve").FirstOrDefault<Response>();
    }

    public Response GrnInsert(PoGrn objPoGrn)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlPoGrnInsert", (object) XmlUtility.XmlSerializeToString((object) objPoGrn), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_PurchaseOrder_GrnInsert", (object) dynamicParameters, "Purchase Order Grn Generate").FirstOrDefault<Response>();
    }

    public PurchaseOrder GetDetailById(long poId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@PoId", (object) poId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      Tuple<IEnumerable<PurchaseOrder>, IEnumerable<PurchaseOrderDetail>> tuple = DataBaseFactory.QueryMultipleSP<PurchaseOrder, PurchaseOrderDetail>("Usp_PurchaseOrder_GetById", (object) dynamicParameters, "Purchase Order - GetDetailById");
      PurchaseOrder purchaseOrder = new PurchaseOrder();
      if (tuple != null && tuple.Item1 != null)
      {
        purchaseOrder = tuple.Item1.FirstOrDefault<PurchaseOrder>();
        if (tuple.Item2 != null)
          purchaseOrder.Details = tuple.Item2.ToList<PurchaseOrderDetail>();
      }
      return purchaseOrder;
    }

    public IEnumerable<PurchaseOrder> GetPurchaseOrderListForGrnInsert(
      DateTime fromDate,
      DateTime toDate,
      byte materialCategoryId,
      short vendorId,
      string poNo,
      string manualPoNo)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@MaterialCategoryId", (object) materialCategoryId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PoNo", (object) poNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ManualPoNo", (object) manualPoNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<PurchaseOrder>("Usp_PurchaseOrder_GetPurchaseOrderListForGrnInsert", (object) dynamicParameters, "Purchase Order - Get Purchase Order List For GrnGenerate");
    }

    public Response AdvancePayment(PurchaseOrderAdvancePayment objAdvancePayment)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlAdvancePayment", (object) XmlUtility.XmlSerializeToString((object) objAdvancePayment), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_PurchaseOrder_AdvancePayment", (object) dynamicParameters, "PurchaseOrder- AdvancePayment").FirstOrDefault<Response>();
    }

    public IEnumerable<PurchaseOrder> GetPurchaseOrderListForAdvancePayment(
      DateTime fromDate,
      DateTime toDate,
      short vendorId,
      DateTime finStartDate,
      DateTime finEndDate,
      string poNo,
      string manualPoNo,
      short locationId)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@FromDate", (object) fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ToDate", (object) toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinStartDate", (object) finStartDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@FinEndDate", (object) finEndDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@VendorId", (object) vendorId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@PoNo", (object) poNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@ManualPoNo", (object) manualPoNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      dynamicParameters.Add("@LocationId", (object) locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<PurchaseOrder>("Usp_PurchaseOrder_GetPurchaseOrderListForAdvancePayment", (object) dynamicParameters, "Purchase Order - GetPurchaseOrderListForAdvancePayment");
    }

    public Response IssueSlip(IssueSlip objIssueSlip)
    {
      DynamicParameters dynamicParameters = new DynamicParameters();
      dynamicParameters.Add("@XmlIssueSlip", (object) XmlUtility.XmlSerializeToString((object) objIssueSlip), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
      return DataBaseFactory.QuerySP<Response>("Usp_PurchaseOrder_IssueSlip", (object) dynamicParameters, "PurchaseOrder- IssueSlip").FirstOrDefault<Response>();
    }
  }
}

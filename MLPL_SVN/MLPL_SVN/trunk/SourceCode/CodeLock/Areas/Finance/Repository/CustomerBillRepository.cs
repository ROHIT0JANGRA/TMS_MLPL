﻿//  
// Type: CodeLock.Areas.Finance.Repository.CustomerBillRepository
//  
//  
//  

using CodeLock.Helper;
using CodeLock.Models;
using CodeLock.Repository;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml;

namespace CodeLock.Areas.Finance.Repository
{
    public class CustomerBillRepository : BaseRepository, ICustomerBillRepository, IDisposable
    {
        public Docket AddDocketList(string docketNos, string CustomerId, byte TransactionTypeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketNo", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransactionTypeId", (object)TransactionTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<Docket>("Usp_Docket_GetAddDocket", (object)dynamicParameters, "Manifest - Docket").FirstOrDefault<Docket>(); ;
        }


        public IEnumerable<BillFinalizationDetail> RegenerateEInvoice(long userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)userId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<BillFinalizationDetail>("Usp_CustomerBillFinalization_RegenerateEInvoiceList", (object)dynamicParameters, "Manifest - BillFinalizationDetail");
        }
        public IEnumerable<BillFinalizationDetail> GenerationErrorList(long userId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", (object)userId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<BillFinalizationDetail>("Usp_CustomerBillFinalization_ForErrorList", (object)dynamicParameters, "Manifest - BillFinalizationDetail");
        }

        public DataSet GenerateEInvoice(long BillId)
        {

            DataSet ds = new DataSet();
            ds.Tables.Add("Irntbl");
            ds.Tables[0].Columns.Add("ErrorMessage");
            ds.Tables[0].Columns.Add("Irn");
            ds.Tables[0].Columns.Add("AckNo");
            ds.Tables[0].Columns.Add("SignedQRCode");
            ds.Tables[0].Columns.Add("SignedInvoice");
            ds.Tables[0].Columns.Add("IrnStatus");
            ds.Tables[0].Columns.Add("AllowEInvoice");
            ds.Tables[0].Columns.Add("Status");

            //  

            string baseURI = "http://einvlive.webtel.in/v1.03/";

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillId", (object)BillId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            CustomerBill customerBill = DataBaseFactory.QuerySP<CustomerBill>("Usp_CustomerGstBillGenerationDumtco_ForBillEInvoice", (object)dynamicParameters, "Manifest - Cancel").FirstOrDefault<CustomerBill>();

            if (customerBill.AllowEInvoice == "NO")
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["AllowEInvoice"] = customerBill.AllowEInvoice;
                dr["Status"] = "1";
                dr["ErrorMessage"] = "";
                dr["Irn"] = "";
                dr["AckNo"] = "";
                dr["SignedQRCode"] = "";
                dr["SignedInvoice"] = "";
                dr["IrnStatus"] = "";
                ds.Tables[0].Rows.Add(dr);
                return ds;
            }

            EinvoiceRequest einvoiceRequest = new EinvoiceRequest();
            einvoiceRequest.CDKey = "1691416";
            einvoiceRequest.EInvUserName = customerBill.EInvUserName; // "mahalakshm_API_ml"; 
            einvoiceRequest.EInvPassword = customerBill.EInvPassword;// "Admin@5303";
            einvoiceRequest.EFUserName = "06C9F628-A8D7-4A8E-A56A-E5DA0D194EC8";
            einvoiceRequest.EFPassword = "10C1C528-6779-419B-8DC6-B3DD11FB829D";
            // einvoiceRequest.GSTIN="23AADCM8862E1ZH";
            einvoiceRequest.GSTIN = customerBill.CompanyGstStateGstTinNo;
            einvoiceRequest.GetQRImg = "1";
            einvoiceRequest.GetSignedInvoice = "1";

            TranDtls tranDtls = new TranDtls();
            tranDtls.SupTyp = "B2B";

            if (customerBill.Igst == 0 && customerBill.Cgst == 0 && customerBill.Sgst == 0)
            {
                tranDtls.RegRev = "Y";
            }
            else
            {
                tranDtls.RegRev = "N";
            }
            tranDtls.IgstOnIntra = "N";


            einvoiceRequest.TranDtls = tranDtls;

            DocDtls docDtls = new DocDtls();
            docDtls.Typ = "INV";
            docDtls.No = customerBill.BillNo;
            docDtls.Dt = customerBill.BillDateEdit;
            einvoiceRequest.DocDtls = docDtls;

            SellerDtls sellerDtls = new SellerDtls();
            sellerDtls.Gstin = customerBill.CompanyGstStateGstTinNo;
            sellerDtls.LglNm = customerBill.CompanyName;
            sellerDtls.TrdNm = customerBill.CompanyName;
            sellerDtls.Addr1 = customerBill.BillingAddress;
            sellerDtls.Addr2 = "";
            sellerDtls.Loc = customerBill.CompanyPinCity;
            sellerDtls.Pin = customerBill.CompanyPinCode;
            sellerDtls.Stcd = customerBill.CompanyStateCode;
            sellerDtls.Ph = customerBill.CompanyPhoneNo;
            sellerDtls.Em = customerBill.CompanyEmail;
            einvoiceRequest.SellerDtls = sellerDtls;

            BuyerDtls buyerDtls = new BuyerDtls();
            buyerDtls.Gstin = customerBill.CustomerGstInNo;
            buyerDtls.LglNm = customerBill.CustomerName;
            buyerDtls.TrdNm = customerBill.CustomerName;
            buyerDtls.Addr1 = customerBill.SubmissionBillingAddress;
            buyerDtls.Addr2 = "";
            buyerDtls.Loc = customerBill.CustomerPinCity;
            buyerDtls.Pin = customerBill.CustomerPinCode;
            buyerDtls.Stcd = customerBill.CustomerStateCode;
            buyerDtls.Ph = customerBill.CustomerPhoneNo;
            buyerDtls.Em = customerBill.CustomerEmail;
            buyerDtls.Pos = customerBill.CustomerStateCode;
            einvoiceRequest.BuyerDtls = buyerDtls;

            ItemListdtl _ItemListdtl = new ItemListdtl();
            _ItemListdtl.SlNo = "1";
            _ItemListdtl.PrdDesc = "INVOICE";
            _ItemListdtl.IsServc = "Y";
            _ItemListdtl.HsnCd = customerBill.SacName;
            _ItemListdtl.Barcde = customerBill.SacName;
            _ItemListdtl.Qty = 1;
            _ItemListdtl.FreeQty = 0;
            _ItemListdtl.Unit = "Pcs";
            _ItemListdtl.UnitPrice = customerBill.SubTotal;
            _ItemListdtl.TotAmt = customerBill.SubTotal;
            _ItemListdtl.Discount = 0;
            _ItemListdtl.AssAmt = customerBill.SubTotal;
            _ItemListdtl.GstRt = customerBill.GstRate;
            _ItemListdtl.IgstAmt = customerBill.Igst;
            _ItemListdtl.CgstAmt = customerBill.Cgst;
            _ItemListdtl.SgstAmt = customerBill.Sgst;
            _ItemListdtl.OthChrg = 0;
            _ItemListdtl.TotItemVal = customerBill.BillAmount;
            einvoiceRequest.ItemList.Add(_ItemListdtl);

            ValDtls valDtls = new ValDtls();
            valDtls.AssVal = customerBill.SubTotal;
            valDtls.CgstVal = customerBill.Cgst;
            valDtls.SgstVal = customerBill.Sgst;
            valDtls.IgstVal = customerBill.Igst;
            valDtls.OthChrg = 0;
            valDtls.RndOffAmt = 0;
            valDtls.TotInvVal = customerBill.BillAmount;
            einvoiceRequest.ValDtls = valDtls;

            var RequestJson = JsonConvert.SerializeObject(einvoiceRequest);
            string url = baseURI + "GenIRN2";
            Dictionary<string, string> pHeaderscust = new Dictionary<string, string>()
            {
            };

            var responsecust = HttpRequest("POST", url, RequestJson, pHeaderscust);
            string newres = responsecust.Replace("\\", "");
            string newres1 = newres.Substring(1, newres.Length - 2).Replace("\"[", "[").Replace("]\"", "]");

            DataSet dsJson = jsonToDataSet(newres1);

            if (dsJson.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["AllowEInvoice"] = customerBill.AllowEInvoice;

                if (dsJson.Tables[0].Rows[0]["Status"].ToString() == "1")
                    dr["ErrorMessage"] = "";
                else
                    dr["ErrorMessage"] = dsJson.Tables[0].Rows[0]["ErrorMessage"].ToString();

                dr["Irn"] = dsJson.Tables[0].Rows[0]["Irn"].ToString();
                dr["SignedQRCode"] = dsJson.Tables[0].Rows[0]["SignedQRCode"].ToString();
                dr["SignedInvoice"] = dsJson.Tables[0].Rows[0]["SignedInvoice"].ToString();
                dr["IrnStatus"] = dsJson.Tables[0].Rows[0]["IrnStatus"].ToString();
                dr["Status"] = dsJson.Tables[0].Rows[0]["Status"].ToString();
                dr["AckNo"] = dsJson.Tables[0].Rows[0]["AckNo"].ToString();

                ds.Tables[0].Rows.Add(dr);

            }
            return ds;
        }
        static DataSet jsonToDataSet(string jsonString)
        {
            try
            {
                XmlDocument xd = new XmlDocument();
                jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + "} }";
                xd = (XmlDocument)JsonConvert.DeserializeXmlNode(jsonString);
                DataSet ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(xd));
                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        private string HttpRequest(string pMethod, string pUrl, string pJsonContent, Dictionary<string, string> pHeaders)
        {
            string result = "";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(pUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = pMethod;
            foreach (var head in pHeaders)
            {
                httpWebRequest.Headers.Add(head.Key, head.Value);
            }
            if (pMethod == "POST")
            {
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(pJsonContent);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
        }

        /* This Method procedure is change for edit the remarks column to get the remarks data  fetch the db */
        /**/


        public CustomerBill GetDocketListGstForCustomerBillEdit(long LoginLocationId, string BillNo, string DocketNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@LocationId", (object)LoginLocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNo", (object)BillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNo", (object)DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            CustomerBill obj = new CustomerBill();

            try
            {
                Tuple<IEnumerable<CustomerBill>, IEnumerable<CustomerBillDetail>, IEnumerable<CustomerBillDetail>> tuple = DataBaseFactory.QueryMultipleSP<CustomerBill, CustomerBillDetail, CustomerBillDetail>("Usp_CustomerGstBillGenerationDumtco_GetDocketListForBillEdit", (object)dynamicParameters, "Customer Gst Bill Generation -");
                if (tuple == null )
                {
                    obj.ErrorList = new List<CustomerBillDetail>();
                }
                obj = tuple.Item1.FirstOrDefault<CustomerBill>();
                obj.Details = tuple.Item2.ToList<CustomerBillDetail>();
                obj.ErrorList = tuple.Item3.ToList<CustomerBillDetail>();

                return obj;
            }
            catch (Exception ex)
            {
              
            }
            return null;
        
        }


        public Response CancellationCreditDebitNote(CreditDebitNote objCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlManifest", (object)XmlUtility.XmlSerializeToString((object)objCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CreditDebitNote_Cancellation", (object)dynamicParameters, "CreditDebitNote - CancellationCreditDebitNote").FirstOrDefault<Response>();
        }

        public IEnumerable<CreditDebitNote> GetCreditDebitNoteListForCancellation(
        string NoteNo,
        DateTime fromDate,
        DateTime toDate,
        short locationId

         )
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@NoteNo", (object)NoteNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CreditDebitNote>("Usp_CreditDebitNote_GetListForCancellation", (object)dynamicParameters, "CreditDebitNote - GetCreditDebitNoteListForCancellation");
        }
        public Response InsertCreditDebitNote(CreditDebitNote objBilling)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCreditDebitNote", (object)XmlUtility.XmlSerializeToString((object)objBilling), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CreditDebitNote_Insert", (object)dynamicParameters, "CreditDebitNote - Insert").FirstOrDefault<Response>();
        }
        public IEnumerable<CreditDebitNoteDetail> CreditDebitNoteBillData(bool isCreditNote, bool isGst, byte billTypeId, string fromDate, string toDate, short partyId, string billNos, string manualBillNos, string transportModeId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@IsCreditNote", (object)isCreditNote, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsGst", (object)isGst, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillTypeId", (object)billTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PartyId", (object)partyId, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransportModeId", (object)transportModeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CreditDebitNoteDetail>("Usp_CreditDebitNote_GetBill", (object)dynamicParameters, "CreditDebitNote - CreditDebitNoteBillData");
        }

        public CustomerBill GetDocketListGstForCustomerBillGenerationMLPL(
        short customerId,
        DateTime fromDate,
        DateTime toDate,
        byte gstServiceTypeId,
        byte customerGstStateId,
        byte companyGstStateId,
        byte paybasId,
        byte serviceTypeId,
        byte ftlTypeId,
        string finYear,
        DateTime finStartDate,
        DateTime finEndDate,
        short locationId,
        byte companyId, string ManifestId, string VendorId, string docketNos, byte TransactionTypeId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)gstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerGstStateId", (object)customerGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyGstStateId", (object)companyGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManifestId", (object)ManifestId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //          dynamicParameters.Add("@IsRcm", (object)isRcm, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNo", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //            dynamicParameters.Add("@IsSez", (object)isSez, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TransactionTypeId", (object)TransactionTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            CustomerBill obj = new CustomerBill();

            Tuple<IEnumerable<CustomerBillDetail>, IEnumerable<CustomerBillDetail>, IEnumerable<CustomerBillDetail>> tuple = DataBaseFactory.QueryMultipleSP<CustomerBillDetail, CustomerBillDetail, CustomerBillDetail>("Usp_CustomerGstBillGenerationDumtco_GetDocketList", (object)dynamicParameters, "Customer Gst Bill Generation - GetDocketListGstForCustomerBillGenerations");
            obj.Details = tuple.Item1.ToList<CustomerBillDetail>();
            obj.ErrorList = tuple.Item2.ToList<CustomerBillDetail>();
            obj.GSTDetails = tuple.Item3.ToList<CustomerBillDetail>();

            //
            return obj;
        }


        public IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerBillGenerationDumtco(
        short customerId,
        DateTime fromDate,
        DateTime toDate,
        byte gstServiceTypeId,
        byte customerGstStateId,
        byte companyGstStateId,
        byte paybasId,
        byte serviceTypeId,
        byte ftlTypeId,
        string finYear,
        DateTime finStartDate,
        DateTime finEndDate,
        short locationId,
        byte companyId, string ManifestId, string VendorId, bool isRcm, string DocketNo)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)gstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerGstStateId", (object)customerGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyGstStateId", (object)companyGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManifestId", (object)ManifestId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsRcm", (object)isRcm, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNo", (object)DocketNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_CustomerGstBillGenerationDumtco_GetDocketList", (object)dynamicParameters, "Customer Gst Bill Generation - GetDocketListGstForCustomerBillGenerations");
        }

        public IEnumerable<AutoCompleteResult> GetServiceTaxList()
        {
            return (IEnumerable<AutoCompleteResult>)new List<AutoCompleteResult>()
      {
        new AutoCompleteResult()
        {
          Value = "0",
          Name = "All without Service Tax"
        },
        new AutoCompleteResult()
        {
          Value = "15",
          Name = "Air with 15%"
        },
        new AutoCompleteResult()
        {
          Value = "4.5",
          Name = "Rail with 4.5%"
        },
        new AutoCompleteResult()
        {
          Value = "15",
          Name = "Road with 15%"
        },
        new AutoCompleteResult()
        {
          Value = "15",
          Name = "Express with 15%"
        }
      };
        }

        public IEnumerable<CustomerBillDetail> GetDocketListForCustomerBillGeneration(
          short customerId,
          DateTime fromDate,
          DateTime toDate,
          byte serviceTax,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTax", (object)serviceTax, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_CustomerBillGeneration_GetDocketList", (object)dynamicParameters, "Customer Bill Generation - GetDocketListForCustomerBillGeneration");
        }

        public Response ReGenerate(CustomerBill objCustomerBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillGeneration", (object)XmlUtility.XmlSerializeToString((object)objCustomerBill), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillGeneration_ReInsert", (object)dynamicParameters, "Customer Bill Generation - Insert").FirstOrDefault<Response>();
        }

        public Response Generate(CustomerBill objCustomerBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillGeneration", (object)XmlUtility.XmlSerializeToString((object)objCustomerBill), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillGeneration_Insert", (object)dynamicParameters, "Customer Bill Generation - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerBillGenerationTriSpeed(
          short customerId,
          DateTime fromDate,
          DateTime toDate,
          byte gstServiceTypeId,
          byte customerGstStateId,
          byte companyGstStateId,
          byte paybasId,
          byte serviceTypeId,
          byte ftlTypeId,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId,
          byte DocketStatusId, string PONo, short billtypeInterIntra, short ownerType, short ownerId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)gstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerGstStateId", (object)customerGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyGstStateId", (object)companyGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketStatusId", (object)DocketStatusId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PONo", (object)PONo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@billtypeInterIntra", (object)billtypeInterIntra, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ownerType", (object)billtypeInterIntra, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ownerId", (object)billtypeInterIntra, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_CustomerGstBillGenerationForTrispeed_GetDocketList", (object)dynamicParameters, "Customer Gst Bill Generation - GetDocketListGstForCustomerBillGenerations");
        }

        public IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerBillGeneration(
      short customerId,
      DateTime fromDate,
      DateTime toDate,
      byte gstServiceTypeId,
      byte customerGstStateId,
      byte companyGstStateId,
      byte paybasId,
      byte serviceTypeId,
      byte ftlTypeId,
      short billtypeInterIntra,
      short ownerType,
      short ownerId,
      bool rcmyn,
      string finYear,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)gstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerGstStateId", (object)customerGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyGstStateId", (object)companyGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@billtypeInterIntra", (object)billtypeInterIntra, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ownerType", (object)billtypeInterIntra, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ownerId", (object)billtypeInterIntra, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@rcmyn", (object)rcmyn, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_CustomerGstBillGeneration_GetDocketList", (object)dynamicParameters, "Customer Gst Bill Generation - GetDocketListGstForCustomerBillGenerations");
        }

        public CustomerBillSupplementryDetail GetGstRate(short servicesId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ServicesId", (object)servicesId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillSupplementryDetail>("Usp_CustomerSupplementryBill_GetGstRate", (object)dynamicParameters, "Customer Supplementry Bill - GetGstRate").FirstOrDefault<CustomerBillSupplementryDetail>();
        }

        public bool IsManualBillNoAvailable(long billId, string manualNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillId", (object)billId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNo", (object)manualNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@IsAvailable", (object)null, new DbType?(DbType.Boolean), new ParameterDirection?(ParameterDirection.Output), new int?(), new byte?(), new byte?());
            DataBaseFactory.QuerySP("Usp_CustomerBill_IsManualBillNoAvailable", (object)dynamicParameters, "Customer Supplementry Bill  - IsManualBillNoAvailable");
            return dynamicParameters.Get<bool>("@IsAvailable");
        }

        public IEnumerable<CustomerBillDetail> GetTripCustomerBillDetails(
                  short customerId,
                  DateTime fromDate,
                  DateTime toDate,
                  byte serviceTypeId,
                  string finYear,
                  short locationId,
                  byte companyId, short SacId, int fromcityid, int tocityid)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@fromdt", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Todt", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Party_code", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@From_City", (object)fromcityid, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@To_City", (object)tocityid, new DbType?(DbType.Int32), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@sacid", (object)SacId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("CL_TripSheet_BillGeneration", (object)dynamicParameters, "Customer Gst Bill Generation - GetTripCustomerBillDetails");
        }
        public IEnumerable<TripBillDetail> GetTripCustomerBillDetailsNew(
                  short customerId,
                  DateTime fromDate,
                  DateTime toDate,
                  short GstServiceTypeId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@fromdt", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Todt", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@customerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)GstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<TripBillDetail>("CL_TripSheet_BillGeneration_New", (object)dynamicParameters, "Customer Gst Bill Generation - GetTripCustomerBillDetails");
        }
        public IEnumerable<MilkRunBillingDetail> GetMilkRunCustomerBillDetails(
                  short customerId,
                  DateTime fromDate,
                  DateTime toDate,
                  short GstServiceTypeId,
                  string VehicleId,
                  string TripsheetNo
                  )
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            //dynamicParameters.Add("@fromdt", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            //dynamicParameters.Add("@Todt", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@customerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)GstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VehicleId", (object)VehicleId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@TripsheetNo", (object)TripsheetNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<MilkRunBillingDetail>("CL_TripSheet_MilkRun_BillGeneration_New", (object)dynamicParameters, "Customer Gst Bill Generation - GetTripCustomerBillDetails");
        }
        public IEnumerable<CustomerBill> GetCustomerBillListForSubmission(
        string billNos,
        string manualBillNos,
        byte paybas,
        short customerId,
        DateTime fromDate,
        DateTime toDate,
        string finYear,
        DateTime finStartDate,
        DateTime finEndDate,
        short locationId,
        byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Paybas", (object)paybas, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBill>("Usp_CustomerBillSubmission_GetCustomerBillList", (object)dynamicParameters, "Customer Bill Submission - GetCustomerBillListForSubmission");
        }

        public Response Submission(CustomerBillSubmission objCustomerBillSubmission)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillSubmission", (object)XmlUtility.XmlSerializeToString((object)objCustomerBillSubmission), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillSubmission_Insert", (object)dynamicParameters, "Customer Bill Submission - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<CustomerBill> GetCustomerBillListForUnSubmission(
          string billNos,
          string manualBillNos,
          byte paybas,
          short customerId,
          DateTime fromDate,
          DateTime toDate,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Paybas", (object)paybas, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBill>("Usp_CustomerBillUnSubmission_GetCustomerBillList", (object)dynamicParameters, "Customer Bill Submission - GetCustomerBillListForSubmission");
        }

        public Response UnSubmission(
          CustomerBillUnSubmission objCustomerBillUnSubmission)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillUnSubmission", (object)XmlUtility.XmlSerializeToString((object)objCustomerBillUnSubmission), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objCustomerBillUnSubmission.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillUnSumission_Insert", (object)dynamicParameters, "Customer Bill Submission - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<CustomerBill> GetCustomerBillListForCollection(
          string billNos,
          string manualBillNos,
          byte paybas,
          short customerId,
          DateTime fromDate,
          DateTime toDate,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId,
          string customerGroup
         )
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Paybas", (object)paybas, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerGroup", (object)customerGroup, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<CustomerBill>("Usp_CustomerBillCollection_GetCustomerBillList", (object)dynamicParameters, "Customer Bill Collection - GetCustomerBillListForCollection");
        }

        public Response Collection(CustomerBillCollection objCollection)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillCollection", (object)XmlUtility.XmlSerializeToString((object)objCollection), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillCollection_Insert", (object)dynamicParameters, "Customer Bill Collection - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<BillFinalizationDetail> GetCustomerBillListForFinalization(
          string billNos,
          DateTime fromDate,
          DateTime toDate,
          short customerId,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId,
          byte paybas,
          string manualBillNos)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybas, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            if (paybas == 10)
            {
                return DataBaseFactory.QuerySP<BillFinalizationDetail>("Usp_DeliveryBillFinalization_GetCustomerBillList", (object)dynamicParameters, "Customer Bill Finalization - GetCustomerBillListForFinalization");
            }
            else
            {
                return DataBaseFactory.QuerySP<BillFinalizationDetail>("Usp_CustomerBillFinalization_GetCustomerBillList", (object)dynamicParameters, "Customer Bill Finalization - GetCustomerBillListForFinalization");
            }


        }
        public Response BillEInvoice(BillFinalizationDetail objBillFinalization)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillFinalization", (object)XmlUtility.XmlSerializeToString((object)objBillFinalization), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillFinalization_UpadteEInvoice", (object)dynamicParameters, "Customer Bill Finalization - BillFinalization").FirstOrDefault<Response>();
        }
        public Response BillFinalization(BillFinalization objBillFinalization)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillFinalization", (object)XmlUtility.XmlSerializeToString((object)objBillFinalization), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillFinalization_Insert", (object)dynamicParameters, "Customer Bill Finalization - BillFinalization").FirstOrDefault<Response>();
        }

        public IEnumerable<Docket> GetDocketListForDocketFinalization(
          string docketNos,
          DateTime fromDate,
          DateTime toDate,
          short customerId,
          string finYear,
          short locationId,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Docket>("Usp_DocketFinalization_GetDocketList", (object)dynamicParameters, "Docket Finalization - GetDocketListForDocketFinalization");
        }

        public Response DocketFinalization(DocketFinalization objDocketFinalization)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDocketFinalization", (object)XmlUtility.XmlSerializeToString((object)objDocketFinalization), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DocketFinalization_Insert", (object)dynamicParameters, "Docket Finalization - DocketFinalization").FirstOrDefault<Response>();
        }

        public Response SupplementaryBill(SupplementryBill objSupplementryBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlSupplementryBill", (object)XmlUtility.XmlSerializeToString((object)objSupplementryBill), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_SupplementaryBill_Insert", (object)dynamicParameters, "SupplementryBill - GenerateSupplementryBill").FirstOrDefault<Response>();
        }

        public Response GstSupDatailAdd(GstGeneration objCustomerBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBill", (object)XmlUtility.XmlSerializeToString((object)objCustomerBill), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBill_GstSupDatailAdd", (object)dynamicParameters, "Customer Bill - GstSupDatailAdd").FirstOrDefault<Response>();
        }

        public IEnumerable<CustomerBillDetail> GetMrDocketList(
          bool isDeliveredByConsignee,
          short customerId,
          string docketNos,
          string docketSuffix,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@IsDeliveredByConsignee", (object)isDeliveredByConsignee, new DbType?(DbType.Boolean), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketNos", (object)docketNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@DocketSuffix", (object)docketSuffix, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_DeliveryMr_GetMrDocketList", (object)dynamicParameters, "Customer Bill - GetMrDocketList");
        }

        public CustomerBillCharges GetDeliveryCharges()
        {
            IEnumerable<MasterCharge> source = DataBaseFactory.QuerySP<MasterCharge>("Usp_DeliveryMr_GetDeliveryChargeList", (object)null, "Customer Bill - GetDeliveryCharges");
            return new CustomerBillCharges()
            {
                OtherChargeList = source.ToList<MasterCharge>()
            };
        }

        public IEnumerable<DeliveryMrDone> DeliveryMr(
          DeliveryMrHeader objDeliveryMrHeader)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlDeliveryMr", (object)XmlUtility.XmlSerializeToString((object)objDeliveryMrHeader), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<DeliveryMrDone>("Usp_DeliveryMr_Insert", (object)dynamicParameters, "Customer Bill - DeliveryMrInsert");
        }

        public IEnumerable<CustomerBillDetail> GetMrDocketListByMrId(
          long mrId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@MrId", (object)mrId, new DbType?(DbType.Int64), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_DeliveryMr_GetMrDocketListByMrId", (object)dynamicParameters, "Customer Bill - GetMrDocketListByMrId");
        }

        public Response MiscellaneousBill(GstGeneration objCustomerBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlMiscellaneousBill", (object)XmlUtility.XmlSerializeToString((object)objCustomerBill), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MiscellaneousBill_Insert", (object)dynamicParameters, "Customer Bill - Miscellaneous Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<CustomerBill> GetCustomerBillListForCancellation(
          string billNos,
          string manualBillNos,
          byte paybas,
          short customerId,
          DateTime fromDate,
          DateTime toDate,
          string finYear,
          DateTime finStartDate,
          DateTime finEndDate,
          short locationId,
          byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Paybas", (object)paybas, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@BillNos", (object)billNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ManualBillNos", (object)manualBillNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBill>("Usp_CustomerBillCancellation_GetCustomerBillList", (object)dynamicParameters, "Customer Bill Cancellation - GetCustomerBillListForCancellation");
        }

        public Response Cancellation(
          CustomerBillCancellation objCustomerBillCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillCancellation", (object)XmlUtility.XmlSerializeToString((object)objCustomerBillCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBillCancellation_Insert", (object)dynamicParameters, "Customer Bill Cancellation - Insert").FirstOrDefault<Response>();
        }

        public Response MrCancellation(MrCancellation objMrCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlMrCancellation", (object)XmlUtility.XmlSerializeToString((object)objMrCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MrCancellation_Insert", (object)dynamicParameters, "Customer Bill Cancellation - Insert").FirstOrDefault<Response>();
        }

        public Response DeliveryMrCancellation(MrCancellation objMrCancellation)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlMrCancellation", (object)XmlUtility.XmlSerializeToString((object)objMrCancellation), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_DeliveryMrCancellation_Insert", (object)dynamicParameters, "Delivery MrCancellation  - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<MrCancellation> GetMrBillListForCancellation(
      string mrNos,
      DateTime fromDate,
      DateTime toDate,
      DateTime finStartDate,
      DateTime finEndDate,
      short locationId,
      byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MrNos", (object)mrNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MrCancellation>("Usp_MrBillCancellation_GetMrBillList", (object)dynamicParameters, "Mr Bill Cancellation - MrBillCancellation");
        }

        public IEnumerable<MrCancellation> GetDeliveryMrBillListForCancellation(
              string mrNos,
              DateTime fromDate,
              DateTime toDate,
              DateTime finStartDate,
              DateTime finEndDate,
              short locationId,
              byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@MrNos", (object)mrNos, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<MrCancellation>("Usp_DeliveryMrMrBillCancellation_GetMrBillList", (object)dynamicParameters, "Delivery Mr Bill Cancellation - DeliveryMrBillCancellation");
        }




        public AutoCompleteResult IsBillNoExist(
          string billNo,
          string finYear,
          short locationId,
          byte companyId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillNo", (object)billNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_CustomerBill_IsBillNoExist", (object)dynamicParameters, "Customer Bill - IsBillNoExist").FirstOrDefault<AutoCompleteResult>();
        }

        public CustomerBill GetCustomerBillDetailById(long billId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillId", (object)billId, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBill>("Usp_CustomerBill_GetDetailById", (object)dynamicParameters, "Customer Bill - GetCustomerBillDetailById").FirstOrDefault<CustomerBill>();
        }

        public IEnumerable<CustomerBillDetail> GetCustomerBillDocketListById(
          long billId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillId", (object)billId, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_CustomerBill_GetDocketListById", (object)dynamicParameters, "Customer Bill - GetCustomerBillDocketListById");
        }

        public Response TripSheetBill(TripBilling objTripBilling)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objTripBilling), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_TripsheetBill_Insert", (object)dynamicParameters, "TripsheetBill - Insert").FirstOrDefault<Response>();
        }
        public Response MilkRunSheetBill(MilkRunBilling objTripBilling)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@@XmlTripsheet", (object)XmlUtility.XmlSerializeToString((object)objTripBilling), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_MilkRunsheetBill_Insert", (object)dynamicParameters, "TripsheetBill - Insert").FirstOrDefault<Response>();
        }

        public IEnumerable<CustomerBillDetail> GetTHCNoFromManifest(
        string ManifestId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@ManifestId", (object)ManifestId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_GetTHCNoFromManifest", (object)dynamicParameters, "Usp_GetTHCNoFromManifest");
        }

        public IEnumerable<AutoCompleteResult> GetManifestList(short locationId, string CustomerId, string VendorId, byte paybasId)
        {

            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@locationId", (object)locationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)CustomerId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@VendorId", (object)VendorId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());

            return DataBaseFactory.QuerySP<AutoCompleteResult>("Usp_MasterManifest_GetManifestForBillingList", (object)dynamicParameters, "Gst Master - GetManifestList");
        }

        public BillUploadInSystem UploadInSystem(
        BillUploadInSystem objDocketUploadInSystem)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("FieldName"));
            dataTable.Columns.Add(new DataColumn("FieldCaption"));

            DataRow row1 = dataTable.NewRow();
            row1["FieldName"] = (object)"ManualBillNo";
            row1["FieldCaption"] = (object)"ManualBillNo";
            dataTable.Rows.Add(row1);

            DataRow row2 = dataTable.NewRow();
            row2["FieldName"] = (object)"BillDate";
            row2["FieldCaption"] = (object)"BillDate";
            dataTable.Rows.Add(row2);

            DataRow row3 = dataTable.NewRow();
            row3["FieldName"] = (object)"DueDate";
            row3["FieldCaption"] = (object)"DueDate";
            dataTable.Rows.Add(row3);

            DataRow row4 = dataTable.NewRow();
            row4["FieldName"] = (object)"CustomerCode";
            row4["FieldCaption"] = (object)"CustomerCode";
            dataTable.Rows.Add(row4);

            DataRow row5 = dataTable.NewRow();
            row5["FieldName"] = (object)"Customer";
            row5["FieldCaption"] = (object)"Customer";
            dataTable.Rows.Add(row5);

            DataRow row6 = dataTable.NewRow();
            row6["FieldName"] = (object)"CollectionBranch";
            row6["FieldCaption"] = (object)"CollectionBranch";
            dataTable.Rows.Add(row6);

            DataRow row7 = dataTable.NewRow();
            row7["FieldName"] = (object)"BillingBranch";
            row7["FieldCaption"] = (object)"BillingBranch";
            dataTable.Rows.Add(row7);

            DataRow row8 = dataTable.NewRow();
            row8["FieldName"] = (object)"Narration";
            row8["FieldCaption"] = (object)"Narration";
            dataTable.Rows.Add(row8);

            DataRow row9 = dataTable.NewRow();
            row9["FieldName"] = (object)"Amount";
            row9["FieldCaption"] = (object)"Amount";
            dataTable.Rows.Add(row9);

            //DataRow row10 = dataTable.NewRow();
            //row10["FieldName"] = (object)"SGST";
            //row10["FieldCaption"] = (object)"SGST";
            //dataTable.Rows.Add(row10);

            //DataRow row11 = dataTable.NewRow();
            //row11["FieldName"] = (object)"CGST";
            //row11["FieldCaption"] = (object)"CGST";
            //dataTable.Rows.Add(row11);

            //DataRow row12 = dataTable.NewRow();
            //row12["FieldName"] = (object)"IGST";
            //row12["FieldCaption"] = (object)"IGST";
            //dataTable.Rows.Add(row12);

            //DataRow row13 = dataTable.NewRow();
            //row13["FieldName"] = (object)"Total";
            //row13["FieldCaption"] = (object)"Total";
            //dataTable.Rows.Add(row13);

            DataRow row10 = dataTable.NewRow();
            row10["FieldName"] = (object)"Paybas";
            row10["FieldCaption"] = (object)"Paybas";
            dataTable.Rows.Add(row10);

            DataRow row11 = dataTable.NewRow();
            row11["FieldName"] = (object)"TransportMode";
            row11["FieldCaption"] = (object)"TransportMode";
            dataTable.Rows.Add(row11);

            DataRow row12 = dataTable.NewRow();
            row12["FieldName"] = (object)"ServiceType";
            row12["FieldCaption"] = (object)"ServiceType";
            dataTable.Rows.Add(row12);

            BillUploadHelper docketUploadHelper1 = new BillUploadHelper();
            docketUploadHelper1.fileUploadControl = objDocketUploadInSystem.File;
            docketUploadHelper1.dtFormat = dataTable;
            docketUploadHelper1.strFileNamePrefix = "BillUpload";
            docketUploadHelper1.strFilePath = "~/UploadedFiles/DocketUploadInSystem";
            docketUploadHelper1.strModuleName = "BillUploadInSystem";
            docketUploadHelper1.strProcedureName = "Usp_Bill_Upload_InSystem";
            BillUploadHelper docketUploadHelper2 = docketUploadHelper1;
            try
            {
                string str1 = docketUploadHelper2.Upload(false);

                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@XmlDocketUpload", (object)str1, new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                dynamicParameters.Add("@EntryBy", (object)objDocketUploadInSystem.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
                docketUploadHelper2.Result = DataBaseFactory.QuerySP<BillUploadInSystem>(docketUploadHelper2.strProcedureName, (object)dynamicParameters, "Bill Upload - UploadInSystem").ToList<BillUploadInSystem>();
                if (docketUploadHelper2.Result != null && docketUploadHelper2.Result.Count > 0)
                {
                    int num1 = docketUploadHelper2.Result.Count<BillUploadInSystem>((Func<BillUploadInSystem, bool>)(x => x.UploadStatus == "Uploaded"));
                    int num2 = docketUploadHelper2.Result.Count - num1;
                    string str2 = "";
                    if (num1 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded";
                    if (num1 == 0 && num2 > 0)
                        str2 = num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    else if (num1 > 0 && num2 > 0)
                        str2 = num1.ToString() + " record" + (num1 == 1 ? "" : "s") + " succeeded and " + num2.ToString() + " record" + (num2 == 1 ? "" : "s") + " failed";
                    docketUploadHelper2.strResultMessage = str2 + " out of " + (num1 + num2).ToString() + " records";
                }
                else
                    docketUploadHelper2.strResultMessage = "No Data Uploaded";
                objDocketUploadInSystem.IsSuccessfull = true;
                objDocketUploadInSystem.ErrorMessage = docketUploadHelper2.strResultMessage;
                objDocketUploadInSystem.Details = docketUploadHelper2.Result;
            }
            catch (Exception ex)
            {
                objDocketUploadInSystem.IsSuccessfull = false;
                objDocketUploadInSystem.ErrorMessage = ex.Message;
            }
            return objDocketUploadInSystem;
        }


        public IEnumerable<CustomerBillDetail> GetDocketListGstForCustomerGatePassBillGeneration(
       short customerId,
       DateTime fromDate,
       DateTime toDate,
       byte gstServiceTypeId,
       byte customerGstStateId,
       byte companyGstStateId,
       byte paybasId,
       byte serviceTypeId,
       byte ftlTypeId,
       string finYear,
       DateTime finStartDate,
       DateTime finEndDate,
       short locationId,
       byte companyId)
        {
            if (toDate > SessionUtility.Now)
                toDate = SessionUtility.Now;
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@FromDate", (object)fromDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ToDate", (object)toDate, new DbType?(DbType.Date), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerId", (object)customerId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@GstServiceTypeId", (object)gstServiceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CustomerGstStateId", (object)customerGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyGstStateId", (object)companyGstStateId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@PaybasId", (object)paybasId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@ServiceTypeId", (object)serviceTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FtlTypeId", (object)ftlTypeId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinYear", (object)finYear, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinStartDate", (object)finStartDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@FinEndDate", (object)finEndDate, new DbType?(DbType.DateTime), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)locationId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@CompanyId", (object)companyId, new DbType?(DbType.Byte), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<CustomerBillDetail>("Usp_CustomerGatePassBillGeneration_GetDocketList", (object)dynamicParameters, "Customer Gst Bill Generation - GetDocketListGstForCustomerBillGenerations");
        }


        public Response GenerateDeliveryBill(CustomerBill objCustomerBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@XmlCustomerBillGeneration", (object)XmlUtility.XmlSerializeToString((object)objCustomerBill), new DbType?(DbType.Xml), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerDeliveryBillGeneration_Insert", (object)dynamicParameters, "Delivery Bill Generation - Insert").FirstOrDefault<Response>();
        }

        public Response InsertBillReAssign(BillReAssign objBill)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillNo", (object)objBill.BillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@LocationId", (object)objBill.LocationId, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@Remarks", (object)objBill.Remarks, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            dynamicParameters.Add("@EntryBy", (object)objBill.EntryBy, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<Response>("Usp_CustomerBill_ReAssign", (object)dynamicParameters, "Docket - Insert").FirstOrDefault<Response>();
        }

        public BillReAssign CheckValidBillNoForReAssign(string BillNo)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@BillNo", (object)BillNo, new DbType?(DbType.String), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            return DataBaseFactory.QuerySP<BillReAssign>("Usp_CustomerBill_GetBillReAssign", (object)dynamicParameters, "Docket- GetDocketData").FirstOrDefault<BillReAssign>();
        }

        public Docket GetDocketChargeDetails(Docket objDocket)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@DocketId", (object)objDocket.DocketId, new DbType?(DbType.Int16), new ParameterDirection?(), new int?(), new byte?(), new byte?());
            Tuple<IEnumerable<Docket>, IEnumerable<MasterCharge>> tuple = DataBaseFactory.QueryMultipleSP<Docket, MasterCharge>("Usp_Docket_GetDocketChargeDetails", (object)dynamicParameters, "Docket - GetStep2Detail");
            Docket docketStep2_2 = tuple.Item1.FirstOrDefault<Docket>();
            docketStep2_2.ChargeList = tuple.Item2.ToList<MasterCharge>();
            return docketStep2_2;
        }
    }
}